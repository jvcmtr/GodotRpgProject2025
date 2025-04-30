using Godot;
using System;

namespace DLL.Stats {
    public class StandartAttribute : Attribute
    {
        public int MinValue {get; private set;}
        public int MaxValue {get; private set;}
        public StandartAttribute(int value, int minValue = 0, int maxValue = 99) : base(value)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        protected override void UpdateCurrent(){
            base.UpdateCurrent();
            if(CurrentValue > MaxValue) 
                CurrentValue = MaxValue;
            if(CurrentValue < MinValue) 
                CurrentValue = MinValue;
        }
    }
}
