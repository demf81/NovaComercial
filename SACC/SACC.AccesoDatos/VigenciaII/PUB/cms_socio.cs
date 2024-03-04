using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class cms_socio : Conexion.ConexionODBC
    {
        public cms_socio()
        {
            NombreConexion = "cxn";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.cms_socio oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spcms_socio_Consultar";
                oComando.CommandType    = CommandType.StoredProcedure;
                oComando.CommandTimeout = 10000;
                oComando.Parameters.Clear();

                oParametro = new System.Data.SqlClient.SqlParameter("@Opcion", System.Data.SqlDbType.SmallInt);
                oParametro.Value = Opcion;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_apellidomat", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_apellidomat;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_apellidopat", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_apellidopat;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_area", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_area;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_cvefam", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_cvefam;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_depto_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_depto_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_edocivil", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_edocivil;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_empresa_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_empresa_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_alta", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_alta;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_baja", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_baja;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_comp", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_comp;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_naci", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_naci;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_reactiva", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_reactiva;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_gpofam", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_gpofam;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_hora_comp", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_hora_comp;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_nombre", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_nombre;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_planta_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_planta_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_sexo", System.Data.SqlDbType.Bit);
                oParametro.Value = oBE.cms_sexo;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_socio_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_socio_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_vigencia", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_vigencia;
                oComando.Parameters.Add(oParametro);

                if (this.Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.cms_socio oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spcms_socio_Insertar";
                oComando.CommandType    = CommandType.StoredProcedure;
                oComando.CommandTimeout = 10000;
                oComando.Parameters.Clear();

                oParametro = new System.Data.SqlClient.SqlParameter("@Opcion", System.Data.SqlDbType.SmallInt);
                oParametro.Value = Opcion;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_apellidomat", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_apellidomat;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_apellidopat", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_apellidopat;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_area", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_area;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_cvefam", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_cvefam;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_depto_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_depto_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_edocivil", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_edocivil;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_empresa_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_empresa_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_alta", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_alta;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_baja", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_baja;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_comp", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_comp;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_naci", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_naci;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_reactiva", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_reactiva;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_gpofam", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_gpofam;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_hora_comp", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_hora_comp;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_nombre", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_nombre;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_planta_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_planta_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_sexo", System.Data.SqlDbType.Bit);
                oParametro.Value = oBE.cms_sexo;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_socio_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_socio_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_vigencia", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_vigencia;
                oComando.Parameters.Add(oParametro);

                if (this.Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.VigenciaII.PUB.cms_socio oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spcms_socio_Actualizar";
                oComando.CommandType    = CommandType.StoredProcedure;
                oComando.CommandTimeout = 10000;
                oComando.Parameters.Clear();

                oParametro = new System.Data.SqlClient.SqlParameter("@Opcion", System.Data.SqlDbType.SmallInt);
                oParametro.Value = Opcion;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_apellidomat", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_apellidomat;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_apellidopat", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_apellidopat;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_area", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_area;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_cvefam", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_cvefam;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_depto_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_depto_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_edocivil", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_edocivil;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_empresa_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_empresa_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_alta", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_alta;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_baja", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_baja;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_comp", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_comp;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_naci", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_naci;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_fec_reactiva", System.Data.SqlDbType.Date);
                oParametro.Value = oBE.cms_fec_reactiva;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_gpofam", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_gpofam;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_hora_comp", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_hora_comp;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_nombre", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_nombre;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_planta_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_planta_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_sexo", System.Data.SqlDbType.Bit);
                oParametro.Value = oBE.cms_sexo;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_socio_id", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_socio_id;
                oComando.Parameters.Add(oParametro);

                oParametro = new System.Data.SqlClient.SqlParameter("@cms_vigencia", System.Data.SqlDbType.VarChar);
                oParametro.Value = oBE.cms_vigencia;
                oComando.Parameters.Add(oParametro);

                if (this.Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }
    }
}