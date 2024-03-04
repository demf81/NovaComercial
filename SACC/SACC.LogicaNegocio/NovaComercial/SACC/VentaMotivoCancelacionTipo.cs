using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class VentaMotivoCancelacionTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaMotivoCancelacionTipo.DtoComboVentaMotivoCancelacionTipo> ConsultarCombo(String pVentaMotivoCancelacionTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaMotivoCancelacionTipo.DtoComboVentaMotivoCancelacionTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaMotivoCancelacionTipo.DtoComboVentaMotivoCancelacionTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.VentaMotivoCancelacionTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.VentaMotivoCancelacionTipoPM
                {
                    Opcion                                = (Int16)SqlOpciones.Lista,
                    VentaMotivoCancelacionTipoDescripcion = pVentaMotivoCancelacionTipoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.VentaMotivoCancelacionTipo oBD = new AccesoDatos.NovaComercial.SACC.VentaMotivoCancelacionTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.VentaMotivoCancelacionTipo.DtoComboVentaMotivoCancelacionTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.VentaMotivoCancelacionTipo.DtoComboVentaMotivoCancelacionTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.VentaMotivoCancelacionTipo.DtoComboVentaMotivoCancelacionTipo
                            {
                                VentaMotivoCancelacionTipoId          = short.Parse(dr["VentaMotivoCancelacionTipoId"].ToString()),
                                VentaMotivoCancelacionTipoDescripcion = dr["VentaMotivoCancelacionTipoDescripcion"].ToString(),
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