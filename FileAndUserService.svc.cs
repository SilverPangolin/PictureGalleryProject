using PictureGalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PictureGalleryProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FileService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FileService.svc or FileService.svc.cs at the Solution Explorer and start debugging.
    public class FileService : IFileAndUserService
    {
        public ServiceFileInfo[] GetFileInfo()
        {
            List<ServiceFileInfo> returnFiles = new List<ServiceFileInfo>();
            using (PictureGalleryModel db = new PictureGalleryModel())
            {
                var dbFilesList = db.PictureInfoes.ToList();
                foreach (var dbrow in dbFilesList)
                {
                    ServiceFileInfo NewFile = new ServiceFileInfo();
                    NewFile.Id = dbrow.Id;
                    NewFile.FileURL = dbrow.PictureURI;
                    NewFile.UserID = dbrow.UserID;
                    returnFiles.Add(NewFile);
                }
            }
            return returnFiles.ToArray();
        }

        public ServiceUserInfo[] GetUserInfo()
        {
            List<ServiceUserInfo> returnUsers = new List<ServiceUserInfo>();
            using (PictureGalleryModel db = new PictureGalleryModel())
            {
                var dbUsersList = db.Users.ToList();
                foreach (var dbrow in dbUsersList)
                {
                    ServiceUserInfo NewUser = new ServiceUserInfo();
                    NewUser.Id = dbrow.Id;
                    NewUser.UserName = dbrow.UserName;
                    NewUser.Password = dbrow.Password;
                    NewUser.FirstName = dbrow.FirstName;
                    NewUser.LastName = dbrow.LastName;
                    returnUsers.Add(NewUser);
                }
            }
            return returnUsers.ToArray();
        }

        public void SaveUser(ServiceUserInfo user)
        {
            using (PictureGalleryModel db = new PictureGalleryModel())
            {
                User NewRegistration = new User();
                NewRegistration.UserName = user.UserName;
                NewRegistration.Password = user.Password;
                NewRegistration.FirstName = user.FirstName;
                NewRegistration.LastName = user.LastName;
                db.Users.Add(NewRegistration);
                db.SaveChanges();
            }
        }
    }
}
