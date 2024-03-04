using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public static class CoberturaCantidadTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CoberturaCantidadTipo.DtoComboCoberturaCantidadTipo> ConsultarCombo(String pCoberturaCantidadTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CoberturaCantidadTipo.DtoComboCoberturaCantidadTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CoberturaCantidadTipo.DtoComboCoberturaCantidadTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CoberturaCantidadTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.CoberturaCantidadTipoPM
                {
                    Opcion                           = (Int16)SqlOpciones.Lista,
                    CoberturaCantidadTipoDescripcion = pCoberturaCantidadTipoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.CoberturaCantidadTipo oBD = new AccesoDatos.NovaComercial.SACC.CoberturaCantidadTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.CoberturaCantidadTipo.DtoComboCoberturaCantidadTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.CoberturaCantidadTipo.DtoComboCoberturaCantidadTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.CoberturaCantidadTipo.DtoComboCoberturaCantidadTipo
                            {
                                CoberturaCantidadTipoId          = Int16.Parse(dr["CoberturaCantidadTipoId"].ToString()),
                                CoberturaCantidadTipoDescripcion = dr["CoberturaCantidadTipoDescripcion"].ToString(),
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