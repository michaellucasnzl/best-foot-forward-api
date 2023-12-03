namespace BestFootForwardApi.Application.Common.Models;

public record SearchQuery
{
    public string? Terms { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? SortBy { get; set; }
    public bool? IsDescending { get; set; }
}