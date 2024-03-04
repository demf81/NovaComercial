using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class Estudio : EntidadBase
    {
        public Estudio()
        {
            _EstudioDescripcion = string.Empty;
            _Codigo             = string.Empty;
            _Mnemonico          = string.Empty;
        }
        
        Int32 _EstudioId;
        public Int32 EstudioId { get { return _EstudioId; } set { _EstudioId = value; } }
        
        String _EstudioDescripcion;
        [StringLength(100)]
        public String EstudioDescripcion { get { return _EstudioDescripcion; } set { _EstudioDescripcion = value; } }
        
        String _Codigo;
        [StringLength(200)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }
        
        String _Mnemonico;
        [StringLength(20)]
        public String Mnemonico { get { return _Mnemonico; } set { _Mnemonico = value; } }
        
        Int32? _SeccionId;
        public Int32? SeccionId { get { return _SeccionId; } set { _SeccionId = value; } }
        
        Boolean? _RequiereConfirmacion;
        public Boolean? RequiereConfirmacion { get { return _RequiereConfirmacion; } set { _RequiereConfirmacion = value; } }
        
        Int32? _ServicioId;
        public Int32? ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }
    }
}