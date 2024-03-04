using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Client.Areas.VentaUnitaria.Models
{
    public class VentaUnitariaResumen
    {
        [Display(Name = "Folio")]
        public int VentaUnitariaId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string VentaUnitariaDescripcion { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "No. Cliente")]
        public int PersonaId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Display(Name = "Folio")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int EmpresaId { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Empresa { get; set; }


        [Display(Name = "Tipo de Servicio")]
        public string TipoServicio { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Folio")]
        public int ContratoId { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Contrato { get; set; }


        [Display(Name = "Vigencia")]
        public DateTime FechaVigencia { get; set; }


        [Display(Name = "Esquema de PrePago")]
        public bool EsquemaPrePago { get; set; }


        [Display(Name = "Cobro Anticipado")]
        public bool CobroAnticipado { get; set; }


        [Display(Name = "Utilidad")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Decimal PorcentajeUtilidadSobreTarifa { get; set; }


        [Display(Name = "Copago")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Decimal PorcentajeCopagoContratante { get; set; }


        [Display(Name = "Descuento")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Decimal PorcentajeDescuentoSobreTarifa { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Total")]
        public Decimal Total { get; set; }
    }
}