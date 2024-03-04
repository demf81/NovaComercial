using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class EmpresaDatosFiscalesPM : ModeloBasePM
    {
        public EmpresaDatosFiscalesPM()
        {
            _EmpresaDatosFiscalesId = 0;
            _EmpresaId              = 0;
        }


        Int32 _EmpresaDatosFiscalesId;
        public Int32 EmpresaDatosFiscalesId { get { return _EmpresaDatosFiscalesId; } set { _EmpresaDatosFiscalesId = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }
    }
}