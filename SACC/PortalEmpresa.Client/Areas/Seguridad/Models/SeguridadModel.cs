using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalEmpresa.Client.Areas.Seguridad.Models
{
    public class SeguridadModel
    {
    }

    public class MiPerfilModel
    {
        [Display(Name = "Id")]
        public int UsuarioId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Apellido Paterno")]
        public string Paterno { get; set;}


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Apellido Materno")]
        public string Materno { get; set;}


        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo Electrónico")]
        public string Correo {get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "Inicio de Vigencia")]
        public DateTime FechaVigenciaDesde { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "Fin de Vigencia")]
        public DateTime FechaVigenciaHasta { get; set; }
    }

    public class CambioContrasenaModel
    {
        [Display(Name = "Id")]
        public int UsuarioId { get; set; }


        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nueva Contraseña")]
        public string NuevaContrasena { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmarContrasena { get; set; }
    }
}