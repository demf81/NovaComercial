using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.VigenciaII.PUB
{
    public class us_usuarios
    {
        public static List<Entidades.NovaComercial.dbo.Persona> BuscarPorCURP(String pCURP)
        {
            Entidades.VigenciaII.PUB.us_usuarios oBE = new Entidades.VigenciaII.PUB.us_usuarios();
            oBE.us_curp = pCURP;

            DataSet ds = Util.Consultar(VigenciaOpciones.ConsusltaPersonaPorCURP, oBE).Resultado;

            List<Entidades.NovaComercial.dbo.Persona> res = new List<Entidades.NovaComercial.dbo.Persona>();
            Entidades.NovaComercial.dbo.Persona item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.Persona();

                    item.PersonaId                = 0;
                    item.Nombre                   = dr["us_nombre"].ToString();
                    item.Paterno                  = dr["us_apellidopat"].ToString();
                    item.Materno                  = dr["us_apellidomat"].ToString();
                    item.Genero                   = Boolean.Parse(dr["us_sexo"].ToString());
                    item.FechaNacimiento          = DateTime.Parse(dr["us_fec_naci"].ToString());
                    item.CURP                     = dr["us_curp"].ToString();
                    item.CampoComplemento_SocioId = dr["us_socio_id"].ToString();

                    res.Add(item);
                }
            }

            return res;
        }


        public static List<Entidades.NovaComercial.dbo.Persona> BuscarPorId(Int32 pSocioId, Int32 pClaveFamiliar)
        {
            Entidades.VigenciaII.PUB.us_usuarios oBE = new Entidades.VigenciaII.PUB.us_usuarios();
            oBE.us_socio_id = pSocioId;
            oBE.us_cvefam   = pClaveFamiliar;

            DataSet ds = Util.Consultar(VigenciaOpciones.ConsusltaPersonaPorId, oBE).Resultado;

            List<Entidades.NovaComercial.dbo.Persona> res = new List<Entidades.NovaComercial.dbo.Persona>();
            Entidades.NovaComercial.dbo.Persona item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.Persona();

                    item.PersonaId                = 0;
                    item.Nombre                   = dr["us_nombre"].ToString().Trim();
                    item.Paterno                  = dr["us_apellidopat"].ToString().Trim();
                    item.Materno                  = dr["us_apellidomat"].ToString().Trim();
                    item.Genero                   = Boolean.Parse(dr["us_sexo"].ToString().Trim());
                    item.FechaNacimiento          = DateTime.Parse(dr["us_fec_naci"].ToString().Trim());
                    item.CURP                     = dr["us_curp"].ToString().Trim();
                    item.CampoComplemento_SocioId = dr["us_socio_id"].ToString().Trim();

                    res.Add(item);
                }
            }

            return res;
        }


        public static DateTime BuscaFechaVigenciaPorSocio(Int32 pNumeroSocio, Int16 pClaveFamiliar)
        {
            Entidades.VigenciaII.PUB.us_usuarios oBE = new Entidades.VigenciaII.PUB.us_usuarios();
            oBE.us_socio_id = pNumeroSocio;
            oBE.us_cvefam   = pClaveFamiliar;

            DataSet ds = Util.Consultar(VigenciaOpciones.ConsultaFechaVigenciaPorNumeroSocio, oBE).Resultado;

            List<Entidades.NovaComercial.dbo.Persona> result = new List<Entidades.NovaComercial.dbo.Persona>();
            Entidades.NovaComercial.dbo.Persona item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.Persona();

                    item.PersonaId = 0;
                    item.Nombre = dr["us_nombre"].ToString().Trim();
                    item.Paterno = dr["us_apellidopat"].ToString().Trim();
                    item.Materno = dr["us_apellidomat"].ToString().Trim();
                    item.Genero = Boolean.Parse(dr["us_sexo"].ToString().Trim());
                    item.FechaNacimiento = DateTime.Parse(dr["us_fec_naci"].ToString().Trim());
                    item.CURP = dr["us_curp"].ToString().Trim();
                    item.CampoComplemento_SocioId = dr["us_socio_id"].ToString().Trim();

                    result.Add(item);
                }
            }

            return DateTime.Now;
        }
    }
}