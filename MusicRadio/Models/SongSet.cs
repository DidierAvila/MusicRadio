using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicRadio.Models
{
    [Table(name: "SongSet")]
    public class SongSet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        [Column(name: "Album_Id")]
        public int AlbumId { get; set; }
    }
}
