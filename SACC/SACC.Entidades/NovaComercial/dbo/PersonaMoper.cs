using System;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class PersonaMoper : EntidadBase
    {
        public PersonaMoper()
        {

        }


        Int32 _PersonaMoperId;
        public Int32 PersonaMoperId { get { return _PersonaMoperId; } set { _PersonaMoperId = value; } }

        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        Int32 _ProcesoId;
        public Int32 ProcesoId { get { return _ProcesoId; } set { _ProcesoId = value; } }
 
        String _ClaveMovimientoId;
        public String ClaveMovimientoId { get { return _ClaveMovimientoId; } set { _ClaveMovimientoId = value; } }

        String _NumeroSocio;
        public String NumeroSocio { get { return _NumeroSocio; } set { _NumeroSocio = value; } }
        
        String _ClaveFamiliar;
        public String ClaveFamiliar { get { return _ClaveFamiliar; } set { _ClaveFamiliar = value; } }

        String _Nombre;
        public String Nombre { get { return _Nombre; } set { _Nombre = value; } }

        String _ApellidoPaterno;
        public String ApellidoPaterno { get { return _ApellidoPaterno; } set { _ApellidoPaterno = value; } }

        String _ApellidoMaterno;
        public String ApellidoMaterno { get { return _ApellidoMaterno; } set { _ApellidoMaterno = value; } }

        String _FechaNacimiento;
        public String FechaNacimiento { get { return _FechaNacimiento; } set { _FechaNacimiento = value; } }

        String _CURP;
        public String CURP { get { return _CURP; } set { _CURP = value; } }

        String _Genero;
        public String Genero { get { return _Genero; } set { _Genero = value; } }

        String _EstadoCivilId;
        public String EstadoCivilId { get { return _EstadoCivilId; } set { _EstadoCivilId = value; } }

        String _GrupoFamiliar;
        public String GrupoFamiliar { get { return _GrupoFamiliar; } set { _GrupoFamiliar = value; } }

        String _EmpresaId;
        public String EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }

        String _PlantaId;
        public String PlantaId { get { return _PlantaId; } set { _PlantaId = value; } }

        String _DepartamentoId;
        public String DepartamentoId { get { return _DepartamentoId; } set { _DepartamentoId = value; } }

        String _TipoTrabajadorId;
        public String TipoTrabajadorId { get { return _TipoTrabajadorId; } set { _TipoTrabajadorId = value; } }

        String _NumeroTernium;
        public String NumeroTernium { get { return _NumeroTernium; } set { _NumeroTernium = value; } }

        String _RI;
        public String RI { get { return _RI; } set { _RI = value; } }

        String _NR;
        public String NR { get { return _NR; } set { _NR = value; } }

        String _FechaIngresoEmpresa;
        public String FechaIngresoEmpresa { get { return _FechaIngresoEmpresa; } set { _FechaIngresoEmpresa = value; } }

        String _FechaIngresoGrupo;
        public String FechaIngresoGrupo { get { return _FechaIngresoGrupo; } set { _FechaIngresoGrupo = value; } }

        String _EstatusActivo;
        public String EstatusActivo { get { return _EstatusActivo; } set { _EstatusActivo = value; } }

        String _FechaAltaMovimiento;
        public String FechaAltaMovimiento { get { return _FechaAltaMovimiento; } set { _FechaAltaMovimiento = value; } }

        String _FechaBajaMovimiento;
        public String FechaBajaMovimiento { get { return _FechaBajaMovimiento; } set { _FechaBajaMovimiento = value; } }

        String _EmpresaAnteriorId;
        public String EmpresaAnteriorId { get { return _EmpresaAnteriorId; } set { _EmpresaAnteriorId = value; } }

        String _PlantaAnteriorId;
        public String PlantaAnteriorId { get { return _PlantaAnteriorId; } set { _PlantaAnteriorId = value; } }

        Boolean? _Error;
        public Boolean? Error { get { return _Error; } set { _Error = value; } }

        String _MensajeError;
        public String MensajeError { get { return _MensajeError; } set { _MensajeError = value; } }

        Int32 _PersonaMoperEstatusId;
        public Int32 PersonaMoperEstatusId { get { return _PersonaMoperEstatusId; } set { _PersonaMoperEstatusId = value; } }
    }
}