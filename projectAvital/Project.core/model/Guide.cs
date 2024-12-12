using System.ComponentModel.DataAnnotations;

namespace Project.core.model
{
    public class Guide
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public bool status { get; set; }
        public List<Trip> trips { get; set; }
    }
}
