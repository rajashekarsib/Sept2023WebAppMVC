using Sept2023WebAppMVC.Models;
using Sept2023WebAppMVC.Repostitory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult SaveImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(ImageModel imageModel, HttpPostedFileBase imageFile)
        {
            ImageRepository imageRepository = new ImageRepository();
            if (imageFile != null && imageFile.ContentLength > 0)
            {
                using (BinaryReader binaryReader = new BinaryReader(imageFile.InputStream))
                {
                    imageModel.ImageData = binaryReader.ReadBytes(imageFile.ContentLength);
                }
                imageModel.ImageName = imageFile.FileName;
                int id = imageRepository.AddImage(imageModel);
                if (id > 0)
                    return RedirectToAction("DisplayImage", new { id = id });
            }
            return View();
        }


        public ActionResult DisplayImage(int id)
        {
            ImageRepository imageRepository = new ImageRepository();
            ImageModel imageModel = imageRepository.GetImageById(id); //pass session id
            return View(imageModel);
        }

        public ActionResult ShowImage(int id)
        {
            ImageRepository imageRepository = new ImageRepository();

            ImageModel imageModel = imageRepository.GetImageById(id);
            if (imageModel != null)
            {
                return File(imageModel.ImageData, "image/jpeg");
            }
            return HttpNotFound();
        }


    }
}