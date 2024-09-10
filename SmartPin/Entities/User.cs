using SmartPin.Entities.Abstractions;

namespace SmartPin.Entities;

public class User : BaseEntity<int>
{
    public string Email { get; set; }

    public RegisteredPlayer? RegisteredPlayer { get; set; }
}