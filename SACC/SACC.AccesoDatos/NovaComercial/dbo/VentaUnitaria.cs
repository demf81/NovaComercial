using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class VentaUnitaria : Conexion.ConexionSQL
    {
        public VentaUnitaria()
        {
            NombreConexion = "cxnSACC";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaComercial.dbo.VentaUnitaria oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spVentaUnitaria_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                   Opcion),
                        new SqlParameter("@VentaUnitariaId",          oBE.VentaUnitariaId),
                        new SqlParameter("@VentaUnitariaDescripcion", oBE.VentaUnitariaDescripcion),
                        new SqlParameter("@VentaTipoId",              oBE.VentaTipoId),
                        new SqlParameter("@ContratanteId",            oBE.ContratanteId),
                        new SqlParameter("@TitularId",                oBE.TitularId),
                        new SqlParameter("@PersonaId",                oBE.PersonaId),
                        new SqlParameter("@AsociadoId",               oBE.AsociadoId),
                        new SqlParameter("@PaqueteId",                oBE.PaqueteId),
                        new SqlParameter("@VigenciaInicio",           oBE.VigenciaInicio),
                        new SqlParameter("@VigenciaTermino",          oBE.VigenciaTermino),
                        new SqlParameter("@AutorizacionId",           oBE.AutorizacionId),
                        new SqlParameter("@EsquemaPrePago",           oBE.EsquemaPrePago),
                        new SqlParameter("@CobroAnticipado",          oBE.CobroAnticipado),
                        new SqlParameter("@CobroAnticipadoMonto",     oBE.CobroAnticipadoMonto),
                        new SqlParameter("@MontoLimite",              oBE.MontoLimite),
                        new SqlParameter("@PrecioCobertura",          oBE.PrecioCobertura),
                        new SqlParameter("@PorcentajeUtilidad",       oBE.PorcentajeUtilidad),
                        new SqlParameter("@CopagoTipoId",             oBE.CopagoTipoId),
                        new SqlParameter("@PorcentajeCoPago",         oBE.PorcentajeCoPago),
                        new SqlParameter("@PorcentajeDescuento",      oBE.PorcentajeDescuento),
                        new SqlParameter("@Total",                    oBE.Total),
                        new SqlParameter("@EstatusId",                oBE.EstatusId),
                        new SqlParameter("@Baja",                     oBE.Baja),
                        new SqlParameter("@Filtro_Nombre",            oBE.Filtro_Nombre)
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
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.VentaUnitaria oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spVentaUnitaria_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                   Opcion),
                        new SqlParameter("@VentaUnitariaDescripcion", oBE.VentaUnitariaDescripcion),
                        new SqlParameter("@VentaTipoId",              oBE.VentaTipoId),
                        new SqlParameter("@ContratanteId",            oBE.ContratanteId),
                        new SqlParameter("@TitularId",                oBE.TitularId),
                        new SqlParameter("@PersonaId",                oBE.PersonaId),
                        new SqlParameter("@AsociadoId",               oBE.AsociadoId),
                        new SqlParameter("@PaqueteId",                oBE.PaqueteId),
                        new SqlParameter("@VigenciaInicio",           oBE.VigenciaInicio),
                        new SqlParameter("@VigenciaTermino",          oBE.VigenciaTermino),
                        new SqlParameter("@AutorizacionId",           oBE.AutorizacionId),
                        new SqlParameter("@EsquemaPrePago",           oBE.EsquemaPrePago),
                        new SqlParameter("@CobroAnticipado",          oBE.CobroAnticipado),
                        new SqlParameter("@CobroAnticipadoMonto",     oBE.CobroAnticipadoMonto),
                        new SqlParameter("@MontoLimite",              oBE.MontoLimite),
                        new SqlParameter("@PrecioCobertura",          oBE.PrecioCobertura),
                        new SqlParameter("@PorcentajeUtilidad",       oBE.PorcentajeUtilidad),
                        new SqlParameter("@CopagoTipoId",             oBE.CopagoTipoId),
                        new SqlParameter("@PorcentajeCoPago",         oBE.PorcentajeCoPago),
                        new SqlParameter("@PorcentajeDescuento",      oBE.PorcentajeDescuento),
                        new SqlParameter("@Total",                    oBE.Total),
                        new SqlParameter("@EstatusId",                oBE.EstatusId),
                        new SqlParameter("@ManejaPrecioLista",        oBE.ManejaPrecioLista),
                        new SqlParameter("@UsuarioCreacionId",        oBE.UsuarioCreacionId)
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
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.VentaUnitaria oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spVentaUnitaria_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                   Opcion),
                        new SqlParameter("@VentaUnitariaId",          oBE.VentaUnitariaId),
                        new SqlParameter("@VentaUnitariaDescripcion", oBE.VentaUnitariaDescripcion),
                        new SqlParameter("@VentaTipoId",              oBE.VentaTipoId),
                        new SqlParameter("@ContratanteId",            oBE.ContratanteId),
                        new SqlParameter("@TitularId",                oBE.TitularId),
                        new SqlParameter("@PersonaId",                oBE.PersonaId),
                        new SqlParameter("@AsociadoId",               oBE.AsociadoId),
                        new SqlParameter("@PaqueteId",                oBE.PaqueteId),
                        new SqlParameter("@VigenciaInicio",           oBE.VigenciaInicio),
                        new SqlParameter("@VigenciaTermino",          oBE.VigenciaTermino),
                        new SqlParameter("@AutorizacionId",           oBE.AutorizacionId),
                        new SqlParameter("@EsquemaPrePago",           oBE.EsquemaPrePago),
                        new SqlParameter("@CobroAnticipado",          oBE.CobroAnticipado),
                        new SqlParameter("@CobroAnticipadoMonto",     oBE.CobroAnticipadoMonto),
                        new SqlParameter("@MontoLimite",              oBE.MontoLimite),
                        new SqlParameter("@PrecioCobertura",          oBE.PrecioCobertura),
                        new SqlParameter("@PorcentajeUtilidad",       oBE.PorcentajeUtilidad),
                        new SqlParameter("@CopagoTipoId",             oBE.CopagoTipoId),
                        new SqlParameter("@PorcentajeCoPago",         oBE.PorcentajeCoPago),
                        new SqlParameter("@PorcentajeDescuento",      oBE.PorcentajeDescuento),
                        new SqlParameter("@Total",                    oBE.Total),
                        new SqlParameter("@EstatusId",                oBE.EstatusId),
                        new SqlParameter("@ManejaPrecioLista",        oBE.ManejaPrecioLista),
                        new SqlParameter("@UsuarioModificacionId",    oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",        oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",            oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                oBE.FechaBaja),
                        new SqlParameter("@Baja",                     oBE.Baja)
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