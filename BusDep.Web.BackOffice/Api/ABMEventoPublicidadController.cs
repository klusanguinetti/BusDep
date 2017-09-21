

namespace BusDep.Web.BackOffice.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.Web.BackOffice.Class;

    public class ABMEventoPublicidadController : BaseController
    {



        #region atributos
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"\Uploads";

        private BlobUtility utility = new BlobUtility();

        private string ContainerName = "photos";
        #endregion


        #region Post Functions

        [HttpPost]
        public List<EventoPublicidadViewModel> GetEventoPublicidadAll(UsuarioViewModel loginModel)
        {
            IBackOfficeBusiness business = DependencyFactory.Resolve<IBackOfficeBusiness>();
            try
            {
                return business.GetEventoPublicidadAll();
            }
            catch (ExceptionBusiness)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw new Exception("Error del servidor", ex);
            }


        }

        [HttpPost]
        public void DeletePublicidad(long id)
        {

            var business = DependencyFactory.Resolve<IBackOfficeBusiness>();
            try
            {
                var user = business.GetPublicidadId(id);
                business.DeleteEventoPublicidad(new EventoPublicidadViewModel { Id = id });
                string blobNameToDelete = user.ImageUrl.Split('/').Last();
                new BlobUtility().DeleteBlob(blobNameToDelete, "photos");
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }

        [HttpPost]
        public EventoPublicidadViewModel NewPublicidad(long id)
        {


            try
            {
                return new EventoPublicidadViewModel();

            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        public static string UriPublicidad { get; set; }
        public static string UriEventoPublicidad { get; set; }
        public IHttpActionResult SaveImagePublicidad()
        {

            var business = DependencyFactory.Resolve<IBackOfficeBusiness>();
            try
            {
                var request = HttpContext.Current.Request;
                var file = request.Files[0];
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                    Stream imageStream = file.InputStream;


                    var result = utility.UploadBlob(fileName, ContainerName, imageStream);

                    if (result != null)
                    {

                        UriPublicidad = result.Uri.ToString();



                        return Ok(new { Message = "Imagen ok" });

                    }

                }

                return BadRequest();
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        public IHttpActionResult SaveImagePublicidadViewModel()
        {

            var business = DependencyFactory.Resolve<IBackOfficeBusiness>();
            try
            {
                var request = HttpContext.Current.Request;
                var file = request.Files[0];
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                    Stream imageStream = file.InputStream;
                    var result = utility.UploadBlob(fileName, ContainerName, imageStream);

                    if (result != null)
                    {

                        UriEventoPublicidad = result.Uri.ToString();
                        return Ok(new { Message = "Imagen ok" });
                    }

                }

                return BadRequest();
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        [HttpPost]
        public EventoPublicidadViewModel GetEventoPublicidadViewModelById(long id)
        {
            var business = DependencyFactory.Resolve<IBackOfficeBusiness>();
            try
            {
                var publ = business.GetEventoPublicidadId(id);
                UriEventoPublicidad = publ.ImageUrl;
                return publ;

            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        [HttpPost]
        public string SaveEventoPublicidad(EventoPublicidadViewModel publicidad)
        {
            var business = DependencyFactory.Resolve<IBackOfficeBusiness>();
            try
            {
                publicidad.ImageUrl = UriEventoPublicidad;
                business.SaveEventoPublicidad(publicidad);
                UriEventoPublicidad = null;
                return "Ok";
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        #endregion

    }
}
