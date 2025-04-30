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
        public void Add(string source, float value, EAttributeMod modType = EAttributeMod.ABSOLUTE)
        {
            var newMod = new Modifier(source, value, modType);
            var index = Modifiers.FindIndex(m => m.Source == source);

            if (index >= 0) Modifiers[index] = newMod;
            else Modifiers.Add(newMod);

        }

        /// <summary>
        /// <i> source não considera capitalização. </i> 
        /// </summary>
        /// <returns></returns>
        public void Remove(string source){
            Modifiers = Modifiers.Where(mod => mod.Source != source).ToList();
        }

        public float CalcModifiers(Attribute value){
            value = Modifiers
                .Where( m => m.type != EAttributeMod.CUMULATIVE)
                .Sum( m => (int) m.GetBonus(value)); 

            value += Modifiers
                .Where( m => m.type == EAttributeMod.CUMULATIVE)
                .Sum( m => (int) m.GetBonus(value)); 

            return value; 
        }

        public float CalcModifiers(float value){
            value = Modifiers
                .Where( m => m.type != EAttributeMod.CUMULATIVE)
                .Sum( m => (int) m.GetBonus((int)value)); 

            value += Modifiers
                .Where( m => m.type == EAttributeMod.CUMULATIVE)
                .Sum( m => (int) m.GetBonus((int)value)); 

            return value; 
        }

        public float GetFinalModifier(int value, EAttributeMod type){
            var val = new Attribute(value);

            return Modifiers
                .Where( m => m.type == type)
                .Sum( m => (int) m.GetBonus(val)); 
        }

        public List<(string, float, EAttributeMod)> GetModifiers(){
            return Modifiers.Select(m => (m.Source, m.Value, m.type)).ToList();
        }

}
}