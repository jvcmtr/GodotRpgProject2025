using DLL.Combat;
using DLL.enums;
using DLL.Stats;
using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DLL	
{

public partial class TestMain : SceneTree
{

	public void Main(){


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






	public void runTests(){
		GD.Print("\n\n\n\n");
		GD.Print("________________________________________________");
		GD.Print("  TESTING... ");
		GD.Print("\n");

		Main();

		GD.Print("\n");
		GD.Print("  DONE ");
		GD.Print("________________________________________________");
	}

	override public void _Initialize(){
		runTests();
		Quit();
	}
}
}
