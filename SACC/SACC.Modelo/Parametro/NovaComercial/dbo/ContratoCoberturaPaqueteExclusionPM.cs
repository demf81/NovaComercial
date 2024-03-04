using System;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class ContratoCoberturaPaqueteExclusionPM : ModeloBasePM
    {
        public ContratoCoberturaPaqueteExclusionPM()
        {
            _ContratoCoberturaPaqueteExclusionId = 0;
            _ContratoCoberturaPaqueteId          = -1;
            _PaqueteId                           = -1;
            _ItemDescripcion                     = String.Empty;
        }


        Int32 _ContratoCoberturaPaqueteExclusionId;
        public Int32 ContratoCoberturaPaqueteExclusionId { get { return _ContratoCoberturaPaqueteExclusionId; } set { _ContratoCoberturaPaqueteExclusionId = value; } }

        Int32 _ContratoCoberturaPaqueteId;
        public Int32 ContratoCoberturaPaqueteId { get { return _ContratoCoberturaPaqueteId; } set { _ContratoCoberturaPaqueteId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        String _ItemDescripcion;
        public String ItemDescripcion { get { return _ItemDescripcion; } set { _ItemDescripcion = value; } }

        Boolean _Excluido;
        public Boolean Excluido { get { return _Excluido; } set { _Excluido = value; } }
    }
}