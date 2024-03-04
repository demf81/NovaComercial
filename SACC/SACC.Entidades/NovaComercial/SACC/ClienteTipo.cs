using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class ClienteTipo : EntidadBase
    {
        public ClienteTipo()
        {
            _ClienteTipoDescripcion = String.Empty;
        }


        Int16 _ClienteTipoId;
        public Int16 ClienteTipoId { get { return _ClienteTipoId; } set { _ClienteTipoId = value; } }

        String _ClienteTipoDescripcion;
        [StringLength(200)]
        public String ClienteTipoDescripcion { get { return _ClienteTipoDescripcion; } set { _ClienteTipoDescripcion = value; } }
    }
}