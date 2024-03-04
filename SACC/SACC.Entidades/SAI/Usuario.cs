using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACC.Entidades.SAI
{
    public class Usuario
    {
        Boolean _AutenticacionCorrecta;
        public Boolean AutenticacionCorrecta { get { return _AutenticacionCorrecta; } set { _AutenticacionCorrecta = value; } }


        int _UsuarioId;
        public int UsuarioId { get { return _UsuarioId; } set { _UsuarioId = value; } }


        string _CuentaRed;
        public string CuentaRed { get { return _CuentaRed; } set { _CuentaRed = value; } }


        string _Nombre;
        public string Nombre{ get { return _Nombre; } set { _Nombre = value; } }


        string _NombreCompleto;
        public string NombreCompleto { get { return _NombreCompleto; } set { _NombreCompleto = value; } }


        string _Correo;
        public string Correo { get { return _Correo; } set { _Correo = value; } }


        byte[] _Foto;
        public byte[] Foto { get { return _Foto; } set { _Foto = value; } }


        public DataTable Permisos { get; set; }
    }
}