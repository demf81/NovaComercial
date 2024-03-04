using System;
using System.Data;


namespace SACC.LogicaNegocio.Registro.dbo
{
    public class CheckUp_Persona
    {
        public static Entidades.EntidadJsonResponse Guardar(SACC.Entidades.Registro.dbo.CheckUp_Persona obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.Registro.dbo.CheckUp_Persona oE = new Entidades.Registro.dbo.CheckUp_Persona();
            DataSet ds = new DataSet();

            oE.PersonaId             = obj.PersonaId;
            oE.TerniumId             = obj.TerniumId;
            oE.NovaId                = obj.NovaId;
            oE.FamiliarId            = obj.FamiliarId;
            oE.Nombre                = obj.Nombre;
            oE.Estatus               = obj.Estatus;
            oE.Correo                = obj.Correo;
            oE.TelefonoOficina       = obj.TelefonoOficina;
            oE.TelefonoOtro          = obj.TelefonoOtro;
            oE.Genero                = obj.Genero;
            oE.PlantaId              = obj.PlantaId;
            oE.NombreSupervisor      = obj.NombreSupervisor;
            oE.FechaNacimiento       = obj.FechaNacimiento;
            oE.FechaCheckUpAnterior  = obj.FechaCheckUpAnterior;
            oE.SACC_PersonaId        = obj.SACC_PersonaId;
            oE.UsuarioCreacionId     = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja                  = Convert.ToBoolean(Convert.ToInt16(0));

            if (obj.PersonaId == 0)
            {
                //NUEVO
                ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;
            }
            else
            {
                //    if (pBaja == "1")
                //    {
                //        oCE.FechaBaja = System.DateTime.Now;
                //        oCE.UsuarioBajaId = 0;
                //    }

                //oCE.PaqueteId = pPaqueteId;
                //oE.FechaModificacion = System.DateTime.Now;
                ds = Util.Actualizar(SqlOpciones.Actualizar, oE).Resultado;

            }

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["PersonaId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(int pPersonaId, int pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.Registro.dbo.CheckUp_Persona oE = new Entidades.Registro.dbo.CheckUp_Persona();
            DataSet ds = new DataSet();

            oE.PersonaId     = pPersonaId;
            oE.UsuarioBajaId = pUsuarioId;
            oE.Baja          = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["PersonaId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }
    }
}