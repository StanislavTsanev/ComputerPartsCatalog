namespace ComputerPartsCatalog.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ComputerPartsCatalog.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
