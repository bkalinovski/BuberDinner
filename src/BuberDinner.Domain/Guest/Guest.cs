﻿using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : Entity<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    
    private readonly List<DinnerId> _pastDinnerIds = new();
    
    private readonly List<DinnerId> _pendingDinnerIds = new();
    
    private readonly List<BillId> _billIds = new();
    
    private readonly List<MenuReviewId> _menuReviewIds = new();
    
    private readonly List<GuestRating> _ratings = new();
    
    public string FirstName { get; }

    public string LastName { get; }

    public Uri ProfilePicture { get; }

    public AverageRating AverageRating { get; }

    public UserId UserId { get; }
    
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    
    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();
    
    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    private Guest(GuestId id,
        string firstName,
        string lastName,
        Uri profilePicture,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfilePicture = profilePicture;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(string firstName, string lastName, Uri profilePicture, UserId userId)
    {
        return new Guest(GuestId.CreateUnique(),
            firstName,
            lastName,
            profilePicture,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}