namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class tu_tipousuario
    {
        public tu_tipousuario()
        { }


        public static Entidades.EntidadResponse BuscarPorClave(string pTipoUsuario)
        {
            Entidades.VigenciaII.PUB.tu_tipousuario oBE = new Entidades.VigenciaII.PUB.tu_tipousuario();
            oBE.tu_tipous_id = pTipoUsuario;

            return Util.Consultar(SqlOpciones.ConsultaPorId, oBE);
        }


        public static string Guardartmu_usuarios(Entidades.NovaComercial.WebService.AsociadoLog asociado)
        {
            string res = string.Empty;

            Entidades.VigenciaII.PUB.tmu_usuarios oBE = new Entidades.VigenciaII.PUB.tmu_usuarios();

            Entidades.EntidadResponse oBEMaxFolio = ObtenerFolioMaximo();

            long folioMaximo = 0;
            if (!oBEMaxFolio.Error)
            {
                if (oBEMaxFolio.Resultado != null)
                {
                    if (oBEMaxFolio.Resultado.Tables.Count > 0)
                    {
                        if (oBEMaxFolio.Resultado.Tables[0].Rows.Count != 0)
                            folioMaximo = long.Parse(oBEMaxFolio.Resultado.Tables[0].Rows[0]["FolioMaximo"].ToString());
                    }
                }
            }
            folioMaximo += 1;
            oBE.tmu_folio = int.Parse(folioMaximo.ToString());
            oBE.tmu_ap_casada = asociado.ApellidoCasadaEsposa;
            oBE.tmu_ap_mat = asociado.Materno;
            oBE.tmu_ap_pat = asociado.Paterno;
            //oBE.tmu_aplica_fam = asociado.
            oBE.tmu_calle = asociado.Calle;
            oBE.tmu_codigopost = asociado.CodigoPostal;
            oBE.tmu_colonia_desc = asociado.Colonia;
            oBE.tmu_colonia_id = asociado.ClaveColonia;
            oBE.tmu_correoelec = asociado.CorreoElectronico;
            oBE.tmu_curp = asociado.Curp;
            oBE.tmu_cve_estatus = 3;// asociado.EstatusId; 
            oBE.tmu_cve_mov = asociado.ClaveMovimiento;
            oBE.tmu_cvefam = asociado.ClaveFamiliar;
            if (asociado.ClaveFamiliarAnterior != null)
                oBE.tmu_cvefam_ant = int.Parse(asociado.ClaveFamiliarAnterior.ToString());
            oBE.tmu_depto_id = "0"; // asociado.clave
            //oBE.tmu_desc_nomina = asociado.
            oBE.tmu_edocivil = asociado.ClaveEstadoCivil;
            oBE.tmu_empresa_id = asociado.ClaveEmpresaContrato;
            if (asociado.NumeroEndoso != null)
                oBE.tmu_Endoso_SIASS = int.Parse(asociado.NumeroEndoso.ToString());
            oBE.tmu_estado_desc = asociado.Estado;
            oBE.tmu_estado_id = asociado.ClaveEstado;
            oBE.tmu_extension = asociado.Extension.ToString();
            oBE.tmu_fax_movil = asociado.Fax.ToString();
            oBE.tmu_fec_alta = asociado.FechaAltaContrato;
            oBE.tmu_fec_baja = asociado.FechaBajaContrato;
            oBE.tmu_fec_captura = asociado.FechaCreacion;
            oBE.tmu_fec_fallecimiento = asociado.FechaFallecimiento;
            oBE.tmu_fec_naci = asociado.FechaNacimiento;
            //oBE.tmu_fec_proceso = asociado.FechaMovimiento;
            oBE.tmu_fec_reactiva = asociado.FechaReactivacionContrato;
            //oBE.tmu_folio = asociado.num;

            //oBE.tmu_hora_cap = asociado.;

            //oBE.tmu_Id_Enlace = asociado.id;
            oBE.tmu_Id_SIASS = "G" + asociado.AseguradoraSocioId;
            //oBE.tmu_mensaje = asociado.me;
            //oBE.tmu_motivo_id = asociado;
            oBE.tmu_muni_id = asociado.ClaveCiudad;
            oBE.tmu_municipio_desc = asociado.Ciudad;
            oBE.tmu_nombre = asociado.Nombre;
            oBE.tmu_numdir = asociado.NumeroExterior;
            //oBE.tmu_observa = asociado.ob;
            oBE.tmu_pais_desc = asociado.Pais;
            oBE.tmu_pais_id = asociado.ClavePais;
            oBE.tmu_planta_id = asociado.ClavePlantaContrato;
            if (asociado.NumeroPoliza != null)
                oBE.tmu_Poliza_SIASS = int.Parse(asociado.NumeroPoliza.ToString());
            oBE.tmu_rfc = asociado.RFCSocio;
            oBE.tmu_segurosoc = asociado.NumeroAfiliacionIMSS.ToString();
            //oBE.tmu_servicio_id = asociado.se;
            oBE.tmu_sexo = false;
            if (asociado.Sexo.Trim().ToUpper() == "1") oBE.tmu_sexo = true;
            oBE.tmu_socio_id = asociado.NumeroSocio;
            if (asociado.NumeroSocioAnterior != null)
                oBE.tmu_socio_id_ant = int.Parse(asociado.NumeroSocioAnterior.ToString());

            oBE.tmu_telefono_casa = asociado.TelefonoCasa.ToString();
            oBE.tmu_telefono_ofi = asociado.TelefonoOficina.ToString();
            oBE.tmu_tiposang_id = asociado.ClaveTipoSanguineo;
            //oBE.tmu_tipotrab = asociado.TipoTrabajador;
            oBE.tmu_tipous_id = asociado.TipoUsuario;
            oBE.tmu_usuario_cap = "webserviceuser";

            Entidades.EntidadResponse response;
            //dhRes = Util.Consultar(SqlOpciones.ConsultaPorId, oBE);
            response = Util.Insertar(SqlOpciones.Insertar, oBE);


            if (response.Error)
                res = "Error al insertar en tabla de control (tmu_usuarios)";

            return res;
        }


        public static Entidades.EntidadResponse ObtenerFolioMaximo()
        {
            Entidades.VigenciaII.PUB.tmu_usuarios oBE = new Entidades.VigenciaII.PUB.tmu_usuarios();

            return Util.Consultar(SqlOpciones.ConsultaMaximo, oBE);
        }
    }
}
