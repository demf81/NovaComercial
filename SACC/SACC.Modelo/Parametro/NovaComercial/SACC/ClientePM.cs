using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class ClientePM : ModeloBasePM
    {
        public ClientePM()
        {

        }


        Int32 _ClienteId;
        public Int32 ClienteId { get { return _ClienteId; } set { _ClienteId = value; } }

        Int16 _ClienteTipoId;
        public Int16 ClienteTipoId { get { return _ClienteTipoId; } set { _ClienteTipoId = value; } }

        String _ClienteDescripcion;
        [StringLength(100)]
        public String ClienteDescripcion { get { return _ClienteDescripcion; } set { _ClienteDescripcion = value; } }
    }
}