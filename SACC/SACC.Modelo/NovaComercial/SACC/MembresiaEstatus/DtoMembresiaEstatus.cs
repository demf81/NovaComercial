using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.MembresiaEstatus
{
    public class DtoMembresiaEstatus : ModeloBase
    {
        public DtoMembresiaEstatus()
        {
            _MembresiaEstatusDescripcion = String.Empty;
        }
        

        Int16 _MembresiaEstatusId;
        public Int16 MembresiaEstatusId { get { return _MembresiaEstatusId; } set { _MembresiaEstatusId = value; } }
        
        String _MembresiaEstatusDescripcion;
        [StringLength(200)]
        public String MembresiaEstatusDescripcion { get { return _MembresiaEstatusDescripcion; } set { _MembresiaEstatusDescripcion = value; } }
    }
}