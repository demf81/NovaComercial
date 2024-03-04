using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class ServicioSubrogadoPM : ModeloBasePM
    {
        public ServicioSubrogadoPM()
        {
            _ServicioSubrogadoId          = 0;
            _ServicioSubrogadoDescripcion = String.Empty;

        }


        Int32 _ServicioSubrogadoId;
        public Int32 ServicioSubrogadoId { get { return _ServicioSubrogadoId; } set { _ServicioSubrogadoId = value; } }

        String _ServicioSubrogadoDescripcion;
        [StringLength(200)]
        public String ServicioSubrogadoDescripcion { get { return _ServicioSubrogadoDescripcion; } set { _ServicioSubrogadoDescripcion = value; } }

        Int32 _ServicioSubrogadoTipoId;
        public Int32 ServicioSubrogadoTipoId { get { return _ServicioSubrogadoTipoId; } set { _ServicioSubrogadoTipoId = value; } }

        String _Codigo;
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }
    }
}