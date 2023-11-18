using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sept2023WebAppMVC.Models
{
    public class PersonDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Date Of Birthh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)] 
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public long MobileNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
    }
}