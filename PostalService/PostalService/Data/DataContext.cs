using Microsoft.EntityFrameworkCore;
using PostalService.Models;

namespace PostalService.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
