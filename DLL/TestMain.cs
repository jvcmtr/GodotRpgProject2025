using Godot;
using System;

namespace DLL	
{

public partial class TestMain : SceneTree
{
	public void Main(){







	}

	public void runTests(){
		GD.Print("________________________________________________");
		GD.Print("  TESTING... ");
		GD.Print("\n\n\n\n");

		Main();

		GD.Print("\n\n\n\n");
		GD.Print("  DONE ");
		GD.Print("________________________________________________");
	}

	override public void _Initialize(){
		runTests();
		Quit();
	}
}
}
