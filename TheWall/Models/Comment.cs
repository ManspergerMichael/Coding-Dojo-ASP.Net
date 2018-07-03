using System.ComponentModel.DataAnnotations;
using System;
namespace TheWall.Models{
    public class Comment{
        [Key]
        public int CommentID{get;set;}
        [Required]
        [MinLength(10)]
        public string CommentText{get;set;}

        public DateTime createdAt{get;set;}
        public DateTime updatedAt{get;set;}

        public int MessageID{get;set;}
       // public Message Message{get;set;}
        public int UserID{get;set;}
        public User User{get;set;}

    }
}