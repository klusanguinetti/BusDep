using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BusDep.Web.BackOffice.Api
{
    using System;
    using System.Web.Http;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.Web.BackOffice.Class;

    public class ABMPublicidadController : BaseController
    {



        #region atributos
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"\Uploads";

        private BlobUtility utility = new BlobUtility();

        private string ContainerName = "photos";
        #endregion


        #region Post Functions

        [HttpPost]
        public List<PublicidadViewModel> GetPublicidadAll(UsuarioViewModel loginModel)
        {
            IBackOfficeBusiness business = DependencyFactory.Resolve<IBackOfficeBusiness>();
            try
            {
                return business.GetPublicidadAll();
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
                var user = GetPublicidadId(id);
                business.DeletePublicidad(new PublicidadViewModel { Id = id });
                string blobNameToDelete = user.ImageUrl.Split('/').Last();
                new BlobUtility().DeleteBlob(blobNameToDelete, "photos");
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }

        [HttpPost]
        public PublicidadViewModel NewPublicidad(long id)
        {


            try
            {
                return new PublicidadViewModel();

            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        public static string UriPublicidad { get; set; }
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
        [HttpPost]
        public PublicidadViewModel GetPublicidadId(long id)
        {
            var business = DependencyFactory.Resolve<IBackOfficeBusiness>();
            try
            {
                var publ = business.GetPublicidadById(id);
                UriPublicidad = publ.ImageUrl;
                return publ;

            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        [HttpPost]
        public string SavePublicidad(PublicidadViewModel publicidad)
        {
            var business = DependencyFactory.Resolve<IBackOfficeBusiness>();
            try
            {
                publicidad.ImageUrl = UriPublicidad;
                business.SavePublicidad(publicidad);
                UriPublicidad = null;
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
