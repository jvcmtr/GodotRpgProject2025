using DLL.Combat;
using DLL.enums;
using DLL.Stats;
using DLL.Stats.Modifiers;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace DLL {
    public static class TestsRepo {

		public static void AttributePerformanceTest(){
			
			uint ITERATIONS = 50000;
			GD.Print($"... starting comparative test with {ITERATIONS} iterations : \n");

			var Test = new ComparativeTest<IAttribute<int>>()
				.AddSubject("Lazy", new LazyAttribute(100))
				.AddSubject("Precalc", new IntAttribute(100, new PrecalculatedModifierGroup()))
				.AddSubject("Default", new IntAttribute(100))
				.addTest("ADD DUPLICATED", (dt) => dt.subject.AddModifier($"1", 1.5, EModifier.ADITIVE) )
				.addTest("ADD", (dt) => dt.subject.AddModifier($"{dt.iteration}", 1.5, EModifier.ADITIVE) )
				.addTest("GET", (dt) => dt.subject.Value )
				.addTest("REMOVE", (dt) => dt.subject.RemoveModifier($"{dt.iteration}") )
				.RunTestsWithProgress( ITERATIONS, true, true)
				.IncludeSum()
				.IncludeAvg();

			var rawResult = Test.GetFormatedResults();

			var resultSTR = Test
				.ClearInterpreters()
				.addInterpreter("ADD", (a, b) => (int)(a.result.TotalMilliseconds / b["Default", "ADD"].TotalMilliseconds * 100 ) + " %" )
				.addInterpreter("ADD DUPLICATED", (a, b) => (int)(a.result.TotalMilliseconds / b["Default", "ADD DUPLICATED"].TotalMilliseconds * 100 ) + " %" )
				.addInterpreter("GET", (a, b) => (int)(a.result.TotalMilliseconds / b["Default", "GET"].TotalMilliseconds * 100 ) + " %" )
				.addInterpreter("REMOVE", (a, b) => (int)(a.result.TotalMilliseconds / b["Default", "REMOVE"].TotalMilliseconds * 100 ) + " %" )
				.addInterpreter( Test.SUM , (a, b) => (int)(a.result.TotalMilliseconds / b["Default", Test.SUM ].TotalMilliseconds * 100 ) + " %" )
				.GetFormatedResults()
				;


			string GetAverage((string subjectName, IAttribute<int> subject, TimeSpan result) current, Table<TimeSpan> otherResults){
				var v = current.result.TotalNanoseconds;
				var total = otherResults[current.subjectName, Test.SUM].TotalNanoseconds;

				return ((int) (v/total * 100 )) + " %" ;
			}
			
			var ResultPersent = Test
				.ClearInterpreters()
				.addInterpreter("ADD", GetAverage)
				.addInterpreter("ADD DUPLICATED", GetAverage)
				.addInterpreter("GET", GetAverage)
				.addInterpreter("REMOVE", GetAverage)
				.GetFormatedResults();

			
			GD.Print("Tempo : ");
			GD.Print(rawResult);
			GD.Print();

			GD.Print("Comparado ao Default : ");
			GD.Print(resultSTR);
			GD.Print();
			
			GD.Print("% tempo para cada operacao");
			GD.Print(ResultPersent);
			GD.Print();
			
			GD.Print("Duracao total do teste : " + Test.TotalTestDuration.TotalSeconds + " sec");
			GD.Print("Overhead da classe de teste : " + Test.GetTestOverhead().TotalSeconds + " sec");

		}



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
