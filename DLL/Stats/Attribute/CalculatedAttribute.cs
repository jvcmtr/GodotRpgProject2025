using System;
using System.Numerics;

namespace DLL.Stats {
    public class CalculatedAttribute : AbstractAttribute<double>, IAttribute<double>{

        public override double BaseValue { get => Calc.Invoke(); protected set => throw new Exception("Cant update calculated value") ;}
        public override double Value { get => Modifiers.GetBonusFor(Calc.Invoke()) ;}

        private readonly Func<double> Calc;

        public CalculatedAttribute(Func<double> calculation) : base ( )
        {
            Calc = calculation;
        }
    }
}
