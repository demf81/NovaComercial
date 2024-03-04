using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.MembresiaEstatus
{
    public class DtoComboMembresiaEstatus
    {
        public DtoComboMembresiaEstatus()
        {
            _MembresiaEstatusDescripcion = String.Empty;
        }
        

        Int32 _MembresiaEstatusId;
        public Int32 MembresiaEstatusId { get { return _MembresiaEstatusId; } set { _MembresiaEstatusId = value; } }
        
        String _MembresiaEstatusDescripcion;
        [StringLength(200)]
        public String MembresiaEstatusDescripcion { get { return _MembresiaEstatusDescripcion; } set { _MembresiaEstatusDescripcion = value; } }
    }
}