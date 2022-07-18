namespace TestLanding.Domain.Base.Interfaces;

public interface IPage<out T>
{
    IEnumerable<T> Items { get; }

    int ItemsCount { get; }

    int TotalCount { get; }

    int PageNumber { get; }

    int PageSize { get; }

    int TotalPagesCount => (int)Math.Ceiling((double)TotalCount / PageSize);

    bool HasPrevPage => PageNumber >= 0;

    bool HasNextPage => PageNumber < TotalPagesCount;
}
