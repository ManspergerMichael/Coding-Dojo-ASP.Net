using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Models{
    public class UserContext : DbContext{
        public UserContext(DbContextOptions<UserContext> options):base(options){
        }
        public DbSet<User> User{get;set;}
        public DbSet<Account> Account{get;set;}
        public DbSet<Transaction> Transaction{get;set;}
        
    }
}