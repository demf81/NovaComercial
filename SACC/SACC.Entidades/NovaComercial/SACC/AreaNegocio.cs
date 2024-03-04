using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class AreaNegocio : EntidadBase
    {
        public AreaNegocio()
        {
            _AreaNegocioDescripcion = string.Empty;
        }
        

        Int16 _AreaNegocioId;
        public Int16 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }
        
        String _AreaNegocioDescripcion;
        [StringLength(200)]
        public String AreaNegocioDescripcion { get { return _AreaNegocioDescripcion; } set { _AreaNegocioDescripcion = value; } }
    }
}