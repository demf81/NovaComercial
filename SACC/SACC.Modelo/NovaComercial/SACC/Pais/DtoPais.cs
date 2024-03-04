using System;
using System.ComponentModel.DataAnnotations;

namespace SACC.Modelo.NovaComercial.SACC.Pais
{
    public class DtoPais : ModeloBase
    {
        public DtoPais()
        {
            _PaisDescripcion = String.Empty;
        }


        Int32 _PaisId;
        public Int32 PaisId { get { return _PaisId; } set { _PaisId = value; } }

        String _PaisDescripcion;
        [StringLength(200)]
        public String PaisDescripcion { get { return _PaisDescripcion; } set { _PaisDescripcion = value; } }
    }
}