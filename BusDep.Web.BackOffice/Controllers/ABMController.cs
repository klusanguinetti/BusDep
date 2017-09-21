namespace BusDep.Web.BackOffice.Controllers
{
    using System.Web.Mvc;
    public class ABMController : BaseController
    {
       
        #region Get functions 

        public ActionResult PublicidadList()
        {
            return View();
        }
        public ActionResult PublicidadABM()
        {
            return View();
        }

        public ActionResult EventoPublicidadList()
        {
            return View();
        }
        public ActionResult EventoPublicidadABM()
        {
            return View();
        }
        #endregion

    }
}
