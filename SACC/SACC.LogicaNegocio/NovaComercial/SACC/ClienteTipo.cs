using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public static class ClienteTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ClienteTipo.DtoComboClienteTipo> ConsultarCombo(String pClienteTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ClienteTipo.DtoComboClienteTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ClienteTipo.DtoComboClienteTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ClienteTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ClienteTipoPM
                {
                    Opcion                 = (Int16)SqlOpciones.Lista,
                    ClienteTipoDescripcion = pClienteTipoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.ClienteTipo oBD = new AccesoDatos.NovaComercial.SACC.ClienteTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ClienteTipo.DtoComboClienteTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ClienteTipo.DtoComboClienteTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ClienteTipo.DtoComboClienteTipo
                            {
                                ClienteTipoId          = Int16.Parse(dr["ClienteTipoId"].ToString()),
                                ClienteTipoDescripcion = dr["ClienteTipoDescripcion"].ToString(),
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