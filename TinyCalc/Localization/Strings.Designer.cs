﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TinyCalc.Localization {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TinyCalc.Localization.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TinyCalc.
        /// </summary>
        public static string AppName {
            get {
                return ResourceManager.GetString("AppName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Equation.
        /// </summary>
        public static string Equation {
            get {
                return ResourceManager.GetString("Equation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Infinite loop occurred.
        /// </summary>
        public static string InfiniteLoop {
            get {
                return ResourceManager.GetString("InfiniteLoop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing function brackets.
        /// </summary>
        public static string MissingFunctionBracket {
            get {
                return ResourceManager.GetString("MissingFunctionBracket", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing (.
        /// </summary>
        public static string MissingLeftBracket {
            get {
                return ResourceManager.GetString("MissingLeftBracket", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing ).
        /// </summary>
        public static string MissingRightBracket {
            get {
                return ResourceManager.GetString("MissingRightBracket", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Syntax error.
        /// </summary>
        public static string SyntaxError {
            get {
                return ResourceManager.GetString("SyntaxError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown.
        /// </summary>
        public static string Unknown {
            get {
                return ResourceManager.GetString("Unknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown token.
        /// </summary>
        public static string UnknownToken {
            get {
                return ResourceManager.GetString("UnknownToken", resourceCulture);
            }
        }
    }
}
