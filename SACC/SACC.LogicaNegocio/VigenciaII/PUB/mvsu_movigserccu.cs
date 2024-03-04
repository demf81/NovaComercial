namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class mvsu_movigserccu
    {
        public mvsu_movigserccu()
        { }


        public static string Guardarmvsu_movigserccu(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.mvsu_movigserccu oBE         = new Entidades.VigenciaII.PUB.mvsu_movigserccu();
            Entidades.VigenciaII.PUB.co_contratos     oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            oBE.mvsu_servicio_id = sc_servdecto.BuscarServicioPorId(oBEContrato.co_contrat_id.ToString(), oBEContrato.co_contrato_id.ToString());

            oBE.mvsu_contrat_id  = oBEContrato.co_contrat_id;
            oBE.mvsu_contrato_id = oBEContrato.co_contrato_id;
            oBE.mvsu_socio_id    = asociado.NumeroSocio;
            oBE.mvsu_cvefam      = asociado.ClaveFamiliar;
            oBE.mvsu_servicio_id = oBE.mvsu_servicio_id;
            oBE.mvsu_vigencia    = oBEContrato.co_vigencia;
            oBE.mvsu_motivo_id = asociado.FechaBajaContrato == null ? 1 : 10;
            oBE.mvsu_fec_mov     = asociado.FechaMovimiento;
            oBE.mvsu_hora_mov    = Util.horaEnEntero(System.DateTime.Now);
            oBE.mvsu_usuario     = "webserviceuser";
            oBE.mvsu_orig_vigen  = oBEContrato.co_orig_vigen;
            oBE.mvsu_mot_post    = 0;

            Entidades.EntidadResponse response = Util.Insertar(SqlOpciones.Insertar, oBE);

            if (response.Error)
                res = "Error al insertar la bitácota de los servicios (US)";

            return res;
        }
    }
}
