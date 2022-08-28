using API_SuperHeroes.Model;
using Microsoft.EntityFrameworkCore;

namespace API_SuperHeroes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }


    }
}
