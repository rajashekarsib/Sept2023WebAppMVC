using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sept2023WebAppMVC.Models
{
    public class ImageModel  
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageName { get; set; }
        public string Username { get; set; }

    }
}