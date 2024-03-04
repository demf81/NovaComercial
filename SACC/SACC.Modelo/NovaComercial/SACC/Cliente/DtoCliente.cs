using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Cliente
{
    public class DtoCliente : ModeloBase
    {
        public DtoCliente()
        {
            _ClienteDescripcion = String.Empty;
        }


        Int32 _ClienteId;
        public Int32 ClienteId { get { return _ClienteId; } set { _ClienteId = value; } }

        String _ClienteDescripcion;
        [StringLength(200)]
        public String ClienteDescripcion { get { return _ClienteDescripcion; } set { _ClienteDescripcion = value; } }

        String _Codigo;
        [StringLength(50)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }

        Int32 _ClienteTipoId;
        public Int32 ClienteTipoId { get { return _ClienteTipoId; } set { _ClienteTipoId = value; } }

        Boolean? _BajaProgramada;
        public Boolean? BajaProgramada { get { return _BajaProgramada; } set { _BajaProgramada = value; } }

        DateTime? _FechaBajaProgramada;
        public DateTime? FechaBajaProgramada { get { return _FechaBajaProgramada; } set { _FechaBajaProgramada = value; } }

        Boolean? _PreActivo;
        public Boolean? PreActivo { get { return _PreActivo; } set { _PreActivo = value; } }

        DateTime? _FechaPreActivo;
        public DateTime? FechaPreActivo { get { return _FechaPreActivo; } set { _FechaPreActivo = value; } }
    }
}