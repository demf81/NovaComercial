using System;


namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class su_serdeusu
    {
        public su_serdeusu()
        { }


        public static string Guardarsu_serdeusu(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.su_serdeusu  oBE         = new Entidades.VigenciaII.PUB.su_serdeusu();
            Entidades.VigenciaII.PUB.co_contratos oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            oBE.su_servicio_id = sc_servdecto.BuscarServicioPorId(oBEContrato.co_contrat_id.ToString(), oBEContrato.co_contrato_id.ToString());

            oBE.su_contrat_id   = oBEContrato.co_contrat_id;
            oBE.su_contrato_id  = oBEContrato.co_contrato_id;
            oBE.su_socio_id     = asociado.NumeroSocio;
            oBE.su_cvefam       = asociado.ClaveFamiliar;
            oBE.su_servicio_id  = oBE.su_servicio_id;
            oBE.su_vigencia     = oBEContrato.co_vigencia;
            oBE.su_orig_vigen   = oBEContrato.co_orig_vigen;
            oBE.su_fec_alta     = asociado.FechaMovimiento;
            oBE.su_fec_baja     = asociado.FechaMovimiento;
            oBE.su_fec_reactiva = asociado.FechaReactivacionContrato;
            oBE.su_ult_act      = DateTime.Now;
            oBE.su_hora_act     = Util.horaEnEntero(DateTime.Now);
            oBE.su_usuario_act = "webserviceuser"; // falta definicion
            oBE.su_campos_act   = "TODOS";

            Entidades.EntidadResponse response = Util.Insertar(SqlOpciones.Insertar, oBE);

            if (response.Error)
                res = "Error al insertar los servicios del contrato (US)";

            mvsu_movigserccu.Guardarmvsu_movigserccu(asociado);

            return res;
        }


        public static string Bajasu_serdeusu(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.su_serdeusu  oBE         = new Entidades.VigenciaII.PUB.su_serdeusu();
            Entidades.VigenciaII.PUB.co_contratos oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());


            oBE.su_contrat_id = oBEContrato.co_contrat_id;
            oBE.su_contrato_id = oBEContrato.co_contrato_id;
            oBE.su_socio_id = asociado.NumeroSocio;
            oBE.su_cvefam = asociado.ClaveFamiliar;
            oBE.su_vigencia = "BA";
            oBE.su_orig_vigen = oBEContrato.co_orig_vigen;
            oBE.su_fec_alta = asociado.FechaMovimiento;
            oBE.su_fec_baja = asociado.FechaMovimiento;
            oBE.su_fec_reactiva = asociado.FechaReactivacionContrato;
            oBE.su_ult_act = DateTime.Now;
            oBE.su_hora_act = Util.horaEnEntero(DateTime.Now);
            oBE.su_usuario_act = "webserviceuser"; // falta definicion
            oBE.su_campos_act = "su_vigencia, su_fec_baja, su_ult_act, su_hora_act";

            Entidades.EntidadResponse response = Util.Actualizar(SqlOpciones.BajaLogica, oBE);

            if (response.Error)
                res = "Error al dar de baja los servicios del contrato (US)";

            mvsu_movigserccu.Guardarmvsu_movigserccu(asociado);

            return res;
        }


        public static string Reactivasu_serdeusu(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.su_serdeusu  oBE         = new Entidades.VigenciaII.PUB.su_serdeusu();
            Entidades.VigenciaII.PUB.co_contratos oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());


            oBE.su_contrat_id = oBEContrato.co_contrat_id;
            oBE.su_contrato_id = oBEContrato.co_contrato_id;
            oBE.su_socio_id = asociado.NumeroSocio;
            oBE.su_cvefam = asociado.ClaveFamiliar;
            oBE.su_vigencia = "AC";
            oBE.su_orig_vigen = oBEContrato.co_orig_vigen;
            //oBE.su_fec_alta = asociado.FechaMovimiento;
            //oBE.su_fec_baja = asociado.FechaMovimiento;
            oBE.su_fec_reactiva = asociado.FechaReactivacionContrato;
            oBE.su_ult_act = DateTime.Now;
            oBE.su_hora_act = Util.horaEnEntero(DateTime.Now);
            oBE.su_usuario_act = "webserviceuser"; // falta definicion
            oBE.su_campos_act = "su_vigencia, su_fec_reactiva, su_ult_act, su_hora_act, su_usuario_act";

            Entidades.EntidadResponse response = Util.Actualizar(SqlOpciones.BajaLogica, oBE);

            if (response.Error)
                res = "Error al reactivar los servicios del contrato (US)";

            mvsu_movigserccu.Guardarmvsu_movigserccu(asociado);

            return res;
        }
    }
}