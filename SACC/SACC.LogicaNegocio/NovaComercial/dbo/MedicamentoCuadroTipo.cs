using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class MedicamentoCuadroTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo> ConsultarCombo(String pMedicamentoCuadroTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo>();
            
            try
            {
                Modelo.Parametro.NovaComercial.dbo.MedicamentoCuadroTipoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.MedicamentoCuadroTipoPM()
                {
                    Opcion                           = (Int16)SqlOpciones.ConsultaGeneral,
                    MedicamentoCuadroTipoDescripcion = pMedicamentoCuadroTipoDescripcion
                };
                
                AccesoDatos.NovaComercial.dbo.MedicamentoCuadroTipo oBD = new AccesoDatos.NovaComercial.dbo.MedicamentoCuadroTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo
                            {
                                MedicamentoCuadroTipoId          = short.Parse(dr["MedicamentoCuadroTipoId"].ToString()),
                                MedicamentoCuadroTipoDescripcion = dr["MedicamentoCuadroTipoDescripcion"].ToString()
                            };
                            
                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }
    }
}