using MusicRadio.Infrastructure.Repositories;
using MusicRadio.Services;

namespace MusicRadio.Extentions
{
    public static class MusicRadioExtention
    {
        public static IServiceCollection AddMusicRadioExtention(this IServiceCollection services)
        {
            services.AddScoped<IClientHandler, ClientHandler>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<ISecurityHandler, SecurityHandler>();
            services.AddScoped<ISecurityRepository, SecurityRepository>();

            services.AddScoped<IAlbumSetHandler, AlbumSetHandler>();
            services.AddScoped<IAlbumSetRepository, AlbumSetRepository>();
            

            return services;
        }
    }
}
