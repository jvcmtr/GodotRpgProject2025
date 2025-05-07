using System;
using System.Collections.Generic;

public class BiDirectionalMap<TEnum, TValue> where TEnum : Enum
{
    private readonly Dictionary<TEnum, TValue> forward = new();
    private readonly Dictionary<TValue, TEnum> reverse = new();

    public BiDirectionalMap<TEnum, TValue> Add(TEnum key, TValue value)
    {
        forward[key] = value;
        reverse[value] = key;
        return this;
    }

    public TValue GetByEnum(TEnum key)
    {
        return forward.TryGetValue(key, out var value)
            ? value
            : throw new InvalidOperationException("Transformation not mapped");
    }

    public TEnum GetByValue(TValue value)
    {
        return reverse.TryGetValue(value, out var enumValue)
            ? enumValue
            : throw new InvalidOperationException("Transformation not mapped");
    }
}
