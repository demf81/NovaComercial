using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PortalEmpresa.Client.Helpers
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            string res               = string.Empty;
            string cssClass          = "active";
            string currentAction     = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            #region CATALOGO
            if (controller == "Catalogo" && (currentController == "Persona"))
                controller = currentController;
            #endregion

            #region SEGURIDAD
            if (controller == "Seguridad" && (currentController == "Perfial"))
                controller = currentController;
            #endregion

            res = controller == currentController && action == currentAction ? cssClass : String.Empty;

            if (controller == currentController && (currentAction == "Create" || currentAction == "Edit" || currentAction == "Delete"))
            {
                controller = currentController;
                action = currentAction;
            }

            return res;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }
    }
}