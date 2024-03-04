using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class PersonaPaquete
    {
        public static List<Entidades.NovaComercial.dbo.PersonaPaquete> Consultar(SqlOpciones pOpcion, int pPersonaPaqueteId, int pPersonaId, int pContratoId, int pBaja)
        {
            Entidades.NovaComercial.dbo.PersonaPaquete oE = new Entidades.NovaComercial.dbo.PersonaPaquete();

            oE.PersonaPaqueteId       = pPersonaPaqueteId;
            oE.PersonaId              = pPersonaId;
            oE.ContratoId             = pContratoId;

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

            List<Entidades.NovaComercial.dbo.PersonaPaquete> res = new List<Entidades.NovaComercial.dbo.PersonaPaquete>();
            Entidades.NovaComercial.dbo.PersonaPaquete item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.PersonaPaquete();

                    if (dr.Table.Columns.Contains("PersonaPaqueteId"))
                        item.PersonaPaqueteId = int.Parse(dr["PersonaPaqueteId"].ToString());

                    if (dr.Table.Columns.Contains("PersonaId"))
                        item.PersonaId = int.Parse(dr["PersonaId"].ToString());

                    if (dr.Table.Columns.Contains("NombreCompleto"))
                        item.CampoComplemento_NombreCompleto = dr["NombreCompleto"].ToString();

                    item.PaqueteId                     = int.Parse(dr["PaqueteId"].ToString());
                    item.ContratoId                    = int.Parse(dr["ContratoId"].ToString());

                    if (dr.Table.Columns.Contains("ContratoProductoId"))
                        item.ContratoProductoId = int.Parse(dr["ContratoProductoId"].ToString());

                    if (dr.Table.Columns.Contains("Seleccionado"))
                        item.CampoComplemento_Seleccionado = dr["Seleccionado"].ToString() == "0" ? false : true;

                    //if (dr.Table.Columns.Contains("PaqueteDescripcion"))
                        //item.CampoComplemento_PaqueteDescripcion = dr["PaqueteDescripcion"].ToString();
                    
                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    res.Add(item);
                }
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.PersonaPaquete obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.PersonaPaquete oE = new Entidades.NovaComercial.dbo.PersonaPaquete();
            DataSet ds = new DataSet();

            oE.PersonaPaqueteId      = obj.PersonaPaqueteId;
            oE.PersonaId             = obj.PersonaId;
            oE.ContratoProductoId    = obj.ContratoProductoId;
            oE.PaqueteId             = obj.PaqueteId;
            oE.ContratoId            = obj.ContratoId;
            oE.UsuarioCreacionId     = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja                  = Convert.ToBoolean(Convert.ToInt16(0));

            if (obj.PersonaPaqueteId == 0)
            {
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

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["PersonaPaqueteId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(int pPaquetePersonaId, int pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.PersonaPaquete oE = new Entidades.NovaComercial.dbo.PersonaPaquete();
            DataSet ds = new DataSet();

            oE.PersonaPaqueteId = pPaquetePersonaId;
            oE.UsuarioBajaId    = pUsuarioId;
            oE.Baja             = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["PersonaPaqueteId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }
    }
}