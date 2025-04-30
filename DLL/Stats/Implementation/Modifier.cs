
namespace DLL.Stats	
{

public class Modifier
{
    public string Source;
    public float Value;
    public EAttributeMod type;

    public Modifier( string source, float value, EAttributeMod type){
        Source = source.ToLower();
        Value = value;
        this.type = type;
    }

    public float GetBonus(Attribute attr){
        switch (type){
            case EAttributeMod.MULTIPLICATIVE:
                return attr.BaseValue * (1 - Value) ;
            case EAttributeMod.CUMULATIVE:
                return attr.CurrentValue * (1 - Value) ;
            case EAttributeMod.ABSOLUTE:
            default:
                return Value;
        }
    }

    // Overides de comparação
    public static bool operator ==(Modifier a, Modifier b) => a.Source == b.Source;
    public static bool operator !=(Modifier a, Modifier b) => a.Source != b.Source;
}
}
