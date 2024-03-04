namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class cl_colonias
    {
        public cl_colonias()
        { }


        public static Entidades.EntidadResponse BuscarPorNombre(string pcl_nombre)
        {
            Entidades.VigenciaII.PUB.cl_colonias oBE = new Entidades.VigenciaII.PUB.cl_colonias();
            oBE.cl_nombre = pcl_nombre;

            return Util.Consultar(SqlOpciones.ConsultaPorId, oBE);
        }
    }
}
