using System;


namespace SACC.Entidades
{
    public class EntidadBase
    {
        Int32 _UsuarioCreacionId;
        public Int32 UsuarioCreacionId { get { return _UsuarioCreacionId; } set { _UsuarioCreacionId = value; } }


        DateTime? _FechaCreacion;
        public DateTime? FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }


        Int32 _UsuarioModificacionId;
        public Int32 UsuarioModificacionId { get { return _UsuarioModificacionId; } set { _UsuarioModificacionId = value; } }


        DateTime? _FechaModificacion;
        public DateTime? FechaModificacion { get { return _FechaModificacion; } set { _FechaModificacion = value; } }


        Int32? _UsuarioBajaId;
        public Int32? UsuarioBajaId { get { return _UsuarioBajaId; } set { _UsuarioBajaId = value; } }


        DateTime? _FechaBaja;
        public DateTime? FechaBaja { get { return _FechaBaja; } set { _FechaBaja = value; } }


        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }


        Boolean? _Baja;
        public Boolean? Baja { get { return _Baja; } set { _Baja = value; } }








        //Int32 _Filtro_PersonaId;
        //public Int32 Filtro_PersonaId { get { return _Filtro_PersonaId; } set { _Filtro_PersonaId = value; } }

        String _Filtro_Nombre;
        public String Filtro_Nombre { get { return _Filtro_Nombre; } set { _Filtro_Nombre = value; } }

        //Int32 _Filtro_ContratoId;
        //public Int32 Filtro_ContratoId { get { return _Filtro_ContratoId; } set { _Filtro_ContratoId = value; } }

        //string _Filtro_ServicioDescripcion;
        //public string Filtro_ServicioDescripcion { get { return _Filtro_ServicioDescripcion; } set { _Filtro_ServicioDescripcion = value; } }

        //Int32 _Filtro_ServicioTipoId;
        //public Int32 Filtro_ServicioTipoId { get { return _Filtro_ServicioTipoId; } set { _Filtro_ServicioTipoId= value; } }

        //Int32? _Filtro_MedicamentoId;
        //public Int32? Filtro_MedicamentoId { get { return _Filtro_MedicamentoId; } set { _Filtro_MedicamentoId = value; } }

        //Int32? _Filtro_MaterialId;
        //public Int32? Filtro_MaterialId { get { return _Filtro_MaterialId; } set { _Filtro_MaterialId = value; } }

        //Int32? _Filtro_CirugiaId;
        //public Int32? Filtro_CirugiaId { get { return _Filtro_CirugiaId; } set { _Filtro_CirugiaId = value; } }

        //Int32? _Filtro_EstudioId;
        //public Int32? Filtro_EstudioId { get { return _Filtro_EstudioId; } set { _Filtro_EstudioId = value; } }

        //Int32? _Filtro_ServicioId;
        //public Int32? Filtro_ServicioId { get { return _Filtro_ServicioId; } set { _Filtro_ServicioId = value; } }

        //Int32? _Filtro_CveFamiliar;
        //public Int32? Filtro_CveFamiliar { get { return _Filtro_CveFamiliar; } set { _Filtro_CveFamiliar = value; } }

        //Decimal _CampoComplemento_Edad;
        //public Decimal CampoComplemento_Edad { get { return _CampoComplemento_Edad; } set { _CampoComplemento_Edad = value; } }

        //String _CampoComplemento_RangoEdad;
        //public String CampoComplemento_RangoEdad { get { return _CampoComplemento_RangoEdad; } set { _CampoComplemento_RangoEdad = value; } }

        //String _CampoComplemento_Genero;
        //public String CampoComplemento_Genero { get { return _CampoComplemento_Genero; } set { _CampoComplemento_Genero = value; } }

        //Int32 _CampoComplemento_PaqueteId;
        //public Int32 CampoComplemento_PaqueteId { get { return _CampoComplemento_PaqueteId; } set { _CampoComplemento_PaqueteId = value; } }

        //String _CampoComplemento_PaqueteDescripcion;
        //public String CampoComplemento_PaqueteDescripcion { get { return _CampoComplemento_PaqueteDescripcion; } set { _CampoComplemento_PaqueteDescripcion = value; } }

        Boolean _CampoComplemento_Seleccionado;
        public Boolean CampoComplemento_Seleccionado { get { return _CampoComplemento_Seleccionado; } set { _CampoComplemento_Seleccionado = value; } }

        String _CampoComplemento_SocioId;
        public String CampoComplemento_SocioId { get { return _CampoComplemento_SocioId; } set { _CampoComplemento_SocioId = value; } }

        Int32 _CampoComplemento_ContratoId;
        public Int32 CampoComplemento_ContratoId { get { return _CampoComplemento_ContratoId; } set { _CampoComplemento_ContratoId = value; } }

        String _CampoComplemento_ContratoDescripcion;
        public String CampoComplemento_ContratoDescripcion { get { return _CampoComplemento_ContratoDescripcion; } set { _CampoComplemento_ContratoDescripcion = value; } }

        String _CampoComplemento_EmpresaDescripcion;
        public String CampoComplemento_EmpresaDescripcion { get { return _CampoComplemento_EmpresaDescripcion; } set { _CampoComplemento_EmpresaDescripcion = value; } }

        //String _CampoComplemento_ContratoTipoDescripcion;
        //public String CampoComplemento_ContratoTipoDescripcion { get { return _CampoComplemento_ContratoTipoDescripcion; } set { _CampoComplemento_ContratoTipoDescripcion = value; } }

        //String _CampoComplemento_EmpresaPlantaDescripcion;
        //public String CampoComplemento_EmpresaPlantaDescripcion { get { return _CampoComplemento_EmpresaPlantaDescripcion; } set { _CampoComplemento_EmpresaPlantaDescripcion = value; } }

        //String _CampoComplemento_PaqueteTipoDescripcion;
        //public String CampoComplemento_PaqueteTipoDescripcion { get { return _CampoComplemento_PaqueteTipoDescripcion; } set { _CampoComplemento_PaqueteTipoDescripcion = value; } }

        String _CampoComplemento_ServicioDescripcion;
        public String CampoComplemento_ServicioDescripcion { get { return _CampoComplemento_ServicioDescripcion; } set { _CampoComplemento_ServicioDescripcion = value; } }

        //String _CampoComplemento_ItemTipoDescripcion;
        //public String CampoComplemento_ItemTipoDescripcion { get { return _CampoComplemento_ItemTipoDescripcion; } set { _CampoComplemento_ItemTipoDescripcion = value; } }

        String _CampoComplemento_ServicioTipoDescripcion;
        public String CampoComplemento_ServicioTipoDescripcion { get { return _CampoComplemento_ServicioTipoDescripcion; } set { _CampoComplemento_ServicioTipoDescripcion = value; } }

        String _CampoComplemento_MedicamentoCuadroTipoDescripcion;
        public String CampoComplemento_MedicamentoCuadroTipoDescripcion { get { return _CampoComplemento_MedicamentoCuadroTipoDescripcion; } set { _CampoComplemento_MedicamentoCuadroTipoDescripcion = value; } }

        String _CampoComplemento_Persona;
        public String CampoComplemento_Persona { get { return _CampoComplemento_Persona; } set { _CampoComplemento_Persona = value; } }

        Decimal _CampoComplemento_PrecioVentaPublico;
        public Decimal CampoComplemento_PrecioVentaPublico { get { return _CampoComplemento_PrecioVentaPublico; } set { _CampoComplemento_PrecioVentaPublico = value; } }

        //String _CampoComplemento_CoberturaDescripcion;
        //public String CampoComplemento_CoberturaDescripcion { get { return _CampoComplemento_CoberturaDescripcion; } set { _CampoComplemento_CoberturaDescripcion = value; } }

        //String _CampoComplemento_ContratoCoberturaDescripcion;
        //public String CampoComplemento_ContratoCoberturaDescripcion { get { return _CampoComplemento_ContratoCoberturaDescripcion; } set { _CampoComplemento_ContratoCoberturaDescripcion = value; } }

        String _CampoComplemento_NombreCompleto;
        public String CampoComplemento_NombreCompleto { get { return _CampoComplemento_NombreCompleto; } set { _CampoComplemento_NombreCompleto = value; } }

        //String _CampoComplemento_CantidadItem;
        //public String CampoComplemento_CantidadItem { get { return _CampoComplemento_CantidadItem; } set { _CampoComplemento_CantidadItem = value; } }

        String _CampoComplemento_StrFecha;
        public String CampoComplemento_StrFecha { get { return _CampoComplemento_StrFecha; } set { _CampoComplemento_StrFecha = value; } }
    }
}