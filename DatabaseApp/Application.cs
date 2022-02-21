using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace DatabaseApp
{
    internal class Application
    {
        Configuration.Application _settings;
        DatabaseLibrary.DemoContext _db;

        public Application(IOptions<Configuration.Application> settings, DatabaseLibrary.DemoContext db)
        {
            _settings = settings.Value;
            _db = db;
        }

        public void Run()
        {
            AddToDB();
            _db.sampleData.ToList()
                .ForEach(d => Console.WriteLine($"Id: {d.Id}, Data: {d.SomeData}"));
            
        }

        private void AddToDB()
        {
            _db.Add(new DatabaseLibrary.SampleData() { SomeData = "foo" });
            _db.Add(new DatabaseLibrary.SampleData() { SomeData = "bar" });
            _db.Add(new DatabaseLibrary.SampleData() { SomeData = "baz" });
            _db.SaveChanges();
        }
    }
}