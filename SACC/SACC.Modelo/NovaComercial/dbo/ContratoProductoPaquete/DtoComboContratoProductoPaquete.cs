using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.ContratoProductoPaquete
{
    public class DtoComboContratoProductoPaquete
    {
        public DtoComboContratoProductoPaquete()
        {
            _ContratoProductoDescripcion = string.Empty;
        }


        Int32 _ContratoProductoId;
        public Int32 ContratoProductoId { get { return _ContratoProductoId; } set { _ContratoProductoId = value; } }

        String _ContratoProductoDescripcion;
        [StringLength(100)]
        public String ContratoProductoDescripcion { get { return _ContratoProductoDescripcion; } set { _ContratoProductoDescripcion = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        String _PaqueteDescripcion;
        [StringLength(100)]
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }
    }
}