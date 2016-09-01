using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBog.Models
{
    public class Poll
    {
        public Poll()
        {
            this.Date = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]       
        public int Votes { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}