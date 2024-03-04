using System;


namespace SACC.Modelo.NovaComercial.SACC.MembresiaContrato
{
    public class DtoCtrlUserGridViewMembresiaContrato : ModeloBase
    {
        public DtoCtrlUserGridViewMembresiaContrato()
        {

        }
        

        Int32 _MembresiaContratoId;
        public Int32 MembresiaContratoId { get { return _MembresiaContratoId; } set { _MembresiaContratoId = value; } }
        
        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }
        
        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }
        
        String _ContratoDescripcion;
        public String ContratoDescripcion { get { return _ContratoDescripcion; } set { _ContratoDescripcion = value; } }
    }
}