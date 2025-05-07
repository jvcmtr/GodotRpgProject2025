using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using DLL.Stats.Modifiers;
using DLL.enums;


namespace DLL.Stats {
    public abstract class AbstractAttribute<T> : IAttribute<T> where T : INumber<T> {
        
        protected ModifierGroup Modifiers = new ModifierGroup();

        public abstract T BaseValue {get; protected set;}
        public abstract T Value { get;}

        public virtual IAttribute<T> AddModifier(string source, float value, EModifier type = EModifier.ADITIVE)
        {
            Modifiers.Add( new StaticModifier(source, value, type) );
            return this;
        }

        public IAttribute<T> RemoveModifier(string source)
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
