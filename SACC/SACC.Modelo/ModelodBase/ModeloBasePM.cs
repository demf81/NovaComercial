using System;


namespace SACC.Modelo
{
    public class ModeloBasePM
    {
        public ModeloBasePM()
        {
            _Opcion = 0;
            _EstatusId = 1;
        }

        Int16 _Opcion;
        public Int16 Opcion { get { return _Opcion; } set { _Opcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}