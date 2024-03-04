using System;
using System.ComponentModel.DataAnnotations;

namespace SACC.Entidades.Nova_ServiciosMedicos.dbo
{
    public class CatAsociado
    {
        public CatAsociado()
        {

        }

        Int32 _IdNumeroSocio;
		public Int32 IdNumeroSocio { get { return _IdNumeroSocio; } set { _IdNumeroSocio = value; } }


		Int32? _NumeroAfiliado;
		public Int32? NumeroAfiliado { get { return _NumeroAfiliado; } set { _NumeroAfiliado = value; } }


		String _vcAfiliado;
        [StringLength(100)]
		public String vcAfiliado { get { return _vcAfiliado; } set { _vcAfiliado = value; } }


		String _vcTelefono;
        [StringLength(30)]
		public String vcTelefono { get { return _vcTelefono; } set { _vcTelefono = value; } }


		Boolean? _bActivo;
		public Boolean? bActivo { get { return _bActivo; } set { _bActivo = value; } }


		String _vcDomicilio;
        [StringLength(100)]
		public System.String vcDomicilio { get { return _vcDomicilio; } set { _vcDomicilio = value; } }


		Int32? _IdColonia;
		public Int32? IdColonia { get { return _IdColonia; } set { _IdColonia = value; } }


		Int32? _IdAseguradora;
		public Int32? IdAseguradora { get { return _IdAseguradora; } set { _IdAseguradora = value; } }


		String _vcPoliza;
        [StringLength(100)]
		public String vcPoliza { get { return _vcPoliza; } set { _vcPoliza = value; } }


		Int32? _iNoPoliza;
		public Int32? iNoPoliza { get { return _iNoPoliza; } set { _iNoPoliza = value; } }


		DateTime? _dtInicio;
		public DateTime? dtInicio { get { return _dtInicio; } set { _dtInicio = value; } }


		DateTime? _dtFinal;
		public DateTime? dtFinal { get { return _dtFinal; } set { _dtFinal = value; } }


		String _vcCurp;
        [StringLength(100)]
		public String vcCurp { get { return _vcCurp; } set { _vcCurp = value; } }


		Int32? _IdInstitucional;
		public Int32? IdInstitucional { get { return _IdInstitucional; } set { _IdInstitucional = value; } }


		String _vcApellidoPaterno;
        [StringLength(100)]
		public String vcApellidoPaterno { get { return _vcApellidoPaterno; } set { _vcApellidoPaterno = value; } }


		String _vcApellidoMaterno;
        [StringLength(100)]
		public String vcApellidoMaterno { get { return _vcApellidoMaterno; } set { _vcApellidoMaterno = value; } }


		String _vcNombre;
        [StringLength(100)]
		public String vcNombre { get { return _vcNombre; } set { _vcNombre = value; } }


		Int32? _IdSexo;
		public Int32? IdSexo { get { return _IdSexo; } set { _IdSexo = value; } }


		Int32? _IdEstadoCivil;
		public Int32? IdEstadoCivil { get { return _IdEstadoCivil; } set { _IdEstadoCivil = value; } }


		DateTime? _dtFechaNacimiento;
		public DateTime? dtFechaNacimiento { get { return _dtFechaNacimiento; } set { _dtFechaNacimiento = value; } }


		Int32? _IdTipoSangre;
		public Int32? IdTipoSangre { get { return _IdTipoSangre; } set { _IdTipoSangre = value; } }


		Boolean? _bConfidencial;
		public Boolean? bConfidencial { get { return _bConfidencial; } set { _bConfidencial = value; } }


		Boolean? _bRequiereEmpresa;
		public Boolean? bRequiereEmpresa { get { return _bRequiereEmpresa; } set { _bRequiereEmpresa = value; } }


		Boolean? _bReqExpedienteFisico;
		public Boolean? bReqExpedienteFisico { get { return _bReqExpedienteFisico; } set { _bReqExpedienteFisico = value; } }


		Int32? _IdMedicoFamiliar;
		public Int32? IdMedicoFamiliar { get { return _IdMedicoFamiliar; } set { _IdMedicoFamiliar = value; } }


		Int32? _IdClasificacionAfiliado;
		public Int32? IdClasificacionAfiliado { get { return _IdClasificacionAfiliado; } set { _IdClasificacionAfiliado = value; } }


		String _vcReferencias;
        [StringLength(100)]

		public String vcReferencias { get { return _vcReferencias; } set { if (value.Length >= 100) _vcReferencias = value.Substring(0, 100); else _vcReferencias = value; } }


		String _vcCodigoPostal;
        [StringLength(50)]
		public String vcCodigoPostal { get { return _vcCodigoPostal; } set { _vcCodigoPostal = value; } }


		String _vcTelefono2;
        [StringLength(30)]
		public String vcTelefono2 { get { return _vcTelefono2; } set { _vcTelefono2 = value; } }


		Int32? _IdTipoAfiliado;
		public Int32? IdTipoAfiliado { get { return _IdTipoAfiliado; } set { _IdTipoAfiliado = value; } }


		DateTime? _dtFechaInicio;
		public DateTime? dtFechaInicio { get { return _dtFechaInicio; } set { _dtFechaInicio = value; } }


		DateTime? _dtFechaTermino;
		public DateTime? dtFechaTermino { get { return _dtFechaTermino; } set { _dtFechaTermino = value; } }


		String _vcContratante;
        [StringLength(100)]
		public String vcContratante { get { return _vcContratante; } set { _vcContratante = value; } }


		Int32? _iNumeroCertificado;
		public Int32? iNumeroCertificado { get { return _iNumeroCertificado; } set { _iNumeroCertificado = value; } }


		Int32 _IdEmpresa;
		public Int32 IdEmpresa { get { return _IdEmpresa; } set { _IdEmpresa = value; } }


		String _vcNumeroTernium;
        [StringLength(20)]
		public String vcNumeroTernium { get { return _vcNumeroTernium; } set { _vcNumeroTernium = value; } }


		Int32? _IdReligion;
		public Int32? IdReligion { get { return _IdReligion; } set { _IdReligion = value; } }


		Int32? _IdNacionalidad;
		public Int32? IdNacionalidad { get { return _IdNacionalidad; } set { if (value >= 0) _IdNacionalidad = value; } }


		Int32? _IdTitular;
		public Int32? IdTitular { get { return _IdTitular; } set { _IdTitular = value; } }


		Boolean? _bTitularPersona;
		public Boolean? bTitularPersona { get { return _bTitularPersona; } set { _bTitularPersona = value; } }


		String _vcNumeroSocio;
        [StringLength(10)]
		public String vcNumeroSocio { get { return _vcNumeroSocio; } set { _vcNumeroSocio = value; } }


		String _vcClaveFamiliar;
        [StringLength(5)]
		public String vcClaveFamiliar { get { return _vcClaveFamiliar; } set { _vcClaveFamiliar = value; } }


		Int32? _IdEstadoNacimiento;
		public Int32? IdEstadoNacimiento { get { return _IdEstadoNacimiento; } set { _IdEstadoNacimiento = value; } }


		String _vcNombreContacto;
        [StringLength(100)]
		public String vcNombreContacto { get { return _vcNombreContacto; } set { _vcNombreContacto = value; } }


		String _vcDireccionContacto;
        [StringLength(100)]
		public String vcDireccionContacto { get { return _vcDireccionContacto; } set { if (value.Length >= 100) _vcDireccionContacto = value.Substring(0, 100); else _vcDireccionContacto = value; } }


		Int32? _IdColoniaContacto;
		public Int32? IdColoniaContacto { get { return _IdColoniaContacto; } set { _IdColoniaContacto = value; } }


		Int32? _iCodigoPostalContacto;
		public Int32? iCodigoPostalContacto { get { return _iCodigoPostalContacto; } set { _iCodigoPostalContacto = value; } }


		String _vcTelefonoContacto;
        [StringLength(30)]
		public String vcTelefonoContacto { get { return _vcTelefonoContacto; } set { _vcTelefonoContacto = value; } }


		Int32? _IdEscolaridad;
		public Int32? IdEscolaridad { get { return _IdEscolaridad; } set { _IdEscolaridad = value; } }


		Int32? _IdOcupacion;
		public Int32? IdOcupacion { get { return _IdOcupacion; } set { _IdOcupacion = value; } }


		System.String _vcPuesto;
        [StringLength(100)]
		public System.String vcPuesto { get { return _vcPuesto; } set { _vcPuesto = value; } }


		Int32? _IdUnidad;
		public Int32? IdUnidad { get { return _IdUnidad; } set { _IdUnidad = value; } }


		Boolean? _bServicioSuspendido;
		public Boolean? bServicioSuspendido { get { return _bServicioSuspendido; } set { _bServicioSuspendido = value; } }


		System.String _vcClavePaciente;
        [StringLength(20)]
		public System.String vcClavePaciente { get { return _vcClavePaciente; } set { _vcClavePaciente = value; } }


		String _vcCorreoElectronico;
        [StringLength(200)]
		public String vcCorreoElectronico { get { return _vcCorreoElectronico; } set { _vcCorreoElectronico = value; } }


		String _vcCorreoContacto;
        [StringLength(200)]
		public String vcCorreoContacto { get { return _vcCorreoContacto; } set { _vcCorreoContacto = value; } }


		String _vcTelefono2Contacto;
        [StringLength(30)]
		public String vcTelefono2Contacto { get { return _vcTelefono2Contacto; } set { _vcTelefono2Contacto = value; } }


		String _vcMovilContacto;
        [StringLength(30)]
		public String vcMovilContacto { get { return _vcMovilContacto; } set { _vcMovilContacto = value; } }


		String _vcTelefonoMovil;
        [StringLength(30)]
		public String vcTelefonoMovil { get { return _vcTelefonoMovil; } set { _vcTelefonoMovil = value; } }


		Boolean? _bCurpTemporal;
		public Boolean? bCurpTemporal { get { return _bCurpTemporal; } set { _bCurpTemporal = value; } }


		String _vcIdentidad;
        [StringLength(100)]
		public String vcIdentidad { get { return _vcIdentidad; } set { _vcIdentidad = value; } }
    }
}