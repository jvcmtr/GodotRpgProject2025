
using System;

namespace DLL.Stats.Modifiers {
    /// <summary>
    /// This class represents a resource pool, such as FP, HP Stamina etc...
    /// </summary>
    public class ResourcePool
    {
        protected int Ammount = 0;
        public IntAttribute Max;
        public ModifierGroup Cost = new ModifierGroup(); 
        public ModifierGroup Recover = new ModifierGroup(); 

        public ResourcePool(int maxValue, int initialValue = -1){
            Max = new IntAttribute(maxValue);
            Ammount = initialValue;
            ContrainResource();
        }

        /// <summary>
        /// Spend the resourse if possible. Else retuns false.
        /// <br/> Is possible to spend a resource if the <b>ammount</b> provided in the argument (+ <b> Cost-Modifiers</b>) is less than or equal to <b>this.Ammount</b>
        /// </summary>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public bool TrySpendResource(int ammount){
            int total = (int) Cost.GetBonusFor(ammount);

            if(total > Ammount){
                return false;
            }
            
            Ammount -= ammount;
            return true;
        }

        public void SpendResource( int ammount){
            Ammount -= ammount + (int) Cost.GetBonusFor(ammount);            
            ContrainResource();
        }

        public void RecoverResource(int ammount){
            Ammount += (int) Recover.GetBonusFor(ammount);
            ContrainResource();
        }

        private void ContrainResource(){
            if(Ammount < 0){Ammount = 0; return; }
            if(Ammount > Max. Value){Ammount = Max. Value;}
        }

        public bool isDepleted(){
            return Ammount == 0;
        }

        public bool isFull(){
            return Ammount == Max. Value;
        }

        public double getRatio(){
            return Ammount/Max. Value;
        }
   
    }
}
