using BestFootForwardApi.Application.Shoes.Queries.GetShoes;
using BestFootForwardApi.Application.TodoLists.Queries.GetTodos;
using BestFootForwardApi.Domain.Entities;
using BestFootForwardApi.Domain.ValueObjects;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace BestFootForwardApi.Application.FunctionalTests.Shoes.Queries;

using static Testing;

public class GetShoesTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnShoes()
    {
        await RunAsDefaultUserAsync();

        var query = new GetShoesQuery();

        var result = await SendAsync(query);

        result.Items.Should().NotBeEmpty();
    }

    [Test]
    public async Task ShouldReturnAllListsAndItems()
    {
        await RunAsDefaultUserAsync();

        var manufacturer = new Manufacturer()
        {
            Name = "Better Shoes Ltd.",
            Address = new Address()
            {
                Address1 = "1 Paki Street",
                City = "Ngaruroro",
                PostCode = "1234",
                Country = "New Zealand"
            },
        };
        await AddAsync(manufacturer);

        await AddAsync(new Shoe
        {
            Name = "Mike Air",
            Colour = Colour.Blue,
            Description = "Best shoes ever",
            Size = 10,
            ManufacturerId = manufacturer.Id
        });

        var query = new GetShoesQuery();

        var result = await SendAsync(query);

        result.Items.Should().HaveCount(1);
        result.Items.First().ManufacturerId.Should().Be(manufacturer.Id);
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetShoesQuery();

        var action = () => SendAsync(query);

        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}