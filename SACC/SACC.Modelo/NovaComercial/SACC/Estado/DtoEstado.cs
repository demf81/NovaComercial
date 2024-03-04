using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Estado
{
    public class DtoEstado : ModeloBase
    {
        public DtoEstado()
        {
            _EstadoDescripcion = String.Empty;
        }


        Int32 _EstadoId;
        public Int32 EstadoId { get { return _EstadoId; } set { _EstadoId = value; } }

        String _EstadoDescripcion;
        [StringLength(200)]
        public String EstadoDescripcion { get { return _EstadoDescripcion; } set { _EstadoDescripcion = value; } }
    }
}