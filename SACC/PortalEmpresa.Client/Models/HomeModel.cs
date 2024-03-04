using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalEmpresa.Client.Models
{
    public class HomeModel
    {
        //public string Nombre { get; set; }
    }

    public class LoginModel
    {
        public int UsuarioId { get; set; }


        public string Nombre { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [DataType( System.ComponentModel.DataAnnotations.DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }
    }

    public class JsonResultModel
    {
        public Boolean success { get; set; }


        public object data { get; set; }


        public string message { get; set; }
    }
}