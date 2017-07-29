﻿using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using BusDep.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BusDep.Web.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {

        private AuthHelper authHelper = new AuthHelper();

        #region Get functions 

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SportsHistory()
        {
            return View();
        }


        #endregion

        #region Get Functions
        
        [HttpGet]
        public JsonResult GetNewAntecedente()
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                var antecedente = business.NuevoAntecedenteViewModel(authHelper.GetAuthData());
                Response.StatusCode = 200;
                return new JsonResult { Data = antecedente, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        #endregion
        #region Post Functions
        public JsonResult SaveAntecedente(AntecedenteViewModel antecedenteViewModel)
        {

            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

            try
            {
                business.GuardarAntecedenteViewModel(antecedenteViewModel);
                var antecedentes = business.ObtenerAntecedentes(authHelper.GetAuthData());
                Response.StatusCode = 200;
                return new JsonResult { Data = antecedentes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public JsonResult GetClubes()
        {
            var business = DependencyFactory.Resolve<ICommonBusiness>();
            try
            {
                var user = business.ObtenerClubes();
                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public JsonResult GetJugador()
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                var user = business.ObtenerJugador(authHelper.GetAuthData());
                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public JsonResult GetAntecedentes()
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                var antecedentes = business.ObtenerAntecedentes(authHelper.GetAuthData());
                Response.StatusCode = 200;
                return new JsonResult { Data = antecedentes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        #endregion


    }
}