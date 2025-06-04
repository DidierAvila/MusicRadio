using MusicRadio.Dtos;
using MusicRadio.Models;

namespace MusicRadio.Services
{
    public interface IClientHandler
    {
        Task<Client> Create(ClientDto client, CancellationToken cancellationToken);
    }
}