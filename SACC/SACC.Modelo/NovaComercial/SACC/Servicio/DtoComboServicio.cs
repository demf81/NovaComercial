using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Servicio
{
    public class DtoComboServicio
    {
        public DtoComboServicio()
        {

        }


        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        String _ServicioDescripcion;
        [StringLength(200)]
        public String ServicioDescripcion { get { return _ServicioDescripcion; } set { _ServicioDescripcion = value; } }
    }
}