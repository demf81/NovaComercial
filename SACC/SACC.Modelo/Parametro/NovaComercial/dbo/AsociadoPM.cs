using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class AsociadoPM : ModeloBasePM
    {
        public AsociadoPM()
        {
            _Curp     = String.Empty;
            _Nombre   = String.Empty;
            _NumSocio = String.Empty;
        }


        String _Curp;
        [StringLength(100)]
        public String Curp { get { return _Curp; } set { _Curp = value; } }

        String _Nombre;
        [StringLength(100)]
        public String Nombre { get { return _Nombre; } set { _Nombre = value; } }

        String _NumSocio;
        [StringLength(100)]
        public String NumSocio { get { return _NumSocio; } set { _NumSocio = value; } }
    }
}
