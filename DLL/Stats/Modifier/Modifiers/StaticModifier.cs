using System;
using DLL.enums;

namespace DLL {

    public struct StaticModifier : IModifier
    {
        public double Value { get; }
        public string Source { get; }

        public bool isMultiplicative { get; }
        public bool isCompound { get;}
        public EModifier Type {get; }

        public StaticModifier(string source, double value, EModifier type)
        {
            Source = source;
            Value = value;

            var a = EnumMapper.MapFrom<EModifier, (bool isMultiplicative, bool isCompound)>(type);
            Type = type;
            isMultiplicative = a.isMultiplicative;
            isCompound = a.isCompound;
        }

        public double Apply(double a)
        {
            return a + GetModifier(a);
        }

        public double GetModifier(double a = 1)
        {
            return isMultiplicative ? a * (Value -1) : Value;
        }

        public bool isOfType(EModifier type)
        {
            return Type == type;
        }
    }
}
