using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DLL.enums;
using DLL.Formulas;
using DLL.Stats.Modifiers;

namespace DLL.Stats {
    /// <summary>
    /// </summary>
    public class LazyAttribute : BaseAttribute<int>{
        
        public override int Value {get => GetValue();}
        
        private bool isUpToDate = true;
        private int lastCalc = 0;

        public LazyAttribute(int value, IModifierGroup? modifiers = null) : base(value, modifiers ){}

        private int GetValue(){
            if(isUpToDate) return lastCalc;

            lastCalc = (int) Modifiers.GetBonusFor(lastCalc);
            isUpToDate = true;
            return lastCalc;
        }

        public override IAttribute<int> AddModifier(string source, double value, EModifier type = EModifier.ADITIVE){
            isUpToDate = false;
            return base.AddModifier(source, value, type);
        }

        public override IAttribute<int> RemoveModifier(string source){
            isUpToDate = false;
            return base.RemoveModifier(source);
        }
        public override IAttribute<int> UpdateBaseValue(int newValue){
            isUpToDate = false;
            return base.UpdateBaseValue(newValue);
        }
    }
}
