using System;
using System.Numerics;

namespace DLL.Stats {
    public class FAttribute : AbstractAttribute<double>, IAttribute<double> {
        
        public override double BaseValue { get; protected set;}
        public override double Value => Modifiers.GetBonusFor(BaseValue); 
        public FAttribute(double value){
            BaseValue = value;
        }

        public FAttribute UpdateBaseValue(double value)
        {
            BaseValue = value;
            return this;
        }
    }
}
