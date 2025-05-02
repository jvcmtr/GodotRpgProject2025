using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DLL.Stats	
{

    public interface IAttribute<T> where T : INumber<T>
    {
        T CurrentValue { get; }
        T BaseValue { get; }

        public IAttribute<T> AddModifier(string source, float value, EAttributeMod modType = EAttributeMod.ABSOLUTE);
        public IAttribute<T> RemoveModifier(string source);
        public IAttribute<T> UpdateBaseValue(T value);
        public List<(string, float, EAttributeMod)> GetModifiers();
        public T GetValue();
    }
}
