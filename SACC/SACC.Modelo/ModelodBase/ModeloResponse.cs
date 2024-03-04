using System;
using System.Data;

namespace SACC.Modelo
{
    public class ModeloResponse
    {
        public ModeloResponse()
        {
            Resultado    = new DataSet();
            Error        = false;
            MensajeError = String.Empty;
        }
        

        public DataSet Resultado { get; set; }
        
        public Boolean Error { get; set; }
        
        public String TituloError { get; set; }

        public String MensajeError { get; set; }
        
        public Boolean ContieneInformacion
        {
            get
            {
                if (Resultado != null && Resultado.Tables.Count > 0)
                {
                    foreach (DataTable dt in Resultado.Tables)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public int StatusCode { get; set; }
    }
}