using BussinessLogic.BussinessLogic;
using BussinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessEntity;

namespace BussinessLogic.WebHost.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/
        private readonly IPersona personaRepository;
        private readonly IPrvUsuario usuarioRepository;
        public UploadController()
            : this(new personaBL(), new usuarioBL())
        {

        }
        public UploadController(IPersona personaRepository, IPrvUsuario usuarioRepository)
        {
            this.personaRepository = personaRepository;
            this.usuarioRepository = usuarioRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadPerfil()
        {

            return PartialView("_UploadPhotoPerfil");
        }

        //http://www.codeproject.com/Articles/379980/Fancy-ASP-NET-MVC-Image-Uploader

        [HttpPost]
        public ActionResult Upload(string imageName, string contentType, string imageData, string codPersona)
        {
            string pathParent = "/Fotos/" + codPersona + "/";
            byte[] data = Convert.FromBase64String(imageData);
            var nameImage = DirautoId() + ".jpg";
            var returnDirectory = pathParent + nameImage;
            var nameDirectory = HttpContext.Server.MapPath(pathParent) + nameImage;
            createDirectory(pathParent);
            saveDirectoryImage(data, nameDirectory);
            personaRepository.registrarImagen(new SG_PERSONA_IMAGENE { C_COD_PERSONA = codPersona, I_COD_TIPO_IMAGEN = 2, V_DES_IMAGEN = returnDirectory });
            return Json(returnDirectory, JsonRequestBehavior.AllowGet);
            //return File(data, contentType, imageName);    
        }

        public string DirautoId()
        {
            Random rnd = new Random();
            var autoId = rnd.Next(1, 999);
            for (int i = autoId; i < 1000; i++)
            {
                autoId += i + DateTime.Now.Millisecond + rnd.Next(400, 700) + DateTime.Now.Second;
            }
            autoId += DateTime.Now.Millisecond + DateTime.Now.Second + rnd.Next(400, 700);
            autoId += DateTime.Now.Millisecond + rnd.Next(999, 2000);
            return DateTime.Now.Millisecond.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Second.ToString() + autoId.ToString(); ;
        }
        public void saveDirectoryImage(byte[] data, string Directory)
        {
            Image image;
            using (MemoryStream ms = new MemoryStream(data))
            {
                image = Image.FromStream(ms);
                image.Save(Directory, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public void createDirectory(string path)
        {
            bool exits = Directory.Exists(Server.MapPath(path));
            if (!exits)
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(path));
            }
        }


    }
}
