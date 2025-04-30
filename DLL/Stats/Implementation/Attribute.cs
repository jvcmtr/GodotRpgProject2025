using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DLL.Stats	
{


    public class Attribute
    {
    public int CurrentValue {get; protected set;}
    public int BaseValue {get; protected set;}
    protected ModifierGroup Modifiers = new ModifierGroup();

    public Attribute(int value){
        CurrentValue = value;
        BaseValue = value;
    }

    public Attribute UpdateBaseValue(int value){
        BaseValue = value;
        UpdateCurrent();
        return this;
    }

    virtual protected void UpdateCurrent(){
        CurrentValue = (int) Modifiers.CalcModifiers(this);
    }




    // MODIFIERS ___________________________________________________________________________________________________________________________
    #region Modifiers

    /// <summary>
    /// <b>Alternativamente</b> é possivel operar a lista de modificadores da seguinte forma:
    /// <list type="bullet">
    /// <item> <c> att += ("nm", 5)</c> -> Adiciona um modificador +5 que acresce o status em 5  </item>
    /// <item> <c> att *= ("nm", 5) </c> -> Adiciona um modificador +5 que acresce o status em 5 x o valor base deste atributo  </item>
    /// <item> <c> att -= "nm" </c>  -> Remove o atributo com determinado nome da lista de modificadores </item>
    /// </list>
    /// <b>Considerações:</b>
    /// <br/>
    /// <i> - O Parametro source não considera capitalização. </i> 
    /// <br/>
    /// <i> - Caso o atributo já possua um modificador com o mesmo source, o antigo será substituido.</i> 
    /// </summary>
    /// <param name="source">Identificador. Não considera capitalização. Um atributo não pode possuir dois modificadores com o mesmo nome</param>
    /// <param name="value">valor</param>
    /// <param name="type"> Enum usado para definir como o valor será aplicado interpretar o valor</param>
    /// <returns></returns>
    public Attribute AddModifier(string source, float value, EAttributeMod modType = EAttributeMod.ABSOLUTE)
    {
        Modifiers.Add(source, value, modType);
        UpdateCurrent();

        return this;
    }

    /// <summary>
    /// <c> att -= "source" </c> <b>Esta notação é o mesmo que chamar este metodo </b> 
    /// <br/>
    /// <i> source não considera capitalização. </i> 
    /// </summary>
    /// <returns></returns>
    public Attribute RemoveModifier(string source){
        Modifiers.Remove(source);
        UpdateCurrent();
        return this;
    }

    #endregion



    // OVERIDES ____________________________________________________________________________________
    #region Overides

    // Permite atributo + 5 == 10?
    public static implicit operator int(Attribute a)
    {
        return a.CurrentValue;
    }

    // Permite atributo = 5
    public static implicit operator Attribute(int value)
    {
        return new Attribute(value);
    }

    // Adiciona modificadores automaticamente
    public static Attribute operator +(Attribute a, (string, int) b) => a.AddModifier(b.Item1, b.Item2);
    public static Attribute operator +(Attribute a, (string, float) b) => a.AddModifier(b.Item1, b.Item2);
    public static Attribute operator *(Attribute a, (string, int) b) => a.AddModifier(b.Item1, b.Item2, EAttributeMod.MULTIPLICATIVE);
    public static Attribute operator *(Attribute a, (string, float) b) => a.AddModifier(b.Item1, b.Item2, EAttributeMod.MULTIPLICATIVE);
    public static int operator -(Attribute a, string b) => a.RemoveModifier(b);



    // Para impedir a divisão de inteiros (garantir a existencia de ponto flutuante na divisão)
    public static double operator /(Attribute a, int b) => a.CurrentValue / (double)b;
    public static double operator /(int a, Attribute b) => a / (double)b.CurrentValue;

    // Para conseguir operar entre atributos
    public static int operator +(Attribute a, Attribute b) => a.CurrentValue + b.CurrentValue;
    public static int operator -(Attribute a, Attribute b) => a.CurrentValue - b.CurrentValue;
    public static int operator *(Attribute a, Attribute b) => a.CurrentValue * b.CurrentValue;
    public static double operator /(Attribute a, Attribute b) => a.CurrentValue / (double) b.CurrentValue;
    public static int operator %(Attribute a, Attribute b) => a.CurrentValue % b.CurrentValue;

    public static bool operator ==(Attribute a, Attribute b) => a.CurrentValue == b.CurrentValue;
    public static bool operator !=(Attribute a, Attribute b) => a.CurrentValue != b.CurrentValue;
    public static bool operator <(Attribute a, Attribute b) => a.CurrentValue < b.CurrentValue;
    public static bool operator >(Attribute a, Attribute b) => a.CurrentValue > b.CurrentValue;
    public static bool operator <=(Attribute a, Attribute b) => a.CurrentValue <= b.CurrentValue;
    public static bool operator >=(Attribute a, Attribute b) => a.CurrentValue >= b.CurrentValue;

    #endregion
}
}