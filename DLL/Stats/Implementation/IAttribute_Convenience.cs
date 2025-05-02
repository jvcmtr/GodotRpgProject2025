using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DLL.Stats	
{

    /// <summary>
    /// Esta Interface permite que você trate o seu atributo como um Numero. Para usa-la, basta extender a interface e adicionar o codigo disponibilizado. <br/> 
    /// <br/> 
    /// Para detalhes da implementação acesse a documentação no <see href="">Github</see> 
    /// </summary>
    /// <typeparam name="T"> Numero (int, float, decimal, double )</typeparam>
    /// <typeparam name="TSelf"> A propria classe que está implementando esta interface </typeparam>
    public interface IAttribute_Convenience<T, TSelf> 
        where TSelf : IAttribute_Convenience<T, TSelf>, IAttribute<T>
        where T : INumber<T>
    {

        /// <summary>
        /// A Method that constructs a new instance of your class from a number (aka a type that implements INumber) <br/> 
        /// This method is the oposite of <c>implicit operator T(IAttribute value)</c>.
        /// </summary>
        static abstract implicit operator TSelf(T value);

        /// <summary>
        /// A Method that returns your class current value.<br/>
        /// Can simply return GetValue() <br/> 
        /// This method is the oposite of <c>implicit operator IAttribute(T value)</c>.
        /// </summary>
        static abstract implicit operator T(TSelf value);

        /// <summary> AddModifier() </summary>
        public static abstract TSelf  operator +(TSelf a, (string, T) b); 
        
        /// <summary> AddModifier( MULTIPLICATIVE ) </summary>
        public static abstract TSelf  operator *(TSelf a, (string, T) b); 

        /// <summary>  RemoveModifier()   </summary>
        public static abstract TSelf  operator -(TSelf a, string b);   

        // Para Atualizar o valor base sem perder os Modificadores
        public static abstract TSelf operator +(TSelf a, T b);
        public static abstract TSelf operator ++(TSelf a);
        public static abstract TSelf operator -(TSelf a, T b);
        public static abstract TSelf operator --(TSelf a);
        public static abstract TSelf operator *(TSelf a, T b);
        public static abstract TSelf operator /(TSelf a, T b);
        public static abstract TSelf operator %(TSelf a, T b);

        // Para impedir a divisão de inteiros (garantir a existencia de ponto flutuante na divisão)
        public static abstract double operator /(TSelf a, int b); // atributo/int
        public static abstract double operator /(int a, TSelf b);
        public static abstract double operator /(TSelf a, TSelf b);

        // Para conseguir operar entre atributos
        public static abstract T operator +(TSelf a, TSelf b);
        public static abstract T operator -(TSelf a, TSelf b);
        public static abstract T operator *(TSelf a, TSelf b);
        public static abstract T operator %(TSelf a, TSelf b);

        public static abstract bool operator ==(TSelf a, TSelf b);
        public static abstract bool operator !=(TSelf a, TSelf b);
        public static abstract bool operator <(TSelf a, TSelf b);
        public static abstract bool operator >(TSelf a, TSelf b);
        public static abstract bool operator <=(TSelf a, TSelf b);
        public static abstract bool operator >=(TSelf a, TSelf b);
    }
}