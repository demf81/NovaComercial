using System;
using System.Data;


namespace SACC.LogicaNegocio.Nova_ServiciosMedicos.dbo
{
    public class TranDatosEmpresa
    {
        public static Entidades.EntidadJsonResponse Guardar(Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa oE = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa();
            DataSet ds = new DataSet();

            oE.iCodigo              = obj.iCodigo;
            oE.vcCodigoAlterno      = obj.vcCodigoAlterno;
            oE.vcNombreComercial    = obj.vcNombreComercial;
            oE.vcDireccion          = obj.vcDireccion;
            oE.IdColonia            = obj.IdColonia;
            oE.vcCodigoPostal       = obj.vcCodigoPostal;
            oE.vcZona               = obj.vcZona;
            oE.vcTelefono1          = obj.vcTelefono1;
            oE.vcTelefono2          = obj.vcTelefono2;
            oE.vcFax                = obj.vcFax;
            oE.IdTipoEmpresa        = obj.IdTipoEmpresa;
            oE.bFideicomitente      = obj.bFideicomitente;
            oE.bEnLinea             = obj.bEnLinea;
            oE.bActivo              = obj.bActivo;
            oE.vcCorreoElectronico  = obj.vcCorreoElectronico;
            oE.iEnLineaSiass        = obj.iEnLineaSiass;
            oE.vcGrupoSAP           = obj.vcGrupoSAP;
            oE.vcSectorSAP          = obj.vcSectorSAP;
            oE.vcZonaSAP            = obj.vcZonaSAP;
            oE.vcRamoIndustrialSAP  = obj.vcRamoIndustrialSAP;
            oE.vcOficinaVentaSAP    = obj.vcOficinaVentaSAP;
            oE.IdMovimiento         = obj.IdMovimiento;
            oE.dtFechaCreacion      = obj.dtFechaCreacion;
            oE.dtFechaActualizacion = obj.dtFechaActualizacion;
            oE.bProceso             = obj.bProceso;

            try
            {
                ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;

                res.Id           = int.Parse(ds.Tables[0].Rows[0]["iCodigo"].ToString());
                res.Mensaje      = "El registro se actualizo satisfactoriamente.";
                res.MensajeError = "";
                res.Error        = false;
                res.TipoMensaje  = "success";

                //res.Id = int.Parse(ds.Tables[0].Rows[0]["ContratoCoberturaId"].ToString());
                //res.Mensaje = ds.Tables[0].Rows[0]["Mensaje"].ToString();
                //res.MensajeError = (ds.Tables[0].Rows[0]["Error"].ToString() == "True" ? ds.Tables[0].Rows[0]["MensajeError"].ToString() : "");
                //res.Error = (ds.Tables[0].Rows[0]["Error"].ToString() == "True" ? true : false);
                //res.TipoMensaje = (ds.Tables[0].Rows[0]["Error"].ToString() == "True" ? "error" : "success");
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


        public static Entidades.EntidadJsonResponse ActualizaDatos(Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa oE = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa();
            DataSet ds = new DataSet();

            oE.vcCodigoAlterno      = obj.vcCodigoAlterno;
            oE.vcNombreComercial    = obj.vcNombreComercial;
            oE.dtFechaActualizacion = obj.dtFechaActualizacion;
            oE.bProceso             = obj.bProceso;

            try
            {
                ds = Util.Actualizar(SqlOpciones.Lista, oE).Resultado;

                res.Id           = int.Parse(ds.Tables[0].Rows[0]["iCodigo"].ToString());
                res.Mensaje      = "El registro se actualizo satisfactoriamente.";
                res.MensajeError = "";
                res.Error        = false;
                res.TipoMensaje  = "success";

                //res.Id = int.Parse(ds.Tables[0].Rows[0]["ContratoCoberturaId"].ToString());
                //res.Mensaje = ds.Tables[0].Rows[0]["Mensaje"].ToString();
                //res.MensajeError = (ds.Tables[0].Rows[0]["Error"].ToString() == "True" ? ds.Tables[0].Rows[0]["MensajeError"].ToString() : "");
                //res.Error = (ds.Tables[0].Rows[0]["Error"].ToString() == "True" ? true : false);
                //res.TipoMensaje = (ds.Tables[0].Rows[0]["Error"].ToString() == "True" ? "error" : "success");
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
    }
}