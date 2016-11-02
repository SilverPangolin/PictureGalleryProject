using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PictureGalleryProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFileService" in both code and config file together.
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        string GetUsers(getusers userInfo);

        [OperationContract]
        string SetUsers(setusers userInfo);

        [OperationContract]
        string GetFiles(getfiles filesInfo);

        [OperationContract]
        string SetFiles(setfiles filesInfo);
    };

    public class getusers
    {
        string username = string.Empty;
        string password = string.Empty;
        string firstname = string.Empty;
        string lastname = string.Empty;

        [DataMember]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        [DataMember]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
    }

    public class setusers
    {
        string username = string.Empty;
        string password = string.Empty;
        string firstname = string.Empty;
        string lastname = string.Empty;

        [DataMember]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        [DataMember]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
    }

    public class getfiles
    {
        string fileurl = string.Empty;
        string userid = string.Empty;

        [DataMember]
        public string FileURL
        {
            get { return fileurl; }
            set { fileurl = value; }
        }

        [DataMember]
        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }
    }

    public class setfiles
    {
        string fileurl = string.Empty;
        string userid = string.Empty;

        [DataMember]
        public string FileURL
        {
            get { return fileurl; }
            set { fileurl = value; }
        }

        [DataMember]
        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }
    }
}
