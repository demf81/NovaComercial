using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class CirugiaPM : ModeloBasePM
    {
        public CirugiaPM()
        {
            _CirugiaId          = 0;
            _CirugiaDescripcion = String.Empty;
        }
        

        Int32 _CirugiaId;
        public Int32 CirugiaId { get { return _CirugiaId; } set { _CirugiaId = value; } }
        
        String _CirugiaDescripcion;
        [StringLength(200)]
        public String CirugiaDescripcion { get { return _CirugiaDescripcion; } set { _CirugiaDescripcion = value; } }
    }
}