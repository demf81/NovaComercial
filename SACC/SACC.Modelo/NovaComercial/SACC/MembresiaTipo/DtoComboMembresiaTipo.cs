using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.MembresiaTipo
{
    public class DtoComboMembresiaTipo
    {
        public DtoComboMembresiaTipo()
        {
            _MembresiaTipoDescripcion = String.Empty;
        }
        

        Int16 _MembresiaTipoId;
        public Int16 MembresiaTipoId { get { return _MembresiaTipoId; } set { _MembresiaTipoId = value; } }
        
        String _MembresiaTipoDescripcion;
        [StringLength(200)]
        public String MembresiaTipoDescripcion { get { return _MembresiaTipoDescripcion; } set { _MembresiaTipoDescripcion = value; } }
    }
}