using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.PaqueteTipo
{
    public class DtoPaqueteTipo : ModeloBase
    {
        public DtoPaqueteTipo()
        {
            _PaqueteTipoDescripcion = String.Empty;
        }


        Int16 _PaqueteTipoId;
        public Int16 PaqueteTipoId { get { return _PaqueteTipoId; } set { _PaqueteTipoId = value; } }

        String _PaqueteTipoDescripcion;
        [StringLength(200)]
        public String PaqueteTipoDescripcion { get { return _PaqueteTipoDescripcion; } set { _PaqueteTipoDescripcion = value; } }
    }
}