using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Membresia
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Membresia.DtoGridMembresia> ConsultarGrid(DateTime? pFechaInicio, DateTime? pFechaFin, DateTime? pVigenciaInicio, DateTime? pVigenciaFin, Int16 pMembresiaTipoId, String pNombre, Int32 pNumSocio, Int16 pClaveFamiliar, Int32 pNumRecibo, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Membresia.DtoGridMembresia> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Membresia.DtoGridMembresia>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaPM
                {
                    Opcion          = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    FechaInicio     = pFechaInicio,
                    FechaFin        = pFechaFin,
                    VigenciaInicio  = pVigenciaInicio,
                    VigenciaFin     = pVigenciaFin,
                    MembresiaTipoId = pMembresiaTipoId,
                    Nombre          = pNombre,
                    NumSocio        = pNumSocio,
                    ClaveFamiliar   = pClaveFamiliar,
                    NumRecibo       = pNumRecibo,
                    EstatusId       = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.Membresia oBD = new AccesoDatos.NovaComercial.SACC.Membresia();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Membresia.DtoGridMembresia item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Membresia.DtoGridMembresia>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Membresia.DtoGridMembresia
                            {
                                MembresiaId                  = Int32.Parse(dr["MembresiaId"].ToString()),
                                Fecha                        = dr["Fecha"].ToString(),
                                Vigencia                     = dr["Vigencia"].ToString(),
                                MembresiaTipoDescripcion     = dr["MembresiaTipoDescripcion"].ToString(),
                                NumSocio                     = dr["NumSocio"].ToString(),
                                NombreComplento              = dr["Paterno"].ToString() + " " + dr["Materno"] + ", " + dr["Nombre"].ToString(),
                                //CantidadBeneficiarios        = Int32.Parse(dr["CantidadBeneficiarios"].ToString()),
                                CantidadAfiliadosRegistrados = Int32.Parse(dr["CantidadAfiliadosRegistrados"].ToString()),
                                CantidadAfiliadosAmparados   = Int32.Parse(dr["CantidadAfiliadosAmparados"].ToString()),
                                CantidadAdicionales          = Int32.Parse(dr["CantidadAdicionales"].ToString()),
                                NumPedido                    = Int32.Parse(dr["NumPedido"].ToString()),
                                NumRecibo                    = Int32.Parse(dr["NumRecibo"].ToString()),
                                MembresiaEstatusId           = Int16.Parse(dr["MembresiaEstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Membresia.DtoMembresia> ConsultarPorId(Int32 pMembresiaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Membresia.DtoMembresia> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Membresia.DtoMembresia>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaPM
                {
                    Opcion      = (Int16)SqlOpciones.ConsultaPorId,
                    MembresiaId = pMembresiaId
                };

                AccesoDatos.NovaComercial.SACC.Membresia oBD = new AccesoDatos.NovaComercial.SACC.Membresia();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Membresia.DtoMembresia item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Membresia.DtoMembresia>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Membresia.DtoMembresia
                            {
                                MembresiaId = Int32.Parse(dr["MembresiaId"].ToString()),
                                Fecha       = DateTime.Parse(dr["Fecha"].ToString()),
                                Vigencia    = DateTime.Parse(dr["Vigencia"].ToString()),
                                Baja        = bool.Parse(dr["Baja"].ToString())
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.Membresia obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.Membresia oBD = new AccesoDatos.NovaComercial.SACC.Membresia();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.MembresiaId == 0)
                {
                    response = oBD.Insertar((short)SqlOpciones.InsertarEspecial, obj);
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
                        res.TituloError  = "(LogicaLegocio) - El registro no se pudo guardar/actualizar.";
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["MembresiaId"].ToString());
                        res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;;
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


        public static Modelo.ModeloJsonResponse ActualizarVigencia(Int32 pMembresiaId, Int32 pNumeroSocio, Int16 pClaveFamiliar)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Modelo.ModeloJsonResponse<Modelo.VigenciaII.PUB.ccu_usuarios.Dtoccu_usuarios> response = new Modelo.ModeloJsonResponse<Modelo.VigenciaII.PUB.ccu_usuarios.Dtoccu_usuarios>();

                /* BUSCAR EN VIGENCIA A LA PERSONA */
                if (pNumeroSocio > 0)
                {
                    response = VigenciaII.PUB.ccu_usuarios.ObtieneVigencia_usuarios(pNumeroSocio, pClaveFamiliar);
                }

                if (!response.Error)
                {
                    AccesoDatos.NovaComercial.SACC.Membresia oBD = new AccesoDatos.NovaComercial.SACC.Membresia();
                    Modelo.ModeloResponse responseMembresia = new Modelo.ModeloResponse();

                    Entidades.NovaComercial.SACC.Membresia obj = new Entidades.NovaComercial.SACC.Membresia
                    {
                        MembresiaId = pMembresiaId,
                        Vigencia    = response.Datos[0].ccu_fec_baja.Value
                    };

                    if (pMembresiaId > 0)
                    {
                        responseMembresia = oBD.Actualizar((short)SqlOpciones.ActualizarVigenciaMembresia, obj);
                    }

                    if (!responseMembresia.Error)
                    {
                        if (responseMembresia.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True")
                        {
                            res.Error        = true;
                            res.TituloError  = "(LogicaLegocio) - El registro no se pudo guardar/actualizar.";
                            res.MensajeError = responseMembresia.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                            res.TipoMensaje  = "warning";
                        }
                        else
                        {
                            res.Id      = Int32.Parse(responseMembresia.Resultado.Tables[0].Rows[0]["MembresiaId"].ToString());
                            res.Mensaje = responseMembresia.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                        }
                    }
                    else
                    {
                        res.Error        = true;
                        res.TituloError  = response.TituloError; ;
                        res.MensajeError = response.MensajeError;
                        res.TipoMensaje  = "error";
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError; ;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = response.TipoMensaje;
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pMembresiaId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                Entidades.NovaComercial.SACC.Membresia oE = new Entidades.NovaComercial.SACC.Membresia
                {
                    MembresiaId       = pMembresiaId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.Membresia oBD = new AccesoDatos.NovaComercial.SACC.Membresia();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["MembresiaId"].ToString());
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


        public static Modelo.ModeloJsonResponse CreatePDF(Int32 pMembresiaId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                String _serverPath = ConfigurationManager.AppSettings["DirectorioPrincipal"].ToString();

                #region OBTENER MEMBRESIA
                Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Membresia.DtoMembresia> objMembresia = ConsultarPorId(pMembresiaId);
                #endregion

                #region OBTENER MEMBRESIA DETALLE
                Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaPersona.DtoGridMembresiaPersona> objMembresiaDetalle = MembresiaPersona.ConsultarGrid(pMembresiaId, 1);
                #endregion

                #region CREA EL PDF
                Document doc = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(_serverPath + "Plantilla\\Membresia" + pMembresiaId + ".pdf", FileMode.Create));

                doc.Open();
                #endregion

                #region DEFINICION DE VARIABLES
                var colorAzulado = new BaseColor(0, 54, 160);
                var colorGrisaseo = new BaseColor(83, 85, 90);
                var colorGrisFondo = new BaseColor(238, 238, 238);
                var colorNaranja = new BaseColor(253, 178, 55);

                BaseColor TabelHeaderBackGroundColor = colorGrisFondo;

                var titleFont = FontFactory.GetFont("Tahoma", 12, Font.BOLD);
                var bodyFont = FontFactory.GetFont("Tahoma", 8, colorGrisaseo);

                var boldTableFont = FontFactory.GetFont("Tahoma", 10, Font.BOLD, colorNaranja);

                var fontTituloIndicaciones = FontFactory.GetFont("Tahoma", 9, Font.BOLD, colorAzulado);
                var fontBodyIndicaciones = FontFactory.GetFont("Trebuchet MS", 8, colorGrisaseo);
                var fontBodyIndicacionesBold = FontFactory.GetFont("Tahoma", 8, Font.BOLD, colorGrisaseo);

                var fontVinetasIndicaciones = FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, colorNaranja);
                var fontCorreoFooter = FontFactory.GetFont("Tahoma", 12, Font.BOLD, BaseColor.WHITE);
                var fontUrlFooter = FontFactory.GetFont("Tahoma", 12, Font.BOLD, BaseColor.WHITE);
                #endregion


                #region CREA EL HEADER
                #region  CREA LA TABLA PRINCIPAL
                PdfPTable TablaEncabezado = new PdfPTable(3)
                {
                    HorizontalAlignment = (int)HorizontalAlign.Left,
                    WidthPercentage = 100
                };
                TablaEncabezado.SetWidths(new float[] { 80f, 320f, 100f });
                TablaEncabezado.DefaultCell.Border = Rectangle.NO_BORDER;
                #endregion

                #region INSERTA LOGO NOVA
                iTextSharp.text.Image logoNova = iTextSharp.text.Image.GetInstance(_serverPath + "Assets\\images\\LogoNova.png");
                logoNova.ScaleToFit(60f, 60f);

                PdfPCell CeldaLogoNova = new PdfPCell(logoNova)
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                TablaEncabezado.AddCell(CeldaLogoNova);
                #endregion

                #region TITULO
                PdfPTable TablaTitulo = new PdfPTable(1);
                TablaTitulo.DefaultCell.Border = Rectangle.NO_BORDER;
                TablaTitulo.HorizontalAlignment = Element.ALIGN_LEFT;

                PdfPCell CeldaTitulos = new PdfPCell()
                {
                    VerticalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER
                };
                CeldaTitulos.AddElement(new Paragraph("Hospital Clínica Nova", titleFont));
                CeldaTitulos.AddElement(new Paragraph("FORMATO DE AFILIACIÓN", titleFont));
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
                    Border = (int)Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_CENTER
                };
                TablaEncabezado.AddCell(pdfCelllogoCSN);
                #endregion

                doc.Add(TablaEncabezado);
                doc.Add(new Paragraph(" "));
                #endregion

                #region CREA EL BODY
                #region Items Table
                #region CREA TABLA AFILIADOS
                //Create body table
                PdfPTable itemTable = new PdfPTable(3)
                {
                    HorizontalAlignment = 0,
                    WidthPercentage = 100
                };
                itemTable.SetWidths(new float[] { 33, 33, 34 });  // then set the column's __relative__ widths
                itemTable.DefaultCell.Border = Rectangle.NO_BORDER;


                PdfPCell cell1 = new PdfPCell(new Phrase("Número de socio", boldTableFont))
                {
                    BackgroundColor = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER
                };
                itemTable.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Phrase("Clave familiar", boldTableFont))
                {
                    BackgroundColor = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER
                };
                itemTable.AddCell(cell2);

                PdfPCell cell3 = new PdfPCell(new Phrase("Nombre", boldTableFont))
                {
                    BackgroundColor = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER
                };
                itemTable.AddCell(cell3);

                Int32 _partida = 1;
                var afiliadosPrincipales = objMembresiaDetalle.Datos.Take(4);
                var afiliadosAdicionales = objMembresiaDetalle.Datos.Skip(4);

                foreach (Modelo.NovaComercial.SACC.MembresiaPersona.DtoGridMembresiaPersona row in afiliadosPrincipales)
                {
                    PdfPCell numSocioCell = new PdfPCell(new Phrase(SepararCadena(row.NumSocio)[0].ToString(), bodyFont));
                    numSocioCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    numSocioCell.PaddingLeft = 10f;
                    numSocioCell.Border = Rectangle.NO_BORDER;// | Rectangle.RIGHT_BORDER;
                    numSocioCell.BackgroundColor = ColorCeldaCebra(_partida);
                    itemTable.AddCell(numSocioCell);

                    PdfPCell qtyCell = new PdfPCell(new Phrase(SepararCadena(row.NumSocio)[1].ToString(), bodyFont));
                    qtyCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    qtyCell.PaddingLeft = 10f;
                    qtyCell.Border = Rectangle.NO_BORDER;// | Rectangle.RIGHT_BORDER;
                    qtyCell.BackgroundColor = ColorCeldaCebra(_partida);
                    itemTable.AddCell(qtyCell);

                    PdfPCell mombreCell = new PdfPCell(new Phrase(row.NombreCompleto.ToString(), bodyFont));
                    mombreCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    mombreCell.PaddingLeft = 10f;
                    mombreCell.Border = Rectangle.NO_BORDER;// | Rectangle.RIGHT_BORDER;
                    mombreCell.BackgroundColor = ColorCeldaCebra(_partida);
                    itemTable.AddCell(mombreCell);

                    _partida++;
                }
                #endregion CREA TABLA AFILIADOS

                #region CREA TABLA AFILIADOS ADICIONALES
                //Create body table adicional
                PdfPTable itemTableAdicional = new PdfPTable(3)
                {
                    HorizontalAlignment = 0,
                    WidthPercentage = 100
                };
                itemTableAdicional.SetWidths(new float[] { 33, 33, 34 });  // then set the column's __relative__ widths
                itemTableAdicional.SpacingAfter = 40;
                itemTableAdicional.DefaultCell.Border = Rectangle.NO_BORDER;

                PdfPCell celdaNumSocioAdicional = new PdfPCell(new Phrase("Número de socio adicional", boldTableFont))
                {
                    BackgroundColor = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER
                };
                itemTableAdicional.AddCell(celdaNumSocioAdicional);

                PdfPCell celdaClaveFamiliarAdicional = new PdfPCell(new Phrase("Clave familiar", boldTableFont))
                {
                    BackgroundColor = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER
                };
                itemTableAdicional.AddCell(celdaClaveFamiliarAdicional);

                PdfPCell celdaNombreAdicional = new PdfPCell(new Phrase("Nombre", boldTableFont))
                {
                    BackgroundColor = TabelHeaderBackGroundColor,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER
                };
                itemTableAdicional.AddCell(celdaNombreAdicional);

                _partida = 1;
                PdfPCell _cellVacia = new PdfPCell(new Phrase(" "))
                {
                    Border = Rectangle.NO_BORDER,
                    BackgroundColor = ColorCeldaCebra(_partida)
                };

                if (afiliadosAdicionales.Count() == 0)
                {
                    itemTableAdicional.AddCell(_cellVacia);
                    itemTableAdicional.AddCell(_cellVacia);
                    itemTableAdicional.AddCell(_cellVacia);
                }

                foreach (Modelo.NovaComercial.SACC.MembresiaPersona.DtoGridMembresiaPersona row in afiliadosAdicionales)
                {
                    PdfPCell numSocioCell = new PdfPCell(new Phrase(SepararCadena(row.NumSocio)[0].ToString(), bodyFont));
                    numSocioCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    numSocioCell.PaddingLeft = 10f;
                    numSocioCell.Border = Rectangle.NO_BORDER;// | Rectangle.RIGHT_BORDER;
                    numSocioCell.BackgroundColor = ColorCeldaCebra(_partida);
                    itemTableAdicional.AddCell(numSocioCell);

                    PdfPCell claveFamiliarCell = new PdfPCell(new Phrase(SepararCadena(row.NumSocio)[1].ToString(), bodyFont));
                    claveFamiliarCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    claveFamiliarCell.PaddingLeft = 10f;
                    claveFamiliarCell.Border = Rectangle.NO_BORDER;// | Rectangle.RIGHT_BORDER;
                    claveFamiliarCell.BackgroundColor = ColorCeldaCebra(_partida);
                    itemTableAdicional.AddCell(claveFamiliarCell);

                    PdfPCell nombreCell = new PdfPCell(new Phrase(row.NombreCompleto.ToString(), bodyFont));
                    nombreCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    nombreCell.PaddingLeft = 10f;
                    nombreCell.Border = Rectangle.NO_BORDER;// | Rectangle.RIGHT_BORDER;
                    nombreCell.BackgroundColor = ColorCeldaCebra(_partida);
                    itemTableAdicional.AddCell(nombreCell);

                    _partida++;
                }
                #endregion CREA TABLA AFILIADOS ADICIONALES

                #region CREA FOOTER TABLA
                // Table footer
                PdfPCell totalAmtCell1 = new PdfPCell(new Phrase("Vigencia:", boldTableFont))
                {
                    Border = Rectangle.NO_BORDER,// | Rectangle.TOP_BORDER;
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = TabelHeaderBackGroundColor
                };
                itemTableAdicional.AddCell(totalAmtCell1);

                PdfPCell totalAmtCell2 = new PdfPCell(new Phrase(objMembresia.Datos[0].Vigencia.ToString("dd-MM-yyyy")))
                {
                    Border = Rectangle.NO_BORDER, //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                    BackgroundColor = TabelHeaderBackGroundColor
                };
                itemTableAdicional.AddCell(totalAmtCell2);

                PdfPCell totalAmtCell3 = new PdfPCell(new Phrase(""))
                {
                    Border = Rectangle.NO_BORDER, //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                    BackgroundColor = TabelHeaderBackGroundColor
                };
                itemTableAdicional.AddCell(totalAmtCell3);

                PdfPCell cell = new PdfPCell(new Phrase("", bodyFont));
                cell.Colspan = 3;
                cell.HorizontalAlignment = 1;
                cell.Border = Rectangle.NO_BORDER;
                itemTableAdicional.AddCell(cell);
                #endregion CREA FOOTER TABLA

                doc.Add(itemTable);
                doc.Add(itemTableAdicional);
                #endregion

                #region INDICACIONES

                PdfPTable TablaIndicaciones = new PdfPTable(1);
                TablaIndicaciones.WidthPercentage = 100;
                TablaIndicaciones.DefaultCell.Border = Rectangle.NO_BORDER;

                PdfPCell CeldaIndicaciones = new PdfPCell();
                CeldaIndicaciones.Border = Rectangle.NO_BORDER;
                CeldaIndicaciones.BackgroundColor = colorGrisFondo;
                CeldaIndicaciones.PaddingLeft = 10f;

                List elements = new List(List.UNORDERED, 10f);
                elements.IndentationLeft = 10f;
                elements.SetListSymbol("\u2022");
                elements.Symbol = new Chunk("\u2022", fontVinetasIndicaciones);

                CeldaIndicaciones.AddElement(new Phrase("CREDENCIALES", fontTituloIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("Lunes a viernes 8:30 a.m. a 1:00 p.m. y de 2:00 p.m. a 6:00 p.m."));
                CeldaIndicaciones.AddElement(new Phrase("Ubicado en Recreativo NOVA, entrando, en la oficina a la derecha."));
                CeldaIndicaciones.AddElement(new Paragraph(" "));

                CeldaIndicaciones.AddElement(new Phrase("INDUCCIÓN AL SERVICIO MÉDICO", fontTituloIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("Todos los jueves a las  4:00 p.m. vía Teams"));
                CeldaIndicaciones.AddElement(new Phrase("Contacto al 81 8865 5666 con Clariza Castillo para envío de la liga"));
                CeldaIndicaciones.AddElement(new Paragraph(" "));

                CeldaIndicaciones.AddElement(new Phrase("CITAS MÉDICAS", fontTituloIndicaciones));

                Phrase contactCenter = new Phrase();
                contactCenter.Add(new Phrase("Contact center: ", fontBodyIndicacionesBold));
                contactCenter.Add(new Phrase("81 8865 5660", fontBodyIndicaciones));

                Phrase portalNova = new Phrase();
                portalNova.Add(new Phrase("Portal Nova: ", fontBodyIndicacionesBold));
                portalNova.Add(new Phrase("www.novaservicios.com.mx", fontBodyIndicaciones));

                Phrase app = new Phrase();
                app.Add(new Phrase("App: ", fontBodyIndicacionesBold));
                app.Add(new Phrase("Nova Servicios", fontBodyIndicaciones));

                elements.Add(new iTextSharp.text.ListItem(contactCenter));
                elements.Add(new iTextSharp.text.ListItem(portalNova));
                elements.Add(new iTextSharp.text.ListItem(app));

                CeldaIndicaciones.AddElement(elements);
                CeldaIndicaciones.AddElement(new Paragraph(" "));

                #region CREA TABLA REDES SOCIALES
                PdfPTable TablaRedesSociales = new PdfPTable(2)
                {
                    WidthPercentage = 100,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                TablaRedesSociales.DefaultCell.Border = Rectangle.NO_BORDER;
                TablaRedesSociales.SetWidths(new float[] { 20f, 480f });

                iTextSharp.text.Image logoFb = iTextSharp.text.Image.GetInstance(_serverPath + "Assets\\images\\facebook.png");
                logoFb.ScaleToFit(20f, 20f);

                PdfPCell celdaLogoFb = new PdfPCell(logoFb)
                {
                    Border = (int)Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_CENTER
                };

                PdfPCell celdaDescRedSocial = new PdfPCell(new Phrase("NOVA", fontBodyIndicaciones))
                {
                    Border = Rectangle.NO_BORDER
                };

                TablaRedesSociales.AddCell(celdaLogoFb);
                TablaRedesSociales.AddCell(celdaDescRedSocial);

                #endregion CREA TABLA REDES SOCIALES

                CeldaIndicaciones.AddElement(new Phrase("SÍGUENOS EN REDES SOCIALES:", fontTituloIndicaciones));
                CeldaIndicaciones.AddElement(TablaRedesSociales);

                CeldaIndicaciones.AddElement(new Paragraph(" "));

                //List elementsContactosKaren = new List(List.UNORDERED, 10f);
                //elementsContactosKaren.IndentationLeft = 10f;
                //elementsContactosKaren.SetListSymbol("\u2022");
                //elementsContactosKaren.Symbol = new Chunk("\u2022", fontVinetasIndicaciones);

                CeldaIndicaciones.AddElement(new Phrase("Club Salud Nova", fontBodyIndicacionesBold));
                CeldaIndicaciones.AddElement(new Phrase("clubdesalud@novaservicios.com.mx", fontBodyIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("81 8865 5896", fontBodyIndicaciones));

                CeldaIndicaciones.AddElement(new Paragraph(" "));

                CeldaIndicaciones.AddElement(new Phrase("Claudia Pompa", fontBodyIndicacionesBold));
                CeldaIndicaciones.AddElement(new Phrase("cpompa@novaservicios.com.mx", fontBodyIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("81 8865 5886", fontBodyIndicaciones));

                CeldaIndicaciones.AddElement(new Paragraph(" "));

                CeldaIndicaciones.AddElement(new Phrase("Daniela Castro", fontBodyIndicacionesBold));
                CeldaIndicaciones.AddElement(new Phrase("dcastro@ternium.com.mx", fontBodyIndicaciones));
                CeldaIndicaciones.AddElement(new Phrase("81 8865 582", fontBodyIndicaciones));

                //Phrase contactoKaren = new Phrase();
                //contactoKaren.Add(new Phrase("Club Salud Nova \n", fontBodyIndicacionesBold));
                //contactoKaren.Add(new Phrase("81 8865 5896 \n", fontBodyIndicaciones));
                //contactoKaren.Add(new Phrase("clubdesalud@novaservicios.com.mx", fontBodyIndicaciones));

                //elementsContactosKaren.Add(new iTextSharp.text.ListItem(contactoKaren));

                //CeldaIndicaciones.AddElement(elementsContactosKaren);
                //CeldaIndicaciones.AddElement(new Paragraph(" "));



                //contactoKaren.Add(new Phrase("Daniela Castro \n", fontBodyIndicacionesBold));
                //contactoKaren.Add(new Phrase("81 8865 582 \n", fontBodyIndicaciones));
                //contactoKaren.Add(new Phrase("dcastro@ternium.com.mx", fontBodyIndicaciones));

                //elementsContactosKaren.Add(new iTextSharp.text.ListItem(contactoKaren));

                //CeldaIndicaciones.AddElement(elementsContactosKaren);
                //CeldaIndicaciones.AddElement(new Paragraph(" "));

                //List elementsContactosClaudia = new List(List.UNORDERED, 10f);
                //elementsContactosClaudia.IndentationLeft = 10f;
                //elementsContactosClaudia.SetListSymbol("\u2022");
                //elementsContactosClaudia.Symbol = new Chunk("\u2022", fontVinetasIndicaciones);

                //Phrase contactoClaudia = new Phrase();
                //contactoClaudia.Add(new Phrase("Claudia Pompa\n", fontBodyIndicacionesBold));
                //contactoClaudia.Add(new Phrase("81 8865 5886\n", fontBodyIndicaciones));
                //contactoClaudia.Add(new Phrase("cpompa@novaservicios.com.mx", fontBodyIndicaciones));

                //elementsContactosClaudia.Add(new iTextSharp.text.ListItem(contactoClaudia));

                //CeldaIndicaciones.AddElement(elementsContactosClaudia);
                //CeldaIndicaciones.AddElement(new Paragraph(" "));

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
                    WidthPercentage = 100
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
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    Border = Rectangle.NO_BORDER
                };

                TablaFooter.AddCell(CeldaLogoMundo);
                #endregion INSERTAR LOGO CSG

                #region INSERTAR LOGO HOSPITAL
                iTextSharp.text.Image logoHospital = iTextSharp.text.Image.GetInstance(_serverPath + "Assets\\images\\Logo_DistintivoH.jpg");
                logoHospital.ScaleToFit(76f, 70f);

                PdfPCell CeldaLogoHospital = new PdfPCell(logoHospital)
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    PaddingLeft = 10f,
                    PaddingRight = 10f,
                    Border = Rectangle.NO_BORDER
                };
                TablaFooter.AddCell(CeldaLogoHospital);
                #endregion INSERTAR LOGO HOSPITAL

                #region INSERTAR CORREO Y PÁGINA
                PdfPCell CeldaUrls = new PdfPCell()
                {
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    Border = Rectangle.NO_BORDER,
                    PaddingTop = -10f,
                    PaddingLeft = 15f,
                    BackgroundColor = colorNaranja
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
                    VerticalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = colorNaranja,
                    Padding = 10f,
                    Border = Rectangle.NO_BORDER
                };
                TablaFooter.AddCell(CeldaCodigoQR);
                #endregion INSERTAR IMGQR

                doc.Add(TablaFooter);
                #endregion CREA EL FOOTER

                doc.Close();
            }
            catch (Exception exc)
            {
                res.Error = true;
                res.TituloError = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje = "error";
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


        private static String[] SepararCadena(String cadena)
        {
            if (String.IsNullOrEmpty(cadena))
                cadena = "0-0";

            String[] valores =  cadena.Split('-');

            return valores;
        }
    }
}