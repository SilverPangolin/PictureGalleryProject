using PictureGalleryProject.Models;
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
        private PictureGalleryModel db = new PictureGalleryModel();
        // GET: Files
        // Whenever the application loads, the action result will be fired
        [Authorize]
        public ActionResult Index()
        {
            foreach (string upload in Request.Files)
            {
                // Checking whether the request parameter contains the files. If it exists, it saves the selected file to the directory 
                // App_Data / Uploaded_Files /
                if (Request.Files[upload].FileName != "")
                {
                    //Does another check to see if the user is logged in
                    //If logged in -> upload file -> Get UserId -> Get filepath -> Save logged in UserID and uploaded file's path to database
                    if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        //Saving the location the file will be saved on as path(/App_Data/Uploaded_Files/)
                        string path = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/Uploaded_Files/";
                        
                        //Fetching the filename's name from the file that is being uploaded and saves it as string filename
                        string filename = Path.GetFileName(Request.Files[upload].FileName);

                        //Combining the path and filename to save the file to a specific map (/App_Data/Uploaded_Files/) and then the name of the file that is being saved in filename.
                        Request.Files[upload].SaveAs(Path.Combine(path, filename));

                        //Getting Logged in users UserID.
                        var id = System.Web.HttpContext.Current.User.Identity.Name;
                        var intID = Int32.Parse(id); //Parse it to be able to add it into the database, This will always be a number so a try / catch is not needed (It's set as a numerical value in the database itself)

                        //Using the filename that has been fetched from the file that has been uploaded.
                        //And saves it as a complete path to file in the string FileURL
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string FileURL = newpath + filename;

                        //Save UserID and FileURL to database
                        PictureInfo NewFile = new PictureInfo();
                        NewFile.UserID = intID;
                        NewFile.PictureURI = FileURL;
                        db.PictureInfoes.Add(NewFile);
                        db.SaveChanges();
                    }
                }
            }
            return View("Upload");
        }
        [Authorize]
        public ActionResult Downloads()
        {
            // Getting all file information from App_Data / Uploaded_Files 
            // Looping through all of the files 
            // Shows all the files
            var dir = new DirectoryInfo(Server.MapPath("~/App_Data/Uploaded_Files/"));

            //This loops through the current map of files and then gets the names of the current files
            //Each file in the current map will get it's own unique link. This is to make sure you are able to download every file in the current map.
            FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }

        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~/App_Data/Uploaded_Files/" + ImageName;

            //The actuall link to each file in the map is being made here as a return value when you klick on a file to download.
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }


    }
}