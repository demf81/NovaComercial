using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Cotizacion
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoGridCotizacion> ConsultarGrid(String pCotizacionDescripcion, DateTime? pFechaInicio, DateTime? pFechaFin, Int16 pCotizacionTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoGridCotizacion> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoGridCotizacion>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CotizacionPM oParametros = new Modelo.Parametro.NovaComercial.SACC.CotizacionPM
                {
                    Opcion                = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    CotizacionDescripcion = pCotizacionDescripcion,
                    FechaInicio           = pFechaInicio,
                    FechaFin              = pFechaFin,
                    CotizacionTipoId      = pCotizacionTipoId,
                    CotizacionEstatusId   = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.Cotizacion oBD = new AccesoDatos.NovaComercial.SACC.Cotizacion();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Cotizacion.DtoGridCotizacion item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Cotizacion.DtoGridCotizacion>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Cotizacion.DtoGridCotizacion
                            {
                                CotizacionId              = Int32.Parse(dr["CotizacionId"].ToString()),
                                CotizacionDescripcion     = dr["CotizacionDescripcion"].ToString(),
                                Fecha                     = dr["Fecha"].ToString(),
                                CotizacionTipoId          = Int16.Parse(dr["CotizacionTipoId"].ToString()),
                                CotizacionTipoDescripcion = dr["CotizacionTipoDescripcion"].ToString(),
                                PersonaId                 = Int32.Parse(dr["PersonaId"].ToString()),
                                PersonaNombre             = dr["PersonaNombre"].ToString(),
                                EmpresaId                 = Int32.Parse(dr["EmpresaId"].ToString()),
                                EmpresaNombre             = dr["EmpresaNombre"].ToString(),
                                SubTotal                  = Decimal.Parse( dr["SubTotal"].ToString()),
                                Descuento                 = Decimal.Parse(dr["Descuento"].ToString()),
                                Iva                       = Decimal.Parse(dr["Iva"].ToString()),
                                Total                     = Decimal.Parse(dr["Total"].ToString()),
                                CotizacionEstatusId       = Int16.Parse(dr["CotizacionEstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion> ConsultarPorId(Int64 pCotizacionId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CotizacionPM oParametros = new Modelo.Parametro.NovaComercial.SACC.CotizacionPM
                {
                    Opcion       = (Int16)SqlOpciones.ConsultaPorId,
                    CotizacionId = pCotizacionId
                };

                AccesoDatos.NovaComercial.SACC.Cotizacion oBD = new AccesoDatos.NovaComercial.SACC.Cotizacion();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion
                            {
                                CotizacionId          = Int32.Parse(dr["CotizacionId"].ToString()),
                                CotizacionDescripcion = dr["CotizacionDescripcion"].ToString(),
                                Fecha                 = DateTime.Parse(dr["Fecha"].ToString()),
                                CotizacionTipoId      = Int16.Parse(dr["CotizacionTipoId"].ToString()),
                                PersonaId             = Int32.Parse(dr["PersonaId"].ToString()),
                                //PersonaNombre         = dr["PersonaNombre"].ToString(),
                                Telefono              = dr["Telefono"].ToString(),
                                CorreoElectronico     = dr["CorreoElectronico"].ToString(),
                                //EmpresaNombre         = dr["EmpresaNombre"].ToString(),
                                Contacto              = dr["Contacto"].ToString(),
                                EmpresaId             = Int32.Parse(dr["EmpresaId"].ToString()),
                                SubTotal              = Decimal.Parse(dr["SubTotal"].ToString()),
                                Descuento             = Decimal.Parse(dr["Descuento"].ToString()),
                                CampaniaId            = Int32.Parse(dr["CampaniaId"].ToString()),
                                Iva                   = Decimal.Parse(dr["Iva"].ToString()),
                                Total                 = Decimal.Parse(dr["Total"].ToString()),
                                CotizacionEstatusId   = Int16.Parse(dr["CotizacionEstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion> ConsultarPorIdConJoin(Int64 pCotizacionId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CotizacionPM oParametros = new Modelo.Parametro.NovaComercial.SACC.CotizacionPM
                {
                    Opcion       = (Int16)SqlOpciones.ConsultaPorIdConJoin,
                    CotizacionId = pCotizacionId
                };

                AccesoDatos.NovaComercial.SACC.Cotizacion oBD = new AccesoDatos.NovaComercial.SACC.Cotizacion();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion
                            {
                                CotizacionId          = Int32.Parse(dr["CotizacionId"].ToString()),
                                CotizacionDescripcion = dr["CotizacionDescripcion"].ToString(),
                                Fecha                 = DateTime.Parse(dr["Fecha"].ToString()),
                                CotizacionTipoId      = Int16.Parse(dr["CotizacionTipoId"].ToString()),
                                PersonaId             = Int32.Parse(dr["PersonaId"].ToString()),
                                PersonaNombre         = dr["PersonaNombre"].ToString(),
                                NumSocio              = dr["NumSocio"].ToString(),
                                Telefono              = dr["Telefono"].ToString(),
                                CorreoElectronico     = dr["CorreoElectronico"].ToString(),
                                EmpresaNombre         = dr["EmpresaNombre"].ToString(),
                                Contacto              = dr["Contacto"].ToString(),
                                EmpresaId             = Int32.Parse(dr["EmpresaId"].ToString()),
                                SubTotal              = Decimal.Parse(dr["SubTotal"].ToString()),
                                Descuento             = Decimal.Parse(dr["Descuento"].ToString()),
                                CampaniaId            = Int32.Parse(dr["CampaniaId"].ToString()),
                                Iva                   = Decimal.Parse(dr["Iva"].ToString()),
                                Total                 = Decimal.Parse(dr["Total"].ToString()),
                                CotizacionEstatusId   = Int16.Parse(dr["CotizacionEstatusId"].ToString())
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
                res.Error         = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.Cotizacion obj, List<Entidades.NovaComercial.SACC.CotizacionDetalle> objDetalle, List<Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle> objProcedimientoDetalle)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.Cotizacion oBD = new AccesoDatos.NovaComercial.SACC.Cotizacion();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                AccesoDatos.NovaComercial.SACC.CotizacionDetalle oBD_Detalle = new AccesoDatos.NovaComercial.SACC.CotizacionDetalle();
                Modelo.ModeloResponse responseDetalle = new Modelo.ModeloResponse();

                AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle oBD_ProcedimientoDetalle = new AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle();
                Modelo.ModeloResponse responseProcedimientoDetalle = new Modelo.ModeloResponse();

                if (obj.CotizacionId == 0)
                {
                    response = oBD.Insertar((short)SqlOpciones.Insertar, obj);

                    if (!response.Error)
                    {
                        var _CotizacionId = int.Parse(response.Resultado.Tables[0].Rows[0]["CotizacionId"].ToString());

                        if (_CotizacionId > 0)
                        {
                            foreach (Entidades.NovaComercial.SACC.CotizacionDetalle itemDetalle in objDetalle)
                            {
                                itemDetalle.CotizacionId = _CotizacionId;

                                if (itemDetalle.CotizacionDetalleId == 0)
                                {
                                    responseDetalle = oBD_Detalle.Insertar((short)SqlOpciones.Insertar, itemDetalle);

                                    var _CotizacionDetalleId = int.Parse(responseDetalle.Resultado.Tables[0].Rows[0]["CotizacionDetalleId"].ToString());

                                    if (_CotizacionDetalleId > 0)
                                    {
                                        if (itemDetalle.ServicioId == 9)
                                        {
                                            foreach (Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle itemProcedimientoDetalle in objProcedimientoDetalle)
                                            {
                                                if (itemDetalle.ItemId == itemProcedimientoDetalle.ProcedimientoId)
                                                {
                                                    itemProcedimientoDetalle.CotizacionDetalleId = _CotizacionDetalleId;
                                                    itemProcedimientoDetalle.CotizacionId        = _CotizacionId;

                                                    responseProcedimientoDetalle = oBD_ProcedimientoDetalle.Insertar((short)SqlOpciones.Insertar, itemProcedimientoDetalle);
                                                }
                                            }
                                        }
                                    }
                                }


                                if (itemDetalle.CotizacionDetalleId > 0)
                                {
                                    responseDetalle = oBD_Detalle.Actualizar((short)SqlOpciones.Actualizar, itemDetalle);

                                    var _CotizacionDetalleId = int.Parse(responseDetalle.Resultado.Tables[0].Rows[0]["CotizacionDetalleId"].ToString());

                                    if (_CotizacionDetalleId > 0)
                                    {
                                        if (itemDetalle.ServicioId == 9)
                                        {
                                            foreach (Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle itemProcedimientoDetalle in objProcedimientoDetalle)
                                            {
                                                if (itemDetalle.ItemId == itemProcedimientoDetalle.ProcedimientoId)
                                                {
                                                    itemProcedimientoDetalle.CotizacionDetalleId = _CotizacionDetalleId;
                                                    itemProcedimientoDetalle.CotizacionId = _CotizacionId;

                                                    responseProcedimientoDetalle = oBD_ProcedimientoDetalle.Actualizar((short)SqlOpciones.Insertar, itemProcedimientoDetalle);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (obj.Baja == true)
                    {
                        obj.UsuarioBajaId = obj.UsuarioBajaId;
                    }

                    response = oBD.Actualizar((short)SqlOpciones.Actualizar, obj);

                    if (!response.Error)
                    {
                        var _CotizacionId = int.Parse(response.Resultado.Tables[0].Rows[0]["CotizacionId"].ToString());

                        if (_CotizacionId > 0)
                        {
                            foreach (Entidades.NovaComercial.SACC.CotizacionDetalle itemDetalle in objDetalle)
                            {
                                itemDetalle.CotizacionId = _CotizacionId;

                                if (itemDetalle.CotizacionDetalleId == 0)
                                {
                                    responseDetalle = oBD_Detalle.Insertar((short)SqlOpciones.Insertar, itemDetalle);

                                    var _CotizacionDetalleId = int.Parse(responseDetalle.Resultado.Tables[0].Rows[0]["CotizacionDetalleId"].ToString());

                                    if (_CotizacionDetalleId > 0)
                                    {
                                        if (itemDetalle.ServicioId == 9)
                                        {
                                            foreach (Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle itemProcedimientoDetalle in objProcedimientoDetalle)
                                            {
                                                if (itemDetalle.ItemId == itemProcedimientoDetalle.ProcedimientoId)
                                                {
                                                    itemProcedimientoDetalle.CotizacionDetalleId = _CotizacionDetalleId;
                                                    itemProcedimientoDetalle.CotizacionId        = _CotizacionId;

                                                    responseProcedimientoDetalle = oBD_ProcedimientoDetalle.Insertar((short)SqlOpciones.Insertar, itemProcedimientoDetalle);
                                                }
                                            }
                                        }
                                    }
                                }


                                if (itemDetalle.CotizacionDetalleId > 0)
                                {
                                    responseDetalle = oBD_Detalle.Actualizar((short)SqlOpciones.Actualizar, itemDetalle);

                                    var _CotizacionDetalleId = int.Parse(responseDetalle.Resultado.Tables[0].Rows[0]["CotizacionDetalleId"].ToString());

                                    if (_CotizacionDetalleId > 0)
                                    {
                                        if (itemDetalle.ServicioId == 9)
                                        {
                                            foreach (Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle itemProcedimientoDetalle in objProcedimientoDetalle)
                                            {
                                                if (itemDetalle.ItemId == itemProcedimientoDetalle.ProcedimientoId)
                                                {
                                                    itemProcedimientoDetalle.CotizacionDetalleId = _CotizacionDetalleId;
                                                    itemProcedimientoDetalle.CotizacionId        = _CotizacionId;

                                                    if (itemProcedimientoDetalle.CotizacionProcedimientoDetalleId == 0)
                                                    {
                                                        responseProcedimientoDetalle = oBD_ProcedimientoDetalle.Insertar((short)SqlOpciones.Insertar, itemProcedimientoDetalle);
                                                    }
                                                    else {
                                                        responseProcedimientoDetalle = oBD_ProcedimientoDetalle.Actualizar((short)SqlOpciones.Insertar, itemProcedimientoDetalle);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["CotizacionId"].ToString());
                        res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pCotizacionId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                Entidades.NovaComercial.SACC.Cotizacion oE = new Entidades.NovaComercial.SACC.Cotizacion
                {
                    CotizacionId      = pCotizacionId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.Cotizacion oBD = new AccesoDatos.NovaComercial.SACC.Cotizacion();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["CotizacionId"].ToString());
                    res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                    res.MensajeError = response.MensajeError;
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




        private static BaseColor ColorCeldaCebra(Int32 numberRow)
        {
            if (numberRow % 2 == 0)
                return new BaseColor(249, 249, 249);
            else
                return BaseColor.WHITE;
        }

        public static void CreatePDF(Int64 pCotizacionId, String pCorreoElectronico)
        {
            String _serverPath            = ConfigurationManager.AppSettings["DirectorioPrincipal"].ToString();
            Boolean _ContieneProcedimiento = false;

            #region OBTENER COTIZACION
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion> objCotizacion = ConsultarPorIdConJoin(pCotizacionId);

            Int32    _Folio            = objCotizacion.Datos[0].CotizacionId;
            DateTime _Fecha            = objCotizacion.Datos[0].Fecha;
            String   _Cliente          = objCotizacion.Datos[0].PersonaNombre;
            String   _NumSocio         = objCotizacion.Datos[0].NumSocio;
            String   _Empresa          = objCotizacion.Datos[0].EmpresaNombre;
            String   _Contacto         = objCotizacion.Datos[0].Contacto;
            String   _Telefono         = objCotizacion.Datos[0].Telefono;
            String   _CorreoElectonico = objCotizacion.Datos[0].CorreoElectronico;
            Int16    _CotizacionTipo   = objCotizacion.Datos[0].CotizacionTipoId;
            Decimal  _Total            = objCotizacion.Datos[0].Total;
            #endregion

            #region OBTENER COTIZACION DETALLE
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalleConPrecio> objCotizacionDetalle = CotizacionDetalle.ConsultarGridConPredio(0, pCotizacionId, 1);
            #endregion

            #region CREA EL PDF
            Document  doc    = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(_serverPath + "Plantilla\\Cotizacion" + objCotizacion.Datos[0].CotizacionId + ".pdf", FileMode.Create));

            doc.Open();
            #endregion

            #region DEFINICION DE VARIABLES
            var colorAzulado   = new BaseColor(0,   54,  160);
            var colorGrisaseo  = new BaseColor(83,  85,  90);
            var colorGrisFondo = new BaseColor(238, 238, 238);
            var colorNaranja   = new BaseColor(253, 178, 55);

            BaseColor TabelHeaderBackGroundColor = colorGrisFondo;

            
            var titleFontBlue           = FontFactory.GetFont("Tahoma",       12,    colorAzulado);
            var bodyFont                = FontFactory.GetFont("Tahoma",       8,     colorGrisaseo);
            var EmailFont               = FontFactory.GetFont("Gothic",       8,     BaseColor.BLUE);

            var boldTableFont           = FontFactory.GetFont("Tahoma",       10,    Font.BOLD, colorNaranja);

            var fontTituloIndicaciones  = FontFactory.GetFont("Tahoma",       9,     Font.BOLD, colorAzulado);
            var fontTituloIndicaciones2 = FontFactory.GetFont("Tahoma",       9,     Font.BOLD, colorGrisaseo);
            var fontBodyIndicaciones    = FontFactory.GetFont("Trebuchet MS", 8,     colorGrisaseo);

            var fontDatosPaciente       = FontFactory.GetFont("Trebuchet MS", 10.5f, colorGrisaseo);
            
            var fontVinetasIndicaciones = FontFactory.GetFont("Trebuchet MS", 9,     colorNaranja);

            var titleFont               = FontFactory.GetFont("Tahoma", 12, Font.BOLD);
            
            var fontTituloDatosPaciente = FontFactory.GetFont("Tahoma", 12, Font.BOLD, colorAzulado);
            
            var fontCorreoFooter        = FontFactory.GetFont("Tahoma", 12, Font.BOLD, BaseColor.WHITE);
            var fontUrlFooter           = FontFactory.GetFont("Tahoma", 12, Font.BOLD, BaseColor.WHITE);
            #endregion

            #region CREA EL HEADER
                #region  CREA LA TABLA PRINCIPAL
                PdfPTable TablaEncabezado = new PdfPTable(3)
                {
                    HorizontalAlignment = (int)HorizontalAlign.Left,
                    WidthPercentage     = 100
                };
                TablaEncabezado.SetWidths(new float[] { 80f, 320f, 100f });
                TablaEncabezado.DefaultCell.Border = Rectangle.NO_BORDER;
                #endregion

                #region INSERTA LOGO NOVA
                iTextSharp.text.Image logoNova = iTextSharp.text.Image.GetInstance(_serverPath + "Assets\\images\\LogoNova.png");
                logoNova.ScaleToFit(60f, 60f);

                PdfPCell CeldaLogoNova = new PdfPCell(logoNova)
                {
                    Border              = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    VerticalAlignment   = Element.ALIGN_MIDDLE
                };
                TablaEncabezado.AddCell(CeldaLogoNova);
                #endregion

                #region TITULO
                PdfPTable TablaTitulo           = new PdfPTable(1);
                TablaTitulo.DefaultCell.Border  = Rectangle.NO_BORDER;
                TablaTitulo.HorizontalAlignment = Element.ALIGN_LEFT;
 
                PdfPCell CeldaTitulos = new PdfPCell()
                {
                    VerticalAlignment = Element.ALIGN_CENTER,
                    Border            = Rectangle.NO_BORDER
                };
                CeldaTitulos.AddElement(new Paragraph("Hospital Clínica Nova", titleFont));
                CeldaTitulos.AddElement(new Paragraph("COTIZACIÓN DE SERVICIOS", titleFont));
                TablaTitulo.AddCell(CeldaTitulos);

                PdfPCell CeldaTablaTitulo = new PdfPCell(TablaTitulo)
                {
                    Border = (int)Rectangle.NO_BORDER,
                };
                TablaEncabezado.AddCell(CeldaTablaTitulo);
                #endregion

                #region INSERTA LOGO CLUB SALUD
                iTextSharp.text.Image logoCSN = iTextSharp.text.Image.GetInstance(_serverPath + "Assets\\images\\LogoClub Salud.png");
                logoCSN.ScaleToFit(80f, 80f);

                PdfPCell pdfCelllogoCSN = new PdfPCell(logoCSN)
                {
                    Border              = (int)Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment   = Element.ALIGN_CENTER
                };
                TablaEncabezado.AddCell(pdfCelllogoCSN);
                #endregion

                doc.Add(TablaEncabezado);
            #endregion


            #region CREA EL BODY
                #region HEADER DE LA COTIZACION
                doc.Add(new Phrase("FOLIO", fontTituloDatosPaciente));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase(objCotizacion.Datos[0].CotizacionId.ToString(), fontDatosPaciente));

                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase("FECHA", fontTituloDatosPaciente));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase(objCotizacion.Datos[0].Fecha.ToString("dd-MMM-yyyy"), fontDatosPaciente));
                #endregion

                #region DATOS DE PACIENTE
                if (_CotizacionTipo == 1)
                {
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("DATOS DEL CLIENTE", fontTituloDatosPaciente));

                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("Nombre: " + _Cliente, fontDatosPaciente));

                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("Teléfono: " + _Telefono, fontDatosPaciente));

                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("Correo Electronico: " + _CorreoElectonico, fontDatosPaciente));

                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Paragraph(" "));
                }

                if (_CotizacionTipo == 2)
                {
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("DATOS DEL CLIENTE", fontTituloDatosPaciente));
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("Nombre: " + _Cliente, fontDatosPaciente));

                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("Número de Socio: " + _NumSocio, fontDatosPaciente));
 
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Paragraph(" "));
                }


                if (_CotizacionTipo == 3)
                {
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("DATOS DE AL EMPRESA", fontTituloDatosPaciente));
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("Nombre: " + _Empresa, fontDatosPaciente));

                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("Contacto: " + _Contacto, fontDatosPaciente));

                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("Teléfono: " + _Telefono, fontDatosPaciente));

                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("Correo Electronico: " + _CorreoElectonico, fontDatosPaciente));

                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Paragraph(" "));
                }

                if (_CotizacionTipo == 4)
                {
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("DATOS DE AL EMPRESA", fontTituloDatosPaciente));
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Phrase("Nombre: " + _Empresa, fontDatosPaciente));

                    //doc.Add(Chunk.NEWLINE);
                    //doc.Add(new Phrase("Contacto: " + _Contacto, fontDatosPaciente));

                    //doc.Add(Chunk.NEWLINE);
                    //doc.Add(new Phrase("Teléfono: " + _Telefono, fontDatosPaciente));

                    //doc.Add(Chunk.NEWLINE);
                    //doc.Add(new Phrase("Correo Electronico: " + _CorreoElectonico, fontDatosPaciente));

                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Paragraph(" "));
                }
                #endregion DATOS DE PACIENTE

            #region Items Table
            //Create body table
            PdfPTable itemTable = new PdfPTable(5)
                {
                    HorizontalAlignment = 0,
                    WidthPercentage     = 100
                };
                itemTable.SetWidths(new float[] { 10, 40, 10, 20, 20 });  // then set the column's __relative__ widths
                itemTable.SpacingAfter = 40;
                itemTable.DefaultCell.Border = Rectangle.NO_BORDER;

                PdfPCell cell1 = new PdfPCell(new Phrase("Partida", boldTableFont))
                {
                    BackgroundColor     = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border              = Rectangle.NO_BORDER
                };
                itemTable.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Phrase("Descripcion", boldTableFont))
                {
                    BackgroundColor     = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    Border              = Rectangle.NO_BORDER
                };
                itemTable.AddCell(cell2);

                PdfPCell cell3 = new PdfPCell(new Phrase("Cantidad", boldTableFont))
                {
                    BackgroundColor     = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border              = Rectangle.NO_BORDER
                };
                itemTable.AddCell(cell3);
 
                PdfPCell cell4 = new PdfPCell(new Phrase("Precio Unitario", boldTableFont))
                {
                    BackgroundColor     = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    Border              = Rectangle.NO_BORDER
                };
                itemTable.AddCell(cell4);

                PdfPCell cell5 = new PdfPCell(new Phrase("Subtotal", boldTableFont))
                {
                    BackgroundColor     = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border              = Rectangle.NO_BORDER
                };
                itemTable.AddCell(cell5);


                Int32 _partida = 1;
                foreach (Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalleConPrecio row in objCotizacionDetalle.Datos)
                {
                    PdfPCell numberCell = new PdfPCell(new Phrase(_partida.ToString(), bodyFont))
                    {
                        HorizontalAlignment = 1,
                        PaddingLeft         = 10f,
                        Border              = Rectangle.NO_BORDER,// | Rectangle.RIGHT_BORDER,
                        BackgroundColor     = ColorCeldaCebra(_partida)
                    };
                    itemTable.AddCell(numberCell);

                    var _phrase = new Phrase
                    {
                        new Chunk(row.ItemDescripcion, bodyFont)
                    };

                    PdfPCell descCell = new PdfPCell(_phrase);
                    descCell.HorizontalAlignment = 0;
                    descCell.PaddingLeft         = 10f;
                    descCell.Border              = Rectangle.NO_BORDER;// | Rectangle.RIGHT_BORDER;
                    descCell.BackgroundColor     = ColorCeldaCebra(_partida);
                    itemTable.AddCell(descCell);

                    PdfPCell qtyCell = new PdfPCell(new Phrase(row.Cantidad.ToString(), bodyFont));
                    qtyCell.HorizontalAlignment = 1;
                    qtyCell.PaddingLeft         = 10f;
                    qtyCell.Border              = Rectangle.NO_BORDER;// | Rectangle.RIGHT_BORDER;
                    qtyCell.BackgroundColor     = ColorCeldaCebra(_partida);
                    itemTable.AddCell(qtyCell);

                    PdfPCell amountCell = new PdfPCell(new Phrase(row.PrecioConIva.ToString("C"), bodyFont));
                    amountCell.HorizontalAlignment = 1;
                    amountCell.PaddingLeft         = 10f;
                    amountCell.Border              = Rectangle.NO_BORDER;// | Rectangle.RIGHT_BORDER;
                    amountCell.BackgroundColor     = ColorCeldaCebra(_partida);
                    itemTable.AddCell(amountCell);

                    PdfPCell totalamtCell = new PdfPCell(new Phrase(row.SubTotalConIva.ToString("C"), bodyFont));
                    totalamtCell.HorizontalAlignment = 1;
                    totalamtCell.Border              = Rectangle.NO_BORDER;// | Rectangle.RIGHT_BORDER;
                    totalamtCell.BackgroundColor     = ColorCeldaCebra(_partida);
                    itemTable.AddCell(totalamtCell);

                if (row.ServicioId == 9)
                    _ContieneProcedimiento = true;

                    _partida++;
                }


                // Table footer
                PdfPCell totalAmtCell1 = new PdfPCell(new Phrase(""));
                totalAmtCell1.Border          = Rectangle.NO_BORDER;// | Rectangle.TOP_BORDER;
                totalAmtCell1.BackgroundColor = ColorCeldaCebra(_partida);
                itemTable.AddCell(totalAmtCell1);

                PdfPCell totalAmtCell2 = new PdfPCell(new Phrase(""));
                totalAmtCell2.Border          = Rectangle.NO_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                totalAmtCell2.BackgroundColor = ColorCeldaCebra(_partida);
                itemTable.AddCell(totalAmtCell2);

                PdfPCell totalAmtCell3 = new PdfPCell(new Phrase(""));
                totalAmtCell3.Border          = Rectangle.NO_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                totalAmtCell3.BackgroundColor = ColorCeldaCebra(_partida);
                itemTable.AddCell(totalAmtCell3);

                PdfPCell totalAmtStrCell = new PdfPCell(new Phrase("Total:", boldTableFont));
                totalAmtStrCell.Border              = Rectangle.NO_BORDER;   //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                totalAmtStrCell.HorizontalAlignment = 1;
                totalAmtStrCell.BackgroundColor     = ColorCeldaCebra(_partida);
                itemTable.AddCell(totalAmtStrCell);

                PdfPCell totalAmtCell = new PdfPCell(new Phrase(_Total.ToString("C"), boldTableFont));
                totalAmtCell.HorizontalAlignment = 1;
                totalAmtCell.BackgroundColor     = ColorCeldaCebra(_partida);
                totalAmtCell.Border              = Rectangle.NO_BORDER;
                itemTable.AddCell(totalAmtCell);

                PdfPCell cell = new PdfPCell(new Phrase("", bodyFont));
                cell.Colspan             = 5;
                cell.HorizontalAlignment = 1;
                cell.Border              = Rectangle.NO_BORDER;
                itemTable.AddCell(cell);

                doc.Add(itemTable);
                #endregion

                #region INDICACIONES
                PdfPTable TablaIndicaciones = new PdfPTable(1);
                TablaIndicaciones.WidthPercentage    = 100;
                TablaIndicaciones.DefaultCell.Border = Rectangle.NO_BORDER;

                PdfPCell CeldaIndicaciones = new PdfPCell();
                CeldaIndicaciones.Border          = Rectangle.NO_BORDER;
                CeldaIndicaciones.BackgroundColor = colorGrisFondo;
                CeldaIndicaciones.PaddingLeft     = 10f;

                List elements = new List(List.UNORDERED, 10f);
                elements.IndentationLeft = 10f;
                elements.SetListSymbol("\u2022");
                elements.Symbol = new Chunk("\u2022", fontVinetasIndicaciones);

                CeldaIndicaciones.AddElement(new Phrase("Los precios ya incluyen IVA.", fontTituloIndicaciones));

                if (_ContieneProcedimiento)
                {
                    CeldaIndicaciones.AddElement(new Phrase("NO INCLUYE:", fontTituloIndicaciones));

                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Medicamentos adicionales a lo cotizado.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Medicamentos complejos como: amal, flounin, Invex, Clindamicina, Gentamicina Traidex, albumina.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Medicamentos para sedación cuando el paciente está en Ucia, de uso crónico, insulex.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Medicamentos para alta o baja presión, anticoagulantes como bolentax.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Exámenes de laboratorio o RX antes o después del procedimiento, pruebas de compatibilidad.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("½ horas adicionales a las cotizadas.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Valoración preoperatoria.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Días de internamiento adicional a lo cotizado.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Estancia en urgencias o UCIA.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Biopsias definitivas, biopsia transoperatoria, marcadores de inmunohistoquímica. Medicamentos especiales para reversion de anestesia como Bridion, lufcuren, dopram, grapadora de piel, renta de equipo no solicitado con anticipación para complementar el presupuesto.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Alimentación nasogástrica, kabiven, multivitamínicos.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("Prueba Pcr covid, prueba serológica.", fontBodyIndicaciones)));
                    elements.Add(new iTextSharp.text.ListItem(new Phrase("UCIA, oxigeno empotrado, colchon neumatico, nebulizaciones, ventilador.", fontBodyIndicaciones)));

                    CeldaIndicaciones.AddElement(elements);
                    CeldaIndicaciones.AddElement(new Paragraph(" "));
                }
                

                CeldaIndicaciones.AddElement(new Phrase("MÉTODOS DE PAGO", fontTituloIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("En caso de procedimiento quirúrgico se requerirá un anticipo del 80% de lo cotizado, el resto será pagado al alta médica del paciente.\n", fontBodyIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("Puedes pagar en caja de Hospital Clínica Nova o en el portal Nova www.novaservicios.com.mx con efectivo, tarjetas de débito y crédito.", fontBodyIndicaciones));

                CeldaIndicaciones.AddElement(new Paragraph(" "));

                CeldaIndicaciones.AddElement(new Phrase("OBSERVACIONES GENERALES", fontTituloIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("El tiempo corre desde el momento que entra a la sala de operación hasta que pasa a la sala de recuperación.", fontBodyIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("La cotización es un aproximado de los gastos, a requerir, pueden varían en cantidad y precio al cierre de la cuenta.", fontBodyIndicaciones));

                CeldaIndicaciones.AddElement(new Paragraph(" "));

                CeldaIndicaciones.AddElement(new Phrase("CONTACTO:", fontTituloIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("Club Salud Nova", fontTituloIndicaciones2));
                CeldaIndicaciones.AddElement(new Phrase("clubdesalud@novaservicios.com.mx", fontBodyIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("81 8865 5896", fontBodyIndicaciones));

                CeldaIndicaciones.AddElement(new Paragraph(" "));

                CeldaIndicaciones.AddElement(new Phrase("Claudia Pompa", fontTituloIndicaciones2));
                CeldaIndicaciones.AddElement(new Phrase("cpompa@novaservicios.com.mx", fontBodyIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("81 8865 5886", fontBodyIndicaciones));

                CeldaIndicaciones.AddElement(new Paragraph(" "));
                
                CeldaIndicaciones.AddElement(new Phrase("Daniela Castro", fontTituloIndicaciones2));
                CeldaIndicaciones.AddElement(new Phrase("dcastro@ternium.com.mx", fontBodyIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("81 8865 582", fontBodyIndicaciones));


            TablaIndicaciones.AddCell(CeldaIndicaciones);
                doc.Add(TablaIndicaciones);
                #endregion INDICACIONES
            #endregion CREA EL BODY

            #region CREA EL FOOTER

            doc.Add(new Paragraph(" "));

            #region CREAR TABLA FOOTER
            PdfPTable TablaFooter = new PdfPTable(4)
            {
                HorizontalAlignment = (int)HorizontalAlign.Left,
                WidthPercentage     = 100
            };
            TablaFooter.SetWidths(new float[] { 54f, 96f, 260, 90f });
            TablaFooter.DefaultCell.Border = Rectangle.NO_BORDER;
            #endregion CREAR TABLA FOOTER

            #region INSERTAR LOGO CSG
            iTextSharp.text.Image logoMundo = iTextSharp.text.Image.GetInstance(_serverPath + "Assets\\images\\Logo_CSG.png");
            logoMundo.ScaleToFit(54f, 70f);

            PdfPCell CeldaLogoMundo = new PdfPCell(logoMundo)
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment   = Element.ALIGN_MIDDLE,
                Border              = Rectangle.NO_BORDER
            };

            TablaFooter.AddCell(CeldaLogoMundo);
            #endregion INSERTAR LOGO CSG

            #region INSERTAR LOGO HOSPITAL
            iTextSharp.text.Image logoHospital = iTextSharp.text.Image.GetInstance(_serverPath + "Assets\\images\\Logo_DistintivoH.jpg");
            logoHospital.ScaleToFit(76f, 70f);

            PdfPCell CeldaLogoHospital = new PdfPCell(logoHospital)
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment   = Element.ALIGN_MIDDLE,
                PaddingLeft         = 10f,
                PaddingRight        = 10f,
                Border              = Rectangle.NO_BORDER
            };
            TablaFooter.AddCell(CeldaLogoHospital);
            #endregion INSERTAR LOGO HOSPITAL

            #region INSERTAR CORREO Y PÁGINA
            PdfPCell CeldaUrls = new PdfPCell()
            {
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Border            = Rectangle.NO_BORDER,
                PaddingTop        = -10f,
                PaddingLeft       = 15f,
                BackgroundColor   = colorNaranja
            };

            CeldaUrls.AddElement(new Phrase("clubdesalud@novaservicios.com.mx", fontCorreoFooter));
            CeldaUrls.AddElement(new Phrase("www.novaservicios.com.mx", fontUrlFooter));
            TablaFooter.AddCell(CeldaUrls);
            #endregion INSERTAR CORREO Y PÁGINA

            #region INSERTAR IMGQR
            iTextSharp.text.Image imgQR = iTextSharp.text.Image.GetInstance(_serverPath + "Assets\\images\\ClubSaludQR.png");
            imgQR.ScaleToFit(70f, 70f);

            PdfPCell CeldaCodigoQR = new PdfPCell(imgQR)
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment   = Element.ALIGN_CENTER,
                BackgroundColor     = colorNaranja,
                Padding             = 10f,
                Border              = Rectangle.NO_BORDER
            };
            TablaFooter.AddCell(CeldaCodigoQR);
            #endregion INSERTAR IMGQR

            doc.Add(TablaFooter);
            #endregion CREA EL FOOTER

            doc.Close();
        }
    }
}