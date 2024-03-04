using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class ClienteTipoPM : ModeloBasePM
    {
        public ClienteTipoPM()
        {
            _ClienteTipoId          = 0;
            _ClienteTipoDescripcion = String.Empty;
        }


        Int32 _ClienteTipoId;
        public Int32 ClienteTipoId { get { return _ClienteTipoId; } set { _ClienteTipoId = value; } }

        String _ClienteTipoDescripcion;
        [StringLength(150)]
        public String ClienteTipoDescripcion { get { return _ClienteTipoDescripcion; } set { _ClienteTipoDescripcion = value; } }
    }
}