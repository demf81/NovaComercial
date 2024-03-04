using System;
using System.Web.Mvc;


namespace SACC.Client.Controllers
{
    public class BaseController : Controller
    {
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data                = data,
                ContentType         = contentType,
                ContentEncoding     = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength       = Int32.MaxValue
            };
        }




        #region Protected Methods
        protected void SetUsuarioId(int usuarioId)
        {
            BaseControllerMethods.SetUsuarioId(Response, usuarioId);
        }

        protected Int32 GetUsuarioId()
        {
            return BaseControllerMethods.GetUsuarioId(Request);
        }




        protected void SetNombreUsuario(string nombreUsuario)
        {
            BaseControllerMethods.SetNombreUsuario(Response, nombreUsuario);
        }

        protected string GetNombreUsuario()
        {
            return BaseControllerMethods.GetNombreUsuario(Request);
        }




        protected void SetCorreoElectronico(string correoElectronico)
        {
            BaseControllerMethods.SetCorreoElectronico(Response, correoElectronico);
        }

        protected string GetCorreoElectronico()
        {
            return BaseControllerMethods.GetCorreoElectronico(Request);
        }
        #endregion Protected Methods
    }
}