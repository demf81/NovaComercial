using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Controllers
{
    public class BaseControllerMethods
    {
        const string cookieId       = "usuarioId";
        const string cookieContrato = "ContratoId";
        const string cookieName     = "nombreUsuario";




        public static int GetUsuarioId(HttpRequestBase request)
        {
            int usuarioId = -1;

            if (request.Cookies[cookieId] != null)
            {
                var cookie     = request.Cookies[cookieId];
                cookie.Expires = DateTime.MaxValue;
                int.TryParse(cookie.Value, out usuarioId);
            }

            return usuarioId;
        }


        public static void SetUsuarioId(HttpResponseBase response, int usuarioId)
        {
            response.Cookies.Remove(cookieId);

            HttpCookie usuarioIdCookie = new HttpCookie(cookieId);
            
            usuarioIdCookie.Value   = usuarioId.ToString();
            usuarioIdCookie.Expires = DateTime.Now.AddHours(1);
            response.Cookies.Add(usuarioIdCookie);
        }

        


        public static int GetContratoId(HttpRequestBase request)
        {
            int contratoId = -1;

            if (request.Cookies[cookieContrato] != null)
            {
                var cookie     = request.Cookies[cookieContrato];
                cookie.Expires = DateTime.MaxValue;
                int.TryParse(cookie.Value, out contratoId);
            }

            return contratoId;
        }


        public static void SetContratoId(HttpResponseBase response, int contratoId)
        {
            response.Cookies.Remove(cookieContrato);

            HttpCookie contratoIdCookie = new HttpCookie(cookieContrato);

            contratoIdCookie.Value   = contratoId.ToString();
            contratoIdCookie.Expires = DateTime.Now.AddHours(1);
            response.Cookies.Add(contratoIdCookie);
        }




        public static string GetNombreUsuario(HttpRequestBase request)
        {
            string nombreUsuario = "";

            if (request.Cookies[cookieName] != null)
            {
                var cookie     = request.Cookies[cookieName];
                cookie.Expires = DateTime.MaxValue;
                nombreUsuario  = cookie.Value;
                //(cookie.Value, out usuario);
            }

            return nombreUsuario;
        }


        public static void SetNombreUsuario(HttpResponseBase response, string nombreUsuario)
        {
            response.Cookies.Remove(cookieName);

            HttpCookie usuarioNameCookie = new HttpCookie(cookieName);

            usuarioNameCookie.Value   = nombreUsuario;
            usuarioNameCookie.Expires = DateTime.Now.AddHours(1);
            response.Cookies.Add(usuarioNameCookie);
        }
    }
}
