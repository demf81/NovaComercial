using System;
using System.ComponentModel.DataAnnotations;

namespace SACC.Entidades.Nova_ServiciosMedicos.dbo
{
    public class TranDatosAfiliado
    {
        public TranDatosAfiliado()
        {
            _dtFecIni             = DateTime.Now;
            _dtFecFin             = DateTime.Now;
            _dtFechaActualizacion = DateTime.Now;
            _dtFechaCreacion      = DateTime.Now;
            _dtFecNaci            = DateTime.Now;
        }


        String _vchIdAfiliado;
        [StringLength(14)]
        public String vchIdAfiliado { get { return _vchIdAfiliado; } set { _vchIdAfiliado = value; } }


        String _vchIdentidad;
        [StringLength(20)]
        public String vchIdentidad { get { return _vchIdentidad; } set { _vchIdentidad = value; } }


        String _vchNombre;
        [StringLength(25)]
        public String vchNombre { get { return _vchNombre; } set { _vchNombre = value; } }


        String _vchPaterno;
        [StringLength(25)]
        public String vchPaterno { get { return _vchPaterno; } set { _vchPaterno = value; } }


        String _vchMaterno;
        [StringLength(25)]
        public string vchMaterno { get { return _vchMaterno; } set { _vchMaterno = value; } }


        Int16 _tiEstatus;
        public Int16 tiEstatus { get { return _tiEstatus; } set { _tiEstatus = value; } }


        String _vchContratante;
        [StringLength(40)]
        public String vchContratante { get { return _vchContratante; } set { _vchContratante = value; } }


        Int32 _iNumPoliza;
        public Int32 iNumPoliza { get { return _iNumPoliza; } set { _iNumPoliza = value; } }


        Int32 _iNumCerti;
        public Int32 iNumCerti { get { return _iNumCerti; } set { _iNumCerti = value; } }


        DateTime _dtFecIni;
        public DateTime dtFecIni { get { return _dtFecIni; } set { _dtFecIni = value; } }


        DateTime _dtFecFin;
        public DateTime dtFecFin { get { return _dtFecFin; } set { _dtFecFin = value; } }


        String _vchDomicilio;
        [StringLength(70)]
        public String vchDomicilio { get { return _vchDomicilio; } set { _vchDomicilio = value; } }


        String _vchColonia;
        [StringLength(25)]
        public String vchColonia { get { return _vchColonia; } set { _vchColonia = value; } }


        String _vchCiudad;
        [StringLength(30)]
        public String vchCiudad { get { return _vchCiudad; } set { _vchCiudad = value; } }


        String _vchEstado;
        [StringLength(30)]
        public String vchEstado { get { return _vchEstado; } set { _vchEstado = value; } }


        DateTime _dtFecNaci;
        public DateTime dtFecNaci { get { return _dtFecNaci; } set { _dtFecNaci = value; } }


        Int16 _siSexo;
        public Int16 siSexo { get { return _siSexo; } set { _siSexo = value; } }


        String _chCodContrato;
        [StringLength(10)]
        public String chCodContrato { get { return _chCodContrato; } set { _chCodContrato = value; } }


        String _chCodEmpresa;
        [StringLength(10)]
        public String chCodEmpresa { get { return _chCodEmpresa; } set { _chCodEmpresa = value; } }


        String _vchDirEmp;
        [StringLength(35)]
        public String vchDirEmp { get { return _vchDirEmp; } set { _vchDirEmp = value; } }


        String _vchColEmp;
        [StringLength(25)]
        public String vchColEmp { get { return _vchColEmp; } set { _vchColEmp = value; } }


        String _vchCPEmp;
        [StringLength(6)]
        public String vchCPEmp { get { return _vchCPEmp; } set { _vchCPEmp = value; } }


        String _vchTelfEmp;
        [StringLength(12)]
        public String vchTelfEmp { get { return _vchTelfEmp; } set { _vchTelfEmp = value; } }


        Int16 _siTipoSangre;
        public Int16 siTipoSangre { get { return _siTipoSangre; } set { _siTipoSangre = value; } }


        Int16 _siEstadoCivil;
        public Int16 siEstadoCivil { get { return _siEstadoCivil; } set { _siEstadoCivil = value; } }


        String _vchCPAfiliado;
        [StringLength(6)]
        public String vchCPAfiliado { get { return _vchCPAfiliado; } set { _vchCPAfiliado = value; } }


        String _vchtelfAfiliado;
        [StringLength(6)]
        public String vchtelfAfiliado { get { return _vchtelfAfiliado; } set { _vchtelfAfiliado = value; } }


        String _vchCiudadEmp;
        [StringLength(30)]
        public String vchCiudadEmp { get { return _vchCiudadEmp; } set { _vchCiudadEmp = value; } }


        String _vchEstadoEmp;
        [StringLength(30)]
        public String vchEstadoEmp { get { return _vchEstadoEmp; } set { _vchEstadoEmp = value; } }


        String _vchIdHospitaliza;
        [StringLength(14)]
        public String vchIdHospitaliza { get { return _vchIdHospitaliza; } set { _vchIdHospitaliza = value; } }


        String _vchCodMedicoFam;
        [StringLength(30)]
        public String vchCodMedicoFam { get { return _vchCodMedicoFam; } set { _vchCodMedicoFam = value; } }


        Int16 _siTipoAfiliado;
        public Int16 siTipoAfiliado { get { return _siTipoAfiliado; } set { _siTipoAfiliado = value; } }


        Int16 _siConfidencial;
        public Int16 siConfidencial { get { return _siConfidencial; } set { _siConfidencial = value; } }


        Byte _imFotoAfiliado;
        public Byte imFotoAfiliado { get { return _imFotoAfiliado; } set { _imFotoAfiliado = value; } }


        String _chrCURP;
        [StringLength(18)]
        public String chrCURP { get { return _chrCURP; } set { _chrCURP = value; } }


        String _vchReferencia;
        [StringLength(35)]
        public String vchReferencia { get { return _vchReferencia; } set { _vchReferencia = value; } }


        Int32 _iMunicipio;
        public Int32 iMunicipio { get { return _iMunicipio; } set { _iMunicipio = value; } }


        Int32 _iMedicoSecundario;
        public Int32 iMedicoSecundario { get { return _iMedicoSecundario; } set { _iMedicoSecundario = value; } }


        Int16 _tiRequiereEmpresa;
        public Int16 tiRequiereEmpresa { get { return _tiRequiereEmpresa; } set { _tiRequiereEmpresa = value; } }


        Int16 _tiRequiereExpediente;
        public Int16 tiRequiereExpediente { get { return _tiRequiereExpediente; } set { _tiRequiereExpediente = value; } }


        Int16 _siRelacionTitular;
        public Int16 siRelacionTitular { get { return _siRelacionTitular; } set { _siRelacionTitular = value; } }


        String _vchIdAfiliadoTitular;
        [StringLength(14)]
        public String vchIdAfiliadoTitular { get { return _vchIdAfiliadoTitular; } set { _vchIdAfiliadoTitular = value; } }


        Int32 _iFechaInduccion;
        public Int32 iFechaInduccion { get { return _iFechaInduccion; } set { _iFechaInduccion = value; } }


        DateTime _dtFechaCreacion;
        public DateTime dtFechaCreacion { get { return _dtFechaCreacion; } set { _dtFechaCreacion = value; } }


        DateTime _dtFechaActualizacion;
        public DateTime dtFechaActualizacion { get { return _dtFechaActualizacion; } set { _dtFechaActualizacion = value; } }


        String _chrCurpp;
        [StringLength(20)]
        public String chrCurpp { get { return _chrCurpp; } set { _chrCurpp = value; } }


        Boolean _bProceso;
        public Boolean bProceso { get { return _bProceso; } set { _bProceso = value; } }


        Int32 _IdEstadoNacimiento;
        public Int32 IdEstadoNacimiento { get { return _IdEstadoNacimiento; } set { _IdEstadoNacimiento = value; } }


        Boolean _bCurpTemporal;
        public Boolean bCurpTemporal { get { return _bCurpTemporal; } set { _bCurpTemporal = value; } }


        Decimal _IdMovimiento;
        public Decimal IdMovimiento { get { return _IdMovimiento; } set { _IdMovimiento = value; } }


        Int32 _IdColonia;
        public Int32 IdColonia { get { return _IdColonia; } set { _IdColonia = value; } }


        String _vcTelefono2;
        [StringLength(30)]
        public String vcTelefono2 { get { return _vcTelefono2; } set { _vcTelefono2 = value; } }


        String _vcTelefonoMovil;
        [StringLength(30)]
        public String vcTelefonoMovil { get { return _vcTelefonoMovil; } set { _vcTelefonoMovil = value; } }
    }
}