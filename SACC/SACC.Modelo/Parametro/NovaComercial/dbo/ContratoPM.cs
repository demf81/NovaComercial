using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class ContratoPM : ModeloBasePM
    {
        public ContratoPM()
        {
            _ContratoId          = 0;
            _ContratoDescripcion = String.Empty;
        }


        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoDescripcion;
        [StringLength(200)]
        public String ContratoDescripcion { get { return _ContratoDescripcion; } set { _ContratoDescripcion = value; } }

        Int32 _ContratoTipoId;
        public Int32 ContratoTipoId { get { return _ContratoTipoId; } set { _ContratoTipoId = value; } }

        Int16 _ContratoEstatusId;
        public Int16 ContratoEstatusId { get { return _ContratoEstatusId; } set { _ContratoEstatusId = value; } }
    }
}