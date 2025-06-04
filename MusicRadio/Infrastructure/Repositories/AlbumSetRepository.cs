using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using MusicRadio.Dtos;
using MusicRadio.Infrastructure.DbContexts;
using MusicRadio.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicRadio.Infrastructure.Repositories
{
    public class AlbumSetRepository : RepositoryBase<AlbumSet>, IAlbumSetRepository
    {
        public AlbumSetRepository(MusicRadioDbContext context) : base(context)
        {
        }

        public async Task<AlbumSet?> GetById(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
                throw new Exception("Id no puede ser null");

            var result = await EntitySet.FromSqlRaw("EXEC GetAlbumById @Id", new SqlParameter("@Id", id)).FirstOrDefaultAsync(cancellationToken);
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
