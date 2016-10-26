namespace PictureGalleryProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            PictureInfoes = new HashSet<PictureInfo>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string UserName { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PictureInfo> PictureInfoes { get; set; }
    }

    public class UserRepository
    {
        PictureGalleryModel context = new PictureGalleryModel();
        public User GetByUsernameAndPassword(User user)
        {
            return context.Users.Where(u => u.UserName == user.UserName & u.Password == user.Password).FirstOrDefault();
        }
    }

    public class UserApplication
    {
        UserRepository userRepo = new UserRepository();
        public User GetByUsernameAndPassword(User user)
        {
            return userRepo.GetByUsernameAndPassword(user);
        }
    }
}
