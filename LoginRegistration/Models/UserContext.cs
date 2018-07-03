using Microsoft.EntityFrameworkCore; 
namespace LoginRegistration.Models{
    public class UserContext : DbContext{
        public UserContext(DbContextOptions<UserContext> options): base(options){}
       public DbSet<User> User{get;set;}
    }
}