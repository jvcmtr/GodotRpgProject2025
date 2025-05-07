using System;
using System.Collections.Generic;


namespace DLL.enums{
    public static partial class EnumMapper
    {
        private static readonly Dictionary<(Type EnumType, Type ValueType), object> mappings = new();
        private static readonly Dictionary<Type, Type> defaultValueTypes = new();

        internal static void RegisterMap<TEnum, TValue>(BiDirectionalMap<TEnum, TValue> map, bool isDefault = true)
            where TEnum : Enum
        {
            var key = (typeof(TEnum), typeof(TValue));
            mappings[key] = map;

            if (isDefault)
            {
                defaultValueTypes[typeof(TEnum)] = typeof(TValue);
            }
        }

        public static TValue MapFrom<TEnum, TValue>(TEnum enumValue)
            where TEnum : Enum
        {
            if (mappings.TryGetValue((typeof(TEnum), typeof(TValue)), out var mapObj) &&
                mapObj is BiDirectionalMap<TEnum, TValue> map)
            {
                return map.GetByEnum(enumValue);
            }

            throw new InvalidOperationException("Transformation not mapped");
        }

        public static TEnum MapTo<TEnum, TValue>(TValue value)
            where TEnum : Enum
        {
            if (mappings.TryGetValue((typeof(TEnum), typeof(TValue)), out var mapObj) &&
                mapObj is BiDirectionalMap<TEnum, TValue> map)
            {
                return map.GetByValue(value);
            }

            throw new InvalidOperationException("Transformation not mapped");
        }
    }

}
