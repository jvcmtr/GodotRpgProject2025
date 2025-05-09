using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using DLL.Stats.Modifiers;
using DLL.enums;


namespace DLL.Stats {
    public abstract class BaseModifierHandlerAttribute<T> : IAttribute<T> where T : INumber<T> {
        
        protected IModifierGroup Modifiers = new ModifierGroup();

        public abstract T BaseValue {get; protected set;}
        public abstract T Value { get;}

        public BaseModifierHandlerAttribute(T value, IModifierGroup? modifierGroup = null ){
            BaseValue = value;
            Modifiers = modifierGroup == null? new ModifierGroup() : modifierGroup;
        }

        public virtual IAttribute<T> AddModifier(string source, double value, EModifier type = EModifier.ADITIVE)
        {
            Modifiers.Add( new StaticModifier(source, value, type) );
            return this;
        }

        public virtual IAttribute<T> RemoveModifier(string source)
        {
            Modifiers.Remove(source);
            return this;
        }
        
        public virtual List<IModifier> GetModifiers()
        {
            return Modifiers.ToList();
        }
    }
}
