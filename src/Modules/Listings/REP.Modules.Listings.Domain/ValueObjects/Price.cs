using REP.Modules.Listings.Domain.Entities;

namespace REP.Modules.Listings.Domain.ValueObjects;

public record Price
{
    public decimal? Amount { get; init; }
    public Currency? Currency { get; init; }

    private Price() { }

    public Price(decimal? amount, Currency? currency)
    {
        // if price is null then you cannot have currency
        if (amount is null && currency is not null)
        {
            throw new ArgumentException("If price is null then currency must be null as well.");
        }

        // if price is not null then you must have currency
        if (amount is not null && currency is null)
        {
            throw new ArgumentException("If price is not null then currency must be provided.");
        }

        // if price is less than zero
        if (amount is not null && amount < 0)
        {
            throw new ArgumentException("Price cannot be less than zero.");
        }

        // Price cannot be larger than 1 billion
        if (amount is not null && amount > 1_000_000_000)
        {
            throw new ArgumentException("Price cannot be larger than 1 billion.");
        }

        // if currency code is empty
        if (currency is not null && string.IsNullOrWhiteSpace(currency.Code))
        {
            throw new ArgumentException("Currency code cannot be empty.");
        }

        // if currency symbol is empty
        if (currency is not null && string.IsNullOrWhiteSpace(currency.Symbol))
        {
            throw new ArgumentException("Currency symbol cannot be empty.");
        }

        Amount = amount;
        Currency = currency;
    }
}

