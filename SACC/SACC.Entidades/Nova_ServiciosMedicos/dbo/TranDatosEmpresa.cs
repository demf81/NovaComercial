using System;
using System.ComponentModel.DataAnnotations;

namespace SACC.Entidades.Nova_ServiciosMedicos.dbo
{
    public class TranDatosEmpresa
    {
        public TranDatosEmpresa()
        {
            _dtFechaCreacion      = DateTime.Now;
            _dtFechaActualizacion = DateTime.Now;
        }


        Int32 _iCodigo;
        public Int32 iCodigo { get { return _iCodigo; } set { _iCodigo = value; } }


        [StringLength(14)]
        String _vcCodigoAlterno;
        public String vcCodigoAlterno { get { return _vcCodigoAlterno; } set { _vcCodigoAlterno = value; } }


        [StringLength(100)]
        String _vcNombreComercial;
        public String vcNombreComercial { get { return _vcNombreComercial; } set { _vcNombreComercial = value; } }


        [StringLength(100)]
        String _vcDireccion;
        public String vcDireccion { get { return _vcDireccion; } set { _vcDireccion = value; } }


        Int32 _IdColonia;
        public Int32 IdColonia { get { return _IdColonia; } set { _IdColonia = value; } }


        [StringLength(10)]
        String _vcCodigoPostal;
        public String vcCodigoPostal { get { return _vcCodigoPostal; } set { _vcCodigoPostal = value; } }


        [StringLength(100)]
        String _vcZona;
        public String vcZona { get { return _vcZona; } set { _vcZona = value; } }


        [StringLength(30)]
        String _vcTelefono1;
        public String vcTelefono1 { get { return _vcTelefono1; } set { _vcTelefono1 = value; } }
        
        
        [StringLength(30)]
        String _vcTelefono2;
        public String vcTelefono2 { get { return _vcTelefono2; } set { _vcTelefono2 = value; } }
        
        
        [StringLength(30)]
        String _vcFax;
        public String vcFax { get { return _vcFax; } set { _vcFax = value; } }
        
        
        Int32 _IdTipoEmpresa;
        public Int32 IdTipoEmpresa { get { return _IdTipoEmpresa; } set { _IdTipoEmpresa = value; } }
        
        
        Boolean _bFideicomitente;
        public Boolean bFideicomitente { get { return _bFideicomitente; } set { _bFideicomitente = value; } }
        
        
        Boolean _bEnLinea;
        public Boolean bEnLinea { get { return _bEnLinea; } set { _bEnLinea = value; } }
        
        
        Boolean _bActivo;
        public Boolean bActivo { get { return _bActivo; } set { _bActivo = value; } }
        
        
        [StringLength(100)]
        String _vcCorreoElectronico;
        public String vcCorreoElectronico { get { return _vcCorreoElectronico; } set { _vcCorreoElectronico = value; } }
                
        
        Int32 _iEnLineaSiass;
        public Int32 iEnLineaSiass { get { return _iEnLineaSiass; } set { _iEnLineaSiass = value; } }
        
        
        [StringLength(2)]
        String _vcGrupoSAP;
        public String vcGrupoSAP { get { return _vcGrupoSAP; } set { _vcGrupoSAP = value; } }
        
        
        [StringLength(2)]
        String _vcSectorSAP;
        public String vcSectorSAP { get { return _vcSectorSAP; } set { _vcSectorSAP = value; } }
        
        
        [StringLength(6)]
        String _vcZonaSAP;
        public String vcZonaSAP { get { return _vcZonaSAP; } set { _vcZonaSAP = value; } }
        
        
        [StringLength(4)]
        String _vcRamoIndustrialSAP;
        public String vcRamoIndustrialSAP { get { return _vcRamoIndustrialSAP; } set { _vcRamoIndustrialSAP = value; } }
        
        
        [StringLength(4)]
        String _vcOficinaVentaSAP;
        public String vcOficinaVentaSAP { get { return _vcOficinaVentaSAP; } set { _vcOficinaVentaSAP = value; } }
        
        
        Int32 _IdMovimiento;
        public Int32 IdMovimiento { get { return _IdMovimiento; } set { _IdMovimiento = value; } }
        
        
        DateTime _dtFechaCreacion;
        public DateTime dtFechaCreacion { get { return _dtFechaCreacion; } set { _dtFechaCreacion = value; } }
        
        
        DateTime _dtFechaActualizacion;
        public DateTime dtFechaActualizacion { get { return _dtFechaActualizacion; } set { _dtFechaActualizacion = value; } }
        
        
        Boolean _bProceso;
        public Boolean bProceso { get { return _bProceso; } set { _bProceso = value; } }
    }
}
