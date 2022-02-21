using System.ComponentModel.DataAnnotations;

namespace DatabaseLibrary
{
    public class SampleData
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string SomeData { get; set; }
    }
}