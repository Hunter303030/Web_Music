using Microsoft.EntityFrameworkCore;
using Web_Music_v3.Models;

namespace Web_Music_v3.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<PlaylistUser> PlaylistUser { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<AlbumTrack> AlbumTrack { get; set; }
        public DbSet<AlbumUser> AlbumUser { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<User>()
                .HasMany(x => x.PlaylistUsers)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.User_Id);
            model.Entity<Track>()
                .HasMany(x => x.PlaylistUsers)
                .WithOne(x => x.Track)
                .HasForeignKey(x => x.Track_Id);

            model.Entity<Album>()
                .HasMany(x => x.AlbumTracks)
                .WithOne(x => x.Album)
                .HasForeignKey(x => x.Album_Id);
            model.Entity<Track>()
                .HasMany(x => x.AlbumTracks)
                .WithOne(x => x.Track)
                .HasForeignKey(x => x.Track_Id);

            model.Entity<User>()
                .HasMany(x => x.AlbumUsers)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.User_Id);
            model.Entity<Album>()
                .HasMany(x => x.AlbumUsers)
                .WithOne(x => x.Album)
                .HasForeignKey(x => x.Album_Id);
        }
    }
}
