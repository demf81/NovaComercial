using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class Cliente : EntidadBase
    {
        public Cliente()
        {
            _ClienteDescripcion = String.Empty;
        }


        Int32 _ClienteId;
        public Int32 ClienteId { get { return _ClienteId; } set { _ClienteId = value; } }

        String _ClienteDescripcion;
        [StringLength(200)]
        public String ClienteDescripcion { get { return _ClienteDescripcion; } set { _ClienteDescripcion = value; } }

        String _Codigo;
        [StringLength(100)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }

        Int32 _ClienteTipoId;
        public Int32 ClienteTipoId { get { return _ClienteTipoId; } set { _ClienteTipoId = value; } }
    }
}