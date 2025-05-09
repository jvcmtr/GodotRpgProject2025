using DLL.Stats.Modifiers;

namespace DLL.Stats {
    public class IntAttribute : BaseAttribute<int>{
        public override int Value { get => (int) Modifiers.GetBonusFor(BaseValue) ;}
        public IntAttribute(int value, IModifierGroup? modifiers = null) : base(value, modifiers ){}

    }
}
