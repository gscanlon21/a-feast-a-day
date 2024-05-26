﻿using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.User;
using System.Linq.Expressions;
using System.Reflection;

namespace Data.Query;

public interface IExerciseVariationCombo
{
    UserRecipe Recipe { get; }
}

public static class Filters
{
    /// <summary>
    /// Make sure the exercise is for the correct workout type
    /// </summary>
    public static IQueryable<T> FilterSection<T>(IQueryable<T> query, Section? value) where T : IExerciseVariationCombo
    {
        // Debug should be able to see all exercises.
        if (value.HasValue && value != Section.None && value != Section.Debug)
        {
            // Has any flag
            query = query.Where(vm => (vm.Recipe.Section & value.Value) != 0);
        }

        return query;
    }

    /// <summary>
    /// Filter down to these specific exercises
    /// </summary>
    public static IQueryable<T> FilterExercises<T>(IQueryable<T> query, IList<int>? exerciseIds) where T : IExerciseVariationCombo
    {
        if (exerciseIds != null)
        {
            query = query.Where(vm => exerciseIds.Contains(vm.Recipe.Id));
        }

        return query;
    }

    /// <summary>
    /// Make sure the exercise works a specific muscle group
    /// </summary>
    public static IQueryable<T> FilterMuscleGroup<T>(IQueryable<T> query, IngredientGroup? muscleGroup, bool include, Expression<Func<IExerciseVariationCombo, IngredientGroup>> muscleTarget) where T : IExerciseVariationCombo
    {
        if (muscleGroup.HasValue && muscleGroup != IngredientGroup.None)
        {
            if (include)
            {
                query = WithMuscleTarget(query, muscleTarget, muscleGroup.Value, include);
            }
            else
            {
                // If a recovery muscle is set, don't choose any exercises that work the injured muscle
                query = WithMuscleTarget(query, muscleTarget, muscleGroup.Value, include);
            }
        }

        return query;
    }

    /// <summary>
    /// Builds an expression consumable by EF Core for filtering what muscles a variation works.
    /// </summary>
    private static IQueryable<T> WithMuscleTarget<T>(this IQueryable<T> entities,
        Expression<Func<IExerciseVariationCombo, IngredientGroup>> propertySelector, IngredientGroup muscleGroup, bool include)
    {
        ParameterExpression parameter = Expression.Parameter(typeof(T));

        // Has any flag
        var innerExpr = new MuscleGroupsExpressionRewriter(parameter).Modify(propertySelector);
        var expression = Expression.Lambda<Func<T, bool>>(
            Expression.Equal(Expression.NotEqual(
            Expression.And(
                Expression.Convert(innerExpr, typeof(long)),
                Expression.Convert(Expression.Constant(muscleGroup), typeof(long))
            ),
            Expression.Constant(0L)), Expression.Constant(include)),
            parameter);

        return entities.Where(expression);
    }

    /// <summary>
    /// Re-writes a C# muscle target expression to be consumable by EF Core.
    /// ev => ev.Variation.StrengthMuscles | ev.Variations.StretchMuscles...
    /// </summary>
    private class MuscleGroupsExpressionRewriter(ParameterExpression parameter) : ExpressionVisitor
    {

        /// <summary>
        /// The IExerciseVariationCombo
        /// </summary>
        public ParameterExpression Parameter { get; } = parameter;

        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            // vm => Convert(Convert(vm.Variation.StrengthMuscles, Int32) | Convert(vm.Variation.StretchMuscles, Int32), Int32)
            return Visit(node.Body);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            // vm.Variation.StrengthMuscles
            return Expression.Property(
                Expression.Property(
                    Parameter,
                    (PropertyInfo)((MemberExpression)node.Expression!).Member),
                (PropertyInfo)node.Member);
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Convert)
            {
                // Convert(vm.Variation.StrengthMuscles, Int32)
                var innerExpr = Visit(node.Operand);
                return Expression.Convert(innerExpr, typeof(long));
            }

            throw new InvalidOperationException();
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            // Convert(vm.Variation.StrengthMuscles, Int32) | Convert(vm.Variation.StretchMuscles, Int32)
            var leftExpr = Visit(node.Left);
            var rightExpr = Visit(node.Right);

            return node.NodeType switch
            {
                ExpressionType.Or => Expression.Or(leftExpr, rightExpr),
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
