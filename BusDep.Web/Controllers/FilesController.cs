﻿using BusDep.Common;
using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using BusDep.Web.Class;
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
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"\Uploads";

        /// <summary>
        ///   Get all photos
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        ///   Delete photo
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string fileName)
        {
            if (!FileExists(fileName))
            {
                return NotFound();
            }

            try
            {
                var filePath = Directory.GetFiles(workingFolder, fileName)
                    .FirstOrDefault();

                await Task.Factory.StartNew(() =>
                {
                    if (filePath != null)
                        File.Delete(filePath);
                });

                var result = new PhotoActionResult
                {
                    Successful = true,
                    Message = fileName + "deleted successfully"
                };
                return Ok(new { message = result.Message });
            }
            catch (Exception ex)
            {
                var result = new PhotoActionResult
                {
                    Successful = false,
                    Message = "error deleting fileName " + ex.GetBaseException().Message
                };
                return BadRequest(result.Message);
            }
        }

        /// <summary>
        ///   Add a photo
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Add()
        {

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }

            try
            {


                var provider = new CustomMultipartFormDataStreamProvider(workingFolder);

                JugadorViewModel jugadorViewModel = new JugadorViewModel();

                var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

                await Task.Run(async () => await Request.Content.ReadAsMultipartAsync(provider));


                var photos = new List<PhotoViewModel>();

                foreach (var file in provider.FileData)
                {
                    var fileInfo = new FileInfo(file.LocalFileName);

                    photos.Add(new PhotoViewModel
                    {
                        Name = fileInfo.Name,
                        Created = fileInfo.CreationTime,
                        Modified = fileInfo.LastWriteTime,
                        Size = fileInfo.Length / 1024
                    });

                    jugadorViewModel.Id = this.GetAuthData().Id;

                    jugadorViewModel.FotoRostro = "Uploads/" + fileInfo.Name;

                    business.ActualizarDatosJugador(jugadorViewModel);

                }

                return Ok(new { Message = "Photos uploaded ok", Photos = photos });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        ///   Check if file exists on disk
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
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

}