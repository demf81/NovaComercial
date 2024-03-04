using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaUnitariaEspecial.Models
{
    public class VentaUnitariaEspecialModel
    {
        #region PROPIEDADES WIZARD
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Folio")]
        public int wizard_txtPersonaId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Num Socio")]
        public string wizard_txtNumSocio{ get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string wizard_txtNombre { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Campo Requerido")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Empresa Planta")]
        public int wizard_EmpresaPlantaId { get; set; }
        public List<SelectListItem> EmpresaPlantas { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Campo Requerido")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Contratos")]
        public int wizard_ContratoId { get; set; }
        public List<SelectListItem> Contratos { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Campo Requerido")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Productos")]
        public int wizard_ContratoProductoId { get; set; }
        public List<SelectListItem> Productos { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Campo Requerido")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Paquete")]
        public int wizard_PaqueteId { get; set; }
        public List<SelectListItem> Paquetes { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Vigencia")]
        public DateTime? wizard_txtFechaVigencia { get; set; }
        #endregion


        public VentaUnitariaEspecialModel()
        {
            wizard_txtFechaVigencia  = null;
            FechaVigencia            = DateTime.Now;
            VentaUnitariaDescripcion = string.Empty;
        }


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


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Folio")]
        public int EmpresaId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Empresa { get; set; }


        //[Display(Name = "Tipo de Servicio")]
        //public string TipoServicio { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Folio")]
        public int ContratoId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Contrato { get; set; }


        [Display(Name = "Vigencia")]
        public DateTime FechaVigencia { get; set; }


        [Display(Name = "Esquema de PrePago")]
        public Boolean EsquemaPrePago { get; set; }


        [Display(Name = "Cobro Anticipado")]
        public Boolean CobroAnticipado { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Utilidad")]
        public decimal PorcentajeUtilidadSobreTarifa { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Copago")]
        public decimal PorcentajeCopagoContratante { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descuento")]
        public decimal PorcentajeDescuentoSobreTarifa { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Total")]
        public decimal Total { get; set; }
    }
}