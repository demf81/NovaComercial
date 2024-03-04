using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.ServicioSubrogado
{
    public class DtoServicioSubrogado : ModeloBase
    {
        public DtoServicioSubrogado()
        {
            _ServicioSubrogadoDescripcion = String.Empty;
        }
        

        Int32 _ServicioSubrogadoId;
        public Int32 ServicioSubrogadoId { get { return _ServicioSubrogadoId; } set { _ServicioSubrogadoId = value; } }
        
        String _ServicioSubrogadoDescripcion;
        [StringLength(200)]
        public String ServicioSubrogadoDescripcion { get { return _ServicioSubrogadoDescripcion; } set { _ServicioSubrogadoDescripcion = value; } }

        String _Codigo;
        [StringLength(100)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }

        Int16 _ServicioSubrogadoTipoId;
        public Int16 ServicioSubrogadoTipoId { get { return _ServicioSubrogadoTipoId; } set { _ServicioSubrogadoTipoId = value; } }

        Decimal _Costo;
        public Decimal Costo { get { return _Costo; } set { _Costo = value; } }
    }
}