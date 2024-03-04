using System;


namespace SACC.Modelo
{
    public class ModeloBase
    {
        public ModeloBase()
        {

        }


        private Int32 _UsuarioCreacionId;
        public Int32 UsuarioCreacionId { get { return _UsuarioCreacionId; } set { _UsuarioCreacionId = value; } }


        private DateTime? _FechaCreacion;
        public DateTime? FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }


        private Int32 _UsuarioModificacionId;
        public Int32 UsuarioModificacionId { get { return _UsuarioModificacionId; } set { _UsuarioModificacionId = value; } }


        private DateTime? _FechaModificacion;
        public DateTime? FechaModificacion { get { return _FechaModificacion; } set { _FechaModificacion = value; } }


        private Int32? _UsuarioBajaId;
        public Int32? UsuarioBajaId { get { return _UsuarioBajaId; } set { _UsuarioBajaId = value; } }


        private DateTime? _FechaBaja;
        public DateTime? FechaBaja { get { return _FechaBaja; } set { _FechaBaja = value; } }


        private Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }

        private Boolean? _Baja;
        public Boolean? Baja { get { return _Baja; } set { _Baja = value; } }
    }
}