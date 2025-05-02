using DLL.Combat;
using DLL.Stats;
using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DLL	
{

public partial class TestMain : SceneTree
{
	public void Main(){
		Attribute<double> a = 5;
		a += ("", 1.5);






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
