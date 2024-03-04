using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Municipio
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Municipio.DtoComboMunicipio> ConsultarCombo(String pMunicipioDescripcion, Int32 pPaisId, Int32 pEstadoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Municipio.DtoComboMunicipio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Municipio.DtoComboMunicipio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MunicipioPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MunicipioPM
                {
                    Opcion               = (Int16)SqlOpciones.Lista,
                    MunicipioDescripcion = pMunicipioDescripcion,
                    PaisId               = pPaisId,
                    EstadoId             = pEstadoId
                };

                AccesoDatos.NovaComercial.SACC.Municipio oBD = new AccesoDatos.NovaComercial.SACC.Municipio();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Municipio.DtoComboMunicipio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Municipio.DtoComboMunicipio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Municipio.DtoComboMunicipio
                            {
                                MunicipioId          = Int32.Parse(dr["MunicipioId"].ToString()),
                                MunicipioDescripcion = dr["MunicipioDescripcion"].ToString(),
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