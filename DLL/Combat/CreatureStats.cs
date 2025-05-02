using DLL.Stats;

namespace DLL.Combat {
    public class CreatureStats {
        public ResourcePool Health {get; protected set;}
        public ResourcePool Mana {get; protected set;}
        public ResourcePool Stamina {get; protected set;}

        // Placeholder stats
        public StandartAttribute Strength {get; protected set;}
        public StandartAttribute Agility {get; protected set;}
        public StandartAttribute Endurance {get; protected set;}
        public StandartAttribute Conviction {get; protected set;}
        public StandartAttribute Inteligence {get; protected set;}
        public StandartAttribute Wisdom {get; protected set;}

        public CreatureStats(
            int strength = 0, 
            int agility = 0, 
            int endurance = 0, 
            int conviction = 0, 
            int inteligence = 0, 
            int wisdom = 0
        ){
            Strength = new StandartAttribute(strength);

        }
    }
}
