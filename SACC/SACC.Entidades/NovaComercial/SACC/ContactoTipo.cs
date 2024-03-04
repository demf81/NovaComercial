using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class ContactoTipo : EntidadBase
    {
        public ContactoTipo()
        {
            _ContactoTipoDescripcion = String.Empty;
        }


        Int16 _ContactoTipoId;
        public Int16 ContactoTipoId { get { return _ContactoTipoId; } set { _ContactoTipoId = value; } }

        String _ContactoTipoDescripcion;
        [StringLength(200)]
        public String ContactoTipoDescripcion { get { return _ContactoTipoDescripcion; } set { _ContactoTipoDescripcion = value; } }
    }
}