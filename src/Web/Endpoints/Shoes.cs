using BestFootForwardApi.Application.Common.Models;
using BestFootForwardApi.Application.Shoes.Commands.CreateShoe;
using BestFootForwardApi.Application.Shoes.Common.Dtos;
using BestFootForwardApi.Application.Shoes.Queries.GetShoes;

namespace BestFootForwardApi.Web.Endpoints;

public class Shoes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetShoes)
            .MapPost(CreateShoe);
    }

    public async Task<PaginatedList<ShoeDto>> GetShoes(ISender sender, [AsParameters]GetShoesQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Guid> CreateShoe(ISender sender, CreateShoeCommand command)
    {
        return await sender.Send(command);
    }
}
