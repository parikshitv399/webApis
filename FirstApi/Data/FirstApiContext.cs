using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Data
{
    public class FirstApiContext :DbContext
    {
        //Create the property of the model classes
        //which will become tables in the database
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public FirstApiContext(DbContextOptions<FirstApiContext> options)
            :base(options)
        {

        }
    }
}
