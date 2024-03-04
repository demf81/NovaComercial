using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class PersonaAsociado
    {
        public static List<Entidades.NovaComercial.dbo.PersonaAsociado> Consultar(SqlOpciones pOpcion, int pPersonaId, int pBaja)
        {
            Entidades.NovaComercial.dbo.PersonaAsociado oE = new Entidades.NovaComercial.dbo.PersonaAsociado();

            oE.PersonaId = pPersonaId;

            switch (pBaja)
            {
                case 0:
                    oE.Baja = false;
                    break;
                case 1:
                    oE.Baja = true;
                    break;
                default:
                    oE.Baja = null;
                    break;
            }

            DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

            List<Entidades.NovaComercial.dbo.PersonaAsociado> res = new List<Entidades.NovaComercial.dbo.PersonaAsociado>();
            Entidades.NovaComercial.dbo.PersonaAsociado item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.PersonaAsociado();

                    item.PersonaId = int.Parse(dr["PersonaId"].ToString());
                    item.AsociadoId = int.Parse(dr["AsociadoId"].ToString());

                    if (dr.Table.Columns.Contains("vcAfiliado"))
                        item.CampoComplemento_SocioId = dr["vcAfiliado"].ToString();

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    res.Add(item);
                }
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.PersonaAsociado obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.PersonaAsociado oE = new Entidades.NovaComercial.dbo.PersonaAsociado();
            DataSet ds = new DataSet();

            oE.PersonaAsociadoId     = obj.PersonaAsociadoId;
            oE.PersonaId             = obj.PersonaId;
            oE.AsociadoId            = obj.AsociadoId;
            oE.UsuarioCreacionId     = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja                  = Convert.ToBoolean(Convert.ToInt16(0));

            if (obj.PersonaId == 0)
            {
                ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;
            }

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["PersonaAsociadoId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }
    }
}