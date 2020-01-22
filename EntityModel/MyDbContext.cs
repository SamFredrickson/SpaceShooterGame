namespace SpaceShooterGame.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }

        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerScore> PlayerScore { get; set; }
        public virtual DbSet<Score> Score { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(e => e.PlayerScore)
                .WithOptional(e => e.Player)
                .HasForeignKey(e => e.id_player);

            modelBuilder.Entity<Score>()
                .HasMany(e => e.PlayerScore)
                .WithOptional(e => e.Score)
                .HasForeignKey(e => e.id_score);
        }
    }
}
