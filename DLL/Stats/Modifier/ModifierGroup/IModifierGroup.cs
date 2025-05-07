using System;
using System.Collections.Generic;
using DLL.enums;

namespace DLL.Stats.Modifiers {
    public interface IModifierGroup : IEnumerable<IModifier> {
        IModifierGroup Add(IModifier modifier);
        IModifierGroup Add(string source, double value, EModifier type = EModifier.ADITIVE);

        public IModifierGroup Remove(string source);

        public double GetBonusFor(double BaseValue);

    }
}
