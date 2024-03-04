using System;
using System.Web.Mvc;


namespace SACC.Client.Helpers
{
    public static class HMTLHelperExtensions
    {
        public static string SACC_IsSelected(this HtmlHelper html, string controller = null, string action = null)
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
            if (
                    controller == "Catalogo"
                    &&
                    (
                        currentController == "Empresa"
                        ||
                        currentController == "Paquete"
                        ||
                        currentController == "PaqueteCobertura"
                        ||
                        currentController == "Persona"
                    )
            )
            controller = currentController;

            if (
                (
                    controller == "Home"
                    ||
                    controller == "Catalogo"
                    ||
                    controller == "Empresa"
                )
                &&
                (currentController == "EmpresaContrato")
            )
            {
                controller        = "Empresa";
                currentController = "Empresa";
            }

            if (
                (
                    controller == "Home"
                    ||
                    controller == "Catalogo"
                    ||
                    controller == "Paquete"
                )
                &&
                (currentController == "PaqueteDetalle")
            )
            {
                controller        = "Paquete";
                currentController = "Paquete";
            }

            if (
                (
                    controller == "Home"
                    ||
                    controller == "Catalogo"
                    ||
                    controller == "PaqueteCobertura"
                )
                &&
                (currentController == "PaqueteCoberturaDetalle")
            )
            {
                controller        = "PaqueteCobertura";
                currentController = "PaqueteCobertura";
            }

            if (
                (
                    controller == "Home"
                    ||
                    controller == "Catalogo"
                    ||
                    controller == "Persona"
                )
                &&
                (currentController == "PersonaContrato")
            )
            {
                controller        = "Persona";
                currentController = "Persona";
            }
            #endregion


            #region MAESTRO
            if (
                    controller == "Maestro"
                    &&
                    (currentController == "PaqueteTipo" )
            )
            controller = currentController;
            #endregion


            #region CONFIGURACION
            if (controller == "Configuracion" && (currentController == "Contrato"))
                controller = currentController;

            if ((controller == "Home" || controller == "Configuracion" || controller == "Contrato") && (currentController == "ContratoCobertura" || currentController == "ContratoProducto"))
            {
                controller        = "Contrato";
                currentController = "Contrato";
            }
            #endregion


            #region VENTAS
            if (controller == "Ventas" && (currentController == "VentaUnitaria" || currentController == "VentaUnitariaEspecial"))
                controller = currentController;
            #endregion


            if (controller == "PortalEmpresa" && (currentController == "Usuario"))
                controller = currentController;

            if ((controller == "Home" || controller == "PortalEmpresa" | controller == "Usuario") && (currentController == "UsuarioContrato"))
            {
                controller        = "Usuario";
                currentController = "Usuario";
            }

            if (controller == currentController && (currentAction == "Create" || currentAction == "Edit" || currentAction == "Delete"))
            {
                controller = currentController;
                action     = currentAction;
            }

            res =  controller == currentController && action == currentAction ? cssClass : String.Empty;

            return res;
        }




        public static string VIGENCIA_IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            string res = string.Empty;
            string cssClass = "active";
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;




            #region CATALOGO
            if (
                    controller == "Catalogo"
                    &&
                    (
                        currentController == "Empresa"
                        ||
                        currentController == "LocalizacionTipo"
                        ||
                        currentController == "ContactoTipo"
                        ||
                        currentController == "Paquete"
                        ||
                        currentController == "PaqueteCobertura"
                        ||
                        currentController == "Persona"
                    )
                )
                controller = currentController;


            if ((controller == "Home" || controller == "Catalogo" || controller == "Empresa") && (currentController == "EmpresaContrato"))
            {
                controller = "Empresa";
                currentController = "Empresa";
            }


            //if ((controller == "Home" || controller == "Catalogo" || controller == "LocalizacionTipo"))
            //{
            //    controller = "LocalizacionTipo";
            //    currentController = "LocalizacionTipo";
            //}


            if ((controller == "Home" || controller == "Catalogo" || controller == "Paquete") && (currentController == "PaqueteDetalle"))
            {
                controller = "Paquete";
                currentController = "Paquete";
            }


            if ((controller == "Home" || controller == "Catalogo" || controller == "PaqueteCobertura") && (currentController == "PaqueteCoberturaDetalle"))
            {
                controller = "PaqueteCobertura";
                currentController = "PaqueteCobertura";
            }


            if ((controller == "Home" || controller == "Catalogo" || controller == "Persona") && (currentController == "PersonaContrato") && (currentAction != "ContartoPoblacion"))
            {
                controller = "Persona";
                currentController = "Persona";
            }
            #endregion




            #region CONFIGURACION
            if (controller == "Configuracion" && (currentController == "Contrato"))
                controller = currentController;

            if ((controller == "Home" || controller == "Configuracion" || controller == "Contrato") && (currentController == "ContratoCobertura" || currentController == "ContratoProducto" || currentController == "ContartoPoblacion"))
            {
                controller = "Contrato";
                currentController = "Contrato";
            }

            if ((controller == "Home" || controller == "Persona") && (currentController == "PersonaContrato") && (currentAction == "ContartoPoblacion"))
            {
                controller = "Contrato";
                currentController = "Contrato";
            }
            #endregion



            #region VENTAS
            if (controller == "Ventas" && (currentController == "VentaUnitaria" || currentController == "VentaUnitariaEspecial"))
                controller = currentController;
            #endregion




            if (controller == "PortalEmpresa" && (currentController == "Usuario"))
                controller = currentController;

            if ((controller == "Home" || controller == "PortalEmpresa" | controller == "Usuario") && (currentController == "UsuarioContrato"))
            {
                controller = "Usuario";
                currentController = "Usuario";
            }




            if (controller == currentController && (currentAction == "Create" || currentAction == "Edit" || currentAction == "Delete" || currentAction == "ContartoPoblacion"))
            {
                controller = currentController;
                action = currentAction;
            }

            res = controller == currentController && action == currentAction ? cssClass : String.Empty;

            return res;
        }




        public static string MEMBRESIA_IsSelected(this HtmlHelper html, string controller = null, string action = null)
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
            if (
                controller == "Catalogo"
                &&
                (
                    currentController == "MembresiaTipo"
                    ||
                    currentController == "MembresiaEstatus"
                )
            )
            controller = currentController;
            #endregion


            #region OPERACION
            if (
                controller == "Operacion"
                &&
                (
                    currentController == "MembresiaRenovacion"
                    ||
                    currentController == "RegistroMembresia"
                )
            )
            controller = currentController;
            #endregion


            #region MEMBRESIA
            if (
                controller == "Membresia"
                &&
                (
                    currentController == "MembresiaIndovidual"
                    ||
                    currentController == "MembresiaEmpresarial"
                )
            )
            controller = currentController;
            #endregion


            if (
                controller == currentController
                &&
                (
                    currentAction == "Create"
                    ||
                    currentAction == "Edit"
                    ||
                    currentAction == "Delete"
                )
            )
            {
                controller = currentController;
                action     = currentAction;
            }


            res = controller == currentController && action == currentAction ? cssClass : String.Empty;


            return res;
        }




        public static string VENTA_IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            string res               = string.Empty;
            string cssClass          = "active";
            string currentAction     = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;
            

            #region OPERACION
            if (
                (controller == "Operacion" && currentController == "Cotizacion")
                ||
                (controller == "VentaPaquete" && currentController == "Venta")
            )
            controller = currentController;
            #endregion

            
            if (
                controller == currentController
                &&
                (
                    currentAction == "Create"
                    ||
                    currentAction == "Edit"
                    ||
                    currentAction == "Delete"
                )
            )
            {
                controller = currentController;
                action     = currentAction;
            }


            res = controller == currentController && action == currentAction ? cssClass : String.Empty;


            return res;
        }




        public static string TARIFA_IsSelected(this HtmlHelper html, string controller = null, string action = null)
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
            if (
                    controller == "Catalogo"
                    &&
                    (
                        currentController == "Material"
                        ||
                        currentController == "Medicamento"
                        ||
                        currentController == "Estudio"
                        ||
                        currentController == "Servicio"
                        ||
                        currentController == "Cirugia"
                        ||
                        currentController == "Subrogados"
                        ||
                        currentController == "ServicioAdministrativo"
                    )
                )
                controller = currentController;


            //if ((controller == "Home" || controller == "Catalogo" || controller == "Empresa") && (currentController == "EmpresaContrato"))
            //{
            //    controller = "Empresa";
            //    currentController = "Empresa";
            //}


            //if ((controller == "Home" || controller == "Catalogo" || controller == "LocalizacionTipo"))
            //{
            //    controller = "LocalizacionTipo";
            //    currentController = "LocalizacionTipo";
            //}


            //if ((controller == "Home" || controller == "Catalogo" || controller == "Paquete") && (currentController == "PaqueteDetalle"))
            //{
            //    controller = "Paquete";
            //    currentController = "Paquete";
            //}


            //if ((controller == "Home" || controller == "Catalogo" || controller == "PaqueteCobertura") && (currentController == "PaqueteCoberturaDetalle"))
            //{
            //    controller = "PaqueteCobertura";
            //    currentController = "PaqueteCobertura";
            //}


            //if ((controller == "Home" || controller == "Catalogo" || controller == "Persona") && (currentController == "PersonaContrato") && (currentAction != "ContartoPoblacion"))
            //{
            //    controller = "Persona";
            //    currentController = "Persona";
            //}
            #endregion




            #region MAESTROS
            #endregion




            #region CONFIGURACION
            if (
                    controller == "Configuracion"
                    &&
                    (
                        currentController == "Tarifa"
                    )
                )
                controller = currentController;

            //if ((controller == "Home" || controller == "Configuracion" || controller == "Contrato") && (currentController == "ContratoCobertura" || currentController == "ContratoProducto" || currentController == "ContartoPoblacion"))
            //{
            //    controller = "Contrato";
            //    currentController = "Contrato";
            //}

            //if ((controller == "Home" || controller == "Persona") && (currentController == "PersonaContrato") && (currentAction == "ContartoPoblacion"))
            //{
            //    controller = "Contrato";
            //    currentController = "Contrato";
            //}
            #endregion



            #region VENTAS
            //if (controller == "Ventas" && (currentController == "VentaUnitaria" || currentController == "VentaUnitariaEspecial"))
            //    controller = currentController;
            #endregion




            //if (controller == "PortalEmpresa" && (currentController == "Usuario"))
            //    controller = currentController;

            //if ((controller == "Home" || controller == "PortalEmpresa" | controller == "Usuario") && (currentController == "UsuarioContrato"))
            //{
            //    controller = "Usuario";
            //    currentController = "Usuario";
            //}




            if (
                    controller == currentController
                    &&
                    (
                        currentAction == "Create"
                        ||
                        currentAction == "Edit"
                        ||
                        currentAction == "Delete"
                    )
                )
            {
                controller = currentController;
                action = currentAction;
            }

            res = controller == currentController && action == currentAction ? cssClass : String.Empty;

            return res;
        }




        public static string CAJA_IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            string res = string.Empty;
            string cssClass = "active";
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;




            #region CATALOGO
            if (
                    controller == "Catalogo"
                    &&
                    (
                        currentController == "Empresa"
                        ||
                        currentController == "PaqueteTipo"
                        ||
                        currentController == "LocalizacionTipo"
                        ||
                        currentController == "ContactoTipo"
                        ||
                        currentController == "Paquete"
                        ||
                        currentController == "PaqueteCobertura"
                        ||
                        currentController == "Persona"
                    )
                )
                controller = currentController;


            if ((controller == "Home" || controller == "Catalogo" || controller == "Empresa") && (currentController == "EmpresaContrato"))
            {
                controller = "Empresa";
                currentController = "Empresa";
            }


            //if ((controller == "Home" || controller == "Catalogo" || controller == "LocalizacionTipo"))
            //{
            //    controller = "LocalizacionTipo";
            //    currentController = "LocalizacionTipo";
            //}


            if ((controller == "Home" || controller == "Catalogo" || controller == "Paquete") && (currentController == "PaqueteDetalle"))
            {
                controller = "Paquete";
                currentController = "Paquete";
            }


            if ((controller == "Home" || controller == "Catalogo" || controller == "PaqueteCobertura") && (currentController == "PaqueteCoberturaDetalle"))
            {
                controller = "PaqueteCobertura";
                currentController = "PaqueteCobertura";
            }


            if ((controller == "Home" || controller == "Catalogo" || controller == "Persona") && (currentController == "PersonaContrato") && (currentAction != "ContartoPoblacion"))
            {
                controller = "Persona";
                currentController = "Persona";
            }
            #endregion




            #region CONFIGURACION
            if (controller == "Configuracion" && (currentController == "Contrato"))
                controller = currentController;

            if ((controller == "Home" || controller == "Configuracion" || controller == "Contrato") && (currentController == "ContratoCobertura" || currentController == "ContratoProducto" || currentController == "ContartoPoblacion"))
            {
                controller = "Contrato";
                currentController = "Contrato";
            }

            if ((controller == "Home" || controller == "Persona") && (currentController == "PersonaContrato") && (currentAction == "ContartoPoblacion"))
            {
                controller = "Contrato";
                currentController = "Contrato";
            }
            #endregion



            #region VENTAS
            if (controller == "Ventas" && (currentController == "VentaUnitaria" || currentController == "VentaUnitariaEspecial"))
                controller = currentController;
            #endregion




            if (controller == "PortalEmpresa" && (currentController == "Usuario"))
                controller = currentController;

            if ((controller == "Home" || controller == "PortalEmpresa" | controller == "Usuario") && (currentController == "UsuarioContrato"))
            {
                controller = "Usuario";
                currentController = "Usuario";
            }




            if (controller == currentController && (currentAction == "Create" || currentAction == "Edit" || currentAction == "Delete" || currentAction == "ContartoPoblacion"))
            {
                controller = currentController;
                action = currentAction;
            }

            res = controller == currentController && action == currentAction ? cssClass : String.Empty;

            return res;
        }




        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }
    }
}