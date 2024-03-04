using System;


namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class cct_titulares
    {
        public cct_titulares()
        { }


        public static string Guardarcct_titulares(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.cct_titulares oBE         = new Entidades.VigenciaII.PUB.cct_titulares();
            Entidades.VigenciaII.PUB.co_contratos  oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            oBE.cct_contrat_id   = oBEContrato.co_contrat_id;
            oBE.cct_contrato_id  = oBEContrato.co_contrato_id;
            oBE.cct_socio_id     = asociado.NumeroSocio;
            oBE.cct_vigencia     = oBEContrato.co_vigencia;
            oBE.cct_fec_alta     = asociado.FechaMovimiento;
            oBE.cct_fec_baja     = asociado.FechaBajaContrato;
            oBE.cct_fec_reactiva = asociado.FechaReactivacionContrato;
            oBE.cct_tipocont     = oBEContrato.co_tipocont;
            oBE.cct_orig_vigen   = oBEContrato.co_orig_vigen;
            oBE.cct_ult_act      = DateTime.Now;
            oBE.cct_hora_act     = Util.horaEnEntero(DateTime.Now);
            oBE.cct_usuario_act = "webserviceuser"; // falta definicion
            oBE.cct_campos_act   = "TODOS";

            Entidades.EntidadResponse response = Util.Insertar(SqlOpciones.Insertar, oBE);

            if (response.Error)
                res = "Error al insertar el contrato (TI)";

            mvt_movigcct.Guardarmvt_movigcct(asociado);

            return res;
        }


        public static string Bajacct_titulares(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.cct_titulares oBE         = new Entidades.VigenciaII.PUB.cct_titulares();
            Entidades.VigenciaII.PUB.co_contratos  oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            oBE.cct_contrat_id = oBEContrato.co_contrat_id;
            oBE.cct_contrato_id = oBEContrato.co_contrato_id;
            oBE.cct_socio_id = asociado.NumeroSocio;
            oBE.cct_vigencia = "BA";
            //oBE.cct_fec_alta = asociado.FechaMovimiento;
            oBE.cct_fec_baja = asociado.FechaBajaContrato;
            oBE.cct_fec_reactiva = asociado.FechaReactivacionContrato;
            oBE.cct_tipocont = oBEContrato.co_tipocont;
            oBE.cct_orig_vigen = oBEContrato.co_orig_vigen;
            oBE.cct_ult_act = DateTime.Now;
            oBE.cct_hora_act = Util.horaEnEntero(DateTime.Now);
            oBE.cct_usuario_act = "webserviceuser"; // falta definicion
            oBE.cct_campos_act = "cct_vigencia, cct_fec_baja";

            Entidades.EntidadResponse response = Util.Actualizar(SqlOpciones.Actualizar , oBE);

            if (response.Error)
                res = "Error al modificar el contrato (TI)";

            mvt_movigcct.Guardarmvt_movigcct(asociado);

            return res;
        }


        public static string Reactivacct_titulares(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.cct_titulares oBE         = new Entidades.VigenciaII.PUB.cct_titulares();
            Entidades.VigenciaII.PUB.co_contratos  oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            oBE.cct_contrat_id = oBEContrato.co_contrat_id;
            oBE.cct_contrato_id = oBEContrato.co_contrato_id;
            oBE.cct_socio_id = asociado.NumeroSocio;
            oBE.cct_vigencia = "AC";
            //oBE.cct_fec_alta = asociado.FechaMovimiento;
            //oBE.cct_fec_baja = asociado.FechaBajaContrato;
            oBE.cct_fec_reactiva = asociado.FechaReactivacionContrato;
            oBE.cct_tipocont = oBEContrato.co_tipocont;
            oBE.cct_orig_vigen = oBEContrato.co_orig_vigen;
            oBE.cct_ult_act = DateTime.Now;
            oBE.cct_hora_act = Util.horaEnEntero(DateTime.Now);
            oBE.cct_usuario_act = "webserviceuser"; // falta definicion
            oBE.cct_campos_act = "cct_vigencia, cct_fec_baja, cct_hora_act, cct_usuario_act";

            Entidades.EntidadResponse response = Util.Actualizar(SqlOpciones.Actualizar, oBE);

            if (response.Error)
                res = "Error al reactivar el contrato (TI)";

            mvt_movigcct.Guardarmvt_movigcct(asociado);

            return res;
        }
    }
}
