using System;


namespace SACC.LogicaNegocio.NovaComercial.WebService
{
    public class AsociadoLog
    {
        public AsociadoLog()
        {

        }


        public static int Insertar(SqlOpciones Opcion, Entidades.NovaComercial.WebService.AsociadoLog oBE)
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

 
        public static string ValidacionesBasica(Guid pToken)
        {
            string res = string.Empty;

            Entidades.NovaComercial.WebService.AsociadoLog oBE = new Entidades.NovaComercial.WebService.AsociadoLog
            {
                Token = pToken
            };

            Entidades.EntidadResponse response = Util.Actualizar(SqlOpciones.ValidacionBasicaAsociado, oBE);
            if (!response.Error)
            {
                if (response.Resultado != null)
                {
                    if (response.Resultado.Tables.Count > 0)
                    {
                        res = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                    }
                }
            }

            Entidades.NovaComercial.WebService.AsociadoPaso oBEpaso = new Entidades.NovaComercial.WebService.AsociadoPaso
            {
                Token = pToken
            };
            AsociadoPaso.Eliminar(oBEpaso);

            if (res != "")
            {
                oBE.EstatusId           = (int)SqlOpciones.ErrorValidacionBasica;
                oBE.AsociadoDescripcion = res;
                ActualizaEstatus(SqlOpciones.ActualizarAsociadoLog, oBE);
            }


            return res;
        }

 
        public static Boolean ActualizaEstatus(SqlOpciones Opcion, Entidades.NovaComercial.WebService.AsociadoLog oBE)
        {
            Boolean res = false;

            try
            {
                Entidades.EntidadResponse response = Util.Actualizar(Opcion, oBE);

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
 
 
        public static string ValidacionesIntegridad(Entidades.NovaComercial.WebService.AsociadoLog oBE)
        {
            string res = string.Empty;

            #region VALIDA TIPO DE USUARIO
            //Entidades.EntidadResponse responseTipoUsuario = VigenciaII.PUB.tu_tipousuario.BuscarPorClave(oBE.TipoUsuario);

            //if (responseTipoUsuario.Error)
            //    res = "Error al validar el tipo de usuario";
            //else
            //{
            //    if (responseTipoUsuario.Resultado != null)
            //    {
            //        if (responseTipoUsuario.Resultado.Tables.Count != 0)
            //        {
            //            if (responseTipoUsuario.Resultado.Tables[0].Rows.Count != 0)
            //                res = "";
            //            else
            //                res = "Tipo de Usuario no encontrado con catálogo";
            //        }
            //        else
            //            res = "Tipo de Usuario no encontrado con catálogo";
            //    }
            //    else
            //        res = "Error al validar el tipo de usuario";
            //}
            #endregion

            #region VALIDA ESTADO CIVIL
            if (res == "")
            {
                //Entidades.EntidadResponse responseEstadoCivil = VigenciaII.PUB.ec_edocivil.BuscarPorClave(oBE.ClaveEstadoCivil);

                //if (responseEstadoCivil.Error)
                //    res = "Error al validar el estado civil";
                //else
                //{
                //    if (responseEstadoCivil.Resultado != null)
                //    {
                //        if (responseEstadoCivil.Resultado.Tables.Count != 0)
                //        {
                //            if (responseEstadoCivil.Resultado.Tables[0].Rows.Count != 0)
                //                res = "";
                //            else
                //                res = "Clave de Estado Civil no encontrado en el catálogo";
                //        }
                //        else
                //            res = "Clave de Estado Civil no encontrado en el catálogo";
                //    }
                //    else
                //        res = "Error al validar el estado civil";
                //}
            }
            #endregion

            #region VALIDA RELACION EMPRESA PLANTA
            if (res == "")
            {
                //Entidades.EntidadResponse responseEmpresaPlanta = VigenciaII.PUB.co_contratos.BuscarPorEmpresaPlanta(oBE.ClaveEmpresaContrato, oBE.ClavePlantaContrato);
                //if (responseEmpresaPlanta.Error)
                //    res = "Error al validar relación empresa-planta";
                //else
                //{
                //    if (responseEmpresaPlanta.Resultado != null)
                //    {
                //        if (responseEmpresaPlanta.Resultado.Tables.Count != 0)
                //        {
                //            if (responseEmpresaPlanta.Resultado.Tables[0].Rows.Count != 0)
                //            {
                //                if (oBE.ClavePlantaContrato.ToString() != responseEmpresaPlanta.Resultado.Tables[0].Rows[0]["co_planta_id"].ToString())
                //                    res = "Relación Empresa-Planta no encontrada en el catálogo";
                //                else
                //                    res = "";

                //            }
                //            else
                //                res = "Relación Empresa-Planta no encontrada en el catálogo";
                //        }
                //        else
                //            res = "Relación Empresa-Planta no encontrada en el catálogo";
                //    }
                //    else
                //        res = "Error al validar relación empresa-planta";
                //}
            }
            #endregion

            #region VALIDA EL PAIS
            if (res == "")
            {
                //Entidades.EntidadResponse responsePais = VigenciaII.PUB.pa_pais.BuscarPorNombre(oBE.Pais);
                //if (responsePais.Error)
                //    res = "Error al validar el país";
                //else
                //{
                //    if (responsePais.Resultado != null)
                //    {
                //        if (responsePais.Resultado.Tables.Count != 0)
                //        {
                //            if (responsePais.Resultado.Tables[0].Rows.Count != 0)
                //                oBE.ClavePais = int.Parse(responsePais.Resultado.Tables[0].Rows[0][0].ToString());
                //            else
                //                oBE.ClavePais = 1;
                //        }
                //        else
                //            oBE.ClavePais = 1;
                //    }
                //    else
                //        res = "Error al validar el país";
                //}
            }
            #endregion

            #region VALIDA EL ESTADO
            if (res == "")
            {
                //Entidades.EntidadResponse responseEstado = VigenciaII.PUB.ed_estados.BuscarPorNombre(oBE.Estado);
                //if (responseEstado.Error)
                //    res = "Error al validar el estado";
                //else
                //{
                //    if (responseEstado.Resultado != null)
                //    {
                //        if (responseEstado.Resultado.Tables.Count != 0)
                //        {
                //            if (responseEstado.Resultado.Tables[0].Rows.Count != 0)
                //                oBE.ClaveEstado = int.Parse(responseEstado.Resultado.Tables[0].Rows[0][0].ToString());
                //            else
                //                oBE.ClaveEstado = 19;
                //        }
                //    }
                //    else
                //        res = "Error al validar el estado";
                //}
            }
            #endregion

            #region VALIDA EL MUNICIPIO
            if (res == "")
            {
                //Entidades.EntidadResponse responseMunicipio = VigenciaII.PUB.mu_municipios.BuscarPorNombre(oBE.Ciudad);
                //if (responseMunicipio.Error)
                //    res = "Error al validar el municipio";
                //else
                //{
                //    if (responseMunicipio.Resultado != null)
                //    {
                //        if (responseMunicipio.Resultado.Tables.Count != 0)
                //        {
                //            if (responseMunicipio.Resultado.Tables[0].Rows.Count != 0)
                //            {
                //                oBE.ClaveCiudad = int.Parse(responseMunicipio.Resultado.Tables[0].Rows[0][0].ToString());
                //            }
                //            else
                //            {
                //                oBE.ClaveCiudad = 2450;
                //            }
                //        }
                //    }
                //    else
                //        res = "Error al validar el municipio";
                //}
            }
            #endregion

            #region VALIDA LA COLONIA
            if (res == "")
            {
                //Entidades.EntidadResponse responseColonia = VigenciaII.PUB.cl_colonias.BuscarPorNombre(oBE.Colonia);
                //if (responseColonia.Error)
                //    res = "Error al validar la colonia";
                //else
                //{
                //    if (responseColonia.Resultado != null)
                //    {
                //        if (responseColonia.Resultado.Tables.Count != 0)
                //        {
                //            if (responseColonia.Resultado.Tables[0].Rows.Count != 0)
                //            {
                //                oBE.ClaveColonia = int.Parse(responseColonia.Resultado.Tables[0].Rows[0][0].ToString());
                //            }
                //            else
                //            {
                //                oBE.ClaveColonia = 8469;
                //            }
                //        }
                //    }
                //    else
                //        res = "Error al validar la colonia";
                //}
            }
            #endregion

            #region VALIDA NUMERO DE SOCIO Y CLAVE FAMILIAR
            //if (res == "")
            //{
            //    Entidades.DataHandler dhNumeroSocio = VigenciaII.PUB.us_usuarios.BuscarPorNumeroClave(oBE.NumeroSocio, oBE.ClaveFamiliar);
            //    if (dhNumeroSocio.Error)
            //        res = "Error al validar el número de asociado";
            //    else
            //    {
            //        if (dhNumeroSocio.Resultado != null)
            //        {
            //            if (dhNumeroSocio.Resultado.Tables.Count != 0)
            //            {
            //                if (dhNumeroSocio.Resultado.Tables[0].Rows.Count != 0)
            //                {
            //                    res = "Número de Asociado ya existente";
            //                }
            //                else
            //                {
            //                    res = "";
            //                }
            //            }
            //            else
            //            {
            //                res = "";
            //            }
            //        }
            //        else
            //            res = "Error al validar el número de asociado";
            //    }
            //}
            #endregion

            #region VALIDA ID DE PROVEEDOR
            //if (res == "")
            //{
            //    Entidades.DataHandler dhIdProveedor = VigenciaII.PUB.us_usuarios.BuscarPorIdProveedor(oBE.AseguradoraSocioId);
            //    if (dhIdProveedor.Error)
            //        res = "Error al validar el Id del proveedor";
            //    else
            //    {
            //        if (dhIdProveedor.Resultado != null)
            //        {
            //            if (dhIdProveedor.Resultado.Tables.Count != 0)
            //            {
            //                if (dhIdProveedor.Resultado.Tables[0].Rows.Count != 0)
            //                {
            //                    res = "Id del proveedor ya existente";
            //                }
            //                else
            //                {
            //                    res = "";
            //                }
            //            }
            //            else
            //            {
            //                res = "";
            //            }
            //        }
            //        else
            //            res = "Error al validar el Id del proveedor";
            //    }
            //}
            #endregion

            if (res == "")
            {
                oBE.EstatusId           = (int)SqlOpciones.ErrorValidacionIntegreidad;
                oBE.AsociadoDescripcion = res;
                ActualizaEstatus(SqlOpciones.ActualizarAsociadoLog, oBE);
            }

            return res;
        }

 
        public static string ValidacionesBaja(Guid pToken)
        {
            string res = string.Empty;

            Entidades.NovaComercial.WebService.AsociadoLog oBE = new Entidades.NovaComercial.WebService.AsociadoLog();
            oBE.Token = pToken;

            Entidades.EntidadResponse response = Util.Actualizar(SqlOpciones.ValidacionesBajaAsociado, oBE);

            if (!response.Error)
            {
                if (response.Resultado != null)
                {
                    if (response.Resultado.Tables.Count > 0)
                    {
                        res = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                    }
                }
            }

            Entidades.NovaComercial.WebService.AsociadoPaso oBEpaso = new Entidades.NovaComercial.WebService.AsociadoPaso
            {
                Token = pToken
            };
            AsociadoPaso.Eliminar(oBEpaso);

            if (res != "")
            {
                oBE.EstatusId           = (int)SqlOpciones.ErrorValidacionBasica;
                oBE.AsociadoDescripcion = res;
                ActualizaEstatus(SqlOpciones.ActualizarAsociadoLog, oBE);
            }


            return res;
        }
    }
}