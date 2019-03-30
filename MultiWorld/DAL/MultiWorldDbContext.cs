using Microsoft.EntityFrameworkCore;
using MultiWorld.Models;

namespace MultiWorld.DAL
{
    public class MultiWorldDbContext : DbContext
    {
        public MultiWorldDbContext(DbContextOptions<MultiWorldDbContext> options)
            : base(options)
        {
        }
        public DbSet<Transformer> Transformers { get; set; }
    }
}
