using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public static class CoberturaCopagoTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CoberturaCopagoTipo.DtoComboCoberturaCopagoTipo> ConsultarCombo(String pCoberturaCopagoTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CoberturaCopagoTipo.DtoComboCoberturaCopagoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CoberturaCopagoTipo.DtoComboCoberturaCopagoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CoberturaCopagoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.CoberturaCopagoTipoPM
                {
                    Opcion                   = (Int16)SqlOpciones.Lista,
                    CoberturaCopagoTipoDescripcion = pCoberturaCopagoTipoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.CoberturaCopagoTipo oBD = new AccesoDatos.NovaComercial.SACC.CoberturaCopagoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.CoberturaCopagoTipo.DtoComboCoberturaCopagoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.CoberturaCopagoTipo.DtoComboCoberturaCopagoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.CoberturaCopagoTipo.DtoComboCoberturaCopagoTipo
                            {
                                CoberturaCopagoTipoId          = Int16.Parse(dr["CoberturaCopagoTipoId"].ToString()),
                                CoberturaCopagoTipoDescripcion = dr["CoberturaCopagoTipoDescripcion"].ToString(),
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