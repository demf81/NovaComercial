using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Parentesco
{
    public class DtoParentesco : ModeloBase
    {
        public DtoParentesco()
        {
            _ParentescoDescripcion = String.Empty;
        }


        Int16 _ParentescoId;
        public Int16 ParentescoId { get { return _ParentescoId; } set { _ParentescoId = value; } }

        String _ParentescoDescripcion;
        [StringLength(200)]
        public String ParentescoDescripcion { get { return _ParentescoDescripcion; } set { _ParentescoDescripcion = value; } }

        Int16 _ClaveFamiliarInicio;
        public Int16 ClaveFamiliarInicio { get { return _ClaveFamiliarInicio; } set { _ClaveFamiliarInicio = value; } }
        
        Int16 _ClaveFamiliarFin;
        public Int16 ClaveFamiliarFin { get { return _ClaveFamiliarFin; } set { _ClaveFamiliarFin = value; } }
    }
}