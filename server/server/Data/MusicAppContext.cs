using Microsoft.EntityFrameworkCore;
using server.Entities;

namespace server.Data
{
    public class MusicAppContext(DbContextOptions<MusicAppContext> options)
        : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
    }
}
