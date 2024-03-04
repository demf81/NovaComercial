using System.Collections.Generic;
using System.Web.Mvc;


namespace SACC.Client.Controllers
{
    public class GeneroController : Controller
    {
        public static List<SelectListItem> GeneroList(OpcionesCombo _opcion)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            if (_opcion == OpcionesCombo.TODOS)
            {
                items.Add(
                    new SelectListItem {
                        Text = "[TODOS]",
                        Value = "0"
                    }
                );
            }

            if (_opcion == OpcionesCombo.SELECCIONE)
            {
                items.Add(
                    new SelectListItem {
                        Text = "[Seleccione...]",
                        Value = "0"
                    }
                );
            }


            items.Add(
                new SelectListItem {
                    Text = "Masculino",
                    Value = "1"
                }
            );

            items.Add(
                new SelectListItem {
                    Text = "Femenino",
                    Value = "2"
                }
            );

            items.Add(
                new SelectListItem {
                    Text = "Indistinto",
                    Value = "3"
                }
            );

            return items;
        }
    }
}