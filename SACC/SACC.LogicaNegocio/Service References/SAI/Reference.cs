﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SACC.LogicaNegocio.SAI {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Autenticar", Namespace="http://schemas.datacontract.org/2004/07/WS_SAI")]
    [System.SerializableAttribute()]
    public partial class Autenticar : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AutenticacionCorrectaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Data.DataSet InformacionUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IntentosFallidosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MensajeErrorField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool AutenticacionCorrecta {
            get {
                return this.AutenticacionCorrectaField;
            }
            set {
                if ((this.AutenticacionCorrectaField.Equals(value) != true)) {
                    this.AutenticacionCorrectaField = value;
                    this.RaisePropertyChanged("AutenticacionCorrecta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Data.DataSet InformacionUsuario {
            get {
                return this.InformacionUsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.InformacionUsuarioField, value) != true)) {
                    this.InformacionUsuarioField = value;
                    this.RaisePropertyChanged("InformacionUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IntentosFallidos {
            get {
                return this.IntentosFallidosField;
            }
            set {
                if ((this.IntentosFallidosField.Equals(value) != true)) {
                    this.IntentosFallidosField = value;
                    this.RaisePropertyChanged("IntentosFallidos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MensajeError {
            get {
                return this.MensajeErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.MensajeErrorField, value) != true)) {
                    this.MensajeErrorField = value;
                    this.RaisePropertyChanged("MensajeError");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Token", Namespace="http://schemas.datacontract.org/2004/07/WS_SAI")]
    [System.SerializableAttribute()]
    public partial class Token : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContrasenaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioCuentaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contrasena {
            get {
                return this.ContrasenaField;
            }
            set {
                if ((object.ReferenceEquals(this.ContrasenaField, value) != true)) {
                    this.ContrasenaField = value;
                    this.RaisePropertyChanged("Contrasena");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuarioCuenta {
            get {
                return this.UsuarioCuentaField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioCuentaField, value) != true)) {
                    this.UsuarioCuentaField = value;
                    this.RaisePropertyChanged("UsuarioCuenta");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Mensaje", Namespace="http://schemas.datacontract.org/2004/07/WS_SAI")]
    [System.SerializableAttribute()]
    public partial class Mensaje : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AutenticacionCorrectaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IntentosFallidosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MensajeErrorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid TokenField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool AutenticacionCorrecta {
            get {
                return this.AutenticacionCorrectaField;
            }
            set {
                if ((this.AutenticacionCorrectaField.Equals(value) != true)) {
                    this.AutenticacionCorrectaField = value;
                    this.RaisePropertyChanged("AutenticacionCorrecta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IntentosFallidos {
            get {
                return this.IntentosFallidosField;
            }
            set {
                if ((this.IntentosFallidosField.Equals(value) != true)) {
                    this.IntentosFallidosField = value;
                    this.RaisePropertyChanged("IntentosFallidos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MensajeError {
            get {
                return this.MensajeErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.MensajeErrorField, value) != true)) {
                    this.MensajeErrorField = value;
                    this.RaisePropertyChanged("MensajeError");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Token {
            get {
                return this.TokenField;
            }
            set {
                if ((this.TokenField.Equals(value) != true)) {
                    this.TokenField = value;
                    this.RaisePropertyChanged("Token");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SAI.ISAI")]
    public interface ISAI {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/ObtenerFoto", ReplyAction="http://tempuri.org/ISAI/ObtenerFotoResponse")]
        byte[] ObtenerFoto(string Dominio, string CuentaRed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/ObtenerFoto", ReplyAction="http://tempuri.org/ISAI/ObtenerFotoResponse")]
        System.Threading.Tasks.Task<byte[]> ObtenerFotoAsync(string Dominio, string CuentaRed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/ObtenerConfiguracionSistema", ReplyAction="http://tempuri.org/ISAI/ObtenerConfiguracionSistemaResponse")]
        System.Data.DataSet ObtenerConfiguracionSistema(int SistemaId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/ObtenerConfiguracionSistema", ReplyAction="http://tempuri.org/ISAI/ObtenerConfiguracionSistemaResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> ObtenerConfiguracionSistemaAsync(int SistemaId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/BuscaUsuarioSAIPorId", ReplyAction="http://tempuri.org/ISAI/BuscaUsuarioSAIPorIdResponse")]
        System.Data.DataSet BuscaUsuarioSAIPorId(int UsuarioId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/BuscaUsuarioSAIPorId", ReplyAction="http://tempuri.org/ISAI/BuscaUsuarioSAIPorIdResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> BuscaUsuarioSAIPorIdAsync(int UsuarioId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/BuscaUsuarioSAIPorCuentaRed", ReplyAction="http://tempuri.org/ISAI/BuscaUsuarioSAIPorCuentaRedResponse")]
        System.Data.DataSet BuscaUsuarioSAIPorCuentaRed(string CuentaRed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/BuscaUsuarioSAIPorCuentaRed", ReplyAction="http://tempuri.org/ISAI/BuscaUsuarioSAIPorCuentaRedResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> BuscaUsuarioSAIPorCuentaRedAsync(string CuentaRed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/ObtenerUsuario", ReplyAction="http://tempuri.org/ISAI/ObtenerUsuarioResponse")]
        System.Data.DataSet ObtenerUsuario(string Dominio, string CuentaRed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/ObtenerUsuario", ReplyAction="http://tempuri.org/ISAI/ObtenerUsuarioResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> ObtenerUsuarioAsync(string Dominio, string CuentaRed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/AutenticarUsuario", ReplyAction="http://tempuri.org/ISAI/AutenticarUsuarioResponse")]
        SACC.LogicaNegocio.SAI.Autenticar AutenticarUsuario(string Dominio, string CuentaRed, string Contraseña, System.Nullable<int> Sistema);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/AutenticarUsuario", ReplyAction="http://tempuri.org/ISAI/AutenticarUsuarioResponse")]
        System.Threading.Tasks.Task<SACC.LogicaNegocio.SAI.Autenticar> AutenticarUsuarioAsync(string Dominio, string CuentaRed, string Contraseña, System.Nullable<int> Sistema);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/AutenticarExterno", ReplyAction="http://tempuri.org/ISAI/AutenticarExternoResponse")]
        SACC.LogicaNegocio.SAI.Mensaje AutenticarExterno(SACC.LogicaNegocio.SAI.Token token, int pServicioId, int pMetodoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/AutenticarExterno", ReplyAction="http://tempuri.org/ISAI/AutenticarExternoResponse")]
        System.Threading.Tasks.Task<SACC.LogicaNegocio.SAI.Mensaje> AutenticarExternoAsync(SACC.LogicaNegocio.SAI.Token token, int pServicioId, int pMetodoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/AgregarUsuario", ReplyAction="http://tempuri.org/ISAI/AgregarUsuarioResponse")]
        int AgregarUsuario(string Dominio, string CuentaRed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/AgregarUsuario", ReplyAction="http://tempuri.org/ISAI/AgregarUsuarioResponse")]
        System.Threading.Tasks.Task<int> AgregarUsuarioAsync(string Dominio, string CuentaRed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/AgregarUsuarioSistema", ReplyAction="http://tempuri.org/ISAI/AgregarUsuarioSistemaResponse")]
        bool AgregarUsuarioSistema(int UsuarioId, int SistemaId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/AgregarUsuarioSistema", ReplyAction="http://tempuri.org/ISAI/AgregarUsuarioSistemaResponse")]
        System.Threading.Tasks.Task<bool> AgregarUsuarioSistemaAsync(int UsuarioId, int SistemaId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/ObtenerPermisos", ReplyAction="http://tempuri.org/ISAI/ObtenerPermisosResponse")]
        System.Data.DataSet ObtenerPermisos(int SistemaId, string CuentaRed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAI/ObtenerPermisos", ReplyAction="http://tempuri.org/ISAI/ObtenerPermisosResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> ObtenerPermisosAsync(int SistemaId, string CuentaRed);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISAIChannel : SACC.LogicaNegocio.SAI.ISAI, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SAIClient : System.ServiceModel.ClientBase<SACC.LogicaNegocio.SAI.ISAI>, SACC.LogicaNegocio.SAI.ISAI {
        
        public SAIClient() {
        }
        
        public SAIClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SAIClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SAIClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SAIClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public byte[] ObtenerFoto(string Dominio, string CuentaRed) {
            return base.Channel.ObtenerFoto(Dominio, CuentaRed);
        }
        
        public System.Threading.Tasks.Task<byte[]> ObtenerFotoAsync(string Dominio, string CuentaRed) {
            return base.Channel.ObtenerFotoAsync(Dominio, CuentaRed);
        }
        
        public System.Data.DataSet ObtenerConfiguracionSistema(int SistemaId) {
            return base.Channel.ObtenerConfiguracionSistema(SistemaId);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ObtenerConfiguracionSistemaAsync(int SistemaId) {
            return base.Channel.ObtenerConfiguracionSistemaAsync(SistemaId);
        }
        
        public System.Data.DataSet BuscaUsuarioSAIPorId(int UsuarioId) {
            return base.Channel.BuscaUsuarioSAIPorId(UsuarioId);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> BuscaUsuarioSAIPorIdAsync(int UsuarioId) {
            return base.Channel.BuscaUsuarioSAIPorIdAsync(UsuarioId);
        }
        
        public System.Data.DataSet BuscaUsuarioSAIPorCuentaRed(string CuentaRed) {
            return base.Channel.BuscaUsuarioSAIPorCuentaRed(CuentaRed);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> BuscaUsuarioSAIPorCuentaRedAsync(string CuentaRed) {
            return base.Channel.BuscaUsuarioSAIPorCuentaRedAsync(CuentaRed);
        }
        
        public System.Data.DataSet ObtenerUsuario(string Dominio, string CuentaRed) {
            return base.Channel.ObtenerUsuario(Dominio, CuentaRed);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ObtenerUsuarioAsync(string Dominio, string CuentaRed) {
            return base.Channel.ObtenerUsuarioAsync(Dominio, CuentaRed);
        }
        
        public SACC.LogicaNegocio.SAI.Autenticar AutenticarUsuario(string Dominio, string CuentaRed, string Contraseña, System.Nullable<int> Sistema) {
            return base.Channel.AutenticarUsuario(Dominio, CuentaRed, Contraseña, Sistema);
        }
        
        public System.Threading.Tasks.Task<SACC.LogicaNegocio.SAI.Autenticar> AutenticarUsuarioAsync(string Dominio, string CuentaRed, string Contraseña, System.Nullable<int> Sistema) {
            return base.Channel.AutenticarUsuarioAsync(Dominio, CuentaRed, Contraseña, Sistema);
        }
        
        public SACC.LogicaNegocio.SAI.Mensaje AutenticarExterno(SACC.LogicaNegocio.SAI.Token token, int pServicioId, int pMetodoId) {
            return base.Channel.AutenticarExterno(token, pServicioId, pMetodoId);
        }
        
        public System.Threading.Tasks.Task<SACC.LogicaNegocio.SAI.Mensaje> AutenticarExternoAsync(SACC.LogicaNegocio.SAI.Token token, int pServicioId, int pMetodoId) {
            return base.Channel.AutenticarExternoAsync(token, pServicioId, pMetodoId);
        }
        
        public int AgregarUsuario(string Dominio, string CuentaRed) {
            return base.Channel.AgregarUsuario(Dominio, CuentaRed);
        }
        
        public System.Threading.Tasks.Task<int> AgregarUsuarioAsync(string Dominio, string CuentaRed) {
            return base.Channel.AgregarUsuarioAsync(Dominio, CuentaRed);
        }
        
        public bool AgregarUsuarioSistema(int UsuarioId, int SistemaId) {
            return base.Channel.AgregarUsuarioSistema(UsuarioId, SistemaId);
        }
        
        public System.Threading.Tasks.Task<bool> AgregarUsuarioSistemaAsync(int UsuarioId, int SistemaId) {
            return base.Channel.AgregarUsuarioSistemaAsync(UsuarioId, SistemaId);
        }
        
        public System.Data.DataSet ObtenerPermisos(int SistemaId, string CuentaRed) {
            return base.Channel.ObtenerPermisos(SistemaId, CuentaRed);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ObtenerPermisosAsync(int SistemaId, string CuentaRed) {
            return base.Channel.ObtenerPermisosAsync(SistemaId, CuentaRed);
        }
    }
}
