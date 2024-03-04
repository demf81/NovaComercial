namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class mvt_movigcct
    {
        public mvt_movigcct()
        { }


        public static string Guardarmvt_movigcct(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.mvt_movigcct oBE         = new Entidades.VigenciaII.PUB.mvt_movigcct();
            Entidades.VigenciaII.PUB.co_contratos oBEContrato = VigenciaII.PUB.co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            oBE.mvt_contrat_id  = oBEContrato.co_contrat_id;
            oBE.mvt_contrato_id = oBEContrato.co_contrato_id;
            oBE.mvt_socio_id    = asociado.NumeroSocio;
            oBE.mvt_vigencia    = oBEContrato.co_vigencia;
            oBE.mvt_orig_vigen  = oBEContrato.co_orig_vigen;
            oBE.mvt_motivo_id   = asociado.FechaBajaContrato == null ? 1 : 10;
            oBE.mvt_fec_mov     = asociado.FechaMovimiento;
            oBE.mvt_hora_mov    = Util.horaEnEntero(System.DateTime.Now);
            oBE.mvt_usuario     = "webserviceuser";
            oBE.mvt_mot_post    = 0; // falta validar
            
            Entidades.EntidadResponse response = Util.Insertar(SqlOpciones.Insertar, oBE);

            if (response.Error)
                res = "Error al insertar la bitácota del contrato (TI)";

            return res;
        }
    }
}
