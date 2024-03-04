using System;


namespace SACC.Client.Areas.VentaUnitariaEspecialDetalle.Models
{
    public class VentaUnitariaEspecialDetalleModel
    {
        public int VentaUnitariaDetalleId { get; set; }


        public int VentaUnitariaId { get; set; }


        public int VentaUnitariaDetalleTipoId { get; set; }


        public string Descripcion { get; set; }


        public int itemId { get; set; }


        public string ArticuloDescripcion { get; set; }


        public int PaqueteCoberturaId { get; set; }


        public Boolean Amparado { get; set; }


        public decimal Cantidad { get; set; }


        public decimal Precio { get; set; }


        public decimal SubTotal { get; set; }
    }
}