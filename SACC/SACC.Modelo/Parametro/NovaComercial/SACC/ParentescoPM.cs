using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class ParentescoPM : ModeloBasePM
    {
        public ParentescoPM()
        {
            _ParentescoId          = 0;
            _ParentescoDescripcion = String.Empty;
        }


        Int32 _ParentescoId;
        public Int32 ParentescoId { get { return _ParentescoId; } set { _ParentescoId = value; } }

        String _ParentescoDescripcion;
        [StringLength(200)]
        public String ParentescoDescripcion { get { return _ParentescoDescripcion; } set { _ParentescoDescripcion = value; } }
    }
}