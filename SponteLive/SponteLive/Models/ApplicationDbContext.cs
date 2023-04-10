using Microsoft.EntityFrameworkCore;

namespace SponteLive.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Instrutor> Instrutores { get; set; }
        public DbSet<Inscrito> Inscritos { get; set; }
        public DbSet<Live> Lives { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrutor>()
                .HasMany(i => i.Lives)
                .WithOne(l => l.Instrutor)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Live)
                .WithMany(l => l.Inscricoes)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Inscrito)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


        }


    }
}
