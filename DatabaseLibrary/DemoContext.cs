using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary
{
    public class DemoContext : DbContext
    {
        public DbSet<SampleData> sampleData { get; set; }

        public DemoContext(DbContextOptions<DemoContext> options)
            :base(options)
        { }
    }
}
