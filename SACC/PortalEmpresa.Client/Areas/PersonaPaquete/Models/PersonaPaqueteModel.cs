using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.PersonaPaquete.Models
{
    public class PersonaPaqueteModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Campo Requerido")]
        [Display(Name = "Folio")]
        public int PersonaPaqueteId { get; set; }


        [Display(Name = "PersonaId")]
        public int PersonaId { get; set; }


        [Display(Name = "Persona")]
        public string PersonaDescripcion { get; set; }


        [Display(Name = "PaqueteId")]
        public int PaqueteId { get; set; }


        [Display(Name = "Paquete")]
        public string PaqueteDescripcion { get; set; }


        [DefaultValue(false)]
        [Display(Name = "Estatus")]
        public Boolean? Baja { get; set; }
    }


    public class PersonaPaqueteVisualizar
    {
        public int PersonaPaqueteId { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Campo Requerido")]
        [Display(Name = "Folio")]
        public int PersonaId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}