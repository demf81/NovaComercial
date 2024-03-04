using System;
using System.Data;


namespace SACC.LogicaNegocio.WS_SAI
{
    public class Seguridad
    {
        public const int SistemaId = 22;


        public static Boolean AutenticarUsuario(string pDominio, string pCuentaRed, string pContrasena)
        {
            SAI.SAIClient oSAI = new SAI.SAIClient();

            SAI.Autenticar oAutenticar = oSAI.AutenticarUsuario(pDominio, pCuentaRed, pContrasena, SistemaId);

            return oAutenticar.AutenticacionCorrecta;
        }

        public static Modelo.ModeloJsonResponse AutenticarUsuarioJS(String pDominio, String pCuentaRed, String pContrasena)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                SAI.SAIClient oSAI = new SAI.SAIClient();

                SAI.Autenticar oAutenticar = oSAI.AutenticarUsuario(pDominio, pCuentaRed, pContrasena, SistemaId);

                //return oAutenticar.AutenticacionCorrecta;
            }
            catch (Exception exc)
            {
                res.Error = true;
                res.TituloError = "(LogicaLegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje = "error";
            }



            return res;
        }




        public static Entidades.SAI.Usuario ObtenerPermisos(string pCuentaRed)
        {
            SAI.SAIClient oSAI = new SAI.SAIClient();
            Entidades.SAI.Usuario res = new Entidades.SAI.Usuario();


            DataSet dsUsuario = oSAI.ObtenerPermisos(SistemaId, pCuentaRed);

            if (dsUsuario != null && dsUsuario.Tables.Count > 0 && dsUsuario.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dsUsuario.Tables[0].Rows[0];

                res.UsuarioId      = int.Parse(dr["UsuarioId"].ToString());
                res.CuentaRed      = dr["Usuario"].ToString();
                res.Nombre         = dr["Nombre"].ToString();
                res.NombreCompleto = string.Format("{0} {1}", dr["Nombre"], dr["Apellido"]).ToUpper();
                res.Correo         = dr["Correo"].ToString();
                res.Foto           = dr["Foto"] as byte[];
            }

            if (dsUsuario != null && dsUsuario.Tables.Count > 1)
            {
                res.Permisos = dsUsuario.Tables[1];
            }

            return res;
        }
    }
}