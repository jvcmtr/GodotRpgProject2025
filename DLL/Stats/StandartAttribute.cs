using Godot;
using System;

namespace DLL.Stats {
    public class StandartAttribute : Attribute<int>
    {
        public int MinValue {get; private set;}
        public int MaxValue {get; private set;}
        public StandartAttribute(int value, int minValue = 0, int maxValue = 99) : base(value)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public StandartAttribute( int a ):base(a){
            MinValue = 0;
            MaxValue = 99;
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
