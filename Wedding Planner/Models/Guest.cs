using System.ComponentModel.DataAnnotations;
using System;
namespace Wedding_Planner.Models{
    public class Guest{
        [Key]
        public int GuestID{get;set;}
        
        public int UserID{get;set;}
        public User User{get;set;}
        public int WeddingID{get;set;}
        public Wedding Wedding{get;set;}
    }
}