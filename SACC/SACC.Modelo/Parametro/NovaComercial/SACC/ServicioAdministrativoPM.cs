using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class ServicioAdministrativoPM : ModeloBasePM
    {
        public ServicioAdministrativoPM()
        {
            _ServicioAdministrativoId          = 0;
            _ServicioAdministrativoDescripcion = String.Empty;

        }
        

        Int32 _ServicioAdministrativoId;
        public Int32 ServicioAdministrativoId { get { return _ServicioAdministrativoId; } set { _ServicioAdministrativoId = value; } }
        
        String _ServicioAdministrativoDescripcion;
        [StringLength(200)]
        public String ServicioAdministrativoDescripcion { get { return _ServicioAdministrativoDescripcion; } set { _ServicioAdministrativoDescripcion = value; } }

        String _Codigo;
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }
    }
}