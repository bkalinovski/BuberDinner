using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public sealed class Price : ValueObject
{
    public float Amount { get; }

    public string Currency { get; }

    private Price(float amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price Create(float amount)
    {
        return new Price(amount, "USD");
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}