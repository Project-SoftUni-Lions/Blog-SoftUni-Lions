﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBog.Models
{
    public class Ads
    {
        public Ads()
        {
            this.Date = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public ApplicationUser Author { get; set; }

        public int? CommentsCount { get; set; }

       
        public byte[] UplImage { get; set; }

        [StringLength(20)]
        public string Price { get; set; }

        [StringLength(100)]
        public string Contacts { get; set; }
    }
}