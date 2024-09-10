using SmartPin.Entities.Abstractions;

namespace SmartPin.Entities;

public abstract class Player: BaseEntity<int>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public List<Shot> Shots { get; set; }
}

public class RegisteredPlayer : Player
{
    public int? UserId { get; set; }

    public User? User { get; set; }

    public int RegistrationNumber { get; set; }

    public List<Guest> Guests { get; set; }

    public List<EventParticipant> EventParticipants { get; set; }
}

public class Guest : Player
{
    public RegisteredPlayer Parent { get; set; }

    public bool HasActivities { get; set; }
}

public class EventParticipant : Player
{
    public RegisteredPlayer Parent { get; set; }

    public int EventId { get; set; }
}