using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace BankAccounts.Models{
    public class Transaction{
        [Key]
        public int TransactionID{get;set;}
        public double BalanceChange{get;set;}
        public DateTime Date{get;set;}
        
        [ForeignKey("Account")]
        public int AccountID{get;set;}
        public Account Account{get;set;}
        //public User User_ID{get;set;}
        //public User User{get;set;}
    }
}