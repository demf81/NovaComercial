using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public static class MetodoPago
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MetodoPago.DtoComboMetodoPago> ConsultarCombo(String pMetodoPagoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MetodoPago.DtoComboMetodoPago> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MetodoPago.DtoComboMetodoPago>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MetodoPagoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MetodoPagoPM
                {
                    Opcion                = (Int16)SqlOpciones.Lista,
                    MetodoPagoDescripcion = pMetodoPagoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.MetodoPago oBD = new AccesoDatos.NovaComercial.SACC.MetodoPago();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MetodoPago.DtoComboMetodoPago item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MetodoPago.DtoComboMetodoPago>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MetodoPago.DtoComboMetodoPago
                            {
                                MetodoPagoId          = Int16.Parse(dr["MetodoPagoId"].ToString()),
                                MetodoPagoDescripcion = dr["MetodoPagoDescripcion"].ToString(),
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