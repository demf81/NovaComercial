using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACC.Entidades.Registro.dbo
{
    public class CheckUp_Programacion : EntidadBase
    {
        public CheckUp_Programacion()
        {
            _Factura = string.Empty;
            _Comentario = string.Empty;
        }


        Int32 _ProgramacionId;
        public Int32 ProgramacionId { get { return _ProgramacionId; } set { _ProgramacionId = value; } }


        DateTime? _ProgramacionFecha;
        public DateTime? ProgramacionFecha { get { return _ProgramacionFecha; } set { _ProgramacionFecha = value; } }


        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }


        Boolean? _EsForaneo;
        public Boolean? EsForaneo { get { return _EsForaneo; } set { _EsForaneo = value; } }


        String _Factura;
        [StringLength(100)]
        public String Factura { get { return _Factura; } set { _Factura = value; } }


        String _Comentario;
        [StringLength(500)]
        public String Comentario { get { return _Comentario; } set { _Comentario = value; } }


        Int32 _ProgramacionEstatusId;
        public Int32 ProgramacionEstatusId { get { return _ProgramacionEstatusId; } set { _ProgramacionEstatusId = value; } }
    }
}