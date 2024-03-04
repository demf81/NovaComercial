using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACC.Entidades.NovaComercial.PortalEmpresa
{
    public class UsuarioContrato : EntidadBase
    {
        public UsuarioContrato()
        {

        }


        Int32 _UsuarioContratoId;
        public Int32 UsuarioContratoId { get { return _UsuarioContratoId; } set { _UsuarioContratoId = value; } }


        Int32 _UsuarioId;
        public Int32 UsuarioId { get { return _UsuarioId; } set { _UsuarioId = value; } }


        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }
    }
}