using System.ComponentModel.DataAnnotations;
using System;
namespace LoginRegistration.Models{
    public class User{
        [Key]
        public int id{get;set;}
        [Required]
        [MinLength(2)]
        [RegularExpression("^[a-zA-Z]*$")]
        public string firstName{get;set;}

        [Required]
        [MinLength(3)]
        [RegularExpression("^[a-zA-Z]*$")]
        public string lastName{get;set;}
        [Required]
        [EmailAddress]
        
        public string email{get;set;}
        [Required]
        [MinLength(8)]
        public string Password{get;set;}

        [Timestamp]
        public DateTime createdAt{get;set;}
        [Timestamp]
        public DateTime updatedAt{get;set;}
    }
}