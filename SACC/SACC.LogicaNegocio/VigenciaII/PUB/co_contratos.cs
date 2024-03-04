using System.Linq;


namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class co_contratos
    {
        public co_contratos()
        { }


        public static Entidades.EntidadResponse BuscarPorEmpresaPlanta(string pco_empresa_id, string pco_planta_id)
        {
            Entidades.VigenciaII.PUB.co_contratos oBE = new Entidades.VigenciaII.PUB.co_contratos();
            oBE.co_empresa_id = pco_empresa_id;
            oBE.co_planta_id  = pco_planta_id;

            return Util.Consultar(SqlOpciones.ConsultaPorId, oBE);
        }


        public static string BuscarContrato(string pco_empresa_id, string pco_planta_id)
        {
            string res = string.Empty;

            Entidades.EntidadResponse response = BuscarPorEmpresaPlanta(pco_empresa_id, pco_planta_id);

            if (response.Error)
                res = "Error al validar el contrato";
            else
            {
                if (response.Resultado != null)
                {
                    if (response.Resultado.Tables.Count != 0)
                    {
                        if (response.Resultado.Tables[0].Rows.Count != 0)
                        {
                            if (response.Resultado.Tables[0].Rows[0]["co_contrat_id"].ToString() != string.Empty || response.Resultado.Tables[0].Rows[0]["co_contrat_id"].ToString() == "0")
                                res = "";
                            else
                                res = "El contrato no existe";

                        }
                        else
                            res = "El contrato no existe";
                    }
                    else
                        res = "El contrato no existe";
                }
                else
                    res = "Error al validar el contrato";
            }

            return res;
        }


        public static string[] BuscarContratoArray(string pco_empresa_id, string pco_planta_id)
        {
            string[] res =  new string[2];

            Entidades.EntidadResponse response = BuscarPorEmpresaPlanta(pco_empresa_id, pco_planta_id);

            if (!response.Error)
            {
                if (response.Resultado != null)
                {
                    if (response.Resultado.Tables.Count != 0)
                    {
                        if (response.Resultado.Tables[0].Rows.Count != 0)
                        {
                            if (response.Resultado.Tables[0].Rows[0]["co_contrat_id"].ToString() != string.Empty || response.Resultado.Tables[0].Rows[0]["co_contrat_id"].ToString() == "0")
                            {
                                res[0] = response.Resultado.Tables[0].Rows[0]["co_contrat_id"].ToString();
                                res[1] = response.Resultado.Tables[0].Rows[0]["co_contrato_id"].ToString();
                            }

                        }
                    }
                }
            }

            return res;
        }


        public static Entidades.VigenciaII.PUB.co_contratos BuscarContratoClass(string pco_empresa_id, string pco_planta_id)
        {
            Entidades.VigenciaII.PUB.co_contratos res = new Entidades.VigenciaII.PUB.co_contratos();

            Entidades.EntidadResponse response = BuscarPorEmpresaPlanta(pco_empresa_id, pco_planta_id);

            if (!response.Error)
            {
                if (response.Resultado != null)
                {
                    if (response.Resultado.Tables.Count != 0)
                    {
                        if (response.Resultado.Tables[0].Rows.Count != 0)
                        {
                            if (response.Resultado.Tables[0].Rows[0]["co_contrat_id"].ToString() != string.Empty || response.Resultado.Tables[0].Rows[0]["co_contrat_id"].ToString() == "0")
                            {
                                res.co_contrat_id  = int.Parse(response.Resultado.Tables[0].Rows[0]["co_contrat_id"].ToString());
                                res.co_contrato_id = int.Parse(response.Resultado.Tables[0].Rows[0]["co_contrato_id"].ToString());
                                res.co_orig_vigen  = response.Resultado.Tables[0].Rows[0]["co_orig_vigen"].ToString();
                                res.co_tipocont    = response.Resultado.Tables[0].Rows[0]["co_tipocont"].ToString();
                                res.co_vigencia    = response.Resultado.Tables[0].Rows[0]["co_vigencia"].ToString();
                            }

                        }
                    }
                }
            }

            return res;
        }


        public static string BuscarPaquete(string pco_empresa_id, string pco_planta_id)
        {
            string res = "0";

            Entidades.EntidadResponse response = BuscarPorEmpresaPlanta(pco_empresa_id, pco_planta_id);

            if (!response.Error)
            {
                if (response.Resultado != null)
                {
                    if (response.Resultado.Tables.Count != 0)
                    {
                        if (response.Resultado.Tables[0].Rows.Count != 0)
                        {
                            if (response.Resultado.Tables[0].Rows[0]["co_paquete_id"].ToString() != string.Empty || response.Resultado.Tables[0].Rows[0]["co_paquete_id"].ToString() == "0")
                                res = response.Resultado.Tables[0].Rows[0]["co_paquete_id"].ToString();
                        }
                    }
                }
            }

            return res;
        }
    }
}
