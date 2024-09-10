using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartPin.Entities.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(user => user.RegisteredPlayer)
            .WithOne(player => player.User)
            .HasForeignKey<RegisteredPlayer>(player => player.UserId); 
    }
}

public class RegisteredPlayerConfiguration : IEntityTypeConfiguration<RegisteredPlayer>
{
    public void Configure(EntityTypeBuilder<RegisteredPlayer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.EventParticipants)
            .WithOne(y => y.Parent);

        builder.HasMany(x => x.Guests)
            .WithOne(y => y.Parent);
    }
}

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.HasKey(x => x.Id);
    }
}

public class EventParticipantConfiguration : IEntityTypeConfiguration<EventParticipant>
{
    public void Configure(EntityTypeBuilder<EventParticipant> builder)
    {
        builder.HasKey(x => x.Id);
    }
}

public class ShotConfiguration : IEntityTypeConfiguration<Shot>
{
    public void Configure(EntityTypeBuilder<Shot> builder)
    {
        builder.HasKey(x => x.Id);
    }
}