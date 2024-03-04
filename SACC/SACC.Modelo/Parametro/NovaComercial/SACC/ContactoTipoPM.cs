using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class ContactoTipoPM : ModeloBasePM
    {
        public ContactoTipoPM()
        {
            _ContactoTipoId          = 0;
            _ContactoTipoDescripcion = String.Empty;
        }


        Int32 _ContactoTipoId;
        public Int32 ContactoTipoId { get { return _ContactoTipoId; } set { _ContactoTipoId = value; } }

        String _ContactoTipoDescripcion;
        [StringLength(200)]
        public String ContactoTipoDescripcion { get { return _ContactoTipoDescripcion; } set { _ContactoTipoDescripcion = value; } }
    }
}