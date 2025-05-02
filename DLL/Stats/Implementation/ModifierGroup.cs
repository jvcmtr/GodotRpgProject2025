using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DLL.Stats	
{

    public class ModifierGroup
    {
        protected List<Modifier> Modifiers = new List<Modifier>();

        public ModifierGroup(){
        }
        public ModifierGroup( ModifierGroup modifiers){
            Modifiers = modifiers.Modifiers;
        }
        public ModifierGroup( List<(string source, float value, EAttributeMod type)> modifiers){
            Modifiers = modifiers.Select( m => new Modifier(m.source, m.value, m.type) ).ToList();
        }



        /// <summary>
        /// <b>Considerações:</b>
        /// <br/>
        /// <i> - O Parametro source não considera capitalização. </i> 
        /// <br/>
        /// <i> - Caso o atributo já possua um modificador com o mesmo source, o antigo será substituido.</i> 
        /// </summary>
        /// <param name="source">Identificador. Não considera capitalização. Um atributo não pode possuir dois modificadores com o mesmo nome</param>
        /// <param name="value">valor</param>
        /// <param name="type"> Enum usado para definir como o valor será aplicado interpretar o valor</param>
        /// <returns></returns>
        public ModifierGroup Add(string source, float value, EAttributeMod modType = EAttributeMod.ABSOLUTE)
        {
            var newMod = new Modifier(source, value, modType);
            var index = Modifiers.FindIndex(m => m.Source == source);

            if (index >= 0) Modifiers[index] = newMod;
            else Modifiers.Add(newMod);

            return this;
        }

        /// <summary>
        /// <i> source não considera capitalização. </i> 
        /// </summary>
        /// <returns></returns>
        public ModifierGroup Remove(string source){
            Modifiers = Modifiers.Where(mod => mod.Source != source).ToList();
            return this;
        }

        public float CalcModifiers(float value){
            var val = new Attribute<float>(value);
            val = Modifiers
                .Where( m => m.type != EAttributeMod.CUMULATIVE)
                .Sum( m => m.GetBonus(val)); 

            val += Modifiers
                .Where( m => m.type == EAttributeMod.CUMULATIVE)
                .Sum( m => m.GetBonus(val)); 

            return val; 
        }

        public float GetFinalModifier(float value, EAttributeMod type){
            var val = new Attribute<float>(value);

            return Modifiers
                .Where( m => m.type == type)
                .Sum( m => m.GetBonus(val)); 
        }

        public List<(string source, float value, EAttributeMod type)> ToList(){
            return Modifiers.Select(m => (m.Source, m.Value, m.type)).ToList();
        }


        // Adiciona modificadores automaticamente
        public static ModifierGroup operator +(ModifierGroup a, (string, int) b) => a.Add(b.Item1, b.Item2);
        public static ModifierGroup operator +(ModifierGroup a, (string, float) b) => a.Add(b.Item1, b.Item2);
        public static ModifierGroup operator *(ModifierGroup a, (string, int) b) => a.Add(b.Item1, b.Item2, EAttributeMod.MULTIPLICATIVE);
        public static ModifierGroup operator *(ModifierGroup a, (string, float) b) => a.Add(b.Item1, b.Item2, EAttributeMod.MULTIPLICATIVE);
        public static ModifierGroup operator -(ModifierGroup a, string b) => a.Remove(b);

}
}