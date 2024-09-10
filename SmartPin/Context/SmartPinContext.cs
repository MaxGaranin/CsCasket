using Microsoft.EntityFrameworkCore;
using SmartPin.Entities;

namespace SmartPin.Context;

public class SmartPinContext : DbContext
{
    public SmartPinContext()
    {
    }

    public SmartPinContext(DbContextOptions<SmartPinContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<RegisteredPlayer> RegisteredPlayers { get; set; }

    public DbSet<Guest> Guests { get; set; }

    public DbSet<EventParticipant> EventParticipants { get; set; }

    public DbSet<Shot> Shots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseNpgsql(
                    "Host=127.0.0.1;sslmode=Disable;Database=smartpin;Username=postgres;Password=postgres;",
                    _ => { })
                .EnableDetailedErrors();
        }
    }
}