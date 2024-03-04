using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACC.Entidades.NovaComercial.PortalEmpresa
{
    public class Usuario : EntidadBase
    {
        public Usuario()
        {
            _Nombre = string.Empty;
            _Paterno = string.Empty;
            _Materno = string.Empty;
            _Telefono = string.Empty;
            _Correo = string.Empty;
            _Contrasenia = string.Empty;
            _FechaVigenciaDesde = DateTime.Now;
            _FechaVigenciaHasta = DateTime.Now;
        }


        Int32 _UsuarioId;
        public Int32 UsuarioId { get { return _UsuarioId; } set { _UsuarioId = value; } }


        String _Nombre;
        [StringLength(50)]
        public String Nombre { get { return _Nombre; } set { _Nombre = value; } }


        String _Paterno;
        [StringLength(50)]
        public String Paterno { get { return _Paterno; } set { _Paterno = value; } }


        String _Materno;
        [StringLength(50)]
        public String Materno { get { return _Materno; } set { _Materno = value; } }


        String _Telefono;
        [StringLength(50)]
        public String Telefono { get { return _Telefono; } set { _Telefono = value; } }


        String _Correo;
        [StringLength(100)]
        public String Correo { get { return _Correo; } set { _Correo = value; } }


        String _Contrasenia;
        [StringLength(50)]
        public String Contrasenia { get { return _Contrasenia; } set { _Contrasenia = value; } }


        DateTime _FechaVigenciaDesde;
        public DateTime FechaVigenciaDesde { get { return _FechaVigenciaDesde; } set { _FechaVigenciaDesde = value; } }


        DateTime _FechaVigenciaHasta;
        public DateTime FechaVigenciaHasta { get { return _FechaVigenciaHasta; } set { _FechaVigenciaHasta = value; } }
    }
}