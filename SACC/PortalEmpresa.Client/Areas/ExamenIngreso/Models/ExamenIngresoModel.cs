using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.ExamenIngreso.Models
{
    public class ExamenIngresoModel
    {
    }

    public class ExamenIngresoVisualizar
    {
        public ExamenIngresoVisualizar()
        {
            Grid = new List<ExamenIngresoLista>();
        }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "No. Cliente")]
        public int PersonaId { get; set; }


        [Display(Name = "Servicios")]
        public int ServicioId { get; set; }
        public List<SelectListItem> Servicio { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }


        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }
        public List<SelectListItem> Empresa { get; set; }


        [Display(Name = "Planta")]
        public int EmpresaPlantaId { get; set; }
        public List<SelectListItem> EmpresaPlanta { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        //[Display(Name = "Estatus")]
        //public List<PortalEmpresa.Client.Models.RadioModel> Estatus { get; set; }


        //[Display(Name = "Estatus")]
        //public int EstatusId { get; set; }


        public List<ExamenIngresoLista> Grid { get; set; }
    }

    public class ExamenIngresoLista
    {
        [Display(Name = "AgendaId")]
        public int AgendaId { get; set; }


        [Display(Name = "PersonaId")]
        public int PersonaId { get; set; }


        [Display(Name = "Empresa")]
        public string Empresa { get; set; }


        //[Display(Name = "Planta")]
        //public string EmpresaPlanta { get; set; }


        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Display(Name = "Estatus")]
        public string Estatus { get; set; }
    }
}