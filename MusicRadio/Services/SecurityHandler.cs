using MusicRadio.Dtos;
using MusicRadio.Infrastructure.Repositories;
using MusicRadio.Models;

namespace MusicRadio.Services
{
    public class SecurityHandler(ISecurityRepository securityRepository, IClientRepository clientRepository) : ISecurityHandler
    {
        public async Task<int> CreateLogin(LoginDto loginDto, CancellationToken cancellationToken)
        {
            if (loginDto == null)
                throw new ArgumentNullException(nameof(loginDto));

            Security entity = new()
            {
                ClientId = loginDto.ClientId,
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                Password = loginDto.Password,
                Status = true
            };

            await securityRepository.Create(entity, cancellationToken);
            return entity.Id;
        }

        public async Task<ClientDto?> Login(LoginDto loginDto, CancellationToken cancellationToken)
        {
            if (loginDto == null)
                throw new ArgumentNullException(nameof(loginDto));

            var result = await securityRepository.Find(x => x.ClientId == loginDto.ClientId && x.Password!.Equals(loginDto.Password), cancellationToken);
            if (result == null)
            {
                var client = await clientRepository.Find(x => x.Id == loginDto.ClientId, cancellationToken);
                if (client != null)
                return new ClientDto() 
                {
                    Id = client.Id,
                    Name = client.Name
                };
            }
            return null;
        }
    }
}
