namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class mu_municipios
    {
        public mu_municipios()
        { }


        public static Entidades.EntidadResponse BuscarPorNombre(string pmu_nombre)
        {
            Entidades.VigenciaII.PUB.mu_municipios oBE = new Entidades.VigenciaII.PUB.mu_municipios();
            oBE.mu_nombre = pmu_nombre;

            return Util.Consultar(SqlOpciones.ConsultaPorId, oBE);
        }
    }
}
