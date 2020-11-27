using ComputerPartsCatalog.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace ComputerPartsCatalog.Data.Models
{
    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
