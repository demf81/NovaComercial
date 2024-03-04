using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class Contrato : EntidadBase
    {
        public Contrato()
        {
            _ContratoDescripcion = string.Empty;
        }


        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoDescripcion;
        [StringLength(250)]
        public System.String ContratoDescripcion { get { return _ContratoDescripcion; } set { _ContratoDescripcion = value; } }

        Int32 _ContratoTipoId;
        public Int32 ContratoTipoId { get { return _ContratoTipoId; } set { _ContratoTipoId = value; } }

        Int32 _ContratanteId;
        public Int32 ContratanteId { get { return _ContratanteId; } set { _ContratanteId = value; } }

        //DateTime? _VigenciaInicio;
        //public DateTime? VigenciaInicio { get { return _VigenciaInicio; } set { _VigenciaInicio = value; } }

        //DateTime? _VigenciaTermino;
        //public DateTime? VigenciaTermino { get { return _VigenciaTermino; } set { _VigenciaTermino = value; } }

        Int16 _ContratoEstatusId;
        public Int16 ContratoEstatusId { get { return _ContratoEstatusId; } set { _ContratoEstatusId = value; } }
    }
}