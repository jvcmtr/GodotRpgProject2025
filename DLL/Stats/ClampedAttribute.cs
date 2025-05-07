using Godot;
using System;

namespace DLL.Stats {
    public class ClampedAttribute : IntAttribute
    {
        public override int Value => GetValue();
        public int MinValue {get; private set;}
        public int MaxValue {get; private set;}
        public ClampedAttribute(int value, int minValue = 0, int maxValue = 99) : base(value)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public ClampedAttribute( int a ):base(a){
            MinValue = 0;
            MaxValue = 99;
        }

        private int GetValue(){
            var val = (int) Modifiers.GetBonusFor(BaseValue);
            return Math.Clamp(val, MinValue, MaxValue);
        }
    }
}
