﻿using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class CoberturaCopagoTipo : Conexion.ConexionSQL
    {
        public CoberturaCopagoTipo()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.CoberturaCopagoTipoPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCoberturaCopagoTipo_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                         oParametro.Opcion),
                        new SqlParameter("@CoberturaCopagoTipoId",          oParametro.CoberturaCopagoTipoId),
                        new SqlParameter("@CoberturaCopagoTipoDescripcion", oParametro.CoberturaCopagoTipoDescripcion),
                        new SqlParameter("@EstatusId",                      oParametro.EstatusId)
                    }
                );

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.TituloError  = "Error SQL - La consulta no se pudo ejecutar";
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.CoberturaCopagoTipo oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCoberturaCopagoTipo_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                         Opcion),
                        new SqlParameter("@CoberturaCopagoTipoDescripcion", oBE.CoberturaCopagoTipoDescripcion),
                        new SqlParameter("@UsuarioCreacionId",              oBE.UsuarioCreacionId)
                    }
                );

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.TituloError  = "Error SQL - El registro no se pudo insertar.";
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.CoberturaCopagoTipo oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCoberturaCopagoTipo_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                         Opcion),
                        new SqlParameter("@CoberturaCopagoTipoId",          oBE.CoberturaCopagoTipoId),
                        new SqlParameter("@CoberturaCopagoTipoDescripcion", oBE.CoberturaCopagoTipoDescripcion),
                        new SqlParameter("@UsuarioModificacionId",          oBE.UsuarioModificacionId),
                        new SqlParameter("@UsuarioBajaId",                  oBE.UsuarioBajaId),
                        new SqlParameter("@EstatusId",                      oBE.EstatusId)
                    }
                );

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.TituloError  = "Error SQL - El registro no se pudo actualizar.";
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }
    }
}