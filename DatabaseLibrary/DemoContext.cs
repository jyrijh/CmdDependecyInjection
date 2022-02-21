using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;

namespace DatabaseLibrary
{
    public class DemoContext : DbContext
    {
        public DbSet<SampleData> sampleData { get; set; }

        public DemoContext(DbContextOptions<DemoContext> options)
            :base(options)
        { }
    }

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DemoContext>
    //{
    //    public DemoContext CreateDbContext(string[] args)
    //    {
    //        var builder = new DbContextOptionsBuilder<DemoContext>();
    //        var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=TestDB;Trusted_Connection=True;";
    //        builder.UseSqlServer(connectionString);
    //        return new DemoContext(builder.Options);
    //    }
    //}
}
