using System;
using System.Data;
using System.Web.Mvc;
using System.Web.Security;


namespace SACC.Client.Controllers
{
    public class HomeController : BaseController
    {
        public const int SistemaId = 22;


        [Authorize]
        [HttpGet]
        public ActionResult IndexSQL()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult IndexSQL(String pOpcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            LogicaNegocio.LUtil.ExecutaSQL(pOpcion);

            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult IndexSQLsoporte()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult IndexSQLsoporte(String pOpcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            LogicaNegocio.LUtil.ExecuteNoQuery("EXEC dbo.spTaskMantenimiento");

            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult IndexVigencia()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult IndexMembresia()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult IndexVentas()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult IndexTarifa()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult IndexCaja()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult Main()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }




        [AllowAnonymous]
        public ActionResult Login()
        {
            Models.LoginModel model = new Models.LoginModel();
            model.Dominio               = Environment.UserDomainName;
            model.CuentaRed             = "";
            model.AutenticacionCorrecta = true;

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Models.LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Entidades.SAI.Usuario oUsuario = new Entidades.SAI.Usuario();
                model.AutenticacionCorrecta = LogicaNegocio.WS_SAI.Seguridad.AutenticarUsuario(Environment.UserDomainName, model.CuentaRed, model.Contrasenia);

                if (model.AutenticacionCorrecta)
                {
                    oUsuario = LogicaNegocio.WS_SAI.Seguridad.ObtenerPermisos(model.CuentaRed);
                    oUsuario.AutenticacionCorrecta = model.AutenticacionCorrecta;


                    SetUsuarioId(oUsuario.UsuarioId);
                    SetNombreUsuario(oUsuario.NombreCompleto);
                    SetCorreoElectronico(oUsuario.Correo);
                    Session["Foto"] = oUsuario.Foto as byte[];

                    if (oUsuario.Permisos.Rows.Count > 0)
                        Session["Permisos"] = oUsuario.Permisos;

                    FormsAuthentication.SetAuthCookie(model.CuentaRed, false);

                    return RedirectToAction("Main", "Home");
                }
                else
                {
                    model.AutenticacionCorrecta = false;
                    return View(model);
                }


                //HOME
                //model.AutenticacionCorrecta = true;

                //if (model.AutenticacionCorrecta)
                //{
                //    SetUsuarioId(142);
                //    SetNombreUsuario("Dan Menchaca");

                //    DataTable dt = new DataTable();

                //    dt.Columns.Add("UsuarioId", typeof(int));
                //    dt.Columns.Add("PerfilId", typeof(int));
                //    dt.Columns.Add("ModuloId", typeof(int));
                //    dt.Columns.Add("AplicacionId", typeof(int));
                //    dt.Columns.Add("ProcesoId", typeof(int));
                //    dt.Columns.Add("ProcesogeneralId", typeof(int));

                //    dt.Rows.Add(521, 69, 51, 167, 474, 1);
                //    dt.Rows.Add(521, 69, 51, 167, 475, 7);
                //    dt.Rows.Add(521, 69, 51, 167, 476, 4);
                //    dt.Rows.Add(521, 69, 51, 167, 674, 6);
                //    dt.Rows.Add(521, 69, 51, 168, 477, 1);
                //    dt.Rows.Add(521, 69, 51, 168, 478, 7);
                //    dt.Rows.Add(521, 69, 51, 168, 479, 4);
                //    dt.Rows.Add(521, 69, 51, 168, 675, 6);
                //    dt.Rows.Add(521, 69, 51, 247, 664, 1);
                //    dt.Rows.Add(521, 69, 51, 247, 665, 7);
                //    dt.Rows.Add(521, 69, 51, 247, 666, 4);
                //    dt.Rows.Add(521, 69, 51, 247, 667, 6);
                //    dt.Rows.Add(521, 69, 51, 248, 676, 1);
                //    dt.Rows.Add(521, 69, 51, 248, 677, 7);
                //    dt.Rows.Add(521, 69, 51, 248, 678, 4);
                //    dt.Rows.Add(521, 69, 51, 248, 679, 6);
                //    dt.Rows.Add(521, 69, 51, 249, 682, 1);
                //    dt.Rows.Add(521, 69, 51, 249, 685, 7);
                //    dt.Rows.Add(521, 69, 51, 249, 686, 6);
                //    dt.Rows.Add(521, 69, 51, 250, 668, 1);
                //    dt.Rows.Add(521, 69, 51, 250, 669, 7);
                //    dt.Rows.Add(521, 69, 51, 250, 670, 6);
                //    dt.Rows.Add(521, 69, 51, 251, 689, 1);
                //    dt.Rows.Add(521, 69, 51, 251, 695, 7);
                //    dt.Rows.Add(521, 69, 51, 251, 696, 4);
                //    dt.Rows.Add(521, 69, 51, 251, 697, 6);
                //    dt.Rows.Add(521, 69, 51, 252, 710, 1);
                //    dt.Rows.Add(521, 69, 51, 252, 712, 7);
                //    dt.Rows.Add(521, 69, 51, 252, 714, 4);
                //    dt.Rows.Add(521, 69, 51, 252, 716, 6);
                //    dt.Rows.Add(521, 69, 51, 252, 723, 1000);
                //    dt.Rows.Add(521, 69, 51, 253, 737, 1);
                //    dt.Rows.Add(521, 69, 51, 253, 740, 7);
                //    dt.Rows.Add(521, 69, 51, 253, 743, 6);
                //    dt.Rows.Add(521, 69, 51, 253, 749, 1000);
                //    dt.Rows.Add(521, 69, 52, 173, 480, 1);
                //    dt.Rows.Add(521, 69, 52, 173, 481, 7);
                //    dt.Rows.Add(521, 69, 52, 173, 482, 4);
                //    dt.Rows.Add(521, 69, 52, 173, 483, 1000);
                //    dt.Rows.Add(521, 69, 52, 173, 780, 4);
                //    dt.Rows.Add(521, 69, 52, 174, 484, 1);
                //    dt.Rows.Add(521, 69, 52, 174, 485, 15);
                //    dt.Rows.Add(521, 69, 52, 259, 769, 7);
                //    dt.Rows.Add(521, 69, 52, 259, 770, 1);
                //    dt.Rows.Add(521, 69, 52, 259, 781, 4);
                //    dt.Rows.Add(521, 69, 72, 254, 751, 1);
                //    dt.Rows.Add(521, 69, 72, 254, 752, 7);
                //    dt.Rows.Add(521, 69, 72, 254, 753, 4);
                //    dt.Rows.Add(521, 69, 72, 254, 754, 6);
                //    dt.Rows.Add(521, 69, 72, 255, 755, 7);
                //    dt.Rows.Add(521, 69, 72, 255, 756, 4);
                //    dt.Rows.Add(521, 69, 72, 255, 757, 6);
                //    dt.Rows.Add(521, 69, 72, 255, 758, 1);
                //    dt.Rows.Add(521, 69, 72, 256, 763, 7);
                //    dt.Rows.Add(521, 69, 72, 256, 764, 6);
                //    dt.Rows.Add(521, 69, 72, 256, 765, 1);
                //    dt.Rows.Add(521, 69, 72, 257, 759, 7);
                //    dt.Rows.Add(521, 69, 72, 257, 760, 6);
                //    dt.Rows.Add(521, 69, 72, 257, 761, 4);
                //    dt.Rows.Add(521, 69, 72, 257, 762, 1);
                //    dt.Rows.Add(521, 69, 72, 258, 766, 7);
                //    dt.Rows.Add(521, 69, 72, 258, 767, 6);
                //    dt.Rows.Add(521, 69, 72, 258, 768, 1);
                //    dt.Rows.Add(521, 69, 73, 260, 771, 7);
                //    dt.Rows.Add(521, 69, 73, 260, 772, 4);
                //    dt.Rows.Add(521, 69, 73, 260, 773, 6);
                //    dt.Rows.Add(521, 69, 73, 260, 774, 1);
                //    dt.Rows.Add(521, 69, 73, 261, 775, 7);
                //    dt.Rows.Add(521, 69, 73, 261, 776, 6);
                //    dt.Rows.Add(521, 69, 73, 261, 777, 1);
                //    dt.Rows.Add(521, 70, 51, 167, 474, 1);
                //    dt.Rows.Add(521, 70, 51, 167, 475, 7);
                //    dt.Rows.Add(521, 70, 51, 167, 476, 4);
                //    dt.Rows.Add(521, 70, 51, 168, 477, 1);
                //    dt.Rows.Add(521, 70, 51, 168, 478, 7);
                //    dt.Rows.Add(521, 70, 51, 168, 479, 4);
                //    dt.Rows.Add(521, 70, 52, 173, 480, 1);
                //    dt.Rows.Add(521, 70, 52, 173, 481, 7);
                //    dt.Rows.Add(521, 70, 52, 173, 482, 4);
                //    dt.Rows.Add(521, 70, 52, 173, 483, 1000);
                //    dt.Rows.Add(521, 70, 52, 174, 484, 1);
                //    dt.Rows.Add(521, 70, 52, 174, 485, 15);
                //    dt.Rows.Add(521, 71, 51, 167, 474, 1);
                //    dt.Rows.Add(521, 71, 51, 167, 475, 7);
                //    dt.Rows.Add(521, 71, 51, 167, 476, 4);
                //    dt.Rows.Add(521, 71, 51, 168, 477, 1);
                //    dt.Rows.Add(521, 71, 51, 168, 478, 7);
                //    dt.Rows.Add(521, 71, 51, 168, 479, 4);
                //    dt.Rows.Add(521, 71, 52, 173, 480, 1);
                //    dt.Rows.Add(521, 71, 52, 173, 481, 7);
                //    dt.Rows.Add(521, 71, 52, 173, 482, 4);
                //    dt.Rows.Add(521, 71, 52, 173, 483, 1000);
                //    dt.Rows.Add(521, 71, 52, 174, 484, 1);
                //    dt.Rows.Add(521, 71, 52, 174, 485, 15);
                //    dt.Rows.Add(521, 72, 52, 173, 480, 1);
                //    dt.Rows.Add(521, 72, 52, 173, 481, 7);
                //    dt.Rows.Add(521, 72, 52, 173, 482, 4);
                //    dt.Rows.Add(521, 72, 52, 174, 484, 1);
                //    dt.Rows.Add(521, 72, 52, 174, 485, 15);


                //    if (dt.Rows.Count > 0)
                //        Session["Permisos"] = dt;

                //    FormsAuthentication.SetAuthCookie(model.CuentaRed, false);

                //    return RedirectToAction("Main", "Home");
                //}
                //else
                //{
                //    model.AutenticacionCorrecta = false;
                //    return View(model);
                //}
            }

            return View(model);
        }




        [AllowAnonymous]
        public ActionResult LoginJS()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoginJS(String pDominio, String pUserName, String pPassword, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //Entidades.SAI.Usuario oUsuario = new Entidades.SAI.Usuario();
                //model.AutenticacionCorrecta = LogicaNegocio.WS_SAI.Seguridad.AutenticarUsuario(Environment.UserDomainName, model.CuentaRed, model.Contrasenia);

                //if (model.AutenticacionCorrecta)
                //{
                //    oUsuario = LogicaNegocio.WS_SAI.Seguridad.ObtenerPermisos(model.CuentaRed);
                //    oUsuario.AutenticacionCorrecta = model.AutenticacionCorrecta;


                //    SetUsuarioId(oUsuario.UsuarioId);
                //    SetNombreUsuario(oUsuario.NombreCompleto);
                //    SetCorreoElectronico(oUsuario.Correo);
                //    Session["Foto"] = oUsuario.Foto as byte[];

                //    if (oUsuario.Permisos.Rows.Count > 0)
                //        Session["Permisos"] = oUsuario.Permisos;

                //    FormsAuthentication.SetAuthCookie(model.CuentaRed, false);

                //    return RedirectToAction("Main", "Home");
                //}
                //else
                //{
                //    model.AutenticacionCorrecta = false;
                //    return View(model);
                //}


                //HOME
                //model.AutenticacionCorrecta = true;

                //if (model.AutenticacionCorrecta)
                //{
                //    SetUsuarioId(142);
                //    SetNombreUsuario("Dan Menchaca");

                //    DataTable dt = new DataTable();

                //    dt.Columns.Add("UsuarioId", typeof(int));
                //    dt.Columns.Add("PerfilId", typeof(int));
                //    dt.Columns.Add("ModuloId", typeof(int));
                //    dt.Columns.Add("AplicacionId", typeof(int));
                //    dt.Columns.Add("ProcesoId", typeof(int));
                //    dt.Columns.Add("ProcesogeneralId", typeof(int));

                //    dt.Rows.Add(521, 69, 51, 167, 474, 1);
                //    dt.Rows.Add(521, 69, 51, 167, 475, 7);
                //    dt.Rows.Add(521, 69, 51, 167, 476, 4);
                //    dt.Rows.Add(521, 69, 51, 167, 674, 6);
                //    dt.Rows.Add(521, 69, 51, 168, 477, 1);
                //    dt.Rows.Add(521, 69, 51, 168, 478, 7);
                //    dt.Rows.Add(521, 69, 51, 168, 479, 4);
                //    dt.Rows.Add(521, 69, 51, 168, 675, 6);
                //    dt.Rows.Add(521, 69, 51, 247, 664, 1);
                //    dt.Rows.Add(521, 69, 51, 247, 665, 7);
                //    dt.Rows.Add(521, 69, 51, 247, 666, 4);
                //    dt.Rows.Add(521, 69, 51, 247, 667, 6);
                //    dt.Rows.Add(521, 69, 51, 248, 676, 1);
                //    dt.Rows.Add(521, 69, 51, 248, 677, 7);
                //    dt.Rows.Add(521, 69, 51, 248, 678, 4);
                //    dt.Rows.Add(521, 69, 51, 248, 679, 6);
                //    dt.Rows.Add(521, 69, 51, 249, 682, 1);
                //    dt.Rows.Add(521, 69, 51, 249, 685, 7);
                //    dt.Rows.Add(521, 69, 51, 249, 686, 6);
                //    dt.Rows.Add(521, 69, 51, 250, 668, 1);
                //    dt.Rows.Add(521, 69, 51, 250, 669, 7);
                //    dt.Rows.Add(521, 69, 51, 250, 670, 6);
                //    dt.Rows.Add(521, 69, 51, 251, 689, 1);
                //    dt.Rows.Add(521, 69, 51, 251, 695, 7);
                //    dt.Rows.Add(521, 69, 51, 251, 696, 4);
                //    dt.Rows.Add(521, 69, 51, 251, 697, 6);
                //    dt.Rows.Add(521, 69, 51, 252, 710, 1);
                //    dt.Rows.Add(521, 69, 51, 252, 712, 7);
                //    dt.Rows.Add(521, 69, 51, 252, 714, 4);
                //    dt.Rows.Add(521, 69, 51, 252, 716, 6);
                //    dt.Rows.Add(521, 69, 51, 252, 723, 1000);
                //    dt.Rows.Add(521, 69, 51, 253, 737, 1);
                //    dt.Rows.Add(521, 69, 51, 253, 740, 7);
                //    dt.Rows.Add(521, 69, 51, 253, 743, 6);
                //    dt.Rows.Add(521, 69, 51, 253, 749, 1000);
                //    dt.Rows.Add(521, 69, 52, 173, 480, 1);
                //    dt.Rows.Add(521, 69, 52, 173, 481, 7);
                //    dt.Rows.Add(521, 69, 52, 173, 482, 4);
                //    dt.Rows.Add(521, 69, 52, 173, 483, 1000);
                //    dt.Rows.Add(521, 69, 52, 173, 780, 4);
                //    dt.Rows.Add(521, 69, 52, 174, 484, 1);
                //    dt.Rows.Add(521, 69, 52, 174, 485, 15);
                //    dt.Rows.Add(521, 69, 52, 259, 769, 7);
                //    dt.Rows.Add(521, 69, 52, 259, 770, 1);
                //    dt.Rows.Add(521, 69, 52, 259, 781, 4);
                //    dt.Rows.Add(521, 69, 72, 254, 751, 1);
                //    dt.Rows.Add(521, 69, 72, 254, 752, 7);
                //    dt.Rows.Add(521, 69, 72, 254, 753, 4);
                //    dt.Rows.Add(521, 69, 72, 254, 754, 6);
                //    dt.Rows.Add(521, 69, 72, 255, 755, 7);
                //    dt.Rows.Add(521, 69, 72, 255, 756, 4);
                //    dt.Rows.Add(521, 69, 72, 255, 757, 6);
                //    dt.Rows.Add(521, 69, 72, 255, 758, 1);
                //    dt.Rows.Add(521, 69, 72, 256, 763, 7);
                //    dt.Rows.Add(521, 69, 72, 256, 764, 6);
                //    dt.Rows.Add(521, 69, 72, 256, 765, 1);
                //    dt.Rows.Add(521, 69, 72, 257, 759, 7);
                //    dt.Rows.Add(521, 69, 72, 257, 760, 6);
                //    dt.Rows.Add(521, 69, 72, 257, 761, 4);
                //    dt.Rows.Add(521, 69, 72, 257, 762, 1);
                //    dt.Rows.Add(521, 69, 72, 258, 766, 7);
                //    dt.Rows.Add(521, 69, 72, 258, 767, 6);
                //    dt.Rows.Add(521, 69, 72, 258, 768, 1);
                //    dt.Rows.Add(521, 69, 73, 260, 771, 7);
                //    dt.Rows.Add(521, 69, 73, 260, 772, 4);
                //    dt.Rows.Add(521, 69, 73, 260, 773, 6);
                //    dt.Rows.Add(521, 69, 73, 260, 774, 1);
                //    dt.Rows.Add(521, 69, 73, 261, 775, 7);
                //    dt.Rows.Add(521, 69, 73, 261, 776, 6);
                //    dt.Rows.Add(521, 69, 73, 261, 777, 1);
                //    dt.Rows.Add(521, 70, 51, 167, 474, 1);
                //    dt.Rows.Add(521, 70, 51, 167, 475, 7);
                //    dt.Rows.Add(521, 70, 51, 167, 476, 4);
                //    dt.Rows.Add(521, 70, 51, 168, 477, 1);
                //    dt.Rows.Add(521, 70, 51, 168, 478, 7);
                //    dt.Rows.Add(521, 70, 51, 168, 479, 4);
                //    dt.Rows.Add(521, 70, 52, 173, 480, 1);
                //    dt.Rows.Add(521, 70, 52, 173, 481, 7);
                //    dt.Rows.Add(521, 70, 52, 173, 482, 4);
                //    dt.Rows.Add(521, 70, 52, 173, 483, 1000);
                //    dt.Rows.Add(521, 70, 52, 174, 484, 1);
                //    dt.Rows.Add(521, 70, 52, 174, 485, 15);
                //    dt.Rows.Add(521, 71, 51, 167, 474, 1);
                //    dt.Rows.Add(521, 71, 51, 167, 475, 7);
                //    dt.Rows.Add(521, 71, 51, 167, 476, 4);
                //    dt.Rows.Add(521, 71, 51, 168, 477, 1);
                //    dt.Rows.Add(521, 71, 51, 168, 478, 7);
                //    dt.Rows.Add(521, 71, 51, 168, 479, 4);
                //    dt.Rows.Add(521, 71, 52, 173, 480, 1);
                //    dt.Rows.Add(521, 71, 52, 173, 481, 7);
                //    dt.Rows.Add(521, 71, 52, 173, 482, 4);
                //    dt.Rows.Add(521, 71, 52, 173, 483, 1000);
                //    dt.Rows.Add(521, 71, 52, 174, 484, 1);
                //    dt.Rows.Add(521, 71, 52, 174, 485, 15);
                //    dt.Rows.Add(521, 72, 52, 173, 480, 1);
                //    dt.Rows.Add(521, 72, 52, 173, 481, 7);
                //    dt.Rows.Add(521, 72, 52, 173, 482, 4);
                //    dt.Rows.Add(521, 72, 52, 174, 484, 1);
                //    dt.Rows.Add(521, 72, 52, 174, 485, 15);


                //    if (dt.Rows.Count > 0)
                //        Session["Permisos"] = dt;

                //    FormsAuthentication.SetAuthCookie(model.CuentaRed, false);

                //    return RedirectToAction("Main", "Home");
                //}
                //else
                //{
                //    model.AutenticacionCorrecta = false;
                //    return View(model);
                //}
            }

            return View();
        }




        [AllowAnonymous]
        public ActionResult Logout()
        {
            foreach (var cookie in HttpContext.Request.Cookies.AllKeys)
            {
                HttpContext.Request.Cookies.Remove(cookie);
            }
            foreach (var cookie in HttpContext.Response.Cookies.AllKeys)
            {
                HttpContext.Response.Cookies.Remove(cookie);
            }

            SetNombreUsuario("");
            SetUsuarioId(-1);

            FormsAuthentication.SignOut();

            return Redirect("Login");
        }




        public ActionResult SinPermiso()
        {
            return View();
        }




        public ActionResult SessionExpirada()
        {
            return View();
        }




        public ActionResult ErrorCreatePdf(
            String pError
            )
        {
            ViewBag.Error = pError;

            return View();
        }
    }
}