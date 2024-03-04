using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Cliente
{
    public class DtoGridCliente
    {
        public DtoGridCliente()
        {
            _ClienteDescripcion      = String.Empty;
            _Codigo                  = String.Empty;
            _ClienteTipoDescripcion  = String.Empty;
        }


        Int32 _ClienteId;
        public Int32 ClienteId { get { return _ClienteId; } set { _ClienteId = value; } }

        String _ClienteDescripcion;
        [StringLength(200)]
        public String ClienteDescripcion { get { return _ClienteDescripcion; } set { _ClienteDescripcion = value; } }

        String _Codigo;
        [StringLength(50)]
        public String Codigo { get { return _Codigo; } set { _Codigo  = value; } }

        String _ClienteTipoDescripcion;
        [StringLength(100)]
        public String ClienteTipoDescripcion { get { return _ClienteTipoDescripcion; } set { _ClienteTipoDescripcion = value; } }

        //String _InicioOperaciones;
        //public String InicioOperaciones { get { return _InicioOperaciones; } set { _InicioOperaciones = value; } }

        //String _CorreoElectronico;
        //[StringLength(100)]
        //public String CorreoElectronico { get { return _CorreoElectronico; } set { _CorreoElectronico = value; } }

        Int32 _CantidadEmpresa;
        public Int32 CantidadEmpresas { get { return _CantidadEmpresa; } set { _CantidadEmpresa = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}