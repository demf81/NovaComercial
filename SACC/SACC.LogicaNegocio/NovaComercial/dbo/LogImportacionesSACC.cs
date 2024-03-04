using System;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class LogImportacionesSACC
    {
        public static Entidades.EntidadJsonResponse Guardar(short Option, Entidades.NovaComercial.dbo.LogImportacionesSACC obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.LogImportacionesSACC oE = new Entidades.NovaComercial.dbo.LogImportacionesSACC();
            DataSet ds = new DataSet();

            oE.LogImportacionesSACCid = obj.LogImportacionesSACCid;
            oE.Proceso                = obj.Proceso;
            oE.Inicio                 = obj.Inicio;
            oE.Fin                    = obj.Fin;
            oE.ErrorEstatus           = obj.ErrorEstatus;
            oE.Mensaje                = obj.Mensaje;
            oE.UsuarioCreacionId      = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId  = obj.UsuarioModificacionId;
            oE.Baja                   = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.LogImportacionesSACCid == 0)
            {
                ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;
            }
            else
            {
                if (obj.Baja == true)
                {
                    oE.UsuarioBajaId = obj.UsuarioBajaId;
                }

                ds = Util.Actualizar(SqlOpciones.Actualizar, oE).Resultado;
            }

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["LogImportacionesSACCid"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }
    }
}