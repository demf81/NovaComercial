using SACC.Client.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaUnitaria.Models
{
    public class VentaUnitariaVisualizar
    {
        [Display(Name = "Contratante")]
        public int ContratanteId { get; set; }


        [Display(Name = "Tipo de Venta")]
        public int VentaTipoId { get; set; }


        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }


        public List<SelectListItem> Empresas { get; set; }


        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Display(Name = "Estatus")]
        public List<RadioModel> Estatus { get; set; }


        [Display(Name = "Estatus")]
        public int EstatusId { get; set; }
    }
}