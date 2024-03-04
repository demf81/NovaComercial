using System.Linq;


namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class sc_servdecto
    {
        public sc_servdecto()
        { }


        public static string BuscarServiciosDelContrato(string pClaveEmpresa, string pClavePlanta)
        {
            string res = string.Empty;
            string[] resContrato = co_contratos.BuscarContratoArray(pClaveEmpresa, pClavePlanta);

            Entidades.VigenciaII.PUB.sc_servdecto oBE = new Entidades.VigenciaII.PUB.sc_servdecto();
            oBE.sc_contrat_id  = resContrato[0];
            oBE.sc_contrato_id = resContrato[1];

            Entidades.EntidadResponse response = Util.Consultar(SqlOpciones.ConsultaPorId, oBE);

            if (response.Error)
                res = "Error al validar los servicos contratados";
            else
            {
                if (response.Resultado != null)
                {
                    if (response.Resultado.Tables.Count > 0)
                    {
                        if (response.Resultado.Tables[0].Rows.Count == 0)
                            res = "No existe servicios contratados";
                    }
                    else
                        res = "No existe servicios contratados";
                }
                else
                    res = "Error al validar los servicos contratados";
            }

            return res;
        }


        public static int BuscarServicioPorId(string psc_contrat_id, string psc_contrato_id)
        {
            int res = 0;
            
            Entidades.VigenciaII.PUB.sc_servdecto oBE = new Entidades.VigenciaII.PUB.sc_servdecto();
            oBE.sc_contrat_id = psc_contrat_id;
            oBE.sc_contrato_id = psc_contrato_id;

            Entidades.EntidadResponse response = Util.Consultar(SqlOpciones.ConsultaPorId, oBE);

            if (response.Error)
                res = 0;
            else
            {
                if (response.Resultado != null)
                {
                    if (response.Resultado.Tables.Count > 0)
                    {
                        if (response.Resultado.Tables[0].Rows.Count == 0)
                            res = 0;
                        else
                            res = int.Parse(response.Resultado.Tables[0].Rows[0]["sc_servicio_id"].ToString());
                    }
                    else
                        res = 0;
                }
                else
                    res = 0;
            }

            return res;
        }
    }
}