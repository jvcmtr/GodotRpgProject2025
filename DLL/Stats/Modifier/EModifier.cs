using System;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace DLL.enums {
    /// <summary>
    /// This enum represents a basic set of behaviours from a Modifier
    /// </summary>
    public enum EModifier {
        /// <summary>
        /// Adds an ammount to the base value after applying any other modifiers
        /// <br/>The same as: 
        /// <br/>. . isMultiplicative = false
        /// <br/>. . isCompound = false
        /// </summary>
        ABSOLUTE,

        /// <summary>
        /// Adds an ammount to the base value before after all other modifiers have been apply.
        /// This means that any multiplicative modifiers will also apply to this modifier.
        /// <br/>The same as: 
        /// <br/>. . isMultiplicative = false
        /// <br/>. . isCompound = true
        /// </summary>
        ADITIVE,


        /// <summary>
        /// Multipply the base value (and other FLAT mods) by the given ammount
        /// <br/>The same as: 
        /// <br/>. . isMultiplicative = true
        /// <br/>. . isCompound = false
        /// </summary>
        MULTIPLICATIVE,
        
        /// <summary>
        /// Multipply the base value (and any other mod) by the given ammount
        /// <br/>The same as: 
        /// <br/>. . isMultiplicative = true
        /// <br/>. . isCompound = true
        /// </summary>
        MULTIPLICATIVE_COMPOUND,
    }

    public static partial class EnumMapper
    {
        static EnumMapper()
        {
            RegisterMap(new BiDirectionalMap<EModifier, (bool isMultiplicative, bool isCompound)>()
                .Add(EModifier.ABSOLUTE, (false, false))
                .Add( EModifier.ADITIVE,(false, true) ) 
                .Add(EModifier.MULTIPLICATIVE, (true, false) )
                .Add(EModifier.MULTIPLICATIVE_COMPOUND,(true, true) )   
            );
        }
    }

    // public static partial class EnumMapper{
    //     public static (bool isMultiplicative, bool isCompound) MapFrom( EModifier type){
    //         return type switch{
    //             EModifier.ABSOLUTE => (false, false),
    //             EModifier.ADITIVE => (false, true),
    //             EModifier.MULTIPLICATIVE => (true, false),
    //             EModifier.MULTIPLICATIVE_COMPOUND => (true, true),
    //             _ => (false, false)
    //         };
    //     }
        
    //     public static EModifier Parse( (bool isMultiplicative, bool isCompound) type, out EModifier EOut){
    //         EOut = type switch{
    //             (false, false) => EModifier.ABSOLUTE,
    //             (false, true) => EModifier.ADITIVE,
    //             (true, false) => EModifier.MULTIPLICATIVE,
    //             (true, true) => EModifier.MULTIPLICATIVE_COMPOUND,
    //             _ => EModifier.ABSOLUTE
    //         };
    //         return EOut;
    //     }

    // }
}