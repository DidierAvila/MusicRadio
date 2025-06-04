using MusicRadio.Dtos;
using MusicRadio.Infrastructure.Repositories;
using MusicRadio.Models;

namespace MusicRadio.Services
{
    public class ClientHandler(IClientRepository clientRepository, ISecurityHandler securityHandler) : IClientHandler
    {
        public async Task<Client> Create(ClientDto client, CancellationToken cancellationToken)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            Client entity = new()
            {
                Id = client.Id,
                Name = client.Name,
                Direction = client.Direction,
                Phone = client.Phone,
                Mail = client.Mail
            };

            var result = await clientRepository.Create(entity, cancellationToken);
            if (result != null)
            {
                LoginDto loginDto = new()
                {
                    ClientId = client.Id,
                    Password = client.Password
                };
                var resultCreateLogin = await securityHandler.CreateLogin(loginDto, cancellationToken);
                if (resultCreateLogin < 0)
                    throw new Exception("Error creando el login");
            }

            return entity;
        }
    }
}
