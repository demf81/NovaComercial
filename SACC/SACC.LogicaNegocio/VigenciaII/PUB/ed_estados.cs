namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class ed_estados
    {
        public ed_estados()
        { }


        public static Entidades.EntidadResponse BuscarPorNombre(string ped_nombre)
        {
            Entidades.VigenciaII.PUB.ed_estados oBE = new Entidades.VigenciaII.PUB.ed_estados();
            oBE.ed_nombre = ped_nombre;

            return Util.Consultar(SqlOpciones.ConsultaPorId, oBE);
        }
    }
}
