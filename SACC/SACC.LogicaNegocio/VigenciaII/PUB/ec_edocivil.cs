namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class ec_edocivil
    {
        public ec_edocivil()
        { }


        public static Entidades.EntidadResponse BuscarPorClave(string pec_edocivil_id)
        {
            Entidades.VigenciaII.PUB.ec_edocivil oBE = new Entidades.VigenciaII.PUB.ec_edocivil();
            oBE.ec_edocivil_id = pec_edocivil_id;

            return Util.Consultar(SqlOpciones.ConsultaPorId, oBE);
        }
    }
}
