using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApi.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        [NotMapped]
        public List<string> Cast { get; set; }
        public string Director { get; set; }
        public double Budget { get; set; }
    }
}
