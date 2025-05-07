using System;
using DLL.enums;

namespace DLL {
    public interface IModifier {
        string Source { get; }
        public EModifier Type {get; }

        /// <summary>
        /// Get the result with the modifier applied. Is the same as <c> a + GetModifier(a) </c>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        double Apply(double a);

        /// <summary>
        /// Get the number to be added to the result.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        double GetModifier(double a = 1);

        bool isOfType(EModifier type);
    }
}
