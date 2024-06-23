using System.ComponentModel.DataAnnotations;

namespace Self.CleanArchitecture.Web.Controllers.Contributors
{
    public record GetCountryGwpResponse(string business, decimal grossRevenue)
    {
        string Business { get; init; } = business;
        decimal GrossRevenue { get; init; } = grossRevenue;

    }
}
