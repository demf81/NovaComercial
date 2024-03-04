using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class tmu_usuarios
    {
        public static List<Entidades.NovaComercial.dbo.Persona> BuscarPorCURP(string pCURP)
        {
            Entidades.VigenciaII.PUB.tmu_usuarios oBE = new Entidades.VigenciaII.PUB.tmu_usuarios();
            oBE.tmu_curp = pCURP;

            DataSet ds = Util.Consultar(VigenciaOpciones.ConsultaPersonaTMUPorCURP, oBE).Resultado;

            List<Entidades.NovaComercial.dbo.Persona> res = new List<Entidades.NovaComercial.dbo.Persona>();
            Entidades.NovaComercial.dbo.Persona item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new SACC.Entidades.NovaComercial.dbo.Persona();

                    item.PersonaId                = 0;
                    item.Nombre                   = dr["tmu_nombre"].ToString();
                    item.Paterno                  = dr["tmu_ap_pat"].ToString();
                    item.Materno                  = dr["tmu_ap_mat"].ToString();
                    item.Genero                   = Boolean.Parse(dr["tmu_sexo"].ToString());
                    item.FechaNacimiento          = DateTime.Parse(dr["tmu_fec_naci"].ToString());
                    item.CURP                     = dr["tmu_curp"].ToString();
                    item.CampoComplemento_SocioId = dr["tmu_socio_id"].ToString();

                    res.Add(item);
                }
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(Entidades.VigenciaII.PUB.tmu_usuarios obj)
        {
            DataSet ds = new DataSet();

            obj.tmu_folio = ObtenerFolioMaximo();

            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            ds = Util.Insertar(SqlOpciones.Insertar, obj).Resultado;

            res.Id           = 1; // int.Parse(ds.Tables[0].Rows[0][0].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }

        public static int ObtenerFolioMaximo()
        {
            int res = 0;

            Entidades.VigenciaII.PUB.tmu_usuarios oBE = new Entidades.VigenciaII.PUB.tmu_usuarios();

            DataSet ds = new DataSet();

            ds = Util.Consultar(VigenciaOpciones.ConsultaMaximoTmu_usuario, oBE).Resultado;

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res = int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
                }
            }

            return res;
        }
    }
}