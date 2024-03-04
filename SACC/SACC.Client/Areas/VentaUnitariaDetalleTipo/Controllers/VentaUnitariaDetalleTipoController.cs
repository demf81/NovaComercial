using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaUnitariaDetalleTipo.Controllers
{
    public class VentaUnitariaDetalleTipoController : Controller
    {
        const Int32 _AplicacionId = 167;


        public static List<SelectListItem> VentaUnitariaDetalleTipoList(OpcionesCombo _opcion)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SACC.Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo> res = SACC.LogicaNegocio.NovaComercial.dbo.VentaUnitariaDetalleTipo.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneral, 0, "", 0);

            if (_opcion == OpcionesCombo.TODOS)
            {
                items.Add(
                        new SelectListItem
                        {
                            Text = "[TODOS]",
                            Value = "0"
                        });
            }

            if (_opcion == OpcionesCombo.SELECCIONE)
            {
                items.Add(
                        new SelectListItem
                        {
                            Text = "[Seleccione...]",
                            Value = "0"
                        });
            }

            foreach (SACC.Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo item in res)
            {
                items.Add(
                        new SelectListItem
                        {
                            Text  = item.VentaUnitariaDetalleTipoDescripcion.ToString(),
                            Value = item.VentaUnitariaDetalleTipoId.ToString()
                        });
            }

            return items;
        }
    }
}