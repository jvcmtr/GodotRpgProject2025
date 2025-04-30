using System.Windows.Markup;

namespace DLL.Stats	
{
    /// <summary>
    /// Represents a abstract class that enables its children to operate as numbers in comparisons and operations. 
    /// For this to work. It is required to:
    /// <br/>
    /// - Implement <b>asN()</b> -> Maps the current instance to a float.
    /// <br/>
    /// <b>This class does not overide Equals() or GetHashCode() so that comparisons with the original class can still be made</b>
    /// </summary>
    public abstract class _AsNumber
    {
        protected float value;

        /// <summary>
        /// Maps a float to an instance
        /// </summary>
        protected _AsNumber(float value){
            value = value ;
        }

        /// <summary>
        /// Maps the current instance to a float.
        /// </summary>
        public virtual float asN(){
            return value;
        }

        // Permite a operação: atributo = 5
        public static implicit operator _AsNumber(float value)
        {
            return new _Value(value);
        }

        // Permite a operação: atributo + 5 == 10?
        public static implicit operator float(_AsNumber c)
        {
            return c.asN();
        }

        // Para conseguir operar entre atributos
        public static float operator +(_AsNumber a, _AsNumber b) => a.asN() + b.asN();
        public static float operator -(_AsNumber a, _AsNumber b) => a.asN() - b.asN();
        public static float operator *(_AsNumber a, _AsNumber b) => a.asN() * b.asN();
        public static float operator /(_AsNumber a, _AsNumber b) => a.asN() / b.asN();
        public static float operator %(_AsNumber a, _AsNumber b) => a.asN() % b.asN();

        public static bool operator ==(_AsNumber a, _AsNumber b) => a.asN() == b.asN();
        public static bool operator !=(_AsNumber a, _AsNumber b) => a.asN() != b.asN();
        public static bool operator <(_AsNumber a, _AsNumber b) => a.asN() < b.asN();
        public static bool operator >(_AsNumber a, _AsNumber b) => a.asN() > b.asN();
        public static bool operator <=(_AsNumber a, _AsNumber b) => a.asN() <= b.asN();
        public static bool operator >=(_AsNumber a, _AsNumber b) => a.asN() >= b.asN();
    }

    // Base _AsNumber implementation
    public class _Value : _AsNumber{
        
        public float value;
        public _Value(float v) : base(v){}
        public float asN() => value;
    }
}