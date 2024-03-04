using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class ContratoCobertura : Conexion.ConexionSQL
    {
        public ContratoCobertura()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCobertura_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                       oParametro.Opcion),
                        new SqlParameter("@ContratoCoberturaId",          oParametro.ContratoCoberturaId),
                        new SqlParameter("@ContratoId",                   oParametro.ContratoId),
                        new SqlParameter("@ContratoCoberturaDescripcion", oParametro.ContratoCoberturaDescripcion),
                        new SqlParameter("@EstatusId",                    oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.ContratoCobertura oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCobertura_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                         Opcion),
                        new SqlParameter("@ContratoId",                     oBE.ContratoId),
                        new SqlParameter("@ContratoCoberturaDescripcion",   oBE.ContratoCoberturaDescripcion),
                        new SqlParameter("@TodoMedicamento",                oBE.TodoMedicamento),
                        new SqlParameter("@TodoMaterial",                   oBE.TodoMaterial),
                        new SqlParameter("@TodoCirugia",                    oBE.TodoCirugia),
                        new SqlParameter("@TodoEstudio",                    oBE.TodoEstudio),
                        new SqlParameter("@TodoServicio",                   oBE.TodoServicio),
                        new SqlParameter("@ContratoCoberturaTipoId",        oBE.ContratoCoberturaTipoId),
                        new SqlParameter("@VigenciaDesde",                  oBE.VigenciaDesde),
                        new SqlParameter("@VigenciaHasta",                  oBE.VigenciaHasta),
                        new SqlParameter("@EsquemaPrePago",                 oBE.EsquemaPrePago),
                        new SqlParameter("@CobroAnticipado",                oBE.CobroAnticipado),
                        new SqlParameter("@TarifaId",                       oBE.TarifaId),
                        new SqlParameter("@PorcentajeUtilidadSobreTarifa",  oBE.PorcentajeUtilidadSobreTarifa),
                        new SqlParameter("@PorcentajeCopagoContratante",    oBE.PorcentajeCopagoContratante),
                        new SqlParameter("@PorcentajeDescuentoSobreTarifa", oBE.PorcentajeDescuentoSobreTarifa),
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.ContratoCobertura oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCobertura_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                         Opcion),
                        new SqlParameter("@ContratoCoberturaId",            oBE.ContratoCoberturaId),
                        new SqlParameter("@ContratoId",                     oBE.ContratoId),
                        new SqlParameter("@ContratoCoberturaDescripcion",   oBE.ContratoCoberturaDescripcion),
                        new SqlParameter("@TodoMedicamento",                oBE.TodoMedicamento),
                        new SqlParameter("@TodoMaterial",                   oBE.TodoMaterial),
                        new SqlParameter("@TodoCirugia",                    oBE.TodoCirugia),
                        new SqlParameter("@TodoEstudio",                    oBE.TodoEstudio),
                        new SqlParameter("@TodoServicio",                   oBE.TodoServicio),
                        new SqlParameter("@ContratoCoberturaTipoId",        oBE.ContratoCoberturaTipoId),
                        new SqlParameter("@VigenciaDesde",                  oBE.VigenciaDesde),
                        new SqlParameter("@VigenciaHasta",                  oBE.VigenciaHasta),
                        new SqlParameter("@EsquemaPrePago",                 oBE.EsquemaPrePago),
                        new SqlParameter("@CobroAnticipado",                oBE.CobroAnticipado),
                        new SqlParameter("@TarifaId",                       oBE.TarifaId),
                        new SqlParameter("@PorcentajeUtilidadSobreTarifa",  oBE.PorcentajeUtilidadSobreTarifa),
                        new SqlParameter("@PorcentajeCopagoContratante",    oBE.PorcentajeCopagoContratante),
                        new SqlParameter("@PorcentajeDescuentoSobreTarifa", oBE.PorcentajeDescuentoSobreTarifa),
                        new SqlParameter("@UsuarioModificacionId",          oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",              oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",                  oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                      oBE.FechaBaja),
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