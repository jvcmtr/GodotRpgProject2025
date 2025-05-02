- [x] Implementar toList (ou IEnumerable) no Modifier Group
- [x] Implementar operators (igual ao Attribute) no Modifier Group
- [ ] Testar ( Amuleto que aumenta a força em um valor igual a agilidade )


RASC 
``` cs
       static abstract implicit operator TSelf(T value);
        static abstract implicit operator T(TSelf value);

        // // Adiciona modificadores automaticamente
        public static abstract TSelf operator +(TSelf a, (string, T) b); // AddModifier()
        public static abstract TSelf operator *(TSelf a, (string, T) b); // AddModifier( MULTIPLICATIVE )
        public static abstract TSelf operator -(TSelf a, string b);      // RemoveModifier()   

        // Para impedir a divisão de inteiros (garantir a existencia de ponto flutuante na divisão)
        public static abstract T operator /(TSelf a, int b); // atributo/int
        public static abstract T operator /(int a, TSelf b);

        // Para conseguir operar entre atributos
        public static abstract double operator /(TSelf a, TSelf b);
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
```