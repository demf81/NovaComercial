using System;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class PersonaNumeroSocio
    {
        public static int ObtieneConsecutivo(Entidades.NovaComercial.dbo.PersonaNumeroSocio obj)
        {
            int res = 0;

            DataSet ds = new DataSet();

            obj.NumeroSocioId         = 0;
            obj.PersonaId             = obj.PersonaId;
            obj.UsuarioCreacionId     = obj.UsuarioCreacionId;
            obj.UsuarioModificacionId = obj.UsuarioModificacionId;
            obj.Baja                  = Convert.ToBoolean(Convert.ToInt16(0));

            if (obj.NumeroSocioId == 0)
            {
                ds = Util.Insertar(SqlOpciones.Insertar, obj).Resultado;

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        res = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    }
                }
            }

            return res;
        }
    }
}