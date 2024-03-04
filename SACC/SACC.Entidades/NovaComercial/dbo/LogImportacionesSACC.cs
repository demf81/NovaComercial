using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class LogImportacionesSACC : EntidadBase
    {
        public LogImportacionesSACC()
        {
            _Proceso = string.Empty;
            _Mensaje = string.Empty;
        }


        Int32 _LogImportacionesSACCid;
        public Int32 LogImportacionesSACCid { get { return _LogImportacionesSACCid; } set { _LogImportacionesSACCid = value; } }


        String _Proceso;
        [StringLength(250)]
        public String Proceso { get { return _Proceso; } set { _Proceso = value; } }


        DateTime? _Inicio;
        public DateTime? Inicio { get { return _Inicio; } set { _Inicio = value; } }


        DateTime? _Fin;
        public DateTime? Fin { get { return _Fin; } set { _Fin = value; } }
        

        Boolean _ErrorEstatus;
        public Boolean ErrorEstatus { get { return _ErrorEstatus; } set { _ErrorEstatus = value; } }


        String _Mensaje;
        [StringLength(250)]
        public String Mensaje { get { return _Mensaje; } set { _Mensaje = value; } }
    }
}