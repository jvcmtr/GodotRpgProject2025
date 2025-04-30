
using System;
using System.Collections.Generic;

namespace DLL.Attribute	
{

public class AttrModifier
{
    public string Source;
    public float Value;
    public EAttributeMod type;

    public AttrModifier( string source, float value, EAttributeMod type){
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
    public static bool operator ==(AttrModifier a, AttrModifier b) => a.Source == b.Source;
    public static bool operator !=(AttrModifier a, AttrModifier b) => a.Source != b.Source;
}
}
