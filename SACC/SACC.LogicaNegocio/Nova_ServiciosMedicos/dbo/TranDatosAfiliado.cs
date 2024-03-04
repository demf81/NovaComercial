using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.Nova_ServiciosMedicos.dbo
{
    public class TranDatosAfiliado
    {
        public static List<Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado> Consultar(SqlOpciones pOpcion)
        {
            Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado oE = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado();

            DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

            List<Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado> res = new List<Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado>();
            Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado();

                    item.IdMovimiento = int.Parse(dr["IdMovimiento"].ToString());
                    
                    res.Add(item);
                }
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado oE = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado();
            DataSet ds = new DataSet();

            oE.vchIdAfiliado        = obj.vchIdAfiliado;
            oE.vchIdentidad         = obj.vchIdentidad;
            oE.vchNombre            = obj.vchNombre;
            oE.vchPaterno           = obj.vchPaterno;
            oE.vchMaterno           = obj.vchMaterno;
            oE.tiEstatus            = obj.tiEstatus;
            oE.vchContratante       = obj.vchContratante;
            oE.iNumPoliza           = obj.iNumPoliza;
            oE.iNumCerti            = obj.iNumCerti;
            oE.dtFecIni             = obj.dtFecIni;
            oE.dtFecFin             = obj.dtFecFin;
            oE.vchDomicilio         = obj.vchDomicilio;
            oE.vchColonia           = obj.vchColonia;
            oE.vchCiudad            = obj.vchCiudad;
            oE.vchEstado            = obj.vchEstado;
            oE.dtFecNaci            = obj.dtFecNaci;
            oE.siSexo               = obj.siSexo;
            oE.chCodContrato        = obj.chCodContrato;
            oE.chCodEmpresa         = obj.chCodEmpresa;
            oE.vchDirEmp            = obj.vchDirEmp;
            oE.vchColEmp            = obj.vchColEmp;
            oE.vchCPEmp             = obj.vchCPEmp;
            oE.vchTelfEmp           = obj.vchTelfEmp;
            oE.siTipoSangre         = obj.siTipoSangre;
            oE.siEstadoCivil        = obj.siEstadoCivil;
            oE.vchCPAfiliado        = obj.vchCPAfiliado;
            oE.vchtelfAfiliado      = obj.vchtelfAfiliado;
            oE.vchCiudadEmp         = obj.vchCiudadEmp;
            oE.vchEstadoEmp         = obj.vchEstadoEmp;
            oE.vchIdHospitaliza     = obj.vchIdHospitaliza;
            oE.vchCodMedicoFam      = obj.vchCodMedicoFam;
            oE.siTipoAfiliado       = obj.siTipoAfiliado;
            oE.siConfidencial       = obj.siConfidencial;
            oE.imFotoAfiliado       = obj.imFotoAfiliado;
            oE.chrCURP              = obj.chrCURP;
            oE.vchReferencia        = obj.vchReferencia;
            oE.iMunicipio           = obj.iMunicipio;
            oE.iMedicoSecundario    = obj.iMedicoSecundario;
            oE.tiRequiereEmpresa    = obj.tiRequiereEmpresa;
            oE.tiRequiereExpediente = obj.tiRequiereExpediente;
            oE.siRelacionTitular    = obj.siRelacionTitular;
            oE.vchIdAfiliadoTitular = obj.vchIdAfiliadoTitular;
            oE.iFechaInduccion      = obj.iFechaInduccion;
            oE.dtFechaCreacion      = obj.dtFechaCreacion;
            oE.dtFechaActualizacion = obj.dtFechaActualizacion;
            oE.chrCurpp             = obj.chrCurpp;
            oE.bProceso             = obj.bProceso;
            oE.IdEstadoNacimiento   = obj.IdEstadoNacimiento;
            oE.IdMovimiento         = obj.IdMovimiento;
            oE.IdColonia            = obj.IdColonia;
            oE.vcTelefono2          = obj.vcTelefono2;
            oE.vcTelefonoMovil      = obj.vcTelefonoMovil;

            try
            {
                ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;

                res.Id           = int.Parse(ds.Tables[0].Rows[0]["IdMovimiento"].ToString());
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
            catch (Exception  exc)
            {
                res.Id           = -1;
                res.Mensaje      = "";
                res.MensajeError = exc.Message.ToString();
                res.Error        = true;
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse ActualizaDatos(Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado oE = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado();
            DataSet ds = new DataSet();

            oE.vchIdAfiliado = obj.vchIdAfiliado;
            oE.vchNombre     = obj.vchNombre;
            oE.vchPaterno    = obj.vchPaterno;
            oE.vchMaterno    = obj.vchMaterno;
            oE.siSexo        = obj.siSexo;
            oE.chrCURP       = obj.chrCURP;
            oE.bProceso      = obj.bProceso;

            try
            {
                ds = Util.Actualizar(SqlOpciones.Lista, oE).Resultado;

                res.Id           = int.Parse(ds.Tables[0].Rows[0]["vchIdAfiliado"].ToString());
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


        public static Entidades.EntidadJsonResponse ActivaSocio(Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado oE = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado();
            DataSet ds = new DataSet();

            oE.vchIdAfiliado = obj.vchIdAfiliado;
            oE.tiEstatus     = obj.tiEstatus;
            oE.bProceso      = obj.bProceso;

            try
            {
                ds = Util.Actualizar(SqlOpciones.ConsultaGeneralConJoin, oE).Resultado;

                res.Id           = int.Parse(ds.Tables[0].Rows[0]["vchIdAfiliado"].ToString());
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


        public static Entidades.EntidadJsonResponse CambioNumeroSocio(Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado oE = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado();
            DataSet ds = new DataSet();

            oE.vchIdAfiliado = obj.vchIdAfiliado;
            oE.tiEstatus = obj.tiEstatus;
            oE.bProceso = obj.bProceso;

            try
            {
                ds = Util.Actualizar(SqlOpciones.ConsultaGeneralConJoin, oE).Resultado;

                res.Id = int.Parse(ds.Tables[0].Rows[0]["vchIdAfiliado"].ToString());
                res.Mensaje = "El registro se actualizo satisfactoriamente.";
                res.MensajeError = "";
                res.Error = false;
                res.TipoMensaje = "success";

                //res.Id = int.Parse(ds.Tables[0].Rows[0]["ContratoCoberturaId"].ToString());
                //res.Mensaje = ds.Tables[0].Rows[0]["Mensaje"].ToString();
                //res.MensajeError = (ds.Tables[0].Rows[0]["Error"].ToString() == "True" ? ds.Tables[0].Rows[0]["MensajeError"].ToString() : "");
                //res.Error = (ds.Tables[0].Rows[0]["Error"].ToString() == "True" ? true : false);
                //res.TipoMensaje = (ds.Tables[0].Rows[0]["Error"].ToString() == "True" ? "error" : "success");
            }
            catch (Exception exc)
            {
                res.Id = -1;
                res.Mensaje = "";
                res.MensajeError = exc.Message.ToString();
                res.Error = true;
                res.TipoMensaje = "error";
            }


            return res;
        }
    }
}