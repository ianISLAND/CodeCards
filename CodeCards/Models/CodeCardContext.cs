using Microsoft.EntityFrameworkCore;

namespace CodeCards.Models
{
    public class CodeCardContext : DbContext
    {
        public DbSet<CodeCard> Code_Card { get; set; }

        public CodeCardContext(DbContextOptions<CodeCardContext> options)
            : base(options) { }
    }
}
