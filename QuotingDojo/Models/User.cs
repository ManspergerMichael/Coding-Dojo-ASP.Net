using System.ComponentModel.DataAnnotations;
namespace QuotingDojo.Models{
    public class User{
        [Required]
        [MinLength(3)]
        public string Name{get;set;}

        [Required]
        [MinLength(6)]
        public string Quote{get;set;}
    }
}