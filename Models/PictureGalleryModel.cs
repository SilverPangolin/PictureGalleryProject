namespace PictureGalleryProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PictureGalleryModel : DbContext
    {
        public PictureGalleryModel()
            : base("name=PictureGalleryModel")
        {
            //En cirkelreferens upptäcktes vid serialisering av ett objekt av typen System.Data.Entity.DynamicProxies.User_6DA8C234C12E33806229D551FC81CA2ED529C82885402F4B3D7F8EC8EEDF2E8A.
            //Had to turn of the dynamic proxies so it's always the same instead of the random number after           user_*NUMBERS*
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<PictureInfo> PictureInfoes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<LoginModel> LoginModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PictureInfo>()
                .Property(e => e.PictureURI)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.PictureInfoes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
