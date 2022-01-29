using Microsoft.EntityFrameworkCore;

public class TransporteContext : DbContext {

    public TransporteContext(DbContextOptions<TransporteContext> options) : base(options)
        {
        }
        public DbSet<TipoTransporte> TiposTransportes { get; set; }
        public DbSet<Horario> Horarios {get;set; }
        public DbSet<TipoCarga> TipoCargas {get;set;}

        public DbSet<Agendamento> Agendamentos {get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
                builder.Entity<TipoTransporte>().HasKey(t => t.Id);
                builder.Entity<Horario>().HasKey(h => h.Id);
                builder.Entity<TipoCarga>().HasKey(tc => tc.Id);
                builder.Entity<Agendamento>().HasKey(a => a.Id);
                builder.Entity<Agendamento>()
                        .HasOne<TipoTransporte>(t => t.TipoTransporte)
                        .WithMany(a => a.Agendamentos)
                        .HasForeignKey(a => a.TipoTransporteId);

                builder.Entity<Agendamento>()
                        .HasOne<Horario>(h => h.Horario)
                        .WithMany(a => a.Agendamentos)
                        .HasForeignKey(a => a.HorarioId);

                builder.Entity<Agendamento>()
                        .HasOne<TipoCarga>(tc => tc.TipoCarga)
                        .WithMany(a => a.Agendamentos)
                        .HasForeignKey(a => a.TipoCargaId);

                base.OnModelCreating(builder);
        }
}
