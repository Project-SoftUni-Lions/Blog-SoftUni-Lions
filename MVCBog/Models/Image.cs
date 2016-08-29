using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace MVCBog.Models

{
    
    public class Image
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
    }
}