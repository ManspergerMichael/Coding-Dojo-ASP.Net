using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace TheWall.Models{
    public class User{
        [Key]
        public int UserID{get;set;}
        [Required]
        [MinLength(3)]
        public string FirstName{get;set;}
        [Required]
        [MinLength(3)]
        public string LastName{get;set;}
        [Required]
        [EmailAddress]
        public string Email{get;set;}
        [Required]
        [MinLength(8)]
        public string Password{get;set;}

        public DateTime createdAt{get;set;}
        public DateTime updatedAt{get;set;}

        public List<Message> Messages{get;set;}
        public List<Comment> Comments{get;set;}

        public User(){
            Messages = new List<Message>();
            Comments = new List<Comment>();
        }
        
    }
}