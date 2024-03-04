using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class MembresiaEstatusPM : ModeloBasePM
    {
        public MembresiaEstatusPM()
        {
            _MembresiaEstatusId          = 0;
            _MembresiaEstatusDescripcion = String.Empty;

        }
        

        Int32 _MembresiaEstatusId;
        public Int32 MembresiaEstatusId { get { return _MembresiaEstatusId; } set { _MembresiaEstatusId = value; } }
        
        String _MembresiaEstatusDescripcion;
        [StringLength(200)]
        public String MembresiaEstatusDescripcion { get { return _MembresiaEstatusDescripcion; } set { _MembresiaEstatusDescripcion = value; } }
    }
}