using System;


namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class ti_titulares
    {
        public ti_titulares()
        { }


        public static string Guardarti_titulares(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.ti_titulares oBE = new Entidades.VigenciaII.PUB.ti_titulares();

            oBE.ti_socio_id = asociado.NumeroSocio;
            oBE.ti_nombrecompleto = string.Format("{0} {1} {2}", asociado.Nombre.ToString().Trim().ToUpper(), asociado.Paterno.ToString().Trim().ToUpper(), asociado.Materno.ToString().Trim().ToUpper());
            oBE.ti_empresa_id = asociado.ClaveEmpresaContrato;
            oBE.ti_planta_id = asociado.ClavePlantaContrato;
            oBE.ti_depto_id = "1";
            oBE.ti_fec_alta = asociado.FechaAltaContrato;
            oBE.ti_fecing_gpo = asociado.FechaIngresoGrupo;
            oBE.ti_fecing_emp = asociado.FechaMovimiento;
            oBE.ti_tipotrab = "E"; //Para asegurados
            oBE.ti_gpofam = 1;
            oBE.ti_edocivil = asociado.ClaveEstadoCivil;
            oBE.ti_segusoc = asociado.NumeroAfiliacionIMSS.ToString();
            oBE.ti_rfc = asociado.RFCSocio;
            oBE.ti_calle = asociado.Calle.ToString().Trim().ToUpper(); ;
            oBE.ti_numdir = asociado.NumeroExterior;
            oBE.ti_codigopost = asociado.CodigoPostal;
            oBE.ti_colonia_id = asociado.ClaveColonia;
            oBE.ti_muni_id = asociado.ClaveCiudad;
            oBE.ti_telefono_casa = asociado.TelefonoCasa.ToString();
            oBE.ti_telefono_ofi = asociado.TelefonoOficina.ToString();
            oBE.ti_extension = asociado.Extension.ToString();
            oBE.ti_fax = asociado.Fax.ToString();
            oBE.ti_correoelec = asociado.CorreoElectronico;
            oBE.ti_ult_act = DateTime.Now;
            oBE.ti_hora_act = Util.horaEnEntero(DateTime.Now);
            oBE.ti_usuario_act = "webserviceuser";
            oBE.ti_campos_act = "TODOS";

            Entidades.EntidadResponse response;

            if (asociado.ClaveMovimiento == "AL")
                response = Util.Insertar(SqlOpciones.Insertar, oBE);
            else
                response = Util.Actualizar(SqlOpciones.Actualizar, oBE);

            if (response.Error)
            {
                if (asociado.ClaveMovimiento == "AL")
                    res = "Error al insertar el titular";
                else
                    res = "Error al modificar el titular";
            }

            if (asociado.ClaveMovimiento == "AL")
            {
                // INSERTAR CONTRATO
                string resContrato = cct_titulares.Guardarcct_titulares(asociado);
                if (resContrato != "")
                    res = resContrato;
                else
                {
                    string resServicios = st_serdetit.Guardarst_serdetit(asociado);
                    if (resServicios != "")
                        res = resServicios;
                }

                if (res == "")
                {
                    asociado.EstatusId = (int)SqlOpciones.ErrorValidacionIntegreidad;
                    asociado.AsociadoDescripcion = res;
                    NovaComercial.WebService.AsociadoLog.ActualizaEstatus(SqlOpciones.ActualizarAsociadoLog, asociado);
                }
            }

            return res;
        }
    }
}