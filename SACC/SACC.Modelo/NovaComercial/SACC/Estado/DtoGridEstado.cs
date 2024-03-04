using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Estado
{
    public class DtoGridEstado
    {
        public DtoGridEstado()
        {
            _EstadoDescripcion = String.Empty;
        }

        Int32 _EstadoId;
        public Int32 EstadoId { get { return _EstadoId; } set { _EstadoId = value; } }

        String _PaisDescripcion;
        [StringLength(200)]
        public String PaisDescripcion { get { return _PaisDescripcion; } set { _PaisDescripcion = value; } }

        String _EstadoDescripcion;
        [StringLength(200)]
        public String EstadoDescripcion { get { return _EstadoDescripcion; } set { _EstadoDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}