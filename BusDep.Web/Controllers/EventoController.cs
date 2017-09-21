using System.Collections.Generic;

namespace BusDep.Web.Controllers
{
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using System;
    using System.Web.Mvc;
    
    public class EventoController : BaseController
    {
        #region Get functions 

        public ActionResult EventoList()
        {
            return View();
        }
        
        #endregion

        

    }
}
