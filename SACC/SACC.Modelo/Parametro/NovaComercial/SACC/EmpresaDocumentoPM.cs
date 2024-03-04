using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class EmpresaDocumentoPM : ModeloBasePM
    {
        public EmpresaDocumentoPM()
        {

        }


        Int32 _EmpresaDocumentoId;
        public Int32 EmpresaDocumentoId { get { return _EmpresaDocumentoId; } set { _EmpresaDocumentoId = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }
    }
}