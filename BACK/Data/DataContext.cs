using BACK.Models;
using Microsoft.EntityFrameworkCore;

namespace BACK.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
    }
}
