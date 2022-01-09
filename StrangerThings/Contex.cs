#nullable disable
using Microsoft.EntityFrameworkCore;

namespace StrangerThings
{
    public class Contex : DbContext
    {
        public Contex(DbContextOptions options)
            : base(options) { }

        public DbSet<Ooga> Oogas { get; set; }
    }

    public class Ooga
    {
        public int Id { get; set; }
        public string Booga { get; set; }
    }

}
