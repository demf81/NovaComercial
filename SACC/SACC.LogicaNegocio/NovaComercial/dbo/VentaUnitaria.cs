using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class VentaUnitaria
    {
        public static List<Entidades.NovaComercial.dbo.VentaUnitaria> Consultar(SqlOpciones pOpcion, int pVentaUnitariaId, int pContratanteId, string pNombre, DateTime? pFecha, int pBaja)
        {
            Entidades.NovaComercial.dbo.VentaUnitaria oE = new Entidades.NovaComercial.dbo.VentaUnitaria();

            oE.VentaUnitariaId = pVentaUnitariaId;
            oE.ContratanteId   = pContratanteId;
            oE.Filtro_Nombre   = pNombre;

            switch (pBaja)
            {
                case 0:
                    oE.Baja = false;
                    break;
                case 1:
                    oE.Baja = true;
                    break;
                default:
                    oE.Baja = null;
                    break;
            }

            DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

            List<Entidades.NovaComercial.dbo.VentaUnitaria> res = new List<Entidades.NovaComercial.dbo.VentaUnitaria>();
            Entidades.NovaComercial.dbo.VentaUnitaria item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.VentaUnitaria();

                    item.VentaUnitariaId          = int.Parse(dr["VentaUnitariaId"].ToString());
                    item.VentaUnitariaDescripcion = dr["VentaUnitariaDescripcion"].ToString();
                    item.ContratanteId            = int.Parse(dr["ContratanteId"].ToString());
                    item.PersonaId                = int.Parse(dr["PersonaId"].ToString());

                    if (dr.Table.Columns.Contains("TipoServicio"))
                        item.CampoComplemento_ServicioTipoDescripcion = dr["TipoServicio"].ToString();

                    if (dr.Table.Columns.Contains("NombreCompleto"))
                        item.CampoComplemento_NombreCompleto = dr["NombreCompleto"].ToString();

                    if (dr.Table.Columns.Contains("AsociadoId"))
                        item.AsociadoId = int.Parse(dr["AsociadoId"].ToString());

                    item.VigenciaTermino          = DateTime.Parse(dr["VigenciaTermino"].ToString());

                    if (dr.Table.Columns.Contains("Total"))
                        item.Total = decimal.Parse(dr["Total"].ToString());

                    if (dr.Table.Columns.Contains("EmpresaDescripcion"))
                        item.CampoComplemento_EmpresaDescripcion = dr["EmpresaDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("Persona"))
                        item.CampoComplemento_Persona = dr["Persona"].ToString();

                    item.ContratanteId = int.Parse(dr["ContratanteId"].ToString());

                    if (dr.Table.Columns.Contains("ContratoId"))
                        item.CampoComplemento_ContratoId = int.Parse(dr["ContratoId"].ToString());

                    if (dr.Table.Columns.Contains("ContratoDescripcion"))
                        item.CampoComplemento_ContratoDescripcion = dr["ContratoDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("EsquemaPrePago"))
                        item.EsquemaPrePago = bool.Parse(dr["EsquemaPrePago"].ToString());

                    if (dr.Table.Columns.Contains("CobroAnticipado"))
                        item.EsquemaPrePago = bool.Parse(dr["CobroAnticipado"].ToString());

                    if (dr.Table.Columns.Contains("PorcentajeUtilidadSobreTarifa"))
                        item.PorcentajeUtilidad = decimal.Parse(dr["PorcentajeUtilidadSobreTarifa"].ToString());

                    if (dr.Table.Columns.Contains("PorcentajeCopagoContratante"))
                        item.PorcentajeCoPago = decimal.Parse(dr["PorcentajeCopagoContratante"].ToString());

                    if (dr.Table.Columns.Contains("PorcentajeDescuentoSobreTarifa"))
                        item.PorcentajeDescuento = decimal.Parse(dr["PorcentajeDescuentoSobreTarifa"].ToString());

                    item.VigenciaTermino           = DateTime.Parse(dr["VigenciaTermino"].ToString());
                    item.CampoComplemento_StrFecha = dr["VigenciaTermino"].ToString();

                    if (dr.Table.Columns.Contains("NumSocio"))
                        item.CampoComplemento_SocioId = dr["NumSocio"].ToString();

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    res.Add(item);
                }
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.VentaUnitaria obj, List<Entidades.NovaComercial.dbo.VentaUnitariaDetalle> objDetalle)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.VentaUnitaria oE = new Entidades.NovaComercial.dbo.VentaUnitaria();
            DataSet ds = new DataSet();

            oE.VentaUnitariaId          = obj.VentaUnitariaId;
            oE.VentaUnitariaDescripcion = obj.VentaUnitariaDescripcion;
            oE.VentaTipoId              = obj.VentaTipoId;
            oE.ContratanteId            = obj.ContratanteId;
            oE.TitularId                = obj.TitularId;
            oE.PersonaId                = obj.PersonaId;
            oE.AsociadoId               = obj.AsociadoId;
            oE.PaqueteId                = obj.PaqueteId;
            oE.VigenciaInicio           = obj.VigenciaInicio;
            oE.VigenciaTermino          = obj.VigenciaTermino;
            oE.AutorizacionId           = obj.AutorizacionId;
            oE.EsquemaPrePago           = obj.EsquemaPrePago;
            oE.CobroAnticipado          = obj.CobroAnticipado;
            oE.CobroAnticipadoMonto     = obj.CobroAnticipadoMonto;
            oE.MontoLimite              = obj.MontoLimite;
            oE.PrecioCobertura          = obj.PrecioCobertura;
            oE.PorcentajeUtilidad       = obj.PorcentajeUtilidad;
            oE.CopagoTipoId             = obj.CopagoTipoId;
            oE.PorcentajeCoPago         = obj.PorcentajeCoPago;
            oE.PorcentajeDescuento      = obj.PorcentajeDescuento;
            oE.Total                    = obj.Total;
            oE.EstatusId                = obj.EstatusId;
            oE.UsuarioCreacionId        = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId    = obj.UsuarioModificacionId;
            oE.Baja                     = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.VentaUnitariaId == 0)
            {
                ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;
            }
            else
            {
                if (obj.Baja == true)
                {
                    oE.UsuarioBajaId = obj.UsuarioBajaId;
                }

                ds = Util.Actualizar(SqlOpciones.Actualizar, oE).Resultado;
            }

            oE.VentaUnitariaId = int.Parse(ds.Tables[0].Rows[0]["VentaUnitariaId"].ToString());

            if (oE.VentaUnitariaId > 0)
            {
                #region INSERTA DETALLE
                foreach (Entidades.NovaComercial.dbo.VentaUnitariaDetalle item in objDetalle)
                {
                    item.VentaUnitariaId            = oE.VentaUnitariaId;
                    VentaUnitariaDetalle.Guardar(item);
                }
                #endregion

                char pad = '0';
                string varVcAfiliado = string.Empty;
                int varIdNumeroSocio;

                if (oE.PersonaId > 0)
                {
                    #region VALIDAR RELACION PersonaAsociado
                    List<Entidades.NovaComercial.dbo.PersonaAsociado> resPersonaAsociado =  LogicaNegocio.NovaComercial.dbo.PersonaAsociado.Consultar(SqlOpciones.ConsultaGeneralConJoin, oE.PersonaId.Value, 0);
                    
                    if (resPersonaAsociado.Count > 0)
                    {
                        varVcAfiliado = resPersonaAsociado[0].CampoComplemento_SocioId;
                    }
                    //else
                    //    varVcAfiliado = (oE.PersonaId.Value.ToString() + "-80").PadLeft(9, pad);
                    #endregion
                }

                if (oE.AsociadoId > 0)
                {
                    List<Entidades.NovaComercial.dbo.Asociado> resSACCAsociado = LogicaNegocio.NovaComercial.dbo.Asociado.Consultar(SqlOpciones.ConsultaPorId, oE.AsociadoId.Value, "", "", "", "", 0);

                    if (resSACCAsociado.Count > 0)
                    {
                        varVcAfiliado = resSACCAsociado[0].CodigoVigencia.PadLeft(6, pad) + "-" + resSACCAsociado[0].ClaveFamiliar.ToString().PadLeft(2, pad);
                    }
                    //else
                    //    varVcAfiliado = "";
                }

                #region BUSCA RELACION VC-AFILIADO
                List<Entidades.Nova_ServiciosMedicos.dbo.CatAsociado> resAsociado = Nova_ServiciosMedicos.dbo.CatAsociado.Consultar(SqlOpciones.ConsultaIdNumeroSocio, varVcAfiliado);

                if (resAsociado.Count > 0)
                {
                    varIdNumeroSocio = resAsociado[0].IdNumeroSocio;
                }
                else
                    varIdNumeroSocio = 0;
                #endregion

                #region INSERTA TBLVENTASUNITARIAS
                if (oE.VentaUnitariaId > 0 & varIdNumeroSocio != 0)
                {
                    Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias oTblVU = new Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias();
                    oTblVU.IdVentaUnitaria    = oE.VentaUnitariaId;
                    oTblVU.vcDescripcion      = oE.VentaUnitariaDescripcion;
                    oTblVU.IdNumeroSocio      = varIdNumeroSocio;
                    oTblVU.vcAfiliado         = varVcAfiliado;
                    oTblVU.bActivo            = 1;
                    oTblVU.dtFechaVencimiento = oE.VigenciaTermino.Value;

                    Nova_ServiciosMedicos.dbo.tblVentasUnitarias.Guardar(oTblVU);
                }
                #endregion
            }

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["VentaUnitariaId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse Reprocesar(int pVentaUnitariaId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            LogicaNegocio.Nova_ServiciosMedicos.dbo.tblVentasUnitarias.Reprocesar(new Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias()
            {
                IdVentaUnitaria = pVentaUnitariaId,
                dtFechaVencimiento = DateTime.Now
            });

            res.Id = pVentaUnitariaId;
            res.Mensaje = "El registro se reproceso satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }

        public static Entidades.EntidadJsonResponse CambioVigencia(Entidades.NovaComercial.dbo.VentaUnitaria obj)
        {
            Entidades.EntidadJsonResponse entidadJsonResponse = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.VentaUnitaria oBE = new Entidades.NovaComercial.dbo.VentaUnitaria();

            DataSet dataSet = new DataSet();

            oBE.VentaUnitariaId = obj.VentaUnitariaId;
            oBE.VigenciaTermino = obj.VigenciaTermino;
            oBE.FechaModificacion = obj.FechaModificacion;
            oBE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oBE.Baja = new bool?(false);

            DataSet resultado = Util.Actualizar(SqlOpciones.VentaUnitariaCambioVigencia, (object)oBE).Resultado;

            oBE.VentaUnitariaId = int.Parse(resultado.Tables[0].Rows[0]["VentaUnitariaId"].ToString());

            if (oBE.VentaUnitariaId > 0 && oBE.VentaUnitariaId > 0)
                LogicaNegocio.Nova_ServiciosMedicos.dbo.tblVentasUnitarias.CambiaVigencia(new Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias()
                {
                    IdVentaUnitaria = oBE.VentaUnitariaId,
                    dtFechaVencimiento = oBE.VigenciaTermino.Value
                });
            entidadJsonResponse.Id = int.Parse(resultado.Tables[0].Rows[0]["VentaUnitariaId"].ToString());
            entidadJsonResponse.Mensaje = "El registro se actualizo satisfactoriamente.";
            entidadJsonResponse.MensajeError = "";
            entidadJsonResponse.Error = false;
            entidadJsonResponse.TipoMensaje = "success";
            return entidadJsonResponse;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(short pVentaUnitariaId, int pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.VentaUnitaria oE = new Entidades.NovaComercial.dbo.VentaUnitaria();
            DataSet ds = new DataSet();

            oE.VentaUnitariaId = pVentaUnitariaId;
            oE.UsuarioBajaId   = pUsuarioId;
            oE.Baja            = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["VentaUnitariaId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }
    }
}