using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicRadio.Models
{
    [Table(name: "Client")]
    public class Client
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Direction { get; set; }
        public string? Phone { get; set; }

        [NotMapped]
        public string? Password { get; set; }
    }
}
