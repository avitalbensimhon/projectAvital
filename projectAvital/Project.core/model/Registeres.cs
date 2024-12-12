using System.ComponentModel.DataAnnotations;

namespace Project.core.model
{
    public class Registeres
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public List<Trip> trips { get; set; }
        public bool status { get; set; }
    }
}
