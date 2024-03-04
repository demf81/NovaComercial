using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACC.Entidades.NovaComercial.PortalEmpresa
{
    public class Perfil : EntidadBase
    {
        public Perfil()
        {

        }


        Int32 _PerfilId;
        public Int32 PerfilId { get { return _PerfilId; } set { _PerfilId = value; } }


        String _PerfilDescripcion;
        [StringLength(100)]
        public String PerfilDescripcion { get { return _PerfilDescripcion; } set { _PerfilDescripcion = value; } }
    }
}