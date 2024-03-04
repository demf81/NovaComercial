using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.PaqueteTipo
{
    public class DtoGridPaqueteTipo
    {
        public DtoGridPaqueteTipo()
        {
            _PaqueteTipoDescripcion = String.Empty;
        }


        Int32 _PaqueteTipoId;
        public Int32 PaqueteTipoId { get { return _PaqueteTipoId; } set { _PaqueteTipoId = value; } }

        String _PaqueteTipoDescripcion;
        [StringLength(200)]
        public String PaqueteTipoDescripcion { get { return _PaqueteTipoDescripcion; } set { _PaqueteTipoDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}