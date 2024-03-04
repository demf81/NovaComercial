using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.Persona.Models
{
    public class PersonaModel
    {
        public PersonaModel()
        {
            FechaNacimiento = null;
        }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "No. Cliente")]
        public int PersonaId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [MinLength(3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [MinLength(3)]
        [Display(Name = "Apellido Paterno")]
        public string Paterno { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [MinLength(3)]
        [Display(Name = "Apellido Paterno")]
        public string Materno { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Género")]
        public Boolean? Genero { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento{ get; set; }


        [MaxLength(18, ErrorMessage = "Campo Requerido (18 catacteres)")]
        [MinLength(18, ErrorMessage = "Campo Requerido (18 catacteres)")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "CURP")]
        public string CURP { get; set; }


        [Display(Name = "Estatus")]
        public Boolean Baja { get; set; }


        //public List<PersonaContratoPaquete> GridPaquete { get; set; }


        public string SocioId { get; set; }
    }


    //public class PersonaContratoPaquete
    //{
    //    public int PersonaPaqueteId { get; set; }


    //    public int PersonaId { get; set; }


    //    public int ContratoId { get; set; }


    //    public int PaqueteId { get; set; }


    //    public string PaqueteDescripcion { get; set; }


    //    public Boolean Seleccionado { get; set; }
    //}

    public class PersonaVisualizar
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "No. Cliente")]
        public int PersonaId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Display(Name = "Estatus")]
        public List<PortalEmpresa.Client.Models.RadioModel> Estatus { get; set; }
        

        [Display(Name = "Estatus")]
        public int EstatusId { get; set; }
    }


    public class PersonaBuscarCURP
    {
        //[MaxLength(18, ErrorMessage = "Campo Requerido (18 catacteres)")]
        //[MinLength(18, ErrorMessage = "Campo Requerido (18 catacteres)")]
        [RegularExpression("^[A-Z]{1}[AEIOU]{1}[A-Z]{2}[0-9]{2}(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[HM]{1}(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)[B-DF-HJ-NP-TV-Z]{3}[0-9A-Z]{1}[0-9]{1}$", ErrorMessage= "CURP Invalido")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "CURP")]
        public string CURP { get; set; }


        [Display(Name = "Tipo de Búsqueda")]
        public Boolean TipoBusqueda { get; set; }
    }


    public class PersonaBuscarSocio
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Num. Socio")]
        public int SocioId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Cve. Familiar")]
        public int ClaveFamiliar { get; set; }


        [Display(Name = "Tipo de Búsqueda")]
        public Boolean TipoBusqueda { get; set; }
    }
}