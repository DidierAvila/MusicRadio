using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicRadio.Models
{
    [Table(name: "Security")]
    public class Security
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(name: "Client_Id")]
        public string? ClientId { get; set; }
        public string? Token { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Status { get; set; }
    }
}
