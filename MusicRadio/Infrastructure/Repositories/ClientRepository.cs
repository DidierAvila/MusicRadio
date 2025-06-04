using MusicRadio.Infrastructure.DbContexts;
using MusicRadio.Models;

namespace MusicRadio.Infrastructure.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(MusicRadioDbContext context) : base(context)
        {
        }
    }
}
