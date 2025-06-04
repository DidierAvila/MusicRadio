using MusicRadio.Infrastructure.Repositories;
using MusicRadio.Models;

namespace MusicRadio.Services
{
    public class AlbumSetHandler(IAlbumSetRepository albumSetRepository) : IAlbumSetHandler
    {
        public async Task<AlbumSet?> GetById(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
                throw new Exception("Id no puede ser null");
            return await albumSetRepository.GetByID(id, cancellationToken);
        }
    }
}
