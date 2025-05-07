
# Exemplos de Utilização
Esta Interface permite que você trate o seu atributo como um Numero.

## ⚠️ Not complete.
> There still a lot of not mapped edgecases and the objective of this interface is not clear.
> The use is not intuitive and standartized, It causes more problems than adds convenience

### DO NO USE 
but here it is anyway:

> **⚠️ Be carefull when doing assignment. with the exception of `+=` and `-=`, all assignments will reset your attributes !!!**

### Managing Modifiers

``` cs
strength += ("My Buff", 2) // This adds a ABSOLUTE modifier to the atribute 
strength *= ("My Buff 2", 1.5) // This adds a MULTIPLICATIVE modifier to the atribute
strength -= "My Buff" // This removes the modifier with that name 
```
### Assignment
``` cs
Attribute<int> strength = 5;    // ✅ This works! creates a attribute 5 as a base value.
int damage = 10 + strength;     // ✅ This also work! treat strength as an integer. 
strength ++     // ✅ This adds 1 to the (Also works for minus sign)
strength += 2;  // ✅ This adds 2 to the base value (Also works for minus sign) 

strength *= 2  // ❌ This DONT work, it returns a completely new Attribute 
			   // and you loose all your modifiers
			   
strength = 2 + strength // ❌ This will also delete all the modifiers from the Attribute
```

> **⚠️ Disclaimer, This notations work only for the type of Attribute declared, as shown below**
``` cs
Attribute<int> x = 10 ;     // ✅ attribute of type integer   
Attribute<float> x = 10.1f; // ✅  attribute of type float
Attribute<double> x = 10.1; // ✅  attribute of type double

Attribute<float> x = 5; // ❌ This wont work. Trying to assign a Integer to a Attribute of type float   
Attribute<float> x = (float) 5; // ✅ this will work, casting a float to an integer   
```


# Implementing
To Implement this interface, copy and paste the code below on your class and replace `MyClass<T>` with the name of your class;
```cs
#region Convenience
        public static implicit operator T(MyClass<T> a) => a.GetValue();
        public static implicit operator MyClass<T>(T value) => new MyClass<T>(value);

        // Adiciona modificadores automaticamente
        public static MyClass<T> operator +(MyClass<T> a, (string, T) b) { a.AddModifier(b.Item1, float.CreateTruncating( b.Item2 )); return a;}
        public static MyClass<T> operator *(MyClass<T> a, (string, T) b) { a.AddModifier(b.Item1, float.CreateTruncating( b.Item2 ), EAttributeMod.MULTIPLICATIVE);  return a;}
        public static MyClass<T> operator -(MyClass<T> a, string b) { a.RemoveModifier(b); return a;}

        // Para impedir a divisão de inteiros (garante a existencia de ponto flutuante na divisão)
        public static double operator /(MyClass<T> a, int b) => float.CreateTruncating( a.GetValue() ) / b ;
        public static double operator /(int a, MyClass<T> b) => a / float.CreateTruncating( b.GetValue() );
        public static double operator /(MyClass<T> a, MyClass<T> b) => float.CreateTruncating( a.GetValue())  / float.CreateTruncating( b.GetValue() ) ;

        // Para Atualizar o valor base sem perder os Modificadores
        public static MyClass<T> operator +(MyClass<T> a, T b) { a.UpdateBaseValue( a.GetValue() + b); return a;}
        public static MyClass<T> operator -(MyClass<T> a, T b) { a.UpdateBaseValue( a.GetValue() - b); return a;}
        public static MyClass<T> operator *(MyClass<T> a, T b) { a.UpdateBaseValue( a.GetValue() * b); return a;}
        public static MyClass<T> operator /(MyClass<T> a, T b) { a.UpdateBaseValue( a.GetValue() / b); return a;}
        public static MyClass<T> operator %(MyClass<T> a, T b) { a.UpdateBaseValue( a.GetValue() % b); return a;}
        public static MyClass<T> operator ++(MyClass<T> a) { a.UpdateBaseValue( a.GetValue() + T.One); return a;}
        public static MyClass<T> operator --(MyClass<T> a) { a.UpdateBaseValue( a.GetValue() - T.One); return a;}

        // Para conseguir operar entre atributos
        public static T operator +(MyClass<T> a, MyClass<T> b) => a.GetValue() + b.GetValue();
        public static T operator -(MyClass<T> a, MyClass<T> b) => a.GetValue() - b.GetValue();
        public static T operator *(MyClass<T> a, MyClass<T> b) => a.GetValue() * b.GetValue();
        public static T operator %(MyClass<T> a, MyClass<T> b) => a.GetValue() % b.GetValue();

        public static bool operator ==(MyClass<T> a, MyClass<T> b) => a.GetValue() == b.GetValue();
        public static bool operator !=(MyClass<T> a, MyClass<T> b) => a.GetValue() != b.GetValue();
        public static bool operator <(MyClass<T> a, MyClass<T> b) => a.GetValue() < b.GetValue();
        public static bool operator >(MyClass<T> a, MyClass<T> b) => a.GetValue() > b.GetValue();
        public static bool operator <=(MyClass<T> a, MyClass<T> b) => a.GetValue() <= b.GetValue();
        public static bool operator >=(MyClass<T> a, MyClass<T> b) => a.GetValue() >= b.GetValue();

#endregion
```