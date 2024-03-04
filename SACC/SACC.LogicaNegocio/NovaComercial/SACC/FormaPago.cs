using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public static class FormaPago
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.FormaPago.DtoComboFormaPago> ConsultarCombo(String pFormaPagoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.FormaPago.DtoComboFormaPago> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.FormaPago.DtoComboFormaPago>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.FormaPagoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.FormaPagoPM
                {
                    Opcion               = (Int16)SqlOpciones.Lista,
                    FormaPagoDescripcion = pFormaPagoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.FormaPago oBD = new AccesoDatos.NovaComercial.SACC.FormaPago();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.FormaPago.DtoComboFormaPago item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.FormaPago.DtoComboFormaPago>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.FormaPago.DtoComboFormaPago
                            {
                                FormaPagoId          = Int16.Parse(dr["FormaPagoId"].ToString()),
                                FormaPagoDescripcion = dr["FormaPagoDescripcion"].ToString(),
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