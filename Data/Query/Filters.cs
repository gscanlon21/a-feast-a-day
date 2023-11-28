using Core.Models.Equipment;
using Core.Models.Exercise;
using Core.Models.User;
using Data.Entities.Exercise;
using System.Linq.Expressions;
using System.Reflection;

namespace Data.Query;

public interface IExerciseVariationCombo
{
    Exercise Exercise { get; }
}

public static class Filters
{
    /// <summary>
    /// Filter down to these specific exercises
    /// </summary>
    public static IQueryable<T> FilterExercises<T>(IQueryable<T> query, IList<int>? exerciseIds) where T : IExerciseVariationCombo
    {
        if (exerciseIds != null)
        {
            query = query.Where(vm => exerciseIds.Contains(vm.Exercise.Id));
        }

        return query;
    }
}
