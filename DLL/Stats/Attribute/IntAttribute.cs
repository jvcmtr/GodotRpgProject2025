using System;
using System.Numerics;
using DLL.enums;
using Godot;

namespace DLL.Stats {
    public class IntAttribute : AbstractAttribute<int>, IAttribute<int>{
        
        public override int BaseValue { get; protected set;}
        public override int Value { get => (int) Modifiers.GetBonusFor(BaseValue) ;}
        public IntAttribute(int value){
            BaseValue = value;
        }

        public IntAttribute UpdateBaseValue(int value)
        {
            BaseValue = value;
            return this;
        }

    }
}
