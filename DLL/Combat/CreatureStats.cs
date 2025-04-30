using DLL.Stats;
using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DLL.Combat {
    public class CreatureStats {
        private ResourcePool Health;
        private ResourcePool Mana;
        private ResourcePool Stamina;

        private StandartAttribute Strength;
        private StandartAttribute Agility;
        private StandartAttribute Endurance;
        private StandartAttribute Conviction;
        private StandartAttribute Inteligence;
        private StandartAttribute Faith;
        private StandartAttribute Wisdom;
    }
}
