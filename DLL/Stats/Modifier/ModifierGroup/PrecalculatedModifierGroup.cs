using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DLL.enums;
using DLL.Formulas;

namespace DLL.Stats.Modifiers {
    /// <summary>
    /// </summary>
    public class PrecalculatedModifierGroup : IEnumerable<IModifier>{
        
        private IList<IModifier> modifiers = new List<IModifier>() ;
        
        private bool isEmpty = true;
        private double ADITIVE_PRECALC = 0;
        private double MULTIPLICATIVE_PRECALC = 1;
        private double COMPOUND_PRECALC = 1;
        private double ABSOLUTE_PRECALC = 0;
        

        public PrecalculatedModifierGroup Add(IModifier modifier){
            var existing = modifiers.FirstOrDefault(m => m.Source == modifier.Source);
            if(existing != null){
                HandlePrecalc(existing , false);
                modifiers.Remove(existing);
            }

            HandlePrecalc(modifier);
            modifiers.Add(modifier);
            return this;
        }

        public PrecalculatedModifierGroup Remove(string source){
            var mod = modifiers.FirstOrDefault(m => m.Source == source);
            if(mod == null){
                return this;
            }
            HandlePrecalc(mod , false);
            modifiers.Remove(mod);
            return this;
        }

        public double GetBonusFor(double BaseValue){
            if(isEmpty) return BaseValue;
            return ModFormula.GetBonusFor(BaseValue, ADITIVE_PRECALC, MULTIPLICATIVE_PRECALC, COMPOUND_PRECALC, ABSOLUTE_PRECALC);
        }

        private void HandlePrecalc(IModifier mod, bool isAddModifier = true){
            
            switch (mod.Type)
            {
                case EModifier.ABSOLUTE:
                    ABSOLUTE_PRECALC += isAddModifier? mod.GetModifier() : -mod.GetModifier();
                    break;
                case EModifier.ADITIVE:
                    ADITIVE_PRECALC += isAddModifier? mod.GetModifier() : - mod.GetModifier();
                    break;
                case EModifier.MULTIPLICATIVE:
                    MULTIPLICATIVE_PRECALC += isAddModifier? mod.GetModifier() : - mod.GetModifier();
                    break;
                case EModifier.MULTIPLICATIVE_COMPOUND:
                    COMPOUND_PRECALC *= isAddModifier? mod.GetModifier() : (1/mod.GetModifier());
                    break;
            }
        }

        public IEnumerator<IModifier> GetEnumerator()
        {
            return modifiers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
