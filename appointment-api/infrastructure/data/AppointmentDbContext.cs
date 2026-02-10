using domain.entity;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.data;

public class AppointmentDbContext : DbContext
{
    public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
    {
    }

    public DbSet<Appointment> Appointment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.Plaque).IsRequired().HasMaxLength(7);
            e.HasIndex(e => e.CreatedHour);
        });
    }
}