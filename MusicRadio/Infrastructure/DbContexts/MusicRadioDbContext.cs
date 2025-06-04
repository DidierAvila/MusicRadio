using Microsoft.EntityFrameworkCore;
using MusicRadio.Models;

namespace MusicRadio.Infrastructure.DbContexts
{
    public partial class MusicRadioDbContext : DbContext
    {
        public MusicRadioDbContext() { }

        public MusicRadioDbContext(DbContextOptions<MusicRadioDbContext> options) : base(options) { }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Security> Securities { get; set; }
        public virtual DbSet<AlbumSet> AlbumSets { get; set; }
        public virtual DbSet<SongSet> SongSets { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
