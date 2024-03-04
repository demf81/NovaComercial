using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Pais
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Pais.DtoComboPais> ConsultarCombo(String pPaisDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Pais.DtoComboPais> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Pais.DtoComboPais>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.PaisPM oParametros = new Modelo.Parametro.NovaComercial.SACC.PaisPM
                {
                    Opcion          = (Int16)SqlOpciones.Lista,
                    PaisDescripcion = pPaisDescripcion
                };

                AccesoDatos.NovaComercial.SACC.Pais oBD = new AccesoDatos.NovaComercial.SACC.Pais();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Pais.DtoComboPais item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Pais.DtoComboPais>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Pais.DtoComboPais
                            {
                                PaisId          = Int32.Parse(dr["PaisId"].ToString()),
                                PaisDescripcion = dr["PaisDescripcion"].ToString(),
                            };

                            res.Datos.Add(item);
                        }
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }
    }
}