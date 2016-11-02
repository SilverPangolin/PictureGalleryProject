using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PictureGalleryProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FileService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FileService.svc or FileService.svc.cs at the Solution Explorer and start debugging.
    public class FileService : IFileService
    {
        public string GetFiles(getfiles filesInfo)
        {
            throw new NotImplementedException();
        }

        public string GetUsers(getusers userInfo)
        {
            throw new NotImplementedException();
        }

        public string SetFiles(setfiles filesInfo)
        {
            throw new NotImplementedException();
        }

        public string SetUsers(setusers userInfo)
        {
            string Message;
            SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Projectdb.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Users(UserName,Password,FirstName,LastName) values(@UserName,@Password,@Country,@Email)", con);
            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@Country", userInfo.FirstName);
            cmd.Parameters.AddWithValue("@Email", userInfo.LastName);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = userInfo.UserName + " Details inserted successfully";
            }
            else
            {
                Message = userInfo.UserName + " Details not inserted successfully";
            }
            con.Close();
            return Message;
        }
    }
}
