using DLL.Stats;

namespace DLL.Combat {
    public class BaseCreatureStats {

        public CalculatedAttribute Health;
        public CalculatedAttribute Stamina;
        public CalculatedAttribute Mana;


        public IAttribute<int> Vitality;
        public IAttribute<int> Endurance;
        public IAttribute<int> Strength;
        public IAttribute<int> Agility;
        public IAttribute<int> Inteligence;
        public IAttribute<int> Wisdom;
        public IAttribute<int> Conviction;

        public BaseCreatureStats(int vitality, int endurance, int strength, int agility, int inteligence, int wisdom, int conviction){
            Vitality = new LazyAttribute(vitality);
            Endurance = new LazyAttribute(endurance);
            Strength = new LazyAttribute(strength);
            Agility = new LazyAttribute(agility);
            Inteligence = new LazyAttribute(inteligence);
            Wisdom = new LazyAttribute(wisdom);
            Conviction = new LazyAttribute(conviction);

            Health = new CalculatedAttribute(() => { return 20 + (Vitality.Value * 1.35) + (Endurance.Value * 0.5); });
            Stamina = new CalculatedAttribute(() => { return 10 + (Endurance.Value * 1.5) + (Agility.Value * 0.5) + (Strength.Value * 0.5); });
            
            Mana = new CalculatedAttribute(() => { return 
                ( (1/Wisdom.Value) * 10 )
                (Vitality.Value * 0.75) + (Endurance.Value * 0.2); });
        }
    }
}
