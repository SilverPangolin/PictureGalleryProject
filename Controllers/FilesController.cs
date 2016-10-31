using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PictureGalleryProject.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        // Whenever the application loads, the action result will be fired
       
        public ActionResult Index()
        {
            foreach (string upload in Request.Files)
            {
                // Checking whether the request parameter contains the files. If it exists, it saves the selected file to the directory 
                // App_Data / Uploaded_Files /
                if (Request.Files[upload].FileName != "")
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/Uploaded_Files/";
                    string filename = Path.GetFileName(Request.Files[upload].FileName);
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));
                }
            }
            return View("Upload");
        }

        public ActionResult Downloads()
        {
            // Getting all file information from App_Data / Uploaded_Files 
            // Looping through all of the files 
            // Shows all the files
            var dir = new DirectoryInfo(Server.MapPath("~/App_Data/Uploaded_Files/"));
            FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }

        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~/App_Data/Uploaded_Files/" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }


    }
}