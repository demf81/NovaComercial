using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class ServicioPM : ModeloBasePM
    {
        public ServicioPM()
        {
            _ServicioId          = 0;
            _ServicioDescripcion = String.Empty;

        }


        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        String _ServicioDescripcion;
        [StringLength(200)]
        public String ServicioDescripcion { get { return _ServicioDescripcion; } set { _ServicioDescripcion = value; } }

        Int16 _AreaNegocioId;
        public Int16 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }
    }
}