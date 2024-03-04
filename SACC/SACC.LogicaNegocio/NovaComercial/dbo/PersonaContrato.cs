using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class PersonaContrato
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContrato> ConsultarGrid(Int32 pPersonaContratoId, Int32 pPersonaId, Int32 pContratoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PersonaContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PersonaContratoPM
                {
                    Opcion            = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    PersonaContratoId = pPersonaContratoId,
                    PersonaId         = pPersonaId,
                    ContratoId        = pContratoId,
                    EstatusId         = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.PersonaContrato oBD = new AccesoDatos.NovaComercial.dbo.PersonaContrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContrato
                            {
                                PersonaContratoId            = Int32.Parse(dr["PersonaContratoId"].ToString()),
                                ContratoDescripcion          = dr["ContratoDescripcion"].ToString(),
                                ContratoCoberturaDescripcion = dr["ContratoCoberturaDescripcion"].ToString(),
                                PaqueteDescripcion           = dr["PaqueteDescripcion"].ToString(),
                                EstatusId                    = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContratoCoberturaDefault> ConsultarCoberturaPorPersonaGrid(Int32 pPersonaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContratoCoberturaDefault> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContratoCoberturaDefault>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PersonaContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PersonaContratoPM
                {
                    Opcion    = (Int16)SqlOpciones.ConsultaGeneralCoberturaPorPersona,
                    PersonaId = pPersonaId,
                };

                AccesoDatos.NovaComercial.dbo.PersonaContrato oBD = new AccesoDatos.NovaComercial.dbo.PersonaContrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContratoCoberturaDefault item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContratoCoberturaDefault>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContratoCoberturaDefault
                            {
                                Seleccionado                 = false,
                                PersonaContratoId            = Int32.Parse(dr["PersonaContratoId"].ToString()),
                                PersonaId                    = Int32.Parse(dr["PersonaId"].ToString()),
                                NombreCompleto               = dr["NombreCompleto"].ToString(),
                                ContratoId                   = Int32.Parse(dr["ContratoId"].ToString()),
                                ContratoDescripcion          = dr["ContratoDescripcion"].ToString(),
                                ContratoCoberturaId          = Int32.Parse(dr["ContratoCoberturaId"].ToString()),
                                ContratoCoberturaDescripcion = dr["ContratoCoberturaDescripcion"].ToString(),
                                PaqueteId                    = Int32.Parse(dr["PaqueteId"].ToString()),
                                PaqueteDescripcion           = dr["PaqueteDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoPersonaContrato> ConsultarPorId(Int32 pPersonaContratoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoPersonaContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoPersonaContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PersonaContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PersonaContratoPM
                {
                    Opcion            = (Int16)SqlOpciones.ConsultaPorId,
                    PersonaContratoId = pPersonaContratoId
                };

                AccesoDatos.NovaComercial.dbo.PersonaContrato oBD = new AccesoDatos.NovaComercial.dbo.PersonaContrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.PersonaContrato.DtoPersonaContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.PersonaContrato.DtoPersonaContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.PersonaContrato.DtoPersonaContrato
                            {
                                PersonaContratoId = Int32.Parse(dr["PersonaContratoId"].ToString()),
                                //PersonaContratoDescripcion = dr["PersonaContratoDescripcion"].ToString(),
                                EstatusId = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoComboPersonaContratoContrato> ConsultarComboContrato(Int32 pPersonaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoComboPersonaContratoContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoComboPersonaContratoContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PersonaContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PersonaContratoPM
                {
                    Opcion    = (Int16)SqlOpciones.ContultarPersonaContratoContrato,
                    PersonaId = pPersonaId
                };

                AccesoDatos.NovaComercial.dbo.PersonaContrato oBD = new AccesoDatos.NovaComercial.dbo.PersonaContrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.PersonaContrato.DtoComboPersonaContratoContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.PersonaContrato.DtoComboPersonaContratoContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.PersonaContrato.DtoComboPersonaContratoContrato
                            {
                                ContratoId           = Int32.Parse(dr["ContratoId"].ToString()),
                                ContratoDescripcion = dr["ContratoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.PersonaContrato obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.PersonaContrato oBD = new AccesoDatos.NovaComercial.dbo.PersonaContrato();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.PersonaContratoId == 0)
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
                        res.TituloError  = "(LogicaLegocio) - El registro no se pudo guardar/actualizar.";
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PersonaContratoId"].ToString());
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


        public static Modelo.ModeloJsonResponse AvtivaCobertura(Entidades.NovaComercial.dbo.PersonaContrato obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.PersonaContrato oBD = new AccesoDatos.NovaComercial.dbo.PersonaContrato();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.PersonaContratoId != 0)
                {
                    response = oBD.Actualizar((short)SqlOpciones.ActivaCoberturaDefault, obj);
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PersonaContratoId"].ToString());
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


        public static Modelo.ModeloJsonResponse InactivaCobertura(Entidades.NovaComercial.dbo.PersonaContrato obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.PersonaContrato oBD = new AccesoDatos.NovaComercial.dbo.PersonaContrato();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.PersonaId != 0)
                {
                    response = oBD.Actualizar((short)SqlOpciones.InactivarCoberturaDefault, obj);
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PersonaContratoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pPersonaContratoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.PersonaContrato oE = new Entidades.NovaComercial.dbo.PersonaContrato
                {
                    PersonaContratoId = pPersonaContratoId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.PersonaContrato oBD = new AccesoDatos.NovaComercial.dbo.PersonaContrato();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PersonaContratoId"].ToString());
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




        //public static List<Entidades.NovaComercial.dbo.PersonaContrato> Consultar(SqlOpciones pOpcion, int pParsonaContratoId, int pPersonaId, int pContratoId, int pBaja)
        //{
        //    Entidades.NovaComercial.dbo.PersonaContrato oE = new Entidades.NovaComercial.dbo.PersonaContrato();

        //    oE.PersonaContratoId = pParsonaContratoId;
        //    oE.PersonaId         = pPersonaId;
        //    oE.ContratoId        = pContratoId;

        //    switch (pBaja)
        //    {
        //        case 0:
        //            oE.Baja = false;
        //            break;
        //        case 1:
        //            oE.Baja = true;
        //            break;
        //        default:
        //            oE.Baja = null;
        //            break;
        //    }

        //    DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

        //    List<Entidades.NovaComercial.dbo.PersonaContrato> res = new List<Entidades.NovaComercial.dbo.PersonaContrato>();
        //    Entidades.NovaComercial.dbo.PersonaContrato item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.PersonaContrato();

        //            item.PersonaContratoId   = int.Parse(dr["PersonaContratoId"].ToString());
        //            item.PersonaId           = int.Parse(dr["PersonaId"].ToString());
        //            item.ContratoId          = int.Parse(dr["ContratoId"].ToString());


        //            if (dr.Table.Columns.Contains("NombreCompleto"))
        //                item.CampoComplemento_NombreCompleto = dr["NombreCompleto"].ToString();

        //            if (dr.Table.Columns.Contains("ContratoDescripcion"))
        //                item.CampoComplemento_ContratoDescripcion = dr["ContratoDescripcion"].ToString();


        //            if (dr.Table.Columns.Contains("ContratoCoberturaId"))
        //                item.ContratoCoberturaId = int.Parse(dr["ContratoCoberturaId"].ToString());

        //            if (dr.Table.Columns.Contains("ContratoCoberturaDescripcion"))
        //                item.CampoComplemento_ContratoCoberturaDescripcion = dr["ContratoCoberturaDescripcion"].ToString();


        //            //if (dr.Table.Columns.Contains("PaqueteId"))
        //            //    item.CampoComplemento_PaqueteId = int.Parse(dr["PaqueteId"].ToString());

        //            //if (dr.Table.Columns.Contains("PaqueteDescripcion"))
        //            //    item.CampoComplemento_PaqueteDescripcion = dr["PaqueteDescripcion"].ToString();


        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse Guardar(SqlOpciones opcion, Entidades.NovaComercial.dbo.PersonaContrato obj)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.PersonaContrato oE = new Entidades.NovaComercial.dbo.PersonaContrato();
        //    DataSet ds = new DataSet();

        //    oE.PersonaContratoId     = obj.PersonaContratoId;
        //    oE.PersonaId             = obj.PersonaId;
        //    oE.ContratoId            = obj.ContratoId;
        //    oE.ContratoCoberturaId   = obj.ContratoCoberturaId;
        //    oE.PaqueteId             = obj.PaqueteId;
        //    oE.UsuarioCreacionId     = obj.UsuarioCreacionId;
        //    oE.UsuarioModificacionId = obj.UsuarioModificacionId;
        //    oE.Baja                  = Convert.ToBoolean(Convert.ToInt16(0));

        //    if (obj.PersonaContratoId == 0)
        //    {
        //        ds = Util.Insertar(opcion, oE).Resultado;
        //    }
        //    else
        //    {
        //        //    if (pBaja == "1")
        //        //    {
        //        //        oCE.FechaBaja = System.DateTime.Now;
        //        //        oCE.UsuarioBajaId = 0;
        //        //    }

        //        //oCE.PaqueteId = pPaqueteId;
        //        //oE.FechaModificacion = System.DateTime.Now;
        //        ds = Util.Actualizar(opcion, oE).Resultado;
        //    }

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["PersonaContratoId"].ToString());
        //    res.Mensaje      = ds.Tables[0].Rows[0]["Mensaje"].ToString() == "" ? "El registro se actualizo satisfactoriamente." : ds.Tables[0].Rows[0]["Mensaje"].ToString();
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse BajaLogica(int pPersonaContratoId, int pUsuarioId)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.PersonaContrato oE = new Entidades.NovaComercial.dbo.PersonaContrato();
        //    DataSet ds = new DataSet();

        //    oE.PersonaContratoId = pPersonaContratoId;
        //    oE.UsuarioBajaId     = pUsuarioId;
        //    oE.Baja              = Convert.ToBoolean(Convert.ToInt16("1"));

        //    ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["PersonaContratoId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}
    }
}