using TestLanding.Domain.Base.Interfaces;

namespace TestLanding.Domain;

public record Page<T>(IEnumerable<T> Items, int PageNumber, int PageSize, int TotalCount) : IPage<T>
{
    public int ItemsCount => (int)Math.Ceiling((double)TotalCount / PageSize);
}