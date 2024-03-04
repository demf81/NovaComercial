using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.PortalEmpresa
{
    public static class Usuario
    {
        public static List<Entidades.NovaComercial.PortalEmpresa.Usuario> Consultar(SqlOpciones pOpcion, int pUsuarioId, string pNombre, string pPaterno, string pMaterno, string pCorreo, int pBaja)
        {
            Entidades.NovaComercial.PortalEmpresa.Usuario oE = new Entidades.NovaComercial.PortalEmpresa.Usuario();

            oE.UsuarioId = pUsuarioId;

            if (pNombre != "")
                oE.Nombre = pNombre;

            if (pPaterno != "")
                oE.Paterno = pPaterno;

            if (pMaterno != "")
                oE.Materno = pMaterno;

            if (pCorreo != "")
                oE.Correo = pCorreo;

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

            List<Entidades.NovaComercial.PortalEmpresa.Usuario> res = null;
            Entidades.NovaComercial.PortalEmpresa.Usuario item = null;

            if (ds.Tables.Count > 0)
                if (ds.Tables[0].Rows.Count > 0)
                    res = new List<Entidades.NovaComercial.PortalEmpresa.Usuario>();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.PortalEmpresa.Usuario();

                    item.UsuarioId = int.Parse(dr["UsuarioId"].ToString());

                    if (dr.Table.Columns.Contains("Nombre"))
                        item.Nombre = dr["Nombre"].ToString();

                    if (dr.Table.Columns.Contains("Paterno"))
                        item.Paterno = dr["Paterno"].ToString();

                    if (dr.Table.Columns.Contains("Materno"))
                        item.Materno = dr["Materno"].ToString();

                    item.CampoComplemento_NombreCompleto = dr["Paterno"].ToString() + " " + dr["Materno"].ToString() + ", " + dr["Nombre"].ToString();

                    if (dr.Table.Columns.Contains("StrFechaVigenciaHasta"))
                        item.CampoComplemento_StrFecha = dr["StrFechaVigenciaHasta"].ToString();

                    if (dr.Table.Columns.Contains("Correo"))
                        item.Correo = dr["Correo"].ToString();

                    if (dr.Table.Columns.Contains("Telefono"))
                        item.Telefono = dr["Telefono"].ToString();

                    if (dr.Table.Columns.Contains("Contrasenia"))
                        item.Contrasenia = dr["Contrasenia"].ToString();

                    if (dr.Table.Columns.Contains("FechaVigenciaDesde"))
                        item.FechaVigenciaDesde = DateTime.Parse(dr["FechaVigenciaDesde"].ToString());

                    if (dr.Table.Columns.Contains("FechaVigenciaHasta"))
                        item.FechaVigenciaHasta = DateTime.Parse(dr["FechaVigenciaHasta"].ToString());

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    if (dr.Table.Columns.Contains("ContratoId"))
                        item.CampoComplemento_ContratoId = int.Parse(dr["ContratoId"].ToString());

                    res.Add(item);
                }
            }

            if (res == null)
                res = new List<Entidades.NovaComercial.PortalEmpresa.Usuario>();

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(SqlOpciones pOpcion, Entidades.NovaComercial.PortalEmpresa.Usuario obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.PortalEmpresa.Usuario oE = new Entidades.NovaComercial.PortalEmpresa.Usuario();
            DataSet ds = new DataSet();

            oE.UsuarioId             = obj.UsuarioId;
            oE.Nombre                = obj.Nombre;
            oE.Paterno               = obj.Paterno;
            oE.Materno               = obj.Materno;
            oE.Telefono              = obj.Telefono;
            oE.Correo                = obj.Correo;
            oE.Contrasenia           = obj.Contrasenia;
            oE.FechaVigenciaDesde    = obj.FechaVigenciaDesde;
            oE.FechaVigenciaHasta    = obj.FechaVigenciaHasta;
            oE.UsuarioCreacionId     = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja                  = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.UsuarioId == 0)
            {
                ds = Util.Insertar(pOpcion, oE).Resultado;
            }
            else
            {
                if (obj.Baja == true)
                {
                    oE.UsuarioBajaId = obj.UsuarioBajaId;
                }

                ds = Util.Actualizar(pOpcion, oE).Resultado;
            }

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["UsuarioId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(int pUserId, int pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.PortalEmpresa.Usuario oE = new Entidades.NovaComercial.PortalEmpresa.Usuario();
            DataSet ds = new DataSet();

            oE.UsuarioId     = pUserId;
            oE.UsuarioBajaId = pUsuarioId;
            oE.Baja          = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["UsuarioId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }
    }
}