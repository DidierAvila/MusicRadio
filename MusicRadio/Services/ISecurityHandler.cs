using MusicRadio.Dtos;

namespace MusicRadio.Services
{
    public interface ISecurityHandler
    {
        Task<int> CreateLogin(LoginDto loginDto, CancellationToken cancellationToken);
        Task<ClientDto?> Login(LoginDto loginDto, CancellationToken cancellationToken);
    }
}