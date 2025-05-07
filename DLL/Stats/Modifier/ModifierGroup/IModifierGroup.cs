using System;
using System.Collections.Generic;

namespace DLL.Stats.Modifiers {
    public interface IModifierGroup : IEnumerable<IModifier> {
        IModifierGroup Add(IModifier modifier);

        public IModifierGroup Remove(string source);

        public double GetBonusFor(double BaseValue);

    }
}
