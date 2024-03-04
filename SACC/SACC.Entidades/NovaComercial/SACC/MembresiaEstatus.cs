using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class MembresiaEstatus : EntidadBase
    {
        public MembresiaEstatus()
        {
            _MembresiaEstatusDescripcion = string.Empty;
        }
        

        Int16 _MembresiaEstatusId;
        public Int16 MembresiaEstatusId { get { return _MembresiaEstatusId; } set { _MembresiaEstatusId = value; } }
        
        String _MembresiaEstatusDescripcion;
        [StringLength(200)]
        public String MembresiaEstatusDescripcion { get { return _MembresiaEstatusDescripcion; } set { _MembresiaEstatusDescripcion = value; } }
    }
}