using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class Asociado : EntidadBase
    {
        public Asociado()
        {
            _CodigoVigencia    = string.Empty;
            _Curp              = string.Empty;
            _Nombre            = string.Empty;
            _ApellidoPaterno   = string.Empty;
            _ApellidoMaterno   = string.Empty;
            _Telefono          = string.Empty;
            _Telefono2         = string.Empty;
            _Poliza            = string.Empty;
            _Contratante       = string.Empty;
            _ClaveFamiliar     = string.Empty;
            _CorreoElectronico = string.Empty;
            _TelefonoMovil     = string.Empty;
        }


        Int32 _AsociadoId;
        public Int32 AsociadoId { get { return _AsociadoId; } set { _AsociadoId = value; } }


        Byte? _AsociadoTipoId;
        public Byte? AsociadoTipoId { get { return _AsociadoTipoId; } set { _AsociadoTipoId = value; } }


        String _CodigoVigencia;
        [StringLength(50)]
        public String CodigoVigencia { get { return _CodigoVigencia; } set { _CodigoVigencia = value; } }


        String _Curp;
        [StringLength(100)]
        public String Curp { get { return _Curp; } set { _Curp = value; } }


        String _Nombre;
        [StringLength(100)]
        public String Nombre { get { return _Nombre; } set { _Nombre = value; } }


        String _ApellidoPaterno;
        [StringLength(100)]
        public String ApellidoPaterno { get { return _ApellidoPaterno; } set { _ApellidoPaterno = value; } }


        String _ApellidoMaterno;
        [StringLength(100)]
        public String ApellidoMaterno { get { return _ApellidoMaterno; } set { _ApellidoMaterno = value; } }


        String _Telefono;
        [StringLength(30)]
        public String Telefono { get { return _Telefono; } set { _Telefono = value; } }


        String _Telefono2;
        [StringLength(30)]
        public String Telefono2 { get { return _Telefono2; } set { _Telefono2 = value; } }


        String _Poliza;
        [StringLength(100)]
        public String Poliza { get { return _Poliza; } set { _Poliza = value; } }


        Int32? _NoPoliza;
        public Int32? NoPoliza { get { return _NoPoliza; } set { _NoPoliza = value; } }


        Int32? _SexoId;
        public Int32? SexoId { get { return _SexoId; } set { _SexoId = value; } }


        Int32? _EstadoCivilId;
        public Int32? EstadoCivilId { get { return _EstadoCivilId; } set { _EstadoCivilId = value; } }


        DateTime? _FechaNacimiento;
        public DateTime? FechaNacimiento { get { return _FechaNacimiento; } set { _FechaNacimiento = value; } }


        Boolean? _Confidencial;
        public Boolean? Confidencial { get { return _Confidencial; } set { _Confidencial = value; } }


        Boolean? _RequiereEmpresa;
        public Boolean? RequiereEmpresa { get { return _RequiereEmpresa; } set { _RequiereEmpresa = value; } }


        Boolean? _ReqExpedienteFisico;
        public Boolean? ReqExpedienteFisico { get { return _ReqExpedienteFisico; } set { _ReqExpedienteFisico = value; } }


        Int32? _AsociadoClasificacionId;
        public Int32? AsociadoClasificacionId { get { return _AsociadoClasificacionId; } set { _AsociadoClasificacionId = value; } }


        String _Contratante;
        [StringLength(100)]
        public String Contratante { get { return _Contratante; } set { _Contratante = value; } }


        Int32 _InstitucionId;
        public Int32 InstitucionId { get { return _InstitucionId; } set { _InstitucionId = value; } }


        Int32? _NacionalidadId;
        public Int32? NacionalidadId { get { return _NacionalidadId; } set { _NacionalidadId = value; } }


        Int32? _TitularId;
        public Int32? TitularId { get { return _TitularId; } set { _TitularId = value; } }


        Boolean? _TitularPersona;
        public Boolean? TitularPersona { get { return _TitularPersona; } set { _TitularPersona = value; } }


        String _ClaveFamiliar;
        [StringLength(5)]
        public String ClaveFamiliar { get { return _ClaveFamiliar; } set { _ClaveFamiliar = value; } }


        Boolean? _ServicioSuspendido;
        public Boolean? ServicioSuspendido { get { return _ServicioSuspendido; } set { _ServicioSuspendido = value; } }


        String _CorreoElectronico;
        [StringLength(200)]
        public String CorreoElectronico { get { return _CorreoElectronico; } set { _CorreoElectronico = value; } }


        String _TelefonoMovil;
        [StringLength(30)]
        public String TelefonoMovil { get { return _TelefonoMovil; } set { _TelefonoMovil = value; } }


        Boolean? _CurpTemporal;
        public Boolean? CurpTemporal { get { return _CurpTemporal; } set { _CurpTemporal = value; } }
    }
}