using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Cliente
{
    public class DtoComboCliente
    {
        public DtoComboCliente()
        {

        }


        Int32 _ClienteId;
        public Int32 ClienteId { get { return _ClienteId; } set { _ClienteId = value; } }

        String _ClienteDescripcion;
        [StringLength(200)]
        public String ClienteDescripcion { get { return _ClienteDescripcion; } set { _ClienteDescripcion = value; } }
    }
}