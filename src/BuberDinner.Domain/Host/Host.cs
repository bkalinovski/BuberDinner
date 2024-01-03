using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host : Entity<HostId>
{
    private readonly List<MenuId> _menuIds = new();
    
    private readonly List<DinnerId> _dinnerIds = new();
    
    public string FirstName { get; }

    public string LastName { get; }

    public Uri ProfileImage { get; }

    public AverageRating AverageRating { get; }

    public UserId UserId { get; }
    
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    
    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    private Host(
        HostId id,
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(string firstName, string lastName, Uri profileImage, UserId userId)
    {
        return new Host(HostId.CreateUnique(), firstName, lastName, profileImage, userId, DateTime.UtcNow, DateTime.UtcNow);
    }
}