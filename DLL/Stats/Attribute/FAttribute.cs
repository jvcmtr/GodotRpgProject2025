using System;
using DLL.Stats.Modifiers;

namespace DLL.Stats {
    public class FAttribute : BaseAttribute<double>{

        public override double Value => Modifiers.GetBonusFor(BaseValue); 
        public FAttribute(int value, IModifierGroup? modifiers = null) : base(value, modifiers ){}
    }
}
