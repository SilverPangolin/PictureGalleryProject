namespace PictureGalleryProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PictureInfo")]
    public partial class PictureInfo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string PictureURI { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
