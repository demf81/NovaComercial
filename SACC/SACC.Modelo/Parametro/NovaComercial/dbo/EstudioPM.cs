using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class EstudioPM : ModeloBasePM
    {
        public EstudioPM()
        {
            _EstudioId          = 0;
            _EstudioDescripcion = String.Empty;
        }
        

        Int32 _EstudioId;
        public Int32 EstudioId { get { return _EstudioId; } set { _EstudioId = value; } }
        
        String _EstudioDescripcion;
        [StringLength(200)]
        public String EstudioDescripcion { get { return _EstudioDescripcion; } set { _EstudioDescripcion = value; } }
    }
}