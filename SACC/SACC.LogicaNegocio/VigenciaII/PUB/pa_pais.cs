namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class pa_pais
    {
        public pa_pais()
        { }


        public static Entidades.EntidadResponse BuscarPorNombre(string ppa_nombre)
        {
            Entidades.VigenciaII.PUB.pa_pais oBE = new Entidades.VigenciaII.PUB.pa_pais();
            oBE.pa_nombre = ppa_nombre;

            return Util.Consultar(SqlOpciones.ConsultaPorId, oBE);
        }
    }
}
