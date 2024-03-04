using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class MembresiaTipoPM : ModeloBasePM
    {
        public MembresiaTipoPM()
        {
            _MembresiaTipoId          = 0;
            _MembresiaTipoDescripcion = String.Empty;
        }
        

        Int32 _MembresiaTipoId;
        public Int32 MembresiaTipoId { get { return _MembresiaTipoId; } set { _MembresiaTipoId = value; } }
        
        String _MembresiaTipoDescripcion;
        [StringLength(200)]
        public String MembresiaTipoDescripcion { get { return _MembresiaTipoDescripcion; } set { _MembresiaTipoDescripcion = value; } }
    }
}