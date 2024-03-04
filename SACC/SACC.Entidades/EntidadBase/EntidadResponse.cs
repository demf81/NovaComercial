using System.Data;


namespace SACC.Entidades
{
    public class EntidadResponse
    {
        public EntidadResponse()
        {
            Resultado    = new DataSet();
            Error        = false;
            MensajeError = string.Empty;
        }


        public DataSet Resultado { get; set; }


        public bool Error { get; set; }


        public string MensajeError { get; set; }


        public bool ContieneInformacion
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
    }
}