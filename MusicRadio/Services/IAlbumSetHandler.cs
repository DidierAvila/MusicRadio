using MusicRadio.Models;

namespace MusicRadio.Services
{
    public interface IAlbumSetHandler
    {
        Task<AlbumSet?> GetById(int id, CancellationToken cancellationToken);
    }
}