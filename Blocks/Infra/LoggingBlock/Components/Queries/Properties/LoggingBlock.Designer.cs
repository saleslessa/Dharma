﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dharma.LoggingBlock.Components.Queries.Properties {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LoggingBlockQuery {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LoggingBlockQuery() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Dharma.LoggingBlock.Components.Queries.Properties", typeof(LoggingBlockQuery).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string Server {
            get {
                return ResourceManager.GetString("Server", resourceCulture);
            }
        }
        
        internal static string Port {
            get {
                return ResourceManager.GetString("Port", resourceCulture);
            }
        }
        
        internal static string Database {
            get {
                return ResourceManager.GetString("Database", resourceCulture);
            }
        }
        
        internal static string User {
            get {
                return ResourceManager.GetString("User", resourceCulture);
            }
        }
        
        internal static string Pwd {
            get {
                return ResourceManager.GetString("Pwd", resourceCulture);
            }
        }
    }
}
