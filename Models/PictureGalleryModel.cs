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
        }

        public virtual DbSet<PictureInfo> PictureInfoes { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
