using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class ServicioTipo : EntidadBase
    {
        public ServicioTipo()
        {
            _ServicioTipoDescripcion = string.Empty;
            _CodigoServiciosMedicos = string.Empty;
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