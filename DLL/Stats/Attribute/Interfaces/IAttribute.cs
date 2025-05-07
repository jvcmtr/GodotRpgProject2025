using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using DLL.enums;

namespace DLL.Stats	
{

    public interface IAttribute<T> where T : INumber<T>
    {
        T BaseValue { get; }
        T Value {get; }

        public IAttribute<T> AddModifier(string source, double value, EModifier modType = EModifier.ADITIVE);
        public IAttribute<T> RemoveModifier(string source);
        public List<IModifier> GetModifiers();
    }
}
