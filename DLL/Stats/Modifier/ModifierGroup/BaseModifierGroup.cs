using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using DLL.Formulas;

namespace DLL.Stats.Modifiers {
    public abstract class BaseModifierGroup : IModifierGroup {
        
        public List<IModifier> Modifiers = new List<IModifier>();

        public virtual IModifierGroup Add(IModifier modifier){
            var existing = Modifiers.FirstOrDefault(m => m.Source == modifier.Source);
            
            if(existing != null) existing = modifier;
            else Modifiers.Add(modifier);

            return this;
        }

        public virtual IModifierGroup Remove(string source){
            var existing = Modifiers.FirstOrDefault(m => m.Source == source);
            if(existing == null){ return this ;}
            
            Modifiers.Remove(existing);
            return this;
        }

        public double GetBonusFor(double BaseValue){
            return ModFormula.GetBonusFor(BaseValue, Modifiers);
        }

        public IEnumerator<IModifier> GetEnumerator()
        {
            return Modifiers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
