using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACC.Entidades.Registro.dbo
{
    public class CheckUp_Persona : EntidadBase
    {
        public CheckUp_Persona()
        {
            _Nombre = string.Empty;
            _Correo = string.Empty;
            _TelefonoOficina = string.Empty;
            _TelefonoOtro = string.Empty;
            _Genero = string.Empty;
            _NombreSupervisor = string.Empty;
        }


        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }


        Int32 _TerniumId;
        public Int32 TerniumId { get { return _TerniumId; } set { _TerniumId = value; } }


        Int32 _NovaId;
        public Int32 NovaId { get { return _NovaId; } set { _NovaId = value; } }


        Int16 _FamiliarId;
        public Int16 FamiliarId { get { return _FamiliarId; } set { _FamiliarId = value; } }


        String _Nombre;
        [StringLength(100)]
        public String Nombre { get { return _Nombre; } set { _Nombre = value; } }


        Boolean _Estatus;
        public Boolean Estatus { get { return _Estatus; } set { _Estatus = value; } }


        String _Correo;
        [StringLength(100)]
        public String Correo { get { return _Correo; } set { _Correo = value; } }


        String _TelefonoOficina;
        [StringLength(20)]
        public String TelefonoOficina { get { return _TelefonoOficina; } set { _TelefonoOficina = value; } }


        String _TelefonoOtro;
        [StringLength(20)]
        public String TelefonoOtro { get { return _TelefonoOtro; } set { _TelefonoOtro = value; } }


        String _Genero;
        [StringLength(1)]
        public String Genero { get { return _Genero; } set { _Genero = value; } }


        Int32 _PlantaId;
        public Int32 PlantaId { get { return _PlantaId; } set { _PlantaId = value; } }


        String _NombreSupervisor;
        [StringLength(100)]
        public System.String NombreSupervisor { get { return _NombreSupervisor; } set { if (value.Length >= 100) _NombreSupervisor = value.Substring(0, 100); else _NombreSupervisor = value; } }


        DateTime? _FechaNacimiento;
        public DateTime? FechaNacimiento { get { return _FechaNacimiento; } set { _FechaNacimiento = value; } }


        DateTime? _FechaCheckUpAnterior;
        public DateTime? FechaCheckUpAnterior { get { return _FechaCheckUpAnterior; } set { _FechaCheckUpAnterior = value; } }

        
        Int32 _SACC_PersonaId;
        public Int32 SACC_PersonaId { get { return _SACC_PersonaId; } set { _SACC_PersonaId = value; } }
    }
}