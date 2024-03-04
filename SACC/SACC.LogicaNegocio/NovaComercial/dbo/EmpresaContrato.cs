using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class EmpresaContrato
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaContrato.DtoGridEmpresaContrato> ConsultarGrid(Int32 pEmpresaId, Int32 pContratoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaContrato.DtoGridEmpresaContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaContrato.DtoGridEmpresaContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.EmpresaContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.EmpresaContratoPM
                {
                    Opcion     = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    EmpresaId  = pEmpresaId,
                    ContratoId = pContratoId,
                    EstatusId  = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.EmpresaContrato oBD = new AccesoDatos.NovaComercial.dbo.EmpresaContrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.EmpresaContrato.DtoGridEmpresaContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.EmpresaContrato.DtoGridEmpresaContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.EmpresaContrato.DtoGridEmpresaContrato
                            {
                                EmpresaContratoId   = Int32.Parse(dr["EmpresaContratoId"].ToString()),
                                EmpresaId           = Int32.Parse(dr["EmpresaId"].ToString()),
                                EmpresaDescripcion  = dr["EmpresaDescripcion"].ToString(),
                                ContratoId          = Int32.Parse(dr["ContratoId"].ToString()),
                                ContratoDescripcion = dr["ContratoDescripcion"].ToString(),
                                EstatusId           = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaContrato.DtoEmpresaContrato> ConsultarPorId(Int32 pEmpresaContratoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaContrato.DtoEmpresaContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaContrato.DtoEmpresaContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.EmpresaContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.EmpresaContratoPM
                {
                    Opcion            = (Int16)SqlOpciones.ConsultaPorId,
                    EmpresaContratoId = pEmpresaContratoId
                };

                AccesoDatos.NovaComercial.dbo.EmpresaContrato oBD = new AccesoDatos.NovaComercial.dbo.EmpresaContrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.EmpresaContrato.DtoEmpresaContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.EmpresaContrato.DtoEmpresaContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.EmpresaContrato.DtoEmpresaContrato
                            {
                                EmpresaContratoId = Int32.Parse(dr["EmpresaContratoId"].ToString()),
                                //EmpresaContratoDescripcion = dr["EmpresaContratoDescripcion"].ToString(),
                                EstatusId         = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaContrato.DtoComboEmpresaContrato> ConsultarComboJon(Int32 pEmpresaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaContrato.DtoComboEmpresaContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaContrato.DtoComboEmpresaContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.EmpresaContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.EmpresaContratoPM
                {
                    Opcion    = (Int16)SqlOpciones.ListaConJoin,
                    EmpresaId = pEmpresaId
                };

                AccesoDatos.NovaComercial.dbo.EmpresaContrato oBD = new AccesoDatos.NovaComercial.dbo.EmpresaContrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.EmpresaContrato.DtoComboEmpresaContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.EmpresaContrato.DtoComboEmpresaContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.EmpresaContrato.DtoComboEmpresaContrato
                            {
                                ContratoId          = Int32.Parse(dr["ContratoId"].ToString()),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.EmpresaContrato obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.EmpresaContrato oBD = new AccesoDatos.NovaComercial.dbo.EmpresaContrato();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.EmpresaContratoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaContratoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pEmpresaContratoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.EmpresaContrato oE = new Entidades.NovaComercial.dbo.EmpresaContrato
                {
                    EmpresaContratoId = pEmpresaContratoId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.EmpresaContrato oBD = new AccesoDatos.NovaComercial.dbo.EmpresaContrato();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    if (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True")
                    {
                        res.Error = true;
                        res.TituloError = "(LogicaLegocio) - El registro no se pudo guardar/actualizar.";
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaContratoId"].ToString());
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }



        //        public static List<Entidades.NovaComercial.dbo.EmpresaContrato> Consultar(SqlOpciones pOpcion, int pEmpresaContratoId, int pEmpresaId, int pContratoId, int pBaja)
        //        {
        //            Entidades.NovaComercial.dbo.EmpresaContrato oE = new Entidades.NovaComercial.dbo.EmpresaContrato();

        //            oE.EmpresaContratoId = pEmpresaContratoId;
        //            oE.EmpresaId         = pEmpresaId;
        //            oE.ContratoId        = pContratoId;

        //            switch (pBaja)
        //            {
        //                case 0:
        //                    oE.Baja = false;
        //                    break;
        //                case 1:
        //                    oE.Baja = true;
        //                    break;
        //                default:
        //                    oE.Baja = null;
        //                    break;
        //            }

        //            DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

        //            List<Entidades.NovaComercial.dbo.EmpresaContrato> res = new List<Entidades.NovaComercial.dbo.EmpresaContrato>();
        //            Entidades.NovaComercial.dbo.EmpresaContrato item = null;

        //            foreach (DataTable table in ds.Tables)
        //            {
        //                foreach (DataRow dr in table.Rows)
        //                {
        //                    item = new Entidades.NovaComercial.dbo.EmpresaContrato();

        //                    item.EmpresaContratoId = int.Parse(dr["EmpresaContratoId"].ToString());
        //                    item.EmpresaId         = int.Parse(dr["EmpresaId"].ToString());
        //                    item.ContratoId        = int.Parse(dr["ContratoId"].ToString());

        //                    if (dr.Table.Columns.Contains("EmpresaDescripcion"))
        //                        item.CampoComplemento_EmpresaDescripcion = dr["EmpresaDescripcion"].ToString();

        //                    if (dr.Table.Columns.Contains("ContratoDescripcion"))
        //                        item.CampoComplemento_ContratoDescripcion = dr["ContratoDescripcion"].ToString();

        //                    if (dr.Table.Columns.Contains("Baja"))
        //                        item.Baja = bool.Parse(dr["Baja"].ToString());

        //                    res.Add(item);
        //                }
        //            }

        //            return res;
        //        }


        //        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.EmpresaContrato obj)
        //        {
        //            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //            Entidades.NovaComercial.dbo.EmpresaContrato oE = new Entidades.NovaComercial.dbo.EmpresaContrato();
        //            DataSet ds = new DataSet();

        //            oE.EmpresaContratoId     = obj.EmpresaContratoId;
        //            oE.EmpresaId             = obj.EmpresaId;
        //            oE.ContratoId            = obj.ContratoId;
        //            oE.UsuarioCreacionId     = obj.UsuarioCreacionId;
        //            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
        //            oE.Baja                  = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

        //            if (oE.EmpresaContratoId == 0)
        //            {
        //                ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;
        //            }
        //            else
        //            {
        //                if (obj.Baja == true)
        //                {
        //                    oE.UsuarioBajaId = obj.UsuarioBajaId;
        //                }

        //                ds = Util.Actualizar(SqlOpciones.Actualizar, oE).Resultado;
        //            }

        //            res.Id           = int.Parse(ds.Tables[0].Rows[0]["EmpresaContratoId"].ToString());
        //            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //            res.MensajeError = "";
        //            res.Error        = false;
        //            res.TipoMensaje  = "success";

        //            return res;
        //        }


        //        public static Entidades.EntidadJsonResponse BajaLogica(int pEmpresaContratoId, int pUsuarioId)
        //        {
        //            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //            Entidades.NovaComercial.dbo.EmpresaContrato oE = new Entidades.NovaComercial.dbo.EmpresaContrato();
        //            DataSet ds = new DataSet();

        //            oE.EmpresaContratoId = pEmpresaContratoId;
        //            oE.UsuarioBajaId     = pUsuarioId;
        //            oE.Baja              = Convert.ToBoolean(Convert.ToInt16("1"));

        //            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

        //            res.Id           = int.Parse(ds.Tables[0].Rows[0]["EmpresaContratoId"].ToString());
        //            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //            res.MensajeError = "";
        //            res.Error        = false;
        //            res.TipoMensaje  = "success";

        //            return res;
        //        }
    }
}