using System.ComponentModel.DataAnnotations.Schema;

namespace MusicRadio.Models
{
    [Table(name: "PurchaseDetail")]
    public class PurchaseDetail
    {
        public int Id { get; set; }
        public decimal Total { get; set; }

        [Column(name: "Album_Id")]
        public int AlbumId { get; set; }

        [Column(name: "Client_Id")]
        public string? ClientId { get; set; }
    }
}
