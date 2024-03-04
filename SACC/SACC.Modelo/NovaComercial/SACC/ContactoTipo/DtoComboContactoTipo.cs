using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.ContactoTipo
{
    public class DtoComboContactoTipo
    {
        public DtoComboContactoTipo()
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