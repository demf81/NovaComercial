using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class Pais : EntidadBase
    {
        public Pais()
        {
            _PaisDescripcion = string.Empty;
        }


        Int32 _PaisId;
        public Int32 PaisId { get { return _PaisId; } set { _PaisId = value; } }

        String _PaisDescripcion;
        [StringLength(200)]
        public String PaisDescripcion { get { return _PaisDescripcion; } set { _PaisDescripcion = value; } }
    }
}