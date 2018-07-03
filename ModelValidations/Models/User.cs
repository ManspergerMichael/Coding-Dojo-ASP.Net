using System.ComponentModel.DataAnnotations;
namespace ModelValidations.Models{
    public class User{
        [Required]
        [MinLength(3)]
        public string firstName{get;set;}

        [Required]
        [MinLength(3)]
        public string lastName{get;set;}

        [Required]
        public int age{get;set;}

        [Required]
        [EmailAddress]
        public string email{get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password{get;set;}
    }
}