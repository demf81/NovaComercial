using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class EmpresaPlanta
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoGridEmpresaPlanta> ConsultarGrid(Int32 pEmpresaId, String pEmpresaPlantaDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoGridEmpresaPlanta> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoGridEmpresaPlanta>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.EmpresaPlantaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.EmpresaPlantaPM
                {
                    Opcion    = (Int16)SqlOpciones.ConsultaGeneral,
                    EmpresaId = pEmpresaId,
                    EstatusId = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.EmpresaPlanta oBD = new AccesoDatos.NovaComercial.dbo.EmpresaPlanta();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.EmpresaPlanta.DtoGridEmpresaPlanta item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoGridEmpresaPlanta>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.EmpresaPlanta.DtoGridEmpresaPlanta
                            {
                                EmpresaPlantaId          = Int32.Parse(dr["EmpresaPlantaId"].ToString()),
                                EmpresaPlantaDescripcion = dr["EmpresaPlantaDescripcion"].ToString(),
                                EstatusId                = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoEmpresaPlanta> ConsultarPorId(Int32 pEmpresaPlantaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoEmpresaPlanta> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoEmpresaPlanta>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.EmpresaPlantaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.EmpresaPlantaPM
                {
                    Opcion          = (Int16)SqlOpciones.ConsultaPorId,
                    EmpresaPlantaId = pEmpresaPlantaId
                };

                AccesoDatos.NovaComercial.dbo.EmpresaPlanta oBD = new AccesoDatos.NovaComercial.dbo.EmpresaPlanta();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.EmpresaPlanta.DtoEmpresaPlanta item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoEmpresaPlanta>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.EmpresaPlanta.DtoEmpresaPlanta
                            {
                                EmpresaPlantaId          = Int32.Parse(dr["EmpresaPlantaId"].ToString()),
                                EmpresaPlantaDescripcion = dr["EmpresaPlantaDescripcion"].ToString(),
                                EstatusId                = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoComboEmpresaPlanta> ConsultarCombo(Int32 pEmpresaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoComboEmpresaPlanta> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoComboEmpresaPlanta>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.EmpresaPlantaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.EmpresaPlantaPM
                {
                    Opcion    = (Int16)SqlOpciones.Lista,
                    EmpresaId = pEmpresaId
                };

                AccesoDatos.NovaComercial.dbo.EmpresaPlanta oBD = new AccesoDatos.NovaComercial.dbo.EmpresaPlanta();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.EmpresaPlanta.DtoComboEmpresaPlanta item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.EmpresaPlanta.DtoComboEmpresaPlanta>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.EmpresaPlanta.DtoComboEmpresaPlanta
                            {
                                EmpresaPlantaId          = Int32.Parse(dr["EmpresaPlantaId"].ToString()),
                                EmpresaPlantaDescripcion = dr["EmpresaPlantaDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.EmpresaPlanta obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.EmpresaPlanta oBD = new AccesoDatos.NovaComercial.dbo.EmpresaPlanta();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.EmpresaPlantaId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaPlantaId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pEmpresaPlantaId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.EmpresaPlanta oE = new Entidades.NovaComercial.dbo.EmpresaPlanta
                {
                    EmpresaPlantaId   = pEmpresaPlantaId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.EmpresaPlanta oBD = new AccesoDatos.NovaComercial.dbo.EmpresaPlanta();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaPlantaId"].ToString());
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


        //public static List<Entidades.NovaComercial.dbo.EmpresaPlanta> Consultar(SqlOpciones pOpcion, int pEmpresaPlantaId, string pEmpresaPlantaDescripcion, int pEmpresaId, int pBaja)
        //{
        //    Entidades.NovaComercial.dbo.EmpresaPlanta oE = new Entidades.NovaComercial.dbo.EmpresaPlanta();

        //    oE.EmpresaPlantaId = pEmpresaPlantaId;
        //    oE.EmpresaId       = pEmpresaId;

        //    if (pEmpresaPlantaDescripcion != "")
        //        oE.EmpresaPlantaDescripcion = pEmpresaPlantaDescripcion;

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

        //    List<Entidades.NovaComercial.dbo.EmpresaPlanta> res = new List<Entidades.NovaComercial.dbo.EmpresaPlanta>();
        //    Entidades.NovaComercial.dbo.EmpresaPlanta item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.EmpresaPlanta();

        //            item.EmpresaPlantaId          = int.Parse(dr["EmpresaPlantaId"].ToString());
        //            item.EmpresaId                = int.Parse(dr["EmpresaId"].ToString());
        //            item.EmpresaPlantaDescripcion = dr["EmpresaPlantaDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}
    }
}