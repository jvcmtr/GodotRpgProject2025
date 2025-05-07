using Godot;
using System.Collections.Generic;
using DLL.enums;
using System;
using System.Linq;

namespace DLL.Formulas {
    public static class ModFormula {

        public static double GetBonusFor(double BaseValue, 
            double aditive,
            double multiplicative,
            double compound, 
            double absolute
        ){
            return (( BaseValue + aditive) * multiplicative * compound ) + absolute;
        }

        public static double GetBonusFor(double baseValue, IList<IModifier> modifiers)
        {
            double aditive = 0, multiplicative = 1, compound = 1, absolute = 0;
            
            foreach (var m in modifiers)
            {
                var t = m.Type;
                switch (t) 
                {
                    case EModifier.ABSOLUTE:
                        absolute += m.GetBonusToAdd();
                        break;
                    case EModifier.ADITIVE:
                        aditive += m.GetBonusToAdd();
                        break;
                    case EModifier.MULTIPLICATIVE:
                        multiplicative += m.GetBonusToAdd();
                        break;
                    case EModifier.MULTIPLICATIVE_COMPOUND:
                        compound += m.GetBonusToAdd(compound);
                        break;
                }
            }
            
            return GetBonusFor(baseValue, aditive, multiplicative, compound, absolute);
        }

    }
}
