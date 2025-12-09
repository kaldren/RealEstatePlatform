namespace REP.Modules.Listings.Domain.Entities;

public record Currency
{
    public string Code { get; init; }
    public string Symbol { get; init; }

    private Currency() { }  // EF uses this

    public Currency(string code, string symbol)
    {
        Code = code;
        Symbol = symbol;
    }
}

