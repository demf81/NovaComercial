using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class ServicioPM : ModeloBasePM
    {
        public ServicioPM()
        {
            _ServicioId          = 0;
            _ServicioDescripcion = String.Empty;
            _ServicioTipoId      = -1;
        }
        

        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }
        
        String _ServicioDescripcion;
        [StringLength(200)]
        public String ServicioDescripcion { get { return _ServicioDescripcion; } set { _ServicioDescripcion = value; } }
        
        Int32 _ServicioTipoId;
        public Int32 ServicioTipoId { get { return _ServicioTipoId; } set { _ServicioTipoId = value; } }
    }
}