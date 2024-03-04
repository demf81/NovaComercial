using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class MedicamentoPM : ModeloBasePM
    {
        public MedicamentoPM()
        {
            _MedicamentoId           = 0;
            _MedicamentoDescripcion  = String.Empty;
            _MedicamentoCuadroTipoId = -1;
        }
        

        Int32 _MedicamentoId;
        public Int32 MedicamentoId { get { return _MedicamentoId; } set { _MedicamentoId = value; } }
        
        String _MedicamentoDescripcion;
        [StringLength(200)]
        public String MedicamentoDescripcion { get { return _MedicamentoDescripcion; } set { _MedicamentoDescripcion = value; } }
        
        Int32 _MedicamentoCuadroTipoId;
        public Int32 MedicamentoCuadroTipoId { get { return _MedicamentoCuadroTipoId; } set { _MedicamentoCuadroTipoId = value; } }
    }
}