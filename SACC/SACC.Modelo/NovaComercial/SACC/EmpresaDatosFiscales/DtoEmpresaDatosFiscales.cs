using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.EmpresaDatosFiscales
{
    public class DtoEmpresaDatosFiscales : ModeloBase
    {
        public DtoEmpresaDatosFiscales()
        {
            _RazonSocial        = String.Empty;
            _RFC                = String.Empty;
            _Colonia            = String.Empty;
            _Calle              = String.Empty;
            _NumeroExterior     = String.Empty;
            _NumeroInterior     = String.Empty;
            _CorreoElectronico  = String.Empty;
        }


        Int32 _EmpresaDatosFiscalesId;
        public Int32 EmpresaDatosFiscalesId { get { return _EmpresaDatosFiscalesId; } set { _EmpresaDatosFiscalesId = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }

        String _RazonSocial;
        [StringLength(100)]
        public String RazonSocial { get { return _RazonSocial; } set { _RazonSocial = value; } }

        String _RFC;
        [StringLength(100)]
        public String RFC { get { return _RFC; } set { _RFC = value; } }

        Int32 _PaisId;
        public Int32 PaisId { get { return _PaisId; } set { _PaisId = value; } }

        Int32 _EstadoId;
        public Int32 EstadoId { get { return _EstadoId; } set { _EstadoId = value; } }

        Int32 _MunicipioId;
        public Int32 MunicipioId { get { return _MunicipioId; } set { _MunicipioId = value; } }

        String _Colonia;
        [StringLength(100)]
        public String Colonia { get { return _Colonia; } set { _Colonia = value; } }

        String _Calle;
        [StringLength(100)]
        public String Calle { get { return _Calle ; } set { _Calle = value; } }

        String _NumeroExterior;
        [StringLength(6)]
        public String NumeroExterior { get { return _NumeroExterior; } set { _NumeroExterior = value; } }

        String _NumeroInterior;
        [StringLength(6)]
        public String NumeroInterior { get { return _NumeroInterior; } set { _NumeroInterior = value; } }

        Int32 _CodigoPostal;
        public Int32 CodigoPostal { get { return _CodigoPostal; } set { _CodigoPostal = value; } }

        String _CorreoElectronico;
        [StringLength(100)]
        public String CorreoElectronico { get { return _CorreoElectronico; } set { _CorreoElectronico = value; } }
    }
}