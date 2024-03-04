using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public static class EmpresaTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaTipo.DtoComboEmpresaTipo> ConsultarCombo(String pEmpresaTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaTipo.DtoComboEmpresaTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaTipo.DtoComboEmpresaTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaTipoPM
                {
                    Opcion                 = (Int16)SqlOpciones.Lista,
                    EmpresaTipoDescripcion = pEmpresaTipoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.EmpresaTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaTipo.DtoComboEmpresaTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaTipo.DtoComboEmpresaTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaTipo.DtoComboEmpresaTipo
                            {
                                EmpresaTipoId          = Int16.Parse(dr["EmpresaTipoId"].ToString()),
                                EmpresaTipoDescripcion = dr["EmpresaTipoDescripcion"].ToString(),
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