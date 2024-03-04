using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class PaquetePM : ModeloBasePM
    {
        public PaquetePM()
        {
            _PaqueteId          = 0;
            _PaqueteDescripcion = String.Empty;
            _PaqueteTipoId      = 0;
        }


        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        String _Codigo;
        [StringLength(50)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }

        String _PaqueteDescripcion;
        [StringLength(200)]
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }

        Int32 _PaqueteTipoId;
        public Int32 PaqueteTipoId { get { return _PaqueteTipoId; } set { _PaqueteTipoId = value; } }
    }
}