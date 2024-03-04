using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public static class FrecuenciaPago
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.FrecuenciaPago.DtoComboFrecuenciaPago> ConsultarCombo(String pFrecuenciaPagoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.FrecuenciaPago.DtoComboFrecuenciaPago> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.FrecuenciaPago.DtoComboFrecuenciaPago>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.FrecuenciaPagoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.FrecuenciaPagoPM
                {
                    Opcion                   = (Int16)SqlOpciones.Lista,
                    FrecuenciaPagoDescripcion = pFrecuenciaPagoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.FrecuenciaPago oBD = new AccesoDatos.NovaComercial.SACC.FrecuenciaPago();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.FrecuenciaPago.DtoComboFrecuenciaPago item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.FrecuenciaPago.DtoComboFrecuenciaPago>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.FrecuenciaPago.DtoComboFrecuenciaPago
                            {
                                FrecuenciaPagoId          = Int16.Parse(dr["FrecuenciaPagoId"].ToString()),
                                FrecuenciaPagoDescripcion = dr["FrecuenciaPagoDescripcion"].ToString(),
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