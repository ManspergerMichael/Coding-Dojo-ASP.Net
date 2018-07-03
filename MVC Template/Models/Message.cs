using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace TheWall.Models{
    public class Message{
        [Key]
        public int MessageID{get;set;}
        [Required]
        [MinLength(10)]
        public string MessageText{get;set;}
        public DataType createdAt{get;set;}
        public DataType updatedAt{get;set;}

        public User user{get;set;}
        public int UserID{get;set;}

        List<Comment> Comments{get;set;}

        public Message(){
            Comments = new List<Comment>();
        }

    }
}