using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class EmpresaContactoPM : ModeloBasePM
    {
        public EmpresaContactoPM()
        {
            _EmpresaContactoId = 0;
        }


        Int32 _EmpresaContactoId;
        public Int32 EmpresaContactoId { get { return _EmpresaContactoId; } set { _EmpresaContactoId = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }
    }
}