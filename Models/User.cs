namespace PictureGalleryProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Spatial;

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
        [Display(Name = "Username: ")]
        public string UserName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PictureInfo> PictureInfoes { get; set; }
    }

    //public partial class UserEntities2 : DbContext
    //{
    //    public UserEntities2()
    //        : base("name=UserEntities2")
    //    {
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<PictureInfo>()
    //            .Property(e => e.PictureURI)
    //            .IsFixedLength();

    //        modelBuilder.Entity<User>()
    //            .Property(e => e.UserName)
    //            .IsFixedLength();

    //        modelBuilder.Entity<User>()
    //            .Property(e => e.Password)
    //            .IsFixedLength();

    //        modelBuilder.Entity<User>()
    //            .Property(e => e.FirstName)
    //            .IsFixedLength();

    //        modelBuilder.Entity<User>()
    //            .Property(e => e.LastName)
    //            .IsFixedLength();

    //        modelBuilder.Entity<User>()
    //            .HasMany(e => e.PictureInfoes)
    //            .WithRequired(e => e.User)
    //            .WillCascadeOnDelete(false);
    //    }

    //    public DbSet<User> Registrations { get; set; }
    //}
}
