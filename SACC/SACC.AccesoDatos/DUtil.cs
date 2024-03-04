using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos
{
    public class DUtil : Conexion.ConexionSQL
    {
        public bool EnviaDataTabla(DataTable dt, string NombreTablaEnSqlQueRecibeEl_dt, List<string> camposDestino)
        {
            try
            {
                if (Conectar())
                {
                    SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(oConexion)
                    {
                        DestinationTableName = NombreTablaEnSqlQueRecibeEl_dt,
                        BulkCopyTimeout      = 3600
                    };

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sqlBulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, camposDestino[i]);
                    }

                    sqlBulkCopy.WriteToServer(dt);
                }

                Desconectar();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool EnviaDataTabla(DataTable dt, string NombreTablaEnSqlQueRecibeEl_dt, List<string> camposDestino, string stringConexion)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConexion))
                {
                    connection.Open();

                    SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection)
                    {
                        DestinationTableName = NombreTablaEnSqlQueRecibeEl_dt,
                        BulkCopyTimeout = 3600
                    };

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sqlBulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, camposDestino[i]);
                    }

                    sqlBulkCopy.WriteToServer(dt);
                    connection.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Boolean ExecuteNoQuery(String pOpcion)
        {
            Boolean oEntidadResponse = false;

            try
            {
                if (pOpcion == "INSERTA_PAQUETE")
                    oComando.CommandText = Resource.InsertaPaquete;

                if (pOpcion == "MANTENIMIENTO")
                    oComando.CommandText = "EXEC dbo.spTranDatosAfiliado_Depurar";

                oComando.CommandType = CommandType.Text;


                oComando.Parameters.Clear();

                
                if (Conectar())
                {
                    oComando.ExecuteNonQuery();
                    //SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    //daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse = false;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public void EjecutaNonQuery(string StrQuery)
        {
            try
            {
                oComando.CommandText = StrQuery;
                oComando.CommandType = CommandType.Text;

                if (this.Conectar())
                {
                    oComando.CommandTimeout = 100000;
                    oComando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Desconectar();
            }
        }
    }
}