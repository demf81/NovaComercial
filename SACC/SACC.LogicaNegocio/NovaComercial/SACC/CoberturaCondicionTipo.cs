using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public static class CoberturaCondicionTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CoberturaCondicionTipo.DtoComboCoberturaCondicionTipo> ConsultarCombo(String pCoberturaCondicionTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CoberturaCondicionTipo.DtoComboCoberturaCondicionTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CoberturaCondicionTipo.DtoComboCoberturaCondicionTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CoberturaCondicionTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.CoberturaCondicionTipoPM
                {
                    Opcion                   = (Int16)SqlOpciones.Lista,
                    CoberturaCondicionTipoDescripcion = pCoberturaCondicionTipoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.CoberturaCondicionTipo oBD = new AccesoDatos.NovaComercial.SACC.CoberturaCondicionTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.CoberturaCondicionTipo.DtoComboCoberturaCondicionTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.CoberturaCondicionTipo.DtoComboCoberturaCondicionTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.CoberturaCondicionTipo.DtoComboCoberturaCondicionTipo
                            {
                                CoberturaCondicionTipoId          = Int16.Parse(dr["CoberturaCondicionTipoId"].ToString()),
                                CoberturaCondicionTipoDescripcion = dr["CoberturaCondicionTipoDescripcion"].ToString(),
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