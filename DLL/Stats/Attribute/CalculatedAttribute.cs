using System;
using System.Numerics;
using DLL.Stats.Modifiers;

namespace DLL.Stats {
    public class CalculatedAttribute : BaseModifierHandlerAttribute<double>{

        public override double BaseValue { get => Calc.Invoke(); protected set => throw new Exception("Cant update calculated value") ;}
        public override double Value { get => Modifiers.GetBonusFor(Calc.Invoke()) ;}

        private readonly Func<double> Calc;

        public CalculatedAttribute(double value, IModifierGroup? modifiers) : base(value, modifiers){
            Calc = () => value;
        }

        public CalculatedAttribute(Func<double> calculation) : base(0)
        {
            Calc = calculation;
        }
    }
}
