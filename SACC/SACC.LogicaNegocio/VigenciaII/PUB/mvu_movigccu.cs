namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class mvu_movigccu
    {
        public mvu_movigccu()
        { }


        public static string Guardarmvu_movigccu(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.mvu_movigccu oBE         = new Entidades.VigenciaII.PUB.mvu_movigccu();
            Entidades.VigenciaII.PUB.co_contratos oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            oBE.mvu_contrat_id  = oBEContrato.co_contrat_id;
            oBE.mvu_contrato_id = oBEContrato.co_contrato_id;
            oBE.mvu_socio_id    = asociado.NumeroSocio;
            oBE.mvu_cvefam      = asociado.ClaveFamiliar;
            oBE.mvu_vigencia    = oBEContrato.co_vigencia;
            oBE.mvu_orig_vigen  = oBEContrato.co_orig_vigen;
            oBE.mvu_motivo_id = asociado.FechaBajaContrato == null ? 1 : 10;
            oBE.mvu_fec_mov     = asociado.FechaMovimiento;
            oBE.mvu_hora_mov    = Util.horaEnEntero(System.DateTime.Now);
            oBE.mvu_usuario     = "webserviceuser";
            oBE.mvu_mot_post    = 0; // falta validar
            
            Entidades.EntidadResponse response = Util.Insertar(SqlOpciones.Insertar, oBE);

            if (response.Error)
                res = "Error al insertar la bitácota del contrato (US)";

            return res;
        }
    }
}
