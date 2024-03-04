using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalEmpresa.Client.Areas.Paquete.Models
{
    public class PaqueteModel
    {
    }


    public class PaqueteSeleccion
    {
        public Boolean Seleccionado { get; set; }


        public int PersonaId { get; set; }


        public int ContratoProductoId { get; set; }


        public string Nombre { get; set; }


        public int ContratoId { get; set; }

        
        public int PaqueteId { get; set; }


        public string PaqueteDescripcion { get; set; }
    }
}