using Microsoft.EntityFrameworkCore;

namespace PropertyManagement.Model
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
