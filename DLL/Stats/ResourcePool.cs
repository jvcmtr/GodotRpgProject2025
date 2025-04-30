using Godot;
using System;
using System.Runtime.CompilerServices;

namespace DLL.Stats {
    /// <summary>
    /// This class represents a resource pool, such as FP, HP Stamina etc...
    /// </summary>
    public class ResourcePool
    {
        public Attribute Max = 0;
        protected int Ammount = 0;
        public ModifierGroup Cost = new ModifierGroup(); 
        public ModifierGroup Recover = new ModifierGroup(); 

        public ResourcePool(int maxValue){
            Max = maxValue;
            Ammount = maxValue;
        }

        /// <summary>
        /// Spend the resourse if possible. Else retuns false.
        /// <br/> Is possible to spend a resource if the <b>ammount</b> provided in the argument (+ <b> Cost-Modifiers</b>) is less than or equal to <b>this.Ammount</b>
        /// </summary>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public bool TrySpendResource(int ammount){
            int total = ammount + (int) Cost.CalcModifiers(ammount);  
            if(total > Ammount){
                return false;
            }
            
            Ammount -= total;
            return true;
        }

        public void SpendResource( int ammount){
            Ammount -= ammount + (int) Cost.CalcModifiers(ammount);            
            if(Ammount < 0) { Ammount = 0; }
        }

        public void RecoverResource(int ammount){
            Ammount += (int) Recover.CalcModifiers(ammount);
            if(ammount > Max){ Ammount = Max; }
        }

        public bool isDepleted(){
            return Ammount == 0;
        }

        public bool isFull(){
            return Ammount == 0;
        }

        public double getRatio(){
            return Ammount/Max;
        }
   
    }
}
