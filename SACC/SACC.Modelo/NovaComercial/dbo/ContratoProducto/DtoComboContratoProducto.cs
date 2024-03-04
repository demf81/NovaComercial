using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.ContratoProducto
{
    public class DtoComboContratoProducto
    {
        public DtoComboContratoProducto()
        {
            _ContratoProductoDescripcion = string.Empty;
        }


        Int32 _ContratoProductoId;
        public Int32 ContratoProductoId { get { return _ContratoProductoId; } set { _ContratoProductoId = value; } }

        String _ContratoProductoDescripcion;
        [StringLength(100)]
        public String ContratoProductoDescripcion { get { return _ContratoProductoDescripcion; } set { _ContratoProductoDescripcion = value; } }
    }
}