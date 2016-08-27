namespace MVCBog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ad
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime Date { get; set; }

        [StringLength(128)]
        public string Author_Id { get; set; }

        public int? CommentsCount { get; set; }
    }
}
