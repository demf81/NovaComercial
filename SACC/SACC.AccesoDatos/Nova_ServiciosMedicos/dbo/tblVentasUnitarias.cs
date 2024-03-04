using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.Nova_ServiciosMedicos.dbo
{
    public class tblVentasUnitarias : Conexion.ConexionSQL
    {
        public tblVentasUnitarias()
        {
            NombreConexion = "cxnNexus";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "SACC.sptblVentasUnitarias_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             Opcion),
                        new SqlParameter("@IdVentaUnitaria",    oBE.IdVentaUnitaria),
                        new SqlParameter("@vcDescripcion",      oBE.vcDescripcion),
                        new SqlParameter("@IdNumeroSocio",      oBE.IdNumeroSocio),
                        new SqlParameter("@vcAfiliado",         oBE.vcAfiliado),
                        new SqlParameter("@bActivo",            oBE.bActivo),
                        new SqlParameter("@dtFechaVencimiento", oBE.dtFechaVencimiento)
                    }
                );

                if (this.Conectar())
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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "SACC.sptblVentasUnitarias_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@iOpcion",             Opcion),
                        new SqlParameter("@IdVentaUnitaria",    oBE.IdVentaUnitaria),
                        new SqlParameter("@vcDescripcion",      oBE.vcDescripcion),
                        new SqlParameter("@IdNumeroSocio",      oBE.IdNumeroSocio),
                        new SqlParameter("@vcAfiliado",         oBE.vcAfiliado),
                        new SqlParameter("@bActivo",            oBE.bActivo),
                        new SqlParameter("@dtFechaVencimiento", oBE.dtFechaVencimiento)
                    }
                );

                if (this.Conectar())
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