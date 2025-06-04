using MusicRadio.Infrastructure.DbContexts;
using MusicRadio.Models;

namespace MusicRadio.Infrastructure.Repositories
{
    public class SecurityRepository : RepositoryBase<Security>, ISecurityRepository
    {
        public SecurityRepository(MusicRadioDbContext context) : base(context)
        {
        }
    }
}
