> Não funciona pois o metodo **asClass()** não pode ser abstract (ou virtual) e statico ao mesmo tempo.

``` c#
    /// <summary>
    /// Represents a abstract class that enables its children to operate as numbers in comparisons and operations. 
    /// For this to work. It is required to:
    /// <br/>
    /// - Implement <b>asN()</b> -> Maps the current instance to a float.
    /// <br/>
    /// - Implement <b>asClass(float i)</b> -> Maps a float to an instance .
    /// <br/>
    /// <b>This class does not overide Equals() or GetHashCode() so that comparisons with the original class can still be made</b>
    /// </summary>
    public abstract class _AsNumber
    {
        public float value;

        /// <summary>
        /// Maps a float to an instance
        /// </summary>
        public abstract  static _AsNumber asClass(float value);
        
        /// <summary>
        /// Maps the current instance to a float.
        /// </summary>
        public abstract  float asN();

        // Permite a operação: atributo = 5
        public static implicit operator _AsNumber(float value)
        {
            return asClass(value);
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
```