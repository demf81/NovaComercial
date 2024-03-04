using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class PaqueteTipo : EntidadBase
    {
        public PaqueteTipo()
        {
            _PaqueteTipoDescripcion = string.Empty;
        }


        Int32 _PaqueteTipoId;
        public Int32 PaqueteTipoId { get { return _PaqueteTipoId; } set { _PaqueteTipoId = value; } }
        
        String _PaqueteTipoDescripcion;
        [StringLength(100)]
        public String PaqueteTipoDescripcion { get { return _PaqueteTipoDescripcion; } set { _PaqueteTipoDescripcion = value; } }
    }
}