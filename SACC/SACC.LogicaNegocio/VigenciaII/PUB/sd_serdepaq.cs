namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class sd_serdepaq
    {
        public sd_serdepaq()
        { }


        //public static string BuscaServiciosContratados(string pNumSocio, string pClaveFamiliar, string pClaveEmpresa, string pClavePlanta)
        //{
        //    string res = string.Empty;
        //    string[] resContrato = co_contratos.BuscarContrato(pClaveEmpresa, pClavePlanta);

        //    Entidades.VigenciaII.PUB.sd_serdepaq oBE = new Entidades.VigenciaII.PUB.sd_serdepaq();
        //    oBE.sd_paquete_id  = co_contratos.BuscarPaquete(pClaveEmpresa, pClavePlanta);
        //    oBE.socio_id       = pNumSocio;
        //    oBE.clavefamiliar  = pClaveFamiliar;
        //    oBE.procesotitular = true;
        //    oBE.co_contrat_id = resContrato[0];
        //    oBE.co_contrato_id = resContrato[1];

        //    Entidades.EntidadResponse response = Util.Consultar(SqlOpciones.ConsultaServicioPaquete, oBE);
        //    if (dhRes.Error)
        //        res = "Error al validar los servicos contratados";
        //    else
        //    {
        //        if (dhRes.Resultado != null)
        //        {
        //            if (dhRes.Resultado.Tables.Count > 0)
        //            {
        //                if(dhRes.Resultado.Tables[0].Rows.Count == 0)
        //                    res = "No existe servicios contratados";
        //            }
        //            else
        //                res = "No existe servicios contratados";
        //        }
        //        else
        //            res = "Error al validar los servicos contratados";
        //    }

        //    return res;
        //}
    }
}
