using System.ComponentModel.DataAnnotations;
using System;
namespace RESTauranter.Models{
    public class reviews {
        [Key]
        public int id{get;set;}
        [Required]
        [MinLength(3)]
        public string name{get;set;}
        [Required]
        [MinLength(5, ErrorMessage="Test")]
        public string resturant{get;set;}
        [Required]
        [MinLength(10)]
        [MaxLength(255)]
        public string review{get;set;}
        [Required]
        [Range(typeof(DateTime), "1/1/2018", "6/15/2018")]
        public DateTime date{get;set;}
        [Range(1,5)]
        public int stars{get;set;}
    }
}