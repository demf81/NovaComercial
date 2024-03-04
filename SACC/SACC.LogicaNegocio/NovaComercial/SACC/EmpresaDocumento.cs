using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class EmpresaDocumento
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoGridEmpresaDocumento> ConsultarGrid(Int32 pEmpresaId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoGridEmpresaDocumento> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoGridEmpresaDocumento>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoPM
                {
                    Opcion    = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    EmpresaId = pEmpresaId,
                    EstatusId = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.EmpresaDocumento oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumento();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaDocumento.DtoGridEmpresaDocumento item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoGridEmpresaDocumento>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaDocumento.DtoGridEmpresaDocumento
                            {
                                EmpresaDocumentoId              = Int32.Parse(dr["EmpresaDocumentoId"].ToString()),
                                EmpresaDocumentoTipoDescripcion = dr["EmpresaDocumentoTipoDescripcion"].ToString(),
                                EmpresaArchivoTipoDescripcion   = dr["EmpresaArchivoTipoDescripcion"].ToString(),
                                NombreArchivo                   = dr["NombreArchivo"].ToString(),
                                FechaCreacion                   = dr["FechaCreacion"].ToString(),
                                EstatusId                       = Int16.Parse(dr["EstatusId"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoEmpresaDocumento> ConsultarPorId(Int32 pEmpresaDocumentoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoEmpresaDocumento> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoEmpresaDocumento>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoPM
                {
                    Opcion = (Int16)SqlOpciones.ConsultaPorId,
                    EmpresaDocumentoId = pEmpresaDocumentoId
                };

                AccesoDatos.NovaComercial.SACC.EmpresaDocumento oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumento();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaDocumento.DtoEmpresaDocumento item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoEmpresaDocumento>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaDocumento.DtoEmpresaDocumento
                            {
                                EmpresaDocumentoId     = Int32.Parse(dr["EmpresaDocumentoId"].ToString()),
                                EmpresaDocumentoTipoId = Int32.Parse(dr["EmpresaDocumentoTipoId"].ToString()),
                                EmpresaArchivoTipoId   = Int32.Parse(dr["EmpresaArchivoTipoId"].ToString()),
                                Archivo                = (Byte[])dr["Archivo"],
                                NombreArchivo          = dr["NombreArchivo"].ToString(),
                                Extension              = dr["Extension"].ToString(),
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoComboEmpresaDocumento> ConsultarCombo()
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoComboEmpresaDocumento> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoComboEmpresaDocumento>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoPM
                {
                    Opcion = (Int16)SqlOpciones.Lista,
                    //EmpresaDocumentoId = pEmpresaDescripcion
                };

                AccesoDatos.NovaComercial.SACC.EmpresaDocumento oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumento();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaDocumento.DtoComboEmpresaDocumento item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoComboEmpresaDocumento>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaDocumento.DtoComboEmpresaDocumento
                            {
                                EmpresaDocumentoId = Int32.Parse(dr["EmpresaDocumentoId"].ToString()),
                                EmpresaId          = Int32.Parse(dr["EmpresaId"].ToString()),
                                EmpresaDescripcion = dr["EmpresaDescripcion"].ToString(),
                                DocumentoTipoId    = Int32.Parse(dr["DocumentoTipoId"].ToString()),
                                ArchivoTipoId      = Int32.Parse(dr["ArchivoTipoId"].ToString()),
                                Archivo            = Byte.Parse(dr["Archivo"].ToString())
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        //public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoCtrlUserBusquedaEmpresaDocumentoGrid> CtrlUserBuscarEmpresaJson(Int32 pEmpresaDescripcion)
        //{
        //    Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoCtrlUserBusquedaEmpresaDocumentoGrid> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoCtrlUserBusquedaEmpresaDocumentoGrid>();

        //    try
        //    {
        //        Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoPM()
        //        {
        //            Opcion = (Int16)Modelo.SqlOpciones.ConsultaGeneral,
        //            EmpresaDocumentoId = pEmpresaDescripcion
        //        };

        //        AccesoDatos.NovaComercial.SACC.EmpresaDocumento oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumento();
        //        Modelo.ModeloResponse response = oBD.Consultar(oParametros);

        //        if (!response.Error)
        //        {
        //            Modelo.NovaComercial.SACC.EmpresaDocumento.DtoCtrlUserBusquedaEmpresaDocumentoGrid item = null;
        //            res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoCtrlUserBusquedaEmpresaDocumentoGrid>();

        //            foreach (DataTable table in response.Resultado.Tables)
        //            {
        //                foreach (DataRow dr in table.Rows)
        //                {
        //                    item = new Modelo.NovaComercial.SACC.EmpresaDocumento.DtoCtrlUserBusquedaEmpresaDocumentoGrid
        //                    {
        //                        EmpresaDocumentoId = Int32.Parse(dr["EmpresaDocumentoId"].ToString()),
        //                        EmpresaId = Int32.Parse(dr["EmpresaId"].ToString()),
        //                        EmpresaDescripcion = dr["EmpresaDescripcion"].ToString(),
        //                        DocumentoTipoId = Int32.Parse(dr["DocumentoTipoId"].ToString()),
        //                        ArchivoTipoId = Int32.Parse(dr["ArchivoTipoId"].ToString()),
        //                        Archivo = Byte.Parse(dr["Archivo"].ToString()),
        //                    };

        //                    res.Datos.Add(item);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            res.Error        = true;
        //            res.TituloError  = response.TituloError;
        //            res.MensajeError = response.MensajeError;
        //            res.TipoMensaje  = "error";
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        res.Error        = true;
        //        res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
        //        res.MensajeError = exc.Message.ToString();
        //        res.TipoMensaje  = "error";
        //    }

        //    return res;
        //}


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.EmpresaDocumento obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.EmpresaDocumento oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumento();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.EmpresaDocumentoId == 0)
                {
                    response = oBD.Insertar((short)SqlOpciones.Insertar, obj);
                }
                else
                {
                    if (obj.Baja == true)
                    {
                        obj.UsuarioBajaId = obj.UsuarioBajaId;
                    }

                    response = oBD.Actualizar((short)SqlOpciones.Actualizar, obj);
                }

                if (!response.Error)
                {
                    if (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True")
                    {
                        res.Error        = true;
                        res.TituloError  = response.TituloError;
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaDocumentoId"].ToString());
                        res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pEmpresaDocumentoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.EmpresaDocumento oE = new Entidades.NovaComercial.SACC.EmpresaDocumento
                {
                    EmpresaDocumentoId = pEmpresaDocumentoId,
                    UsuarioBajaId      = pUsuarioId,
                    FechaModificacion  = DateTime.Now,
                    FechaBaja          = DateTime.Now,
                    Baja               = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.EmpresaDocumento oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumento();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaDocumentoId"].ToString());
                    res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                    res.MensajeError = response.Resultado.Tables[0].Rows[0]["Error"].ToString();
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }
    }
}