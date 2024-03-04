using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.PortalEmpresa
{
    public static class UsuarioContrato
    {
        public static List<Entidades.NovaComercial.PortalEmpresa.UsuarioContrato> Consultar(SqlOpciones pOpcion, int pUsuarioContratoId, int pUsuarioId, int pBaja)
        {
            Entidades.NovaComercial.PortalEmpresa.UsuarioContrato oE = new Entidades.NovaComercial.PortalEmpresa.UsuarioContrato();

            oE.UsuarioId = pUsuarioId;
            oE.UsuarioContratoId = pUsuarioContratoId;

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

            List<Entidades.NovaComercial.PortalEmpresa.UsuarioContrato> res = new List<Entidades.NovaComercial.PortalEmpresa.UsuarioContrato>();
            Entidades.NovaComercial.PortalEmpresa.UsuarioContrato item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.PortalEmpresa.UsuarioContrato();

                    item.UsuarioId         = int.Parse(dr["UsuarioId"].ToString());
                    item.UsuarioContratoId = int.Parse(dr["UsuarioContratoId"].ToString());

                    if (dr.Table.Columns.Contains("ContratoDescripcion"))
                        item.CampoComplemento_ContratoDescripcion = dr["ContratoDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("ContratoId"))
                        item.ContratoId = int.Parse(dr["ContratoId"].ToString());

                    if (dr.Table.Columns.Contains("NombreCompleto"))
                        item.CampoComplemento_NombreCompleto = dr["NombreCompleto"].ToString();

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    res.Add(item);
                }
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.PortalEmpresa.UsuarioContrato obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.PortalEmpresa.UsuarioContrato oE = new Entidades.NovaComercial.PortalEmpresa.UsuarioContrato();
            DataSet ds = new DataSet();

            oE.UsuarioContratoId     = obj.UsuarioContratoId;
            oE.UsuarioId             = obj.UsuarioId;
            oE.ContratoId            = obj.ContratoId;
            oE.UsuarioCreacionId     = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja                  = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.UsuarioContratoId == 0)
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

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["UsuarioContratoId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(int pUsuarioContratoId, int pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.PortalEmpresa.UsuarioContrato oE = new Entidades.NovaComercial.PortalEmpresa.UsuarioContrato();
            DataSet ds = new DataSet();

            oE.UsuarioContratoId = pUsuarioContratoId;
            oE.UsuarioBajaId     = pUsuarioId;
            oE.Baja              = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["UsuarioContratoId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }
    }
}