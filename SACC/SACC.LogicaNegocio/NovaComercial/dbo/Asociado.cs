using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Configuration;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Asociado
    {
        public static List<Entidades.NovaComercial.dbo.Asociado> Consultar(SqlOpciones pOpcion, int pAsociadoId, string pCURP, string pSocioId, string pCveFamiliar, string pNombre, int? pBaja)
        {
            Entidades.NovaComercial.dbo.Asociado oE = new Entidades.NovaComercial.dbo.Asociado();

            oE.AsociadoId     = pAsociadoId;
            oE.Curp           = pCURP;
            oE.CodigoVigencia = pSocioId;
            oE.ClaveFamiliar  = pCveFamiliar;
            oE.Nombre         = pNombre;


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

            List<Entidades.NovaComercial.dbo.Asociado> res = new List<Entidades.NovaComercial.dbo.Asociado>();
            Entidades.NovaComercial.dbo.Asociado item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.Asociado();

                    item.AsociadoId = int.Parse(dr["AsociadoId"].ToString());

                    if (dr.Table.Columns.Contains("Nombre"))
                        item.Nombre = dr["Nombre"].ToString();

                    if (dr.Table.Columns.Contains("ApellidoPaterno"))
                        item.ApellidoPaterno = dr["ApellidoPaterno"].ToString();

                    if (dr.Table.Columns.Contains("ApellidoMaterno"))
                        item.ApellidoMaterno = dr["ApellidoMaterno"].ToString();

                    if (dr.Table.Columns.Contains("SexoId"))
                        item.SexoId = int.Parse(dr["SexoId"].ToString());

                    if (dr.Table.Columns.Contains("FechaNacimiento"))
                        item.FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());

                    if (dr.Table.Columns.Contains("CodigoVigencia"))
                        item.CodigoVigencia = dr["CodigoVigencia"].ToString();

                    if (dr.Table.Columns.Contains("ClaveFamiliar"))
                        item.ClaveFamiliar = dr["ClaveFamiliar"].ToString();

                    if (dr.Table.Columns.Contains("NombreCompleto"))
                        item.CampoComplemento_NombreCompleto = dr["NombreCompleto"].ToString();

                    if (dr.Table.Columns.Contains("CURP"))
                        item.Curp = dr["CURP"].ToString();

                    //if (dr.Table.Columns.Contains("Edad"))
                        //item.CampoComplemento_Edad = decimal.Parse(dr["Edad"].ToString());

                    //if (dr.Table.Columns.Contains("SexoId"))
                        //item.CampoComplemento_Genero = dr["SexoId"].ToString();

                    //if (dr.Table.Columns.Contains("NumSocio"))
                    //    item.CampoComplemento_SocioId = dr["NumSocio"].ToString();

                    //if (dr.Table.Columns.Contains("EmpresaPlantaDescripcion"))
                    //    item.CampoComplemento_EmpresaPlantaDescripcion = dr["EmpresaPlantaDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    res.Add(item);
                }
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Asociado.DtoGridAsociado> ConsultarGrid(String pCurp, String pNombre, String pNumSocio)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Asociado.DtoGridAsociado> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Asociado.DtoGridAsociado>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.AsociadoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.AsociadoPM
                {
                    Opcion   = (Int16)SqlOpciones.ConsultarAsociadosNexus,
                    Curp     = pCurp,
                    Nombre   = pNombre,
                    NumSocio = pNumSocio
                };

                AccesoDatos.NovaComercial.dbo.Asociado oBD = new AccesoDatos.NovaComercial.dbo.Asociado();
                Modelo.ModeloResponse response = oBD.ConsultarGrid(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Asociado.DtoGridAsociado item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Asociado.DtoGridAsociado>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Asociado.DtoGridAsociado
                            {
                                AsociadoId         = Int32.Parse(dr["AsociadoId"].ToString()),
                                NumSocio           = dr["NumSocio"].ToString(),
                                Nombre             = dr["Nombre"].ToString(),
                                Curp               = dr["Curp"].ToString(),
                                Genero             = dr["Genero"].ToString(),
                                FechaNacimiento    = dr["FechaNacimiento"].ToString(),
                                Contratante        = dr["Contratante"].ToString(),
                                TitularId          = !dr.IsNull("TitularId") ? Int32.Parse(dr["TitularId"].ToString()) : 0,
                                ServicioSuspendido = !dr.IsNull("ServicioSuspendido") ? Boolean.Parse(dr["ServicioSuspendido"].ToString()) : false,

                            };

                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaNegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse ImportarBajoDemanda()
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.LogImportacionesSACC objLogImportaciones = new Entidades.NovaComercial.dbo.LogImportacionesSACC();
                Entidades.EntidadJsonResponse resLogImportaciones = new Entidades.EntidadJsonResponse();

                objLogImportaciones.Baja         = false;
                objLogImportaciones.ErrorEstatus = false;
                objLogImportaciones.Inicio       = DateTime.Now;
                objLogImportaciones.Mensaje      = "Procesos: Inicio";
                objLogImportaciones.Proceso      = "Importación Bajo Demanda";

                resLogImportaciones = LogicaNegocio.NovaComercial.dbo.LogImportacionesSACC.Guardar((short)SqlOpciones.Insertar, objLogImportaciones);

                AccesoDatos.NovaComercial.dbo.Asociado oBDAsociado = new AccesoDatos.NovaComercial.dbo.Asociado();
                oBDAsociado.EjecutaNonQuery("EXEC [dbo].[spTaskLimpiaTemporalesDemanda];");

                Entidades.EntidadResponse resAsociadoVigencia = ObtenerValoresProgressDemanda("us_usuarios");
                Entidades.EntidadResponse resContrato         = ObtenerValoresProgressDemanda("co_contratos");
                Entidades.EntidadResponse resUsuarios         = ObtenerValoresProgressDemanda("ccu_usuarios");
                Entidades.EntidadResponse resSerDeuSu         = ObtenerValoresProgressDemanda("su_serdeusu");
                Entidades.EntidadResponse resTitulares        = ObtenerValoresProgressDemanda("cct_titulares");
                Entidades.EntidadResponse resSerDeTit         = ObtenerValoresProgressDemanda("st_serdetit");

                LUtil.EnviaDataTable(resAsociadoVigencia.Resultado.Tables[0], "us_usuarios");
                LUtil.EnviaDataTable(resContrato.Resultado.Tables[0], "co_contratos");
                LUtil.EnviaDataTable(resUsuarios.Resultado.Tables[0], "ccu_usuarios");
                LUtil.EnviaDataTable(resSerDeuSu.Resultado.Tables[0], "su_serdeusu");
                LUtil.EnviaDataTable(resTitulares.Resultado.Tables[0], "cct_titulares");
                LUtil.EnviaDataTable(resSerDeTit.Resultado.Tables[0], "st_serdetit");

                oBDAsociado.EjecutaNonQuery("EXEC [dbo].[spTaskImportacionBajoDemanda];");

                oBDAsociado.EjecutaNonQuery("EXEC [dbo].[spTaskPersonaAsociado_Importar];");

                res.Id      = 1;
                res.Error   = false;
                res.Mensaje = "Proceso terminado exitosamente";
            }
            catch (Exception ex)
            {
                res.Id           = 0;
                res.Error        = true;
                res.MensajeError = "Errores encontrados en el proceso";
            }

            return res;
        }


        private static Entidades.EntidadResponse ObtenerValoresProgressDemanda(string metodo)
        {
            Entidades.EntidadResponse res = new Entidades.EntidadResponse();
            string StrQuery = "";

            switch (metodo)
            {
                case "us_usuarios":
                    StrQuery += "SELECT us_socio_id, us_cvefam, us_apellidopat, us_apellidomat, us_nombre, us_sexo, us_tiposang_id, us_fec_naci, us_fec_alta, ";
                    StrQuery += "us_tipous_id, us_edocivil, us_ult_act, us_usuario_act, us_hora_act, us_reposi, us_Beca, us_curp, us_estudiante, us_fec_fallecimiento, us_pass_www, us_relind_id,";
                    StrQuery += "us_respuesta, Id_Enlace, Id_SIASS, us_rfc, us_calle, us_numdir, us_codigopost, us_colonia_id, us_muni_id, us_telefono_casa, us_telefono_ofi, us_extension, ";
                    StrQuery += "us_fax_movil, us_correoelec, us_pregunta, us_curp_provisional, us_curp_vigencia, us_num_ternium, us_pais_id, us_colonia_desc, us_correo_confirmado, us_cadena_confirmacion";
                    StrQuery += " FROM pub.us_usuarios ";
                    StrQuery += " WHERE YEAR(us_fec_naci) >= 1900 ";
                    break;

                case "co_contratos":
                    StrQuery += "SELECT * FROM pub.co_contratos ";
                    break;

                case "ccu_usuarios":
                    StrQuery = "SELECT * FROM pub.ccu_usuarios";
                    break;

                case "cct_titulares":
                    StrQuery = "SELECT * FROM pub.cct_titulares";
                    break;

                case "su_serdeusu":
                    StrQuery = "SELECT * FROM pub.su_serdeusu";
                    break;

                case "st_serdetit":
                    StrQuery = "SELECT * FROM pub.st_serdetit";
                    break;
            }

            try
            {
                OdbcConnection oConexion = new OdbcConnection();
                OdbcCommand oComando = new OdbcCommand();

                oComando.CommandText = StrQuery;
                oComando.CommandType = CommandType.Text;

                oConexion.ConnectionString = ConfigurationManager.ConnectionStrings["cxnVigencia"].ConnectionString;

                oConexion.Open();
                oComando.Connection = oConexion;
                OdbcDataAdapter daResultado = new OdbcDataAdapter(oComando);
                daResultado.Fill(res.Resultado);

                oConexion.Close();
            }
            catch (Exception ex)
            {
                res.Error        = true;
                res.MensajeError = ex.Message;
            }

            return res;
        }
    }
}