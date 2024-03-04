namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class mvst_movigsercct
    {
        public static string Guardarmvst_movigsercct(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.mvst_movigsercct oBE         = new Entidades.VigenciaII.PUB.mvst_movigsercct();
            Entidades.VigenciaII.PUB.co_contratos     oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            oBE.mvst_servicio_id = sc_servdecto.BuscarServicioPorId(oBEContrato.co_contrat_id.ToString(), oBEContrato.co_contrato_id.ToString());

            oBE.mvst_contrat_id  = oBEContrato.co_contrat_id;
            oBE.mvst_contrato_id = oBEContrato.co_contrato_id;
            oBE.mvst_socio_id    = asociado.NumeroSocio;
            oBE.mvst_servicio_id = oBE.mvst_servicio_id;
            oBE.mvst_vigencia    = oBEContrato.co_vigencia;
            oBE.mvst_motivo_id = asociado.FechaBajaContrato == null ? 1 : 10;
            oBE.mvst_fec_mov     = asociado.FechaMovimiento;
            oBE.mvst_hora_mov    = Util.horaEnEntero(System.DateTime.Now);
            oBE.mvst_usuario     = "webserviceuser";
            oBE.mvst_orig_vigen  = oBEContrato.co_orig_vigen;
            oBE.mvst_mot_post    = 0;
            
            Entidades.EntidadResponse response = Util.Insertar(SqlOpciones.Insertar, oBE);

            if (response.Error)
                res = "Error al insertar la bitácota de los servicios (TI)";

            return res;
        }
    }
}
