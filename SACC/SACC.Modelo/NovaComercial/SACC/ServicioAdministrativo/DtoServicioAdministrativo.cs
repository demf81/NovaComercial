using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.ServicioAdministrativo
{
    public class DtoServicioAdministrativo : ModeloBase
    {
        public DtoServicioAdministrativo()
        {
            _ServicioAdministrativoDescripcion = String.Empty;
        }
        

        Int32 _ServicioAdministrativoId;
        public Int32 ServicioAdministrativoId { get { return _ServicioAdministrativoId; } set { _ServicioAdministrativoId = value; } }
        
        String _ServicioAdministrativoDescripcion;
        [StringLength(200)]
        public String ServicioAdministrativoDescripcion { get { return _ServicioAdministrativoDescripcion; } set { _ServicioAdministrativoDescripcion = value; } }

        String _Codigo;
        [StringLength(100)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }

        Decimal _Costo;
        public Decimal Costo { get { return _Costo; } set { _Costo = value; } }
    }
}