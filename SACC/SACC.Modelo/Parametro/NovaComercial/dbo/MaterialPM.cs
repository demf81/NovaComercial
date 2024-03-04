using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class MaterialPM : ModeloBasePM
    {
        public MaterialPM()
        {
            _MaterialId          = 0;
            _MaterialDescripcion = String.Empty;
        }
        

        Int32 _MaterialId;
        public Int32 MaterialId { get { return _MaterialId; } set { _MaterialId = value; } }
        
        String _MaterialDescripcion;
        [StringLength(200)]
        public String MaterialDescripcion { get { return _MaterialDescripcion; } set { _MaterialDescripcion = value; } }
    }
}