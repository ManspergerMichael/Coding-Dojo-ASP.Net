using Microsoft.EntityFrameworkCore;
namespace TheWall.Models{
    public class WallContext : DbContext{
       public WallContext(DbContextOptions<WallContext> options) :base(options){}
           public DbSet<User> Users{get;set;}
           public DbSet<Message> Messages{get;set;}
           public DbSet<Comment> Comments{get;set;}
       
    }
}