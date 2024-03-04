using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.Conexion
{
    public class ConexionSQL
    {
        public string             NombreConexion = "cxnSACC";
        public SqlConnection      oConexion = new SqlConnection();
        public SqlCommand         oComando;
        public List<SqlParameter> oParametro;
        public SqlDataAdapter     oAdaptador;


        public ConexionSQL()
        {
            oComando = new SqlCommand();
        }


        public bool Conectar()
        {
            oConexion.ConnectionString = ConfigurationManager.ConnectionStrings[NombreConexion].ConnectionString;

            if (oConexion.State == ConnectionState.Closed)
            {
                try
                {
                    oConexion.Open();
                    oComando.Connection = oConexion;

                    return true;
                }
                catch (Exception ex)
                {

                }
            }

            return false;
        }


        public void Desconectar()
        {
            try
            {
                oConexion.Close();
            }
            catch
            {
            }
        }
    }
}