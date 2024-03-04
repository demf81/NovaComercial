using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Estado
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Estado.DtoComboEstado> ConsultarCombo(String pEstadoDescripcion, Int32 pPaisId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Estado.DtoComboEstado> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Estado.DtoComboEstado>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EstadoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EstadoPM
                {
                    Opcion            = (Int16)SqlOpciones.Lista,
                    EstadoDescripcion = pEstadoDescripcion,
                    PaisId            = pPaisId
                };

                AccesoDatos.NovaComercial.SACC.Estado oBD = new AccesoDatos.NovaComercial.SACC.Estado();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Estado.DtoComboEstado item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Estado.DtoComboEstado>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Estado.DtoComboEstado
                            {
                                EstadoId          = Int32.Parse(dr["EstadoId"].ToString()),
                                EstadoDescripcion = dr["EstadoDescripcion"].ToString(),
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