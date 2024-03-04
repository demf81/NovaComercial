using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.ServicioTipo
{
    public class DtoServicioTipo : ModeloBase
    {
        public DtoServicioTipo()
        {
            _ServicioTipoDescripcion = String.Empty;
            _CodigoServiciosMedicos  = String.Empty;
        }
        
        Int32 _ServicioTipoId;
        public Int32 ServicioTipoId { get { return _ServicioTipoId; } set { _ServicioTipoId = value; } }
        
        String _ServicioTipoDescripcion;
        [StringLength(100)]
        public String ServicioTipoDescripcion { get { return _ServicioTipoDescripcion; } set { _ServicioTipoDescripcion = value; } }
        
        Int32 _AreaNegocioId;
        public Int32 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }
        
        String _CodigoServiciosMedicos;
        [StringLength(10)]
        public String CodigoServiciosMedicos { get { return _CodigoServiciosMedicos; } set { _CodigoServiciosMedicos = value; } }
    }
}