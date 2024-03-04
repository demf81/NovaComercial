using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Empresa
{
    public class DtoEmpresa : ModeloBase
    {
        public DtoEmpresa()
        {
            _EmpresaDescripcion = String.Empty;
            _Codigo             = String.Empty;
            //_RazonSocial        = String.Empty;
            //_RFC                = String.Empty;
            //_PaisId             = -1;
            //_EstadoId           = -1;
            //_MunicipioId        = -1;
            //_Colonia            = String.Empty;
            //_Calle              = String.Empty;
            //_NumeroExterior     = String.Empty;
            //_NumeroInterior     = String.Empty;
            //_CodigoPostal       = -1;
            //_CorreoElectronico  = String.Empty;
            _EmpresaTipoId      = -1;
            _MetodoPagoId       = -1;
            _FormaPagoId        = -1;
            _FrecuenciaPagoId   = -1;
            _DiaPago            = 1;
            _InicioOperaciones  = DateTime.Now;
            _EmpresaVigenciaId  = -1;
        }


        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }
        
        String _EmpresaDescripcion;
        [StringLength(200)]
        public String EmpresaDescripcion { get { return _EmpresaDescripcion; } set { _EmpresaDescripcion = value; } }

        String _Codigo;
        [StringLength(50)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }

        //String _RazonSocial;
        //[StringLength(100)]
        //public String RazonSocial { get { return _RazonSocial; } set { _RazonSocial = value; } }

        //String _RFC;
        //[StringLength(20)]
        //public String RFC { get { return _RFC; } set { _RFC = value; } }

        //Int32 _PaisId;
        //public Int32 PaisId { get { return _PaisId; } set { _PaisId = value; } }

        //Int32 _EstadoId;
        //public Int32 EstadoId { get { return _EstadoId; } set { _EstadoId = value; } }

        //Int32 _MunicipioId;
        //public Int32 MunicipioId { get { return _MunicipioId; } set { _MunicipioId = value; } }

        //String _Colonia;
        //[StringLength(100)]
        //public String Colonia { get { return _Colonia; } set { _Colonia = value; } }

        //String _Calle;
        //[StringLength(100)]
        //public String Calle { get { return _Calle; } set { _Calle = value; } }

        //String _NumeroExterior;
        //[StringLength(6)]
        //public String NumeroExterior { get { return _NumeroExterior; } set { _NumeroExterior = value; } }

        //String _NumeroInterior;
        //[StringLength(6)]
        //public String NumeroInterior { get { return _NumeroInterior; } set { _NumeroInterior = value; } }

        //Int32 _CodigoPostal;
        //public Int32 CodigoPostal { get { return _CodigoPostal; } set { _CodigoPostal = value; } }

        //String _CorreoElectronico;
        //[StringLength(100)]
        //public String CorreoElectronico { get { return _CorreoElectronico; } set { _CorreoElectronico = value; } }

        Int32 _EmpresaTipoId;
        public Int32 EmpresaTipoId { get { return _EmpresaTipoId; } set { _EmpresaTipoId = value; } }

        Int32 _MetodoPagoId;
        public Int32 MetodoPagoId { get { return _MetodoPagoId; } set { _MetodoPagoId = value; } }

        Int32 _FormaPagoId;
        public Int32 FormaPagoId { get { return _FormaPagoId; } set { _FormaPagoId = value; } }

        Int32 _FrecuenciaPagoId;
        public Int32 FrecuenciaPagoId { get { return _FrecuenciaPagoId; } set { _FrecuenciaPagoId = value; } }

        Int32 _DiaPago;
        public Int32 DiaPago { get { return _DiaPago; } set { _DiaPago = value; } }

        Int32 _EmpresaVigenciaId;
        public Int32 EmpresaVigenciaId { get { return _EmpresaVigenciaId; } set { _EmpresaVigenciaId = value; } }

        DateTime _InicioOperaciones;
        public DateTime InicioOperaciones { get { return _InicioOperaciones; } set { _InicioOperaciones = value; } }
    }
}