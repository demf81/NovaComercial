using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.Checkup.Models
{
    public class CheckupModel
    {
    }

    public class CheckupVisualizar
    {
        public CheckupVisualizar()
        {
            //Grid = new List<CheckupLista>();
        }


        //[Required(ErrorMessage = "Campo Requerido")]
        //[Display(Name = "No. Cliente")]
        //public int PersonaId { get; set; }


        [Display(Name = "Protocolo")]
        public int ServicioId { get; set; }
        public List<SelectListItem> Servicio { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }


        //[Display(Name = "Empresa")]
        //public int EmpresaId { get; set; }
        //public List<SelectListItem> Empresa { get; set; }


        //[Display(Name = "Planta")]
        //public int EmpresaPlantaId { get; set; }
        //public List<SelectListItem> EmpresaPlanta { get; set; }


        //[Required(ErrorMessage = "Campo Requerido")]
        //[Display(Name = "Nombre")]
        //public string Nombre { get; set; }


        //[Display(Name = "Estatus")]
        //public List<PortalEmpresa.Client.Models.RadioModel> Estatus { get; set; }


        //[Display(Name = "Estatus")]
        //public int EstatusId { get; set; }


        //public List<CheckupLista> Grid { get; set; }
    }

    //public class CheckupLista
    //{
    //    [Display(Name = "AgendaId")]
    //    public int AgendaId { get; set; }


    //    [Display(Name = "PersonaId")]
    //    public int PersonaId { get; set; }


    //    [Display(Name = "Empresa")]
    //    public string Empresa { get; set; }


    //    [Display(Name = "Planta")]
    //    public string EmpresaPlanta { get; set; }


    //    [Display(Name = "Nombre")]
    //    public string Nombre { get; set; }


    //    [Display(Name = "Fecha")]
    //    public DateTime Fecha { get; set; }


    //    [Display(Name = "Estatus")]
    //    public string Estatus { get; set; }
    //}

    public class CheckupPersonaBuscar
    {
        public CheckupPersonaBuscar()
        {
            Grid = new List<CheckupPersonaBuscarLista>();
        }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "No. Cliente")]
        public int PersonaId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        public List<CheckupPersonaBuscarLista> Grid { get; set; }
    }

    public class CheckupPersonaBuscarLista
    {
        public bool Seleccionado { get; set; }


        [Display(Name = "PersonaId")]
        public int PersonaId { get; set; }


        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }


        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }


        [Display(Name = "Nombre")]
        public string Nombre{ get; set; }


        [Display(Name = "Genero")]
        public string Genero{ get; set; }


        [Display(Name = "Edad")]
        public decimal Edad { get; set; }


        [Display(Name = "Estatus")]
        public string Estatus { get; set; }
    }
}