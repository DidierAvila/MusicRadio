using MusicRadio.Models;

namespace MusicRadio.Infrastructure.Repositories
{
    public interface IAlbumSetRepository : IRepositoryBase<AlbumSet>
    {
        Task<AlbumSet?> GetById(int id, CancellationToken cancellationToken);
    }
}