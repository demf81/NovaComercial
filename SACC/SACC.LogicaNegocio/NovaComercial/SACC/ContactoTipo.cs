using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class ContactoTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ContactoTipo.DtoComboContactoTipo> ConsultarCombo(String pContactoTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ContactoTipo.DtoComboContactoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ContactoTipo.DtoComboContactoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ContactoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ContactoTipoPM
                {
                    Opcion                   = (Int16)SqlOpciones.Lista,
                    ContactoTipoDescripcion = pContactoTipoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.ContactoTipo oBD = new AccesoDatos.NovaComercial.SACC.ContactoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ContactoTipo.DtoComboContactoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ContactoTipo.DtoComboContactoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ContactoTipo.DtoComboContactoTipo
                            {
                                ContactoTipoId          = short.Parse(dr["ContactoTipoId"].ToString()),
                                ContactoTipoDescripcion = dr["ContactoTipoDescripcion"].ToString(),
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