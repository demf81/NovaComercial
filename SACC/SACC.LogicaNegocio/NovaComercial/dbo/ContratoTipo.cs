using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class ContratoTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoTipo.DtoGridContratoTipo> ConsultarGrid(String pContratoTipoDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoTipo.DtoGridContratoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoTipo.DtoGridContratoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoTipoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoTipoPM
                {
                    Opcion                  = (Int16)SqlOpciones.ConsultaGeneral,
                    ContratoTipoDescripcion = pContratoTipoDescripcion,
                    EstatusId               = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.ContratoTipo oBD = new AccesoDatos.NovaComercial.dbo.ContratoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoTipo.DtoGridContratoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoTipo.DtoGridContratoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoTipo.DtoGridContratoTipo
                            {
                                ContratoTipoId          = Int32.Parse(dr["ContratoTipoId"].ToString()),
                                ContratoTipoDescripcion = dr["ContratoTipoDescripcion"].ToString(),
                                EstatusId               = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoTipo.DtoContratoTipo> ConsultarPorId(Int32 pContratoTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoTipo.DtoContratoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoTipo.DtoContratoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoTipoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoTipoPM
                {
                    Opcion         = (Int16)SqlOpciones.ConsultaPorId,
                    ContratoTipoId = pContratoTipoId
                };

                AccesoDatos.NovaComercial.dbo.ContratoTipo oBD = new AccesoDatos.NovaComercial.dbo.ContratoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoTipo.DtoContratoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoTipo.DtoContratoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoTipo.DtoContratoTipo
                            {
                                ContratoTipoId          = Int16.Parse(dr["ContratoTipoId"].ToString()),
                                ContratoTipoDescripcion = dr["ContratoTipoDescripcion"].ToString(),
                                EstatusId               = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoTipo.DtoComboContratoTipo> ConsultarCombo(String pContratoTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoTipo.DtoComboContratoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoTipo.DtoComboContratoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoTipoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoTipoPM
                {
                    Opcion                  = (Int16)SqlOpciones.Lista,
                    ContratoTipoDescripcion = pContratoTipoDescripcion
                };

                AccesoDatos.NovaComercial.dbo.ContratoTipo oBD = new AccesoDatos.NovaComercial.dbo.ContratoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoTipo.DtoComboContratoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoTipo.DtoComboContratoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoTipo.DtoComboContratoTipo
                            {
                                ContratoTipoId          = Int16.Parse(dr["ContratoTipoId"].ToString()),
                                ContratoTipoDescripcion = dr["ContratoTipoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoTipo obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.ContratoTipo oBD = new AccesoDatos.NovaComercial.dbo.ContratoTipo();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ContratoTipoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoTipoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pContratoTipoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.ContratoTipo oE = new Entidades.NovaComercial.dbo.ContratoTipo
                {
                    ContratoTipoId    = pContratoTipoId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.ContratoTipo oBD = new AccesoDatos.NovaComercial.dbo.ContratoTipo();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoTipoId"].ToString());
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

        //public static List<Entidades.NovaComercial.dbo.ContratoTipo> Consultar(SqlOpciones pOpcion, int pContratoTipoId, string pContratoTipoDescripcion, int pBaja)
        //{
        //    Entidades.NovaComercial.dbo.ContratoTipo oE = new Entidades.NovaComercial.dbo.ContratoTipo();

        //    oE.ContratoTipoId = pContratoTipoId;

        //    if (pContratoTipoDescripcion != "")
        //        oE.ContratoTipoDescripcion = pContratoTipoDescripcion;

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

        //    List<Entidades.NovaComercial.dbo.ContratoTipo> res = new List<Entidades.NovaComercial.dbo.ContratoTipo>();
        //    Entidades.NovaComercial.dbo.ContratoTipo item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.ContratoTipo();

        //            item.ContratoTipoId          = int.Parse(dr["ContratoTipoId"].ToString());
        //            item.ContratoTipoDescripcion = dr["ContratoTipoDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}
    }
}