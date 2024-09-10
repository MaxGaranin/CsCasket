using SmartPin.Entities.Abstractions;

namespace SmartPin.Entities;

public class Shot : BaseEntity<int>
{
    public DateTime CreatedAt { get; set; }

    public Player Player { get; set; }
}