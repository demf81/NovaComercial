using System;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class VentaCancelacion : EntidadBase
    {
        public VentaCancelacion()
        {

        }


        Int32 _VentaCancelacionId;
        public Int32 VentaCancelacionId { get { return _VentaCancelacionId; } set { _VentaCancelacionId = value; } }

        Int32 _VentaId;
        public Int32 VentaId { get { return _VentaId; } set { _VentaId = value; } }

        Int16 _VentaMotivoCancelacionTipoId;
        public Int16 VentaMotivoCancelacionTipoId { get { return _VentaMotivoCancelacionTipoId; } set { _VentaMotivoCancelacionTipoId = value; } }

        String _Comentario;
        public String Comentario { get { return _Comentario; } set { _Comentario = value; } }
    }
}