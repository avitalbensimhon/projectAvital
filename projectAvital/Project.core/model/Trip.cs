using System.ComponentModel.DataAnnotations;

namespace Project.core.model
{
    public class Trip
    {
        [Key]
        public string code { get; set; }
        public string location { get; set; }
        public DateTime date { get; set; }
        public int numRegisteres { get; set; }
        public List<Registeres> registeres { get; set; }
        public string idGuide { get; set; }
        public Guide guide { get; set; }
    }
}
