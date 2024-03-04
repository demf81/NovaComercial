using System;

namespace SACC.LogicaNegocio.NovaComercial.WebService
{
    public class AsociadoPaso
    {
        public AsociadoPaso()
        {

        }


        public static int Insertar(SqlOpciones Opcion, Entidades.NovaComercial.WebService.AsociadoPaso oBE)
        {
            int res = 0;

            try
            {
                Entidades.EntidadResponse response = Util.Insertar(Opcion, oBE);

                if (!response.Error)
                {
                    if (response.Resultado != null)
                    {
                        if (response.Resultado.Tables.Count > 0)
                        {
                            res = int.Parse(response.Resultado.Tables[0].Rows[0]["AsociadoId"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //BusinessUtils.Logger.WriteLogFile(ex.Message);
            }

            return res;
        }


        public static Boolean Eliminar(Entidades.NovaComercial.WebService.AsociadoPaso oBE)
        {
            Boolean res = false;

            try
            {
                Entidades.EntidadResponse response = Util.Actualizar(SqlOpciones.EliminarRegistroPaso, oBE);

                if (!response.Error)
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                //BusinessUtils.Logger.WriteLogFile(ex.Message);
            }

            return res;
        }

        //public static Entidades.DataHandler Guiardar(Entidades.NovaComercial.WebService.AsociadoPaso oBE)
        //{
        //    try
        //    {
        //        Entidades.NovaComercial.helper.MensajeAseguradora resMensaje = new Entidades.NovaComercial.helper.MensajeAseguradora();

        //        DataSet dsAsociado = new DataSet();

        //        if (oBE.AsociadoId == 0)
        //        {
        //            //NUEVO
        //            dsAsociado = Util.Insertar(BusinessLogic.SqlOpciones.Insertar, oBE).Resultado;
        //        }


        //        if (dsAsociado == null)
        //            resMensaje.Mensaje = "Error al Procesar el registro";
        //        else
        //            resMensaje.Mensaje = "";


        //        if (resMensaje.Mensaje == "")
        //        {
        //            if (dsAsociado.Tables.Count == 0)
        //            {
        //                resMensaje.Mensaje = "El registro no se pudo guardar";
        //            }

        //            oBE.AsociadoId = int.Parse(dsAsociado.Tables[0].Rows[0]["AsociadoId"].ToString());

        //            Entidades.NovaComercial.helper.MensajeAseguradora resValidacionBasicaAcosiado = new Entidades.NovaComercial.helper.MensajeAseguradora();
        //            Entidades.NovaComercial.helper.MensajeAseguradora resValidacionVigenciaAsociado = new Entidades.NovaComercial.helper.MensajeAseguradora();

        //            if (oBE.AsociadoId > 0)
        //            {
        //                #region VALIDACIONES BASICAS
        //                resValidacionBasicaAcosiado = ValidacionesBasica(oBE.Token);
        //                resMensaje.Mensaje = resValidacionBasicaAcosiado.Mensaje;
        //                #endregion

        //                #region VALIDACIONES DE INTEGRIDAD
        //                if (resMensaje.Mensaje == "")
        //                {
        //                    resValidacionVigenciaAsociado = ValidacionesIntegridad(oBE);
        //                    resMensaje.Mensaje = resValidacionVigenciaAsociado.Mensaje;
        //                }
        //                #endregion

        //                #region VALIDACIONES SIASS
        //                if (resMensaje.Mensaje == "") // INSERTA EN VIGENCIA
        //                {
        //                    Entidades.VigenciaII.PUB.P
        //                    Util.Insertar(SqlOpciones.Insertar, 
        //                }
        //                #endregion
        //            }
        //        }

        //        resMensaje.TransaccionId = oBE.Token;

        //        return resMensaje;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private static Entidades.NovaComercial.helper.MensajeAseguradora ValidacionesBasica(Guid  pToken) 
        //{

        //    Entidades.NovaComercial.helper.MensajeAseguradora res = new Entidades.NovaComercial.helper.MensajeAseguradora();
        //    Entidades.NovaComercial.WebService.AsociadoPaso oBE = new Entidades.NovaComercial.WebService.AsociadoPaso();
        //    oBE.Token = pToken;

        //    DataSet dsRes = new DataSet();

        //    dsRes = Util.Actualizar(SqlOpciones.ValidacionBasicaAsociado, oBE).Resultado;

        //    try
        //    {
        //        int contador = 0;

        //        foreach (DataTable table in dsRes.Tables)
        //        {
        //            if (contador == 1)
        //                break;

        //            foreach (DataRow dr in table.Rows)
        //            {
        //                res.TransaccionId = Guid.Parse(dr["TransaccionId"].ToString());
        //                res.Mensaje       = dr["Mensaje"].ToString();
        //            }

        //            contador++;
        //        }

        //        Util.Actualizar(SqlOpciones.EliminarRegistroPaso, oBE);

        //    }
        //    catch (Exception exc)
        //    {
        //    }            

        //    return res;
        //}

        //private static Entidades.NovaComercial.helper.MensajeAseguradora ValidacionesIntegridad(Entidades.NovaComercial.WebService.AsociadoPaso oBE)
        //{

        //    Entidades.NovaComercial.helper.MensajeAseguradora res = new Entidades.NovaComercial.helper.MensajeAseguradora();
        //    DataSet dsRes = new DataSet();

        //    Entidades.VigenciaII.PUB.tu_tipousuario oTipoUsuarioBE = new Entidades.VigenciaII.PUB.tu_tipousuario();
        //    oTipoUsuarioBE.tu_tipous_id = oBE.TipoUsuario;

        //    #region VALIDA TIPO DE USUARIO
        //    dsRes = Util.Consultar(SqlOpciones.ConsultaPorId, oTipoUsuarioBE).Resultado;
        //    if (dsRes.Tables.Count != 0)
        //    {
        //        if (dsRes.Tables[0].Rows.Count != 0)
        //        {
        //            if (oBE.TipoUsuario != dsRes.Tables[0].Rows[0]["Clave"].ToString())
        //            {
        //                res.Mensaje = "Tipo de Usuario no encontrado con catálogo";
        //                //res.EstatusId = 2;
        //            }
        //            else
        //            {
        //                res.Mensaje = "";
        //                //res.EstatusId = 1;
        //            }
        //        }
        //    }
        //    #endregion

        //    #region VALIDA ESTADO CIVIL
        //    if (1 == 1)
        //    {
        //        Entidades.VigenciaII.PUB.ec_edocivil oEstadoCivilBE = new Entidades.VigenciaII.PUB.ec_edocivil();
        //        oEstadoCivilBE.ec_edocivil_id = oBE.ClaveEstadoCivil;

        //        dsRes = Util.Consultar(SqlOpciones.ConsultaPorId, oEstadoCivilBE).Resultado;

        //        if (dsRes.Tables.Count != 0)
        //        {
        //            if (dsRes.Tables[0].Rows.Count != 0)
        //            {
        //                if (oBE.ClaveEstadoCivil != dsRes.Tables[0].Rows[0]["Clave"].ToString())
        //                {
        //                    res.Mensaje = "Clave de Estado Civil no encontrado en el catálogo";
        //                    //res.EstatusId = 2;
        //                }
        //                else
        //                {
        //                    res.Mensaje = "";
        //                    //res.EstatusId = 1;
        //                }
        //            }
        //        }
        //    }
        //    #endregion

        //    #region VALIDA RELACION EMPRESA PLANTA
        //    if (1 == 1)
        //    {
        //        Entidades.VigenciaII.PUB.co_contratos oContratoBE = new Entidades.VigenciaII.PUB.co_contratos();
        //        oContratoBE.co_empresa_id = oBE.ClaveEmpresaContrato.ToString();
        //        oContratoBE.co_planta_id = oBE.ClavePlantaContrato.ToString();

        //        dsRes = Util.Consultar(SqlOpciones.ConsultaPorId, oContratoBE).Resultado;

        //        if (dsRes.Tables.Count != 0)
        //        {
        //            if (dsRes.Tables[0].Rows.Count != 0)
        //            {
        //                if (oBE.ClavePlantaContrato.ToString() != dsRes.Tables[0].Rows[0]["co_planta_id"].ToString())
        //                {
        //                    res.Mensaje = "Relación Empresa-Planta no encontrada en el catálogo";
        //                    //res.EstatusId = 2;
        //                }
        //                else
        //                {
        //                    res.Mensaje = "";
        //                    //res.EstatusId = 1;
        //                }

        //            }
        //        }
        //    }
        //    #endregion

        //    if(res.Mensaje != "")
        //    {
        //        Entidades.NovaComercial.WebService.AsociadoLog oBELog = new Entidades.NovaComercial.WebService.AsociadoLog();
        //        oBELog.Token = oBE.Token;
        //        oBELog.EstatusId = 3;
        //        oBELog.AsociadoDescripcion = res.Mensaje;

        //        Util.Actualizar(SqlOpciones.ValidacionVigenciaAsociado, oBELog);
        //    }

        //    return res;
        //}

        //private static Entidades.NovaComercial.helper.MensajeAseguradora ValidacionSIASS(int pAseguradoraSocioId)
        //{
        //    Entidades.NovaComercial.helper.MensajeAseguradora res = new Entidades.NovaComercial.helper.MensajeAseguradora();

        //    //Entidades.VigenciaII.PUB.us_usuarios


        //    return res;
        //}
    }
}