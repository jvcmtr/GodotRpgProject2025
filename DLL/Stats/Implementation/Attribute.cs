using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DLL.Stats	
{
    public class Attribute<T> : 
        IAttribute<T>,
        IAttribute_Convenience<T, Attribute<T>> where T : INumber<T>
    {
        public T CurrentValue { get; protected set; }
        public T BaseValue { get; protected set; }
        protected ModifierGroup Modifiers = new ModifierGroup();

        public Attribute(T value){
            BaseValue = value;
            CurrentValue = value;
        }
        
        public Attribute(IAttribute<T> att)
        {
            BaseValue = att.GetValue();
            Modifiers = new ModifierGroup(att.GetModifiers());
        }

        public IAttribute<T> UpdateBaseValue(T value)
        {
            BaseValue = value;
            UpdateCurrent();
            return this;
        }

        virtual protected void UpdateCurrent()
        {
            // var a = new Attribute(this.BaseValue)
            // CurrentValue = (T) Modifiers.CalcModifiers(this);
        }

        public IAttribute<T> AddModifier(string source, float value, EAttributeMod modType = EAttributeMod.ABSOLUTE)
        {
            Modifiers.Add(source, value, modType);
            UpdateCurrent();

            return this;
        }

        /// <c> att -= "source" </c> <b>Esta notação é o mesmo que chamar este metodo </b> 
        /// <br/>
        /// <i> source não considera capitalização. </i> 
        /// </summary>
        /// <returns></returns>
        public IAttribute<T> RemoveModifier(string source)
        {
            Modifiers.Remove(source);
            UpdateCurrent();
            return this;
        }

        public List<(string, float, EAttributeMod)> GetModifiers() => Modifiers.ToList();
        public T GetValue() => CurrentValue;












        // Convenience _______________________________________________________________________________________________________
        #region Convenience

        // Permite transformação implicita de Atributo => Numero
        public static implicit operator T(Attribute<T> a) => a.GetValue();
        public static implicit operator Attribute<T>(T value) => new Attribute<T>(value);

        // Adiciona modificadores automaticamente
        public static Attribute<T> operator +(Attribute<T> a, (string, T) b) { a.AddModifier(b.Item1, float.CreateTruncating( b.Item2 )); return a;}
        public static Attribute<T> operator *(Attribute<T> a, (string, T) b) { a.AddModifier(b.Item1, float.CreateTruncating( b.Item2 ), EAttributeMod.MULTIPLICATIVE);  return a;}
        public static Attribute<T> operator -(Attribute<T> a, string b) { a.RemoveModifier(b); return a;}

        // Para impedir a divisão de inteiros (garante a existencia de ponto flutuante na divisão)
        public static double operator /(Attribute<T> a, int b) => float.CreateTruncating( a.GetValue() ) / b ;
        public static double operator /(int a, Attribute<T> b) => a / float.CreateTruncating( b.GetValue() );
        public static double operator /(Attribute<T> a, Attribute<T> b) => float.CreateTruncating( a.GetValue())  / float.CreateTruncating( b.GetValue() ) ;

        // Para Atualizar o valor base sem perder os Modificadores
        public static Attribute<T> operator +(Attribute<T> a, T b) { a.UpdateBaseValue( a.GetValue() + b); return a;}
        public static Attribute<T> operator -(Attribute<T> a, T b) { a.UpdateBaseValue( a.GetValue() - b); return a;}
        public static Attribute<T> operator *(Attribute<T> a, T b) { a.UpdateBaseValue( a.GetValue() * b); return a;}
        public static Attribute<T> operator /(Attribute<T> a, T b) { a.UpdateBaseValue( a.GetValue() / b); return a;}
        public static Attribute<T> operator %(Attribute<T> a, T b) { a.UpdateBaseValue( a.GetValue() % b); return a;}
        public static Attribute<T> operator ++(Attribute<T> a) { a.UpdateBaseValue( a.GetValue() + T.One); return a;}
        public static Attribute<T> operator --(Attribute<T> a) { a.UpdateBaseValue( a.GetValue() - T.One); return a;}

        // Para conseguir operar entre atributos
        public static T operator +(Attribute<T> a, Attribute<T> b) => a.GetValue() + b.GetValue();
        public static T operator -(Attribute<T> a, Attribute<T> b) => a.GetValue() - b.GetValue();
        public static T operator *(Attribute<T> a, Attribute<T> b) => a.GetValue() * b.GetValue();
        public static T operator %(Attribute<T> a, Attribute<T> b) => a.GetValue() % b.GetValue();

        public static bool operator ==(Attribute<T> a, Attribute<T> b) => a.GetValue() == b.GetValue();
        public static bool operator !=(Attribute<T> a, Attribute<T> b) => a.GetValue() != b.GetValue();
        public static bool operator <(Attribute<T> a, Attribute<T> b) => a.GetValue() < b.GetValue();
        public static bool operator >(Attribute<T> a, Attribute<T> b) => a.GetValue() > b.GetValue();
        public static bool operator <=(Attribute<T> a, Attribute<T> b) => a.GetValue() <= b.GetValue();
        public static bool operator >=(Attribute<T> a, Attribute<T> b) => a.GetValue() >= b.GetValue();

        #endregion
    }
}