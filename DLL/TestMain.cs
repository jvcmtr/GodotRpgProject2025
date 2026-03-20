using DLL.Combat;
using DLL.enums;
using DLL.Stats;
using DLL.Stats.Modifiers;
using Godot;
using System;

namespace DLL	
{

// Must be scene tree to run with headless godot
// Must extend node to be assigned to run in godot
public partial class TestMain : SceneTree
{

	public void Main(){
		TestsRepo.AttributePerformanceTest();
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
