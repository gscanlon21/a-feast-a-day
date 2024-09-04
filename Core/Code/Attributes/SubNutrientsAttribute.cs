﻿using Core.Code.Extensions;

namespace Core.Code.Attributes;


/// <summary>
/// Provides conditional validation based on related property value.
/// </summary>
/// <param name="otherProperty">The other property.</param>
/// <param name="otherPropertyValue">The other property value.</param>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class SubNutrientsAttribute<T>() : SubNutrientsAttributeInternal where T : struct, Enum
{
    /// <summary>
    /// The other property name that will be used during validation.
    /// </summary>
    public override Type SkillType { get; } = typeof(T);

    public override Enum[] AllValues => Enum.GetValues<T>().Select(m => (Enum)m).ToArray();
    public override Enum[] SelectList => EnumExtensions.GetDisplayValues<T>().Select(m => (Enum)m).ToArray();
}

public abstract class SubNutrientsAttributeInternal : Attribute
{
    public abstract Type SkillType { get; }
    public abstract Enum[] AllValues { get; }
    public abstract Enum[] SelectList { get; }
}