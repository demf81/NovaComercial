using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class MedicamentoCuadroTipoPM : ModeloBasePM
    {
        public MedicamentoCuadroTipoPM()
        {
            _MedicamentoCuadroTipoId          = 0;
            _MedicamentoCuadroTipoDescripcion = String.Empty;
        }
        

        Int32 _MedicamentoCuadroTipoId;
        public Int32 MedicamentoCuadroTipoId { get { return _MedicamentoCuadroTipoId; } set { _MedicamentoCuadroTipoId = value; } }
        
        String _MedicamentoCuadroTipoDescripcion;
        [StringLength(200)]
        public String MedicamentoCuadroTipoDescripcion { get { return _MedicamentoCuadroTipoDescripcion; } set { _MedicamentoCuadroTipoDescripcion = value; } }
    }
}