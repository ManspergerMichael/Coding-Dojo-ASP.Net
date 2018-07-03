using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models{
    public class Wedding{
        [Key]
        public int WeddingID{get;set;}
        [Required]
        public string WedderOne{get;set;}
        [Required]
        public string WedderTwo{get;set;}
        [Required]
        [DataType(DataType.DateTime)]   
        public DateTime Date{get;set;}
        [Required]
        public string WeddingAddress{get;set;}
        public int Guests{get;set;}
        [ForeignKey("User")]
        public int UserID{get;set;}
        public User User{get;set;}
        public DateTime createdAt{get;set;}
        public DateTime updatedAt{get;set;}

        public List<Guest> GuestList{get;set;}

        public Wedding(){
            GuestList = new List<Guest>();
        }
    }
}