using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalEmpresa.Client.Models
{
    public class RadioModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}