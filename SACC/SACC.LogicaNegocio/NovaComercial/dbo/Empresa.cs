using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Empresa
    {
        public static List<Entidades.NovaComercial.dbo.Empresa> Consultar(SqlOpciones pOpcion, int pEmpresaId, string pEmpresaDescripcion, int pBaja)
        {
            Entidades.NovaComercial.dbo.Empresa oE = new Entidades.NovaComercial.dbo.Empresa();

            oE.EmpresaId = pEmpresaId;

            if (pEmpresaDescripcion != "")
                oE.EmpresaDescripcion = pEmpresaDescripcion;

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

            List<Entidades.NovaComercial.dbo.Empresa> res = new List<Entidades.NovaComercial.dbo.Empresa>();
            Entidades.NovaComercial.dbo.Empresa item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.Empresa();

                    item.EmpresaId          = int.Parse(dr["EmpresaId"].ToString());
                    item.EmpresaDescripcion = dr["EmpresaDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    res.Add(item);
                }
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.Empresa obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Empresa oE = new Entidades.NovaComercial.dbo.Empresa();
            DataSet ds = new DataSet();

            oE.EmpresaId             = obj.EmpresaId;
            oE.EmpresaDescripcion    = obj.EmpresaDescripcion;
            oE.UsuarioCreacionId     = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja                  = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.EmpresaId == 0)
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

                if (ds != null || ds.Tables.Count > 0)
                {
                    Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa tranDatosEmpresa = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa();

                    char paddingChar = '0';
                    tranDatosEmpresa.vcCodigoAlterno = "0400SAC" + obj.EmpresaId.ToString().PadLeft(3, paddingChar);
                    tranDatosEmpresa.vcNombreComercial = oE.EmpresaDescripcion;
                    tranDatosEmpresa.dtFechaActualizacion = DateTime.Now;
                    tranDatosEmpresa.bProceso = false;

                    Entidades.EntidadJsonResponse res2 = new Entidades.EntidadJsonResponse();
                    Nova_ServiciosMedicos.dbo.TranDatosEmpresa.ActualizaDatos(tranDatosEmpresa);
                }

            }

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["EmpresaId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(int pEmpresaId, int pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Empresa oE = new Entidades.NovaComercial.dbo.Empresa();
            DataSet ds = new DataSet();

            oE.EmpresaId     = pEmpresaId;
            oE.UsuarioBajaId = pUsuarioId;
            oE.Baja          = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;
                
            res.Id           = int.Parse(ds.Tables[0].Rows[0]["EmpresaId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }
    }
}