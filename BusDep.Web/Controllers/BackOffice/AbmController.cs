namespace BusDep.Web.Controllers.BackOffice
{
    using System.Web.Mvc;
    using BusDep.Web.Controllers;
    public class AbmController : BaseController
    {
       
        #region Get functions 
        public ActionResult EventoPublicidadList()
        {
            return View();
        }
        public ActionResult EventoPublicidadAbm()
        {
            return View();
        }
        #endregion

    }
}
