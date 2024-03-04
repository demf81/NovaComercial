using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class PersonaMoper
    {
        //public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaMoper.DtoPersonaMoper> Consultar()
        //{
        //    Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaMoper.DtoPersonaMoper> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoPersonaMoper>();

        //    try
        //    {
        //        Modelo.Parametro.NovaComercial.dbo.PersonaMoperPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PersonaMoperPM
        //        {
        //            Opcion = (Int16)LogicaNegocio.SqlOpciones.ConsultaGeneral
        //        };

        //        AccesoDatos.NovaComercial.dbo.PersonaMoper oBD = new AccesoDatos.NovaComercial.dbo.PersonaMoper();
        //        Modelo.ModeloResponse response = oBD.Consultar(oParametros);                

        //        if (!response.Error)
        //        {
        //            Modelo.NovaComercial.dbo.Persona.DtoPersonaMoper item = null;
        //            res.Datos = new List<Modelo.NovaComercial.dbo.Persona.DtoPersonaMoper>();

        //            foreach (DataTable table in response.Resultado.Tables)
        //            {
        //                foreach (DataRow dr in table.Rows)
        //                {
        //                    item = new Modelo.NovaComercial.dbo.Persona.DtoPersonaMoper();

        //                    item.PersonaMoperId = int.Parse(dr["PersonaMoperId"].ToString());
        //                    item.PersonaId = int.Parse(dr["PersonaId"].ToString());
        //                    item.ProcesoId = int.Parse(dr["ProcesoId"].ToString());
        //                    item.ClaveMovimientoId = dr["ClaveMovimientoId"].ToString();
        //                    item.ClaveFamiliar = dr["ClaveFamiliar"].ToString();
        //                    item.NumeroSocio = dr["NumeroSocio"].ToString();
        //                    item.Nombre = dr["Nombre"].ToString();
        //                    item.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
        //                    item.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
        //                    item.FechaNacimiento = dr["FechaNacimiento"].ToString();
        //                    item.CURP = dr["CURP"].ToString();
        //                    item.Genero = dr["Genero"].ToString();
        //                    item.EstadoCivilId = dr["EstadoCivilId"].ToString();
        //                    item.GrupoFamiliar = dr["GrupoFamiliar"].ToString();
        //                    item.EmpresaId = dr["EmpresaId"].ToString();
        //                    item.PlantaId = dr["PlantaId"].ToString();
        //                    item.DepartamentoId = dr["DepartamentoId"].ToString();
        //                    item.TipoTrabajadorId = dr["TipoTrabajadorId"].ToString();
        //                    item.NumeroTernium = dr["NumeroTernium"].ToString();
        //                    item.RI = dr["RI"].ToString();
        //                    item.NR = dr["NR"].ToString();
        //                    item.FechaIngresoEmpresa = dr["FechaIngresoEmpresa"].ToString();
        //                    item.FechaIngresoGrupo = dr["FechaIngresoGrupo"].ToString();
        //                    item.EstatusActivo = dr["EstatusActivo"].ToString();
        //                    item.FechaAltaMovimiento = dr["FechaAltaMovimiento"].ToString();
        //                    item.FechaBajaMovimiento = dr["FechaBajaMovimiento"].ToString();
        //                    item.EmpresaAnteriorId = dr["EmpresaAnteriorId"].ToString();
        //                    item.PlantaAnteriorId = dr["PlantaAnteriorId"].ToString();
        //                    item.PersonaMoperEstatusId = int.Parse(dr["PersonaMoperEstatusId"].ToString());
        //                    item.Edad = int.Parse(dr["Edad"].ToString());

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
        //        res.TituloError  = "(LogicaNegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
        //        res.MensajeError = exc.Message.ToString();
        //        res.TipoMensaje  = "error";
        //    }

        //    return res;
        //}


        public static Modelo.ModeloJsonResponse CambiarEstatus(Int32 pPersonaMoperId, Int32 pEstatusId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.PersonaMoper oE = new Entidades.NovaComercial.dbo.PersonaMoper
                {
                    PersonaMoperId        = pPersonaMoperId,
                    PersonaMoperEstatusId = pEstatusId,
                    UsuarioModificacionId = pUsuarioId,
                    FechaModificacion     = DateTime.Now
                };

                AccesoDatos.NovaComercial.dbo.PersonaMoper oBD = new AccesoDatos.NovaComercial.dbo.PersonaMoper();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.CambioEstatus, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PersonaMoperId"].ToString());
                    res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = "(LogicaLegocio) - Error Inesperado - El cambio de estatus no se pudo ejecutar.";
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - El cambio de estatus no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse CambiarEstatusErroneo(Int32 pPersonaMoperId, Int32 pEstatusId, Int32 pUsuarioId, string MensajeError)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.PersonaMoper oE = new Entidades.NovaComercial.dbo.PersonaMoper
                {
                    PersonaMoperId        = pPersonaMoperId,
                    PersonaMoperEstatusId = pEstatusId,
                    UsuarioModificacionId = pUsuarioId,
                    MensajeError          = MensajeError

                };

                AccesoDatos.NovaComercial.dbo.PersonaMoper oBD = new AccesoDatos.NovaComercial.dbo.PersonaMoper();
                Modelo.ModeloResponse response = oBD.Actualizar(4, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PersonaMoperId"].ToString());
                    res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = "(LogicaLegocio) - Error Inesperado - El cambio de estatus no se pudo ejecutar.";
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - El cambio de estatus no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.PersonaMoper obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.PersonaMoper oBD = new AccesoDatos.NovaComercial.dbo.PersonaMoper();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.PersonaMoperId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PersonaId"].ToString());
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
    }
}
