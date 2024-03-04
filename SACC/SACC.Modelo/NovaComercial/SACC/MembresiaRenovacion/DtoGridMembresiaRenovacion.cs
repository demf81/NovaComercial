using System;


namespace SACC.Modelo.NovaComercial.SACC.MembresiaRenovacion
{
    public class DtoGridMembresiaRenovacion
    {
        public DtoGridMembresiaRenovacion()
        {

        }


        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }

        String _Fecha;
        public String Fecha { get { return _Fecha; } set { _Fecha = value; } }

        String _Vigencia;
        public String Vigencia { get { return _Vigencia; } set { _Vigencia = value; } }

        String _MembresiaTipoDescripcion;
        public String MembresiaTipoDescripcion { get { return _MembresiaTipoDescripcion; } set { _MembresiaTipoDescripcion = value; } }

        String _NumSocio;
        public String NumSocio { get { return _NumSocio; } set { _NumSocio = value; } }

        String _NombreComplento;
        public String NombreComplento { get { return _NombreComplento; } set { _NombreComplento = value; } }

        Int32 _CantidadBeneficiarios;
        public Int32 CantidadBeneficiarios { get { return _CantidadBeneficiarios; } set { _CantidadBeneficiarios = value; } }

        Int32 _CantidadAfiliados;
        public Int32 CantidadAfiliados { get { return _CantidadAfiliados; } set { _CantidadAfiliados = value; } }

        Int32 _CantidadAdicionales;
        public Int32 CantidadAdicionales { get { return _CantidadAdicionales; } set { _CantidadAdicionales = value; } }

        Int16 _MembresiaEstatusId;
        public Int16 MembresiaEstatusId { get { return _MembresiaEstatusId; } set { _MembresiaEstatusId = value; } }
    }
}