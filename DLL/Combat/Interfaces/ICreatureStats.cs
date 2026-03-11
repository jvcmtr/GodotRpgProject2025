using DLL.Stats;

namespace DLL.Combat;


public interface ICreatureStats {
    public CalculatedAttribute Health {get;}
    public CalculatedAttribute Stamina {get;}
    public CalculatedAttribute Mana {get;}


    public IAttribute<int> Vitality {get;}
    public IAttribute<int> Endurance {get;}
    public IAttribute<int> Strength {get;}
    public IAttribute<int> Agility {get;}
    public IAttribute<int> Inteligence {get;}
    public IAttribute<int> Wisdom {get;}
    public IAttribute<int> Conviction {get;}
    }