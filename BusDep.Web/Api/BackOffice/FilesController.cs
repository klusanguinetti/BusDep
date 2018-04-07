namespace BusDep.Web.Api.BackOffice
{
    using BusDep.Common;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Security;
    using BusDep.Web.Class;
    public class BackOficceFilesController : ApiController
    {

        #region Propiedades

        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"\Uploads";

        private BlobUtility utility = new BlobUtility();

        private string ContainerName = "photos";

        #endregion
        

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


        public IHttpActionResult AddPublicidad()
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

                    return Ok(new { Message = "Photos uploaded ok" });

                }
            }
            else if (userViewModel.EntrenadorId.HasValue)
            {

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

                    DependencyFactory.Resolve<IUsuarioEntrenadorBusiness>().ActualizarDatosEntrenador(user);

                    return Ok(new { Message = "Photos uploaded ok" });

                }
            }
            else if (userViewModel.VideoAnalistaId.HasValue)
            {

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

    }


}