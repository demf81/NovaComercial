using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class EstadoPM : ModeloBasePM
    {
        public EstadoPM()
        {
            _EstadoId          = 0;
            _EstadoDescripcion = String.Empty;
        }


        Int32 _EstadoId;
        public Int32 EstadoId { get { return _EstadoId; } set { _EstadoId = value; } }

        Int32 _PaisId;
        public Int32 PaisId { get { return _PaisId; } set { _PaisId = value; } }

        String _EstadoDescripcion;
        [StringLength(200)]
        public String EstadoDescripcion { get { return _EstadoDescripcion; } set { _EstadoDescripcion = value; } }
    }
}