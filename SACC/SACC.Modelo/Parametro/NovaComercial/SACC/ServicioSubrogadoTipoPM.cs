using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class ServicioSubrogadoTipoPM : ModeloBasePM
    {
        public ServicioSubrogadoTipoPM()
        {
            _ServicioSubrogadoTipoId          = 0;
            _ServicioSubrogadoTipoDescripcion = String.Empty;

        }
        

        Int32 _ServicioSubrogadoTipoId;
        public Int32 ServicioSubrogadoTipoId { get { return _ServicioSubrogadoTipoId; } set { _ServicioSubrogadoTipoId = value; } }
        
        String _ServicioSubrogadoTipoDescripcion;
        [StringLength(200)]
        public String ServicioSubrogadoTipoDescripcion { get { return _ServicioSubrogadoTipoDescripcion; } set { _ServicioSubrogadoTipoDescripcion = value; } }
    }
}