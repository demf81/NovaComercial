using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class ServicioTipoPM : ModeloBasePM
    {
        public ServicioTipoPM()
        {
            _ServicioTipoId          = 0;
            _ServicioTipoDescripcion = String.Empty;

        }
        

        Int32 _ServicioTipoId;
        public Int32 ServicioTipoId { get { return _ServicioTipoId; } set { _ServicioTipoId = value; } }
        
        String _ServicioTipoDescripcion;
        [StringLength(200)]
        public String ServicioTipoDescripcion { get { return _ServicioTipoDescripcion; } set { _ServicioTipoDescripcion = value; } }
    }
}