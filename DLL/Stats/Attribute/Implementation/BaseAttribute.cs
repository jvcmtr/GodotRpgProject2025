using System;
using System.Numerics;
using DLL.enums;
using DLL.Stats.Modifiers;
using Godot;

namespace DLL.Stats {
    public abstract class BaseAttribute<T> : BaseModifierHandlerAttribute<T>, IAttribute<T> where T : INumber<T>{
        
        public override T BaseValue { get; protected set;}

        public BaseAttribute(T value, IModifierGroup? modifierGroup = null ): base(value, modifierGroup) {}

        public virtual IAttribute<T> UpdateBaseValue(T value)
        {
            BaseValue = value;
            return this;
        }

    }
}
