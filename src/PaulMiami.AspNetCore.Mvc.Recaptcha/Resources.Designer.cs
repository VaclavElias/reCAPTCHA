﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaulMiami.AspNetCore.Mvc.Recaptcha {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal Resources() {
        }
        
        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PaulMiami.AspNetCore.Mvc.Recaptcha.Resources", typeof(Resources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
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
        ///    Looks up a localized string similar to Validate that you are not a robot..
        /// </summary>
        public static string Default_ValidationMessage {
            get {
                return ResourceManager.GetString("Default_ValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The &apos;{0}&apos; option must be provided..
        /// </summary>
        public static string Exception_OptionMustBeProvided {
            get {
                return ResourceManager.GetString("Exception_OptionMustBeProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Recaptcha validation failed. {Message}.
        /// </summary>
        public static string Log_ValidationException {
            get {
                return ResourceManager.GetString("Log_ValidationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The response parameter is invalid or malformed..
        /// </summary>
        public static string ValidateError_InvalidInputResponse {
            get {
                return ResourceManager.GetString("ValidateError_InvalidInputResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The secret parameter is invalid or malformed..
        /// </summary>
        public static string ValidateError_InvalidInputSecret {
            get {
                return ResourceManager.GetString("ValidateError_InvalidInputSecret", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The response parameter is missing..
        /// </summary>
        public static string ValidateError_MissingInputResponse {
            get {
                return ResourceManager.GetString("ValidateError_MissingInputResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The secret parameter is missing..
        /// </summary>
        public static string ValidateError_MissingInputSecret {
            get {
                return ResourceManager.GetString("ValidateError_MissingInputSecret", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Unknown error &apos;{0}&apos;..
        /// </summary>
        public static string ValidateError_Unknown {
            get {
                return ResourceManager.GetString("ValidateError_Unknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Unspecified remote server error..
        /// </summary>
        public static string ValidateError_UnspecifiedRemoteServerError {
            get {
                return ResourceManager.GetString("ValidateError_UnspecifiedRemoteServerError", resourceCulture);
            }
        }
    }
}
