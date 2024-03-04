using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Client.Models
{
    public class HomeModel
    {
        //public string Nombre { get; set; }
    }


    public class LoginModel
    {
        public int UsuarioId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Dominio")]
        public string Dominio { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Usuario")]
        public string CuentaRed { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }


        public Boolean AutenticacionCorrecta { get; set; }
    }


    public class JsonResultModel
    {
        public Boolean success { get; set; }

        public object data { get; set; }

        public string message { get; set; }
    }
}