using System;


namespace SACC.Entidades.NovaComercial.WebService
{
    public class AsociadoLog : EntidadBase
    {
        public AsociadoLog()
        {
            _Nombre               = String.Empty;
            _Paterno              = String.Empty;
            _Materno              = String.Empty;
            _Curp                 = String.Empty;
            _TipoUsuario          = String.Empty;
            _ClaveTipoSanguineo   = String.Empty;
            _ClaveEstadoCivil     = String.Empty;
            _Sexo                 = String.Empty;
            _ClaveMovimiento      = String.Empty;
            _ClaveEmpresaContrato = String.Empty;
            _ClavePlantaContrato  = String.Empty;
            _RFCSocio             = String.Empty;
            _Calle                = String.Empty;
            _NumeroExterior       = String.Empty;
            _CodigoPostal         = String.Empty;
            _Colonia              = String.Empty;
            _Pais                 = String.Empty;
            _Estado               = String.Empty;
            _Ciudad               = String.Empty;
            _TelefonoCasa         = 0;
            _TelefonoOficina      = 0;
            _Extension            = 0;
            _Fax                  = 0;
            _CorreoElectronico    = String.Empty;
            _NumeroAfiliacionIMSS = 0;
            _ApellidoCasadaEsposa = String.Empty;
            _AseguradoraSocioId   = String.Empty;
            _TipoTrabajador       = String.Empty;
        }


        Int32 _AsociadoId;
        public Int32 AsociadoId { get { return _AsociadoId; } set { if (value >= 0) _AsociadoId = value; } }

        String _AsociadoDescripcion;
        public String AsociadoDescripcion { get { return _AsociadoDescripcion; } set { if (value.Length >= 100) _Paterno = value.Substring(0, 100); else _AsociadoDescripcion = value; } }

        Int32 _NumeroSocio;
        public Int32 NumeroSocio { get { return _NumeroSocio; } set { if (value >= 0) _NumeroSocio = value; } }

        Int32 _ClaveFamiliar;
        public Int32 ClaveFamiliar { get { return _ClaveFamiliar; } set { if (value >= 0) _ClaveFamiliar = value; } }

        String _Nombre;
        public String Nombre { get { return _Nombre; } set { if (value.Length >= 50) _Nombre = value.Substring(0, 50); else _Nombre = value; } }

        String _Paterno;
        public String Paterno { get { return _Paterno; } set { if (value.Length >= 50) _Paterno = value.Substring(0, 50); else _Paterno = value; } }

        String _Materno;
        public String Materno { get { return _Materno; } set { if (value.Length >= 50) _Materno = value.Substring(0, 50); else _Materno = value; } }

        String _Curp;
        public String Curp { get { return _Curp; } set { if (value.Length >= 20) _Curp = value.Substring(0, 20); else _Curp = value; } }

        String _TipoUsuario;
        public String TipoUsuario { get { return _TipoUsuario; } set { if (value.Length >= 2) _TipoUsuario = value.Substring(0, 2); else _TipoUsuario = value; } }

        String _ClaveTipoSanguineo;
        public String ClaveTipoSanguineo { get { return _ClaveTipoSanguineo; } set { if (value.Length >= 3) _ClaveTipoSanguineo = value.Substring(0, 3); else _ClaveTipoSanguineo = value; } }

        String _ClaveEstadoCivil;
        public String ClaveEstadoCivil { get { return _ClaveEstadoCivil; } set { if (value.Length >= 1) _ClaveEstadoCivil = value.Substring(0, 1); else _ClaveEstadoCivil = value; } }

        String _Sexo;
        public String Sexo { get { return _Sexo; } set { if (value.Length >= 1) _Sexo = value.Substring(0, 1); else _Sexo = value; } }

        DateTime? _FechaNacimiento;
        public DateTime? FechaNacimiento { get { return _FechaNacimiento; } set { _FechaNacimiento = value; } }

        DateTime? _FechaFallecimiento;
        public DateTime? FechaFallecimiento { get { return _FechaFallecimiento; } set { _FechaFallecimiento = value; } }

        DateTime? _FechaAltaContrato;
        public DateTime? FechaAltaContrato { get { return _FechaAltaContrato; } set { _FechaAltaContrato = value; } }

        DateTime? _FechaBajaContrato;
        public DateTime? FechaBajaContrato { get { return _FechaBajaContrato; } set { _FechaBajaContrato = value; } }

        DateTime? _FechaReactivacionContrato;
        public DateTime? FechaReactivacionContrato { get { return _FechaReactivacionContrato; } set { _FechaReactivacionContrato = value; } }

        DateTime? _FechaMovimiento;
        public DateTime? FechaMovimiento { get { return _FechaMovimiento; } set { _FechaMovimiento = value; } }

        String _ClaveMovimiento;
        public String ClaveMovimiento { get { return _ClaveMovimiento; } set { if (value.Length >= 2) _ClaveMovimiento = value.Substring(0, 2); else _ClaveMovimiento = value; } }

        String _ClaveEmpresaContrato;
        public String ClaveEmpresaContrato { get { return _ClaveEmpresaContrato; } set { if (value.Length >= 3) _ClaveEmpresaContrato = value.Substring(0, 3); else _ClaveEmpresaContrato = value; } }

        String _ClavePlantaContrato;
        public String ClavePlantaContrato { get { return _ClavePlantaContrato; } set { if (value.Length >= 3) _ClavePlantaContrato = value.Substring(0, 3); else _ClavePlantaContrato = value; } }

        String _RFCSocio;
        public String RFCSocio { get { return _RFCSocio; } set { if (value.Length >= 18) _RFCSocio = value.Substring(0, 18); else _RFCSocio = value; } }

        String _Calle;
        public String Calle { get { return _Calle; } set { if (value.Length >= 250) _Calle = value.Substring(0, 250); else _Calle = value; } }

        String _NumeroExterior;
        public String NumeroExterior { get { return _NumeroExterior; } set { if (value.Length >= 8) _NumeroExterior = value.Substring(0, 8); else _NumeroExterior = value; } }

        String _CodigoPostal;
        public String CodigoPostal { get { return _CodigoPostal; } set { if (value.Length >= 10) _CodigoPostal = value.Substring(0, 10); else _CodigoPostal = value; } }

        Int32 _ClaveColonia;
        public Int32 ClaveColonia { get { return _ClaveColonia; } set { if (value >= 0) _ClaveColonia = value; } }

        String _Colonia;
        public String Colonia { get { return _Colonia; } set { if (value.Length >= 250) _Colonia = value.Substring(0, 250); else _Colonia = value; } }

        Int32 _ClavePais;
        public Int32 ClavePais { get { return _ClavePais; } set { if (value >= 0) _ClavePais = value; } }

        String _Pais;
        public String Pais { get { return _Pais; } set { if (value.Length >= 250) _Pais = value.Substring(0, 250); else _Pais = value; } }

        Int32 _ClaveEstado;
        public Int32 ClaveEstado { get { return _ClaveEstado; } set { if (value >= 0) _ClaveEstado = value; } }

        String _Estado;
        public String Estado { get { return _Estado; } set { if (value.Length >= 250) _Estado = value.Substring(0, 250); else _Estado = value; } }

        Int32 _ClaveCiudad;
        public Int32 ClaveCiudad { get { return _ClaveCiudad; } set { if (value >= 0) _ClaveCiudad = value; } }

        String _Ciudad;
        public String Ciudad { get { return _Ciudad; } set { if (value.Length >= 250) _Ciudad = value.Substring(0, 250); else _Ciudad = value; } }

        Int32 _TelefonoCasa;
        public Int32 TelefonoCasa { get { return _TelefonoCasa; } set { _TelefonoCasa = value; } }

        Int32 _TelefonoOficina;
        public Int32 TelefonoOficina { get { return _TelefonoOficina; } set { _TelefonoOficina = value; } }

        Int32 _Extension;
        public Int32 Extension { get { return _Extension; } set { _Extension = value; } }

        Int32 _Fax;
        public Int32 Fax { get { return _Fax; } set { _Fax = value; } }

        String _CorreoElectronico;
        public String CorreoElectronico { get { return _CorreoElectronico; } set { if (value.Length >= 100) _CorreoElectronico = value.Substring(0, 100); else _CorreoElectronico = value; } }

        Int32 _NumeroAfiliacionIMSS;
        public Int32 NumeroAfiliacionIMSS { get { return _NumeroAfiliacionIMSS; } set { _NumeroAfiliacionIMSS = value; } }

        String _ApellidoCasadaEsposa;
        public String ApellidoCasadaEsposa { get { return _ApellidoCasadaEsposa; } set { if (value.Length >= 50) _ApellidoCasadaEsposa = value.Substring(0, 50); else _ApellidoCasadaEsposa = value; } }

        String _AseguradoraSocioId;
        public String AseguradoraSocioId { get { return _AseguradoraSocioId; } set { if (value.Length >= 14) _AseguradoraSocioId = value.Substring(0, 14); else _AseguradoraSocioId = value; } }

        Int32? _NumeroSocioAnterior;
        public Int32? NumeroSocioAnterior { get { return _NumeroSocioAnterior; } set { if (value >= 0) _NumeroSocioAnterior = value; } }

        Int32? _ClaveFamiliarAnterior;
        public Int32? ClaveFamiliarAnterior { get { return _ClaveFamiliarAnterior; } set { if (value >= 0) _ClaveFamiliarAnterior = value; } }

        Int32? _NumeroPoliza;
        public Int32? NumeroPoliza { get { return _NumeroPoliza; } set { if (value >= 0) _NumeroPoliza = value; } }

        Int32? _NumeroEndoso;
        public Int32? NumeroEndoso { get { return _NumeroEndoso; } set { if (value >= 0) _NumeroEndoso = value; } }

        Boolean? _ActualizarDatosPersonales;
        public Boolean? ActualizarDatosPersonales { get { return _ActualizarDatosPersonales; } set { _ActualizarDatosPersonales = value; } }

        String _TipoTrabajador;
        public String TipoTrabajador { get { return _TipoTrabajador; } set { if (value.Length >= 1) _TipoTrabajador = value.Substring(0, 1); else _TipoTrabajador = value; } }

        DateTime? _FechaIngresoPlanta;
        public DateTime? FechaIngresoPlanta { get { return _FechaIngresoPlanta; } set { _FechaIngresoPlanta = value; } }

        DateTime? _FechaIngresoGrupo;
        public DateTime? FechaIngresoGrupo { get { return _FechaIngresoGrupo; } set { _FechaIngresoGrupo = value; } }

        //Byte _EstatusId;
        //public Byte EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }

        Guid _Token;
        public Guid Token { get { return _Token; } set { _Token = value; } }
    }
}