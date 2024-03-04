using System;


namespace SACC.Modelo.Parametro
{
    public class ParametroBase
    {
        public ParametroBase()
        {
            _Opcion    = 0;
            _EstatusID = 1;
            //_Baja      = false;
        }
        
        Int16 _Opcion;
        public Int16 Opcion { get { return _Opcion; } set { _Opcion = value; } }

        Int16 _EstatusID;
        public Int16 EstatusID { get { return _EstatusID; } set { _EstatusID = value; } }

        //Boolean? _Baja;
        //public Boolean? Baja { get { return _Baja; } set { _Baja = value; } }
    }
}