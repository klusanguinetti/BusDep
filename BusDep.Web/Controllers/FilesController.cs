using BusDep.Common;
using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using BusDep.Web.Class;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace AspNetWebApi.Controllers
{

    public class FilesController : ApiController
    {

        #region Propiedades

        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"\Uploads";

        private BlobUtility utility = new BlobUtility();

        private string ContainerName = "photos";

        #endregion

        public async Task<IHttpActionResult> Get()
        {
            var photos = new List<PhotoViewModel>();

            var photoFolder = new DirectoryInfo(workingFolder);

            await Task.Factory.StartNew(() =>
            {
                photos = photoFolder.EnumerateFiles()
                    .Where(fi => new[] { ".jpeg", ".jpg", ".bmp", ".png", ".gif", ".tiff" }
                        .Contains(fi.Extension.ToLower()))
                    .Select(fi => new PhotoViewModel
                    {
                        Name = fi.Name,
                        Created = fi.CreationTime,
                        Modified = fi.LastWriteTime,
                        Size = fi.Length / 1024
                    })
                    .ToList();
            });

            return Ok(new { Photos = photos });
        }

        [HttpDelete]
        public IHttpActionResult Delete()
        {

            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

            var user = business.ObtenerJugador(GetAuthData());

            if(user.FotoRostro != null)
            {

            string BlobNameToDelete = user.FotoRostro.Split('/').Last();

            utility.DeleteBlob(BlobNameToDelete, ContainerName);

            user.FotoRostro = null;

            business.ActualizarDatosJugador(user);

            return Ok(new { Message = "Photo delete ok" });

            }

            return Ok(new { Message = "No photo to delete" });

        }

        [HttpDelete]
        public IHttpActionResult DeleteCuerpoCompleto()
        {

            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

            var user = business.ObtenerJugador(GetAuthData());

            if (user.FotoCuertoEntero != null)
            {

                string BlobNameToDelete = user.FotoCuertoEntero.Split('/').Last();

                utility.DeleteBlob(BlobNameToDelete, ContainerName);

                user.FotoCuertoEntero = null;

                business.ActualizarDatosJugador(user);

                return Ok(new { Message = "Photo delete ok" });

            }

            return Ok(new { Message = "No photo to delete" });

        }

        [HttpDelete]
        public IHttpActionResult RemoveVideo()
        {

            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

            var user = business.ObtenerJugador(GetAuthData());

            if (user.VideoUrl != null)
            {

                string BlobNameToDelete = user.VideoUrl.Split('/').Last();

                utility.DeleteBlob(BlobNameToDelete, "videos");

                user.VideoUrl = null;

                business.ActualizarDatosJugador(user);

                return Ok(new { Message = "video delete ok" });

            }

            return Ok(new { Message = "No video to delete" });

        }

        public IHttpActionResult AddFotoRostro()
        {

            var request = HttpContext.Current.Request;

            var file = request.Files[0];

            string fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);

            Stream imageStream = file.InputStream;

            var userViewModel = GetAuthData();

            if (userViewModel.JugadorId.HasValue)
            {
                var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

                var user = business.ObtenerJugador(userViewModel);

                if (user.FotoRostro != null)
                {

                    string BlobNameToDelete = user.FotoRostro.Split('/').Last();

                    utility.DeleteBlob(BlobNameToDelete, ContainerName);

                }

                var result = utility.UploadBlob(fileName, ContainerName, imageStream);

                if (result != null)
                {

                    user.FotoRostro = result.Uri.ToString();

                    business.ActualizarDatosJugador(user);

                    return Ok(new {Message = "Photos uploaded ok"});

                }
            }
            else if (userViewModel.EntrenadorId.HasValue)
            {
                var business = DependencyFactory.Resolve<IUsuarioEntrenadorBusiness>();

                var user = DependencyFactory.Resolve<IBusquedaBusiness>().GetPerfilEntrenador(userViewModel);

                if (user.FotoRostro != null)
                {

                    string BlobNameToDelete = user.FotoRostro.Split('/').Last();

                    utility.DeleteBlob(BlobNameToDelete, ContainerName);

                }

                var result = utility.UploadBlob(fileName, ContainerName, imageStream);

                if (result != null)
                {

                    user.FotoRostro = result.Uri.ToString();

                    business.ActualizarDatosEntrenador(user);

                    return Ok(new { Message = "Photos uploaded ok" });

                }
            }
            else if (userViewModel.VideoAnalistaId.HasValue)
            {
                var business = DependencyFactory.Resolve<IUsuarioEntrenadorBusiness>();

                var user = DependencyFactory.Resolve<IBusquedaBusiness>().GetPerfilVideoAnalista(userViewModel);

                if (user.FotoRostro != null)
                {

                    string BlobNameToDelete = user.FotoRostro.Split('/').Last();

                    utility.DeleteBlob(BlobNameToDelete, ContainerName);

                }

                var result = utility.UploadBlob(fileName, ContainerName, imageStream);

                if (result != null)
                {

                    user.FotoRostro = result.Uri.ToString();
                    DependencyFactory.Resolve<IUsuarioVideoAnalistaBusiness>().ActualizarDatos(user);
                    return Ok(new { Message = "Photos uploaded ok" });

                }
            }

            return BadRequest();

        }

        public IHttpActionResult AddFotoCuertoEntero()
        {

            var request = HttpContext.Current.Request;

            var file = request.Files[0];

            string fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);

            Stream imageStream = file.InputStream;


            var userViewModel = GetAuthData();

            if (userViewModel.JugadorId.HasValue)
            {
                var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

                var user = business.ObtenerJugador(userViewModel);

                if (user.FotoCuertoEntero != null)
                {

                    string BlobNameToDelete = user.FotoCuertoEntero.Split('/').Last();

                    utility.DeleteBlob(BlobNameToDelete, ContainerName);

                }

                var result = utility.UploadBlob(fileName, ContainerName, imageStream);

                if (result != null)
                {

                    user.FotoCuertoEntero = result.Uri.ToString();

                    business.ActualizarDatosJugador(user);

                    return Ok(new { Message = "Photos uploaded ok" });

                }
            }
           
            

            return BadRequest();

        }

        public IHttpActionResult AddPlayerVideo()
        {

            var request = HttpContext.Current.Request;

            var file = request.Files[0];

            string fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);

            Stream videoStream = file.InputStream;

            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

            var user = business.ObtenerJugador(GetAuthData());

            if (user.VideoUrl != null)
            {

                string BlobNameToDelete = user.VideoUrl.Split('/').Last();

                utility.DeleteBlob(BlobNameToDelete, "videos");

            }

            var result = utility.UploadBlob(fileName, "videos", videoStream);

            if (result != null)
            {

                user.VideoUrl = result.Uri.ToString();

                business.ActualizarDatosJugador(user);

                return Ok(new { url = user.VideoUrl });

            }

            return BadRequest();

        }

        private UsuarioViewModel GetAuthData()
        {

            UsuarioViewModel loggedUser = new UsuarioViewModel();

            FormsIdentity id = (FormsIdentity)System.Web.HttpContext.Current.User.Identity;

            if (id.IsAuthenticated)
            {
                try
                {
                    var user = StringCompressor.DecompressString(id.Name);
                    loggedUser = user.DeserializarToJson<UsuarioViewModel>();
                    if (loggedUser != null && loggedUser.Id != 0)
                    {
                        return loggedUser;
                    }
                }
                catch { }


                string[] substrings = id.Name.Split('|');

                loggedUser.Id = long.Parse(substrings[1]);

                loggedUser.DatosPersonaId = long.Parse(substrings[1]);

                loggedUser.Mail = substrings[0].ToString();

                return loggedUser;

            }
            else
            {
                return loggedUser;
            }

        }

    }

    #region Clases auxiliares

    public class PhotoViewModel
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public long Size { get; set; }

    }

    public class PhotoActionResult
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
    }

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string rootPath) : base(rootPath)
        {
        }

        public CustomMultipartFormDataStreamProvider(string rootPath, int bufferSize) : base(rootPath, bufferSize)
        {
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            //Make the file name URL safe and then use it & is the only disallowed url character allowed in a windows filename
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName)
              ? headers.ContentDisposition.FileName
              : "NoName";

            return name.Trim('"').Replace("&", "and");
        }
    }


    #endregion

}