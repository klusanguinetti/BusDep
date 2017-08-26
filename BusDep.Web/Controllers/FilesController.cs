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

            string BlobNameToDelete = user.FotoRostro.Split('/').Last();

            if(BlobNameToDelete == "default_avatar-thumb.jpg")
            {
                // Default Photo, No need to delete anything.
                return BadRequest("Default Image - No need to delete");
            }

            utility.DeleteBlob(BlobNameToDelete, ContainerName);

            user.FotoRostro = null;

            business.ActualizarDatosJugador(user);

            return Ok(new { Message = "Photo delete ok" });

        }

        public IHttpActionResult Add()
        {

            var request = HttpContext.Current.Request;

            var file = request.Files[0];

            string fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);

            Stream imageStream = file.InputStream;

            var result = utility.UploadBlob(fileName, ContainerName, imageStream);

            if (result != null)
            {

                var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

                var user = business.ObtenerJugador(GetAuthData());

                user.FotoRostro = result.Uri.ToString();

                business.ActualizarDatosJugador(user);

                return Ok(new { Message = "Photos uploaded ok" });

            }

            return BadRequest();

        }

        public bool FileExists(string fileName)
        {
            var file = Directory.GetFiles(workingFolder, fileName)
                .FirstOrDefault();

            return file != null;
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