using DLL.Combat;
using DLL.enums;
using DLL.Stats;
using DLL.Stats.Modifiers;
using Godot;
using System;

namespace DLL {
    public static class TempTest {
        public static void ResourcePoolTest(){
            // ResourcePool hp = new ResourcePool(10);
            // IAttribute<double> LowHealthBonus = new CalculatedAttribute(()=> (hp.getRatio()-1) * -1 * 10);
            // hp.Cost.Add("Take double damage", 2, EModifier.MULTIPLICATIVE);
            // hp.Recover.Add("Heal half ammount", 0.5, EModifier.MULTIPLICATIVE);
            // hp.Recover.Add("Heal +2", 2, EModifier.ABSOLUTE);
            
            // hp.TrySpendResource(6); // Should be 6
            // if(hp.isDepleted()){ GD.Print("ERROR ON try(6) " + hp.Ammount); }
            
            // hp.TrySpendResource(5); // Should be 10
            // if(!hp.isDepleted()){ GD.Print("ERROR ON try(5) " + hp.Ammount); }
            
            // hp.RecoverResource(10); // Should be (10*0.5)+2 = 7
            // if(hp.Ammount != 7){ GD.Print("ERROR ON rec(10) " + hp.Ammount); }
            
            // hp.SpendResource(6); //Should be 12
            // if(!hp.isDepleted()){ GD.Print("ERROR ON spend(6) " + hp.Ammount); }

        }

        public static void  AttributeTest(){
		// IntAttribute agility = new IntAttribute(10);
		// IAttribute<double> agiMod = new CalculatedAttribute(()=> agility.Value / 2);
		// agility.AddModifier("a", 2, EModifier.ADITIVE);
		// agility.AddModifier("b", 0.5, EModifier.MULTIPLICATIVE);
		// agility.AddModifier("c", 100, EModifier.ABSOLUTE);
		
		// GD.Print("10 * 2 * 5 * 0.25 = " + 106 );
		// GD.Print("agility: " + agility.Value);
		// GD.Print("/2 = " + 53 );
		// GD.Print("agiMod: " + agiMod.Value);




		// IntAttribute agility = new IntAttribute(10);
		// IAttribute<double> agiMod = new CalculatedAttribute(()=> agility.Value / 2);
		// agility.AddModifier("a", 2, EModifier.ADITIVE);
		// agility.AddModifier("b", 5, EModifier.ADITIVE);
		// agility.AddModifier("c", 0.25, EModifier.ADITIVE);
		
		// GD.Print("10 * 2 * 5 * 0.25 = " + (10+2+5+0.25) );
		// GD.Print("agility: " + agility.Value);
		// GD.Print("/2 = " + (10+2+5+0.25) / 2 );
		// GD.Print("agiMod: " + agiMod.Value);

		

		// IntAttribute agility = new IntAttribute(10);
		// IAttribute<double> agiMod = new CalculatedAttribute(()=> agility.Value / 2);
		// agility.AddModifier("a", 2, EModifier.MULTIPLICATIVE_COMPOUND);
		// agility.AddModifier("b", 5, EModifier.MULTIPLICATIVE_COMPOUND);
		// agility.AddModifier("c", 0.25, EModifier.MULTIPLICATIVE_COMPOUND);
		
		// GD.Print("10 * 2 * 5 * 0.25 = " + 10*2*5*0.25 );
		// GD.Print("agility: " + agility.Value);
		// GD.Print("/2 = " + 10*2*5*0.25 / 2 );
		// GD.Print("agiMod: " + agiMod.Value);




		// IntAttribute agility = new IntAttribute(10);
		// IAttribute<double> agiMod = new CalculatedAttribute(()=> agility.Value / 2);
		// agility.AddModifier("a", 2, EModifier.MULTIPLICATIVE);
		// agility.AddModifier("b", 5, EModifier.MULTIPLICATIVE);
		// agility.AddModifier("c", 0.25, EModifier.MULTIPLICATIVE);
		
		// GD.Print("10 * 2 * 5 * 0.25 = " + (10 + (10*(2-1))+ (10*(5-1))+ (10*(0.25-1))) );
		// GD.Print("agility: " + agility.Value);
		// GD.Print("/2 = " + (10 + (10*(2-1))+ (10*(5-1))+ (10*(0.25-1))) / 2 );
		// GD.Print("agiMod: " + agiMod.Value);
    }
    }
}
