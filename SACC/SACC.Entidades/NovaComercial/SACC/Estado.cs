using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class Estado : EntidadBase
    {
        public Estado()
        {
            _EstadoDescripcion = string.Empty;
        }


        Int32 _EstadoId;
        public Int32 EstadoId { get { return _EstadoId; } set { _EstadoId = value; } }

        Int32 _PaisId;
        public Int32 PaisId { get { return _PaisId; } set { _PaisId = value; } }

        String _EstadoDescripcion;
        [StringLength(200)]
        public String EstadoDescripcion { get { return _EstadoDescripcion; } set { _EstadoDescripcion = value; } }

        String _Codigo;
        [StringLength(10)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }
    }
}