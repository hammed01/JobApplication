using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace jobApplication.Models
{
    
    public class Person
        
    {
       
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }     
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Id { get; set; }
        public string Nationality { get; set; }
        public string HighSchool { get; set; }
        [Display(Name = "State Of Origin")]
        public string StateOfOrigin { get; set; }
        public string Qualification { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name ="Date Of Birth") ]
        public DateTime DateOfBirth { get; set; }
        public List<Person> PersonList { get; set; }
        public string ActionMessage;
        public bool ActionStatus;


    }
} 

