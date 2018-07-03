using Microsoft.EntityFrameworkCore;
 
namespace RESTauranter.Models
{
    public class RestContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestContext(DbContextOptions<RestContext> options) : base(options) { }
        public DbSet<reviews> reviews{get;set;}
    }
}
