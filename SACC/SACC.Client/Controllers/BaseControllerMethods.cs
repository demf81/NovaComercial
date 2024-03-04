using System;
using System.Web;


namespace SACC.Client.Controllers
{
    public class BaseControllerMethods
    {
        const String cookieId                = "usuarioId";
        const String cookieName              = "nombreUsuario";
        const String cookieCorreoElectronico = "correoElectronico";




        public static Int32 GetUsuarioId(HttpRequestBase request)
        {
            Int32 usuarioId = -1;

            if (request.Cookies[cookieId] != null)
            {
                var cookie     = request.Cookies[cookieId];
                cookie.Expires = DateTime.MaxValue;
                Int32.TryParse(cookie.Value, out usuarioId);
            }

            return usuarioId;
        }

        public static void SetUsuarioId(HttpResponseBase response, Int32 usuarioId)
        {
            response.Cookies.Remove(cookieId);

            HttpCookie usuarioIdCookie = new HttpCookie(cookieId);
            
            usuarioIdCookie.Value   = usuarioId.ToString();
            usuarioIdCookie.Expires = DateTime.Now.AddHours(1);
            response.Cookies.Add(usuarioIdCookie);
        }




        public static string GetNombreUsuario(HttpRequestBase request)
        {
            String nombreUsuario = "";

            if (request.Cookies[cookieName] != null)
            {
                var cookie     = request.Cookies[cookieName];
                cookie.Expires = DateTime.MaxValue;
                nombreUsuario  = cookie.Value;
            }

            return nombreUsuario;
        }

        public static void SetNombreUsuario(HttpResponseBase response, String nombreUsuario)
        {
            response.Cookies.Remove(cookieName);

            HttpCookie usuarioNameCookie = new HttpCookie(cookieName);

            usuarioNameCookie.Value   = nombreUsuario;
            usuarioNameCookie.Expires = DateTime.Now.AddHours(1);
            response.Cookies.Add(usuarioNameCookie);
        }




        public static String GetCorreoElectronico(HttpRequestBase request)
        {
            String correoElectronico = "";

            if (request.Cookies[cookieCorreoElectronico] != null)
            {
                var cookie        = request.Cookies[cookieCorreoElectronico];
                cookie.Expires    = DateTime.MaxValue;
                correoElectronico = cookie.Value;
            }

            return correoElectronico;
        }

        public static void SetCorreoElectronico(HttpResponseBase response, String correoElectronico)
        {
            response.Cookies.Remove(cookieCorreoElectronico);

            HttpCookie correoElectronicoCookie = new HttpCookie(cookieCorreoElectronico);

            correoElectronicoCookie.Value = correoElectronico;
            correoElectronicoCookie.Expires = DateTime.Now.AddHours(1);
            response.Cookies.Add(correoElectronicoCookie);
        }
    }
}