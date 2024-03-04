using System;
using System.Data;


namespace SACC.LogicaNegocio.Nova_ServiciosMedicos.dbo
{
    public class tblVentasUnitarias
    {
        public static Entidades.EntidadJsonResponse Guardar(Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias oE = new Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias();
            DataSet ds = new DataSet();

            oE.IdVentaUnitaria    = obj.IdVentaUnitaria;
            oE.vcDescripcion      = obj.vcDescripcion;
            oE.IdNumeroSocio      = obj.IdNumeroSocio;
            oE.vcAfiliado         = obj.vcAfiliado;
            oE.bActivo            = obj.bActivo;
            oE.dtFechaVencimiento = obj.dtFechaVencimiento;

            try
            {
                ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;

                res.Id           = int.Parse(ds.Tables[0].Rows[0]["IdVentaUnitaria"].ToString());
                res.Mensaje      = (res.Id > 0) ? "El registro se actualizo satisfactoriamente." : "";
                res.MensajeError = (res.Id < 0) ? ds.Tables[0].Rows[0]["Mensaje"].ToString() : "";
                res.Error        = (res.Id > 0) ? false : true;
                res.TipoMensaje  = (res.Id > 0) ? "success" : "error";
            }
            catch (Exception exc)
            {
                res.Id           = -1;
                res.Mensaje      = "";
                res.MensajeError = exc.Message.ToString();
                res.Error        = true;
                res.TipoMensaje  = "error";
            }
            
            return res;
        }


        public static Entidades.EntidadJsonResponse Reprocesar(Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias oE = new Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias();
            DataSet ds = new DataSet();

            oE.IdVentaUnitaria    = obj.IdVentaUnitaria;
            oE.dtFechaVencimiento = obj.dtFechaVencimiento;
            oE.IdVentaUnitaria    = obj.IdVentaUnitaria;

            try
            {
                ds = Util.Actualizar(SqlOpciones.Lista, oE).Resultado;

                res.Id           = int.Parse(ds.Tables[0].Rows[0]["IdVentaUnitaria"].ToString());
                res.Mensaje      = (res.Id > 0) ? "El registro se actualizo satisfactoriamente." : "";
                res.MensajeError = (res.Id < 0) ? ds.Tables[0].Rows[0]["Mensaje"].ToString() : "";
                res.Error        = (res.Id > 0) ? false : true;
                res.TipoMensaje  = (res.Id > 0) ? "success" : "error";
            }
            catch (Exception exc)
            {
                res.Id           = -1;
                res.Mensaje      = "";
                res.MensajeError = exc.Message.ToString();
                res.Error        = true;
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse CambiaVigencia(Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            SACC.Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias oE = new SACC.Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias();
            DataSet ds = new DataSet();

            oE.IdVentaUnitaria    = obj.IdVentaUnitaria;
            oE.dtFechaVencimiento = obj.dtFechaVencimiento;

            try
            {
                ds = Util.Actualizar(SqlOpciones.ConsultaGeneralConJoin, oE).Resultado;

                res.Id           = int.Parse(ds.Tables[0].Rows[0]["IdVentaUnitaria"].ToString());
                res.Mensaje      = (res.Id > 0) ? "El registro se actualizo satisfactoriamente." : "";
                res.MensajeError = (res.Id < 0) ? ds.Tables[0].Rows[0]["Mensaje"].ToString() : "";
                res.Error        = (res.Id > 0) ? false : true;
                res.TipoMensaje  = (res.Id > 0) ? "success" : "error";
            }
            catch(Exception exc)
            {
                res.Id           = -1;
                res.Mensaje      = "";
                res.MensajeError = exc.Message.ToString();
                res.Error        = true;
                res.TipoMensaje  = "error";
            }

            return res;
        }
    }
}