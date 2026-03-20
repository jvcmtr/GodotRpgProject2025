using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using DLL.enums;
using DLL.Stats;

namespace DLL.Stats ;

//Trying to implement dynamic dispatch using generic argument polimorphism
// public class Attribute<T> : IAttribute<T> where T : INumber<T> {
// 	IAttribute<T> _implementation;

// 	public Attribute<T>(T value)
// 	{
		
// 	}

// 	public T BaseValue => _implementation.BaseValue;
// 	public T Value => _implementation.Value;
// 	public IAttribute<T> AddModifier(string source, double value, EModifier modType = EModifier.ADITIVE)=> _implementation.AddModifier(source, value, modType);
// 	public List<IModifier> GetModifiers() => _implementation.GetModifiers();
// 	public IAttribute<T> RemoveModifier(string source) => _implementation.RemoveModifier(source);

// }


// 	public static class AttributeGetter<T> where T : INumber<T> {
// 		public static Func<IAttribute<T>> CreateImpl { get; set; } = () => throw new NotSupportedException($"No implementation for type {typeof(T)}");
// 		public static IAttribute<T> Create() => CreateImpl();
// 	}

// 	public static class AttrGetterInt{
// 		static AttrGetterInt(){
// 			AttributeGetter<int>.CreateImpl = () => new IntAttribute(0);
// 		}
// 	}

// 	public static class AttrGetterDouble{
// 		static AttrGetterDouble(){
// 			AttributeGetter<double>.CreateImpl = () => new FAttribute(1);
// 		}
// 	}
