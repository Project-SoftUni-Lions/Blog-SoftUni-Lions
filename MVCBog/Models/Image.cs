using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBog.Models
{
    public class Image
    {

        [Key]
        public int Id { get; set; }

        public byte[] BrandImage { get; set; }
    }
}