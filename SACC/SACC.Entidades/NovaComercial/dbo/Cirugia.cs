using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class Cirugia : EntidadBase
    {
        public Cirugia()
        {
            _CirugiaDescripcion   = string.Empty;
            _IndicacionesPaciente = string.Empty;
            _IndicacionesPersonal = string.Empty;
        }
        
        Int32 _CirugiaId;
        public Int32 CirugiaId { get { return _CirugiaId; } set { _CirugiaId = value; } }
        
        String _CirugiaDescripcion;
        [StringLength(250)]
        public String CirugiaDescripcion { get { return _CirugiaDescripcion; } set { _CirugiaDescripcion = value; } }
        
        Int32? _Codigo;
        public Int32? Codigo { get { return _Codigo; } set { _Codigo = value; } }
        
        Decimal? _Precio;
        public Decimal? Precio { get { return _Precio; } set { _Precio = value; } }
                
        Decimal? _Iva;
        public Decimal? Iva { get { return _Iva; } set { _Iva = value; } }
        
        Int32? _TipoHonorario;
        public Int32? TipoHonorario { get { return _TipoHonorario; } set { _TipoHonorario = value; } }
        
        Boolean? _GeneraCargo;
        public Boolean? GeneraCargo { get { return _GeneraCargo; } set { _GeneraCargo = value; } }
        
        Boolean? _RequiereAutorizacion;
        public Boolean? RequiereAutorizacion { get { return _RequiereAutorizacion; } set { _RequiereAutorizacion = value; } }
        
        String _IndicacionesPaciente;
        [StringLength(500)]
        public String IndicacionesPaciente { get { return _IndicacionesPaciente; } set { _IndicacionesPaciente = value; } }
        
        String _IndicacionesPersonal;
        public String IndicacionesPersonal { get { return _IndicacionesPersonal; } set { _IndicacionesPersonal = value; } }
        
        Int32? _DuracionMin;
        public Int32? DuracionMin { get { return _DuracionMin; } set { _DuracionMin = value; } }
    }
}