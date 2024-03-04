using System;


namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class st_serdetit
    {
        public st_serdetit()
        { }


        public static string Guardarst_serdetit(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.st_serdetit  oBE         = new Entidades.VigenciaII.PUB.st_serdetit();
            Entidades.VigenciaII.PUB.co_contratos oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            oBE.st_servicio_id = sc_servdecto.BuscarServicioPorId(oBEContrato.co_contrat_id.ToString(), oBEContrato.co_contrato_id.ToString());

            oBE.st_contrat_id   = oBEContrato.co_contrat_id;
            oBE.st_contrato_id  = oBEContrato.co_contrato_id;
            oBE.st_socio_id     = asociado.NumeroSocio;
            oBE.st_servicio_id  = oBE.st_servicio_id;
            oBE.st_vigencia     = oBEContrato.co_vigencia;
            oBE.st_orig_vigen   = oBEContrato.co_orig_vigen;
            oBE.st_fec_alta     = asociado.FechaMovimiento;
            oBE.st_fec_baja     = asociado.FechaBajaContrato;
            oBE.st_fec_reactiva = asociado.FechaReactivacionContrato;
            oBE.st_ult_act      = DateTime.Now;
            oBE.st_hora_act     = Util.horaEnEntero(DateTime.Now);
            oBE.st_usuario_act = "webserviceuser"; // falta definicion
            oBE.st_campos_act   = "TODOS";
            
            Entidades.EntidadResponse response = Util.Insertar(SqlOpciones.Insertar, oBE);

            if (response.Error)
                res = "Error al insertar los servicios del contrato (TI)";

            mvst_movigsercct.Guardarmvst_movigsercct(asociado);

            return res;
        }


        public static string Bajast_serdetit(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.st_serdetit  oBE         = new Entidades.VigenciaII.PUB.st_serdetit();
            Entidades.VigenciaII.PUB.co_contratos oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            //oBE.st_servicio_id = BusinessLogic.VigenciaII.PUB.sc_servdecto.BuscarServicioPorId(oBEContrato.co_contrat_id.ToString(), oBEContrato.co_contrato_id.ToString());


            oBE.st_contrat_id = oBEContrato.co_contrat_id;
            oBE.st_contrato_id = oBEContrato.co_contrato_id;
            oBE.st_socio_id = asociado.NumeroSocio;
            oBE.st_vigencia = "BA";
            oBE.st_orig_vigen = oBEContrato.co_orig_vigen;
            //oBE.st_fec_alta = asociado.FechaMovimiento;
            oBE.st_fec_baja = asociado.FechaBajaContrato;
            //oBE.st_fec_reactiva = asociado.FechaReactivacionContrato;
            oBE.st_ult_act = DateTime.Now;
            oBE.st_hora_act = Util.horaEnEntero(DateTime.Now);
            oBE.st_usuario_act = "webserviceuser"; // falta definicion
            oBE.st_campos_act = "st_vigencia, st_fec_baja, st_ult_act, st_hora";

            Entidades.EntidadResponse response = Util.Actualizar(SqlOpciones.BajaLogica, oBE);

            if (response.Error)
                res = "Error al dar de baja los servicios del contrato (TI)";

            mvst_movigsercct.Guardarmvst_movigsercct(asociado);

            return res;
        }


        public static string Reactivast_serdetit(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.st_serdetit  oBE         = new Entidades.VigenciaII.PUB.st_serdetit();
            Entidades.VigenciaII.PUB.co_contratos oBEContrato = co_contratos.BuscarContratoClass(asociado.ClaveEmpresaContrato, asociado.ClavePlantaContrato.ToString());

            //oBE.st_servicio_id = BusinessLogic.VigenciaII.PUB.sc_servdecto.BuscarServicioPorId(oBEContrato.co_contrat_id.ToString(), oBEContrato.co_contrato_id.ToString());


            oBE.st_contrat_id = oBEContrato.co_contrat_id;
            oBE.st_contrato_id = oBEContrato.co_contrato_id;
            oBE.st_socio_id = asociado.NumeroSocio;
            oBE.st_vigencia = "AC";
            oBE.st_orig_vigen = oBEContrato.co_orig_vigen;
            //oBE.st_fec_alta = asociado.FechaMovimiento;
            //oBE.st_fec_baja = asociado.FechaBajaContrato;
            oBE.st_fec_reactiva = asociado.FechaReactivacionContrato;
            oBE.st_ult_act = DateTime.Now;
            oBE.st_hora_act = Util.horaEnEntero(DateTime.Now);
            oBE.st_usuario_act = "webserviceuser"; // falta definicion
            oBE.st_campos_act = "st_vigencia, st_fec_baja, st_ult_act, st_hora, st_usuario_act";

            Entidades.EntidadResponse response = Util.Actualizar(SqlOpciones.BajaLogica, oBE);

            if (response.Error)
                res = "Error al reactivar los servicios del contrato (TI)";

            mvst_movigsercct.Guardarmvst_movigsercct(asociado);

            return res;
        }
    }
}
