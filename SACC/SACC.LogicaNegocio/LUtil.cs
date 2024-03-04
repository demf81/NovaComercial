using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio
{
    public static class LUtil
    {
        public static void EnviaDataTable(DataSet ds, string NombreTablaEnSqQueRecibeEl_dt, string stringConexion)
        {
            List<string> listadoCampos = new List<string>();
            string campo = string.Empty;

            if (ds.Tables.Count != 0)
            {
                for (int i = 0; i <= ds.Tables[0].Columns.Count - 1; i++)
                {
                    campo = ds.Tables[0].Columns[i].ColumnName.Trim();
                    listadoCampos.Add(campo);
                }
            }

            SACC.AccesoDatos.DUtil oBD = new AccesoDatos.DUtil();
            oBD.EnviaDataTabla(ds.Tables[0], NombreTablaEnSqQueRecibeEl_dt, listadoCampos, stringConexion);
        }

        public static void EnviaDataTable(DataTable dt, string NombreTablaEnSqQueRecibeEl_dt)
        {
            List<string> listadoCampos = new List<string>();
            string campo = string.Empty;

            //if (ds.Tables.Count != 0)
            //{
            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                campo = dt.Columns[i].ColumnName.Trim();
                listadoCampos.Add(campo);
            }
            //}

            SACC.AccesoDatos.DUtil oBD = new SACC.AccesoDatos.DUtil();
            oBD.EnviaDataTabla(dt, NombreTablaEnSqQueRecibeEl_dt, listadoCampos);
        }




        public static void ExecutaSQL(String pOpcion)
        {
            AccesoDatos.DUtil util = new SACC.AccesoDatos.DUtil();
            
            util.ExecuteNoQuery(pOpcion);
        }

        public static void ExecuteNoQuery(String text)
        {
            AccesoDatos.DUtil oBD = new AccesoDatos.DUtil();
            oBD.EjecutaNonQuery(text);
        }
    }
}