using BestFootForwardApi.Application.Common.Exceptions;
using BestFootForwardApi.Application.Shoes.Commands.CreateShoe;
using BestFootForwardApi.Application.TodoLists.Commands.CreateTodoList;
using BestFootForwardApi.Domain.Entities;
using BestFootForwardApi.Domain.ValueObjects;

namespace BestFootForwardApi.Application.FunctionalTests.Shoes.Commands;

using static Testing;

public class CreateShoeTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateShoeCommand
        {
            Shoe = new Shoe()
            {
                Colour = Colour.Green,
                Name = "123456789012345678901234567890123456789012345678901234567890",
                Size = 10,
                ManufacturerId = new Guid()
            }
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateShoe()
    {
        var userId = await RunAsDefaultUserAsync();

        var shoe = new Shoe
        {
            Colour = Colour.Green,
            Name = "Test shoe",
            Size = 10,
            ManufacturerId = new Guid(), //todo: first create manufacturer.
            Description = "Bes shoe ever made",
            ImageUrl = "https://testimage"
        };
        
        var shoeId = await SendAsync(new CreateShoeCommand()
        {
            Shoe = shoe
        });

        var item = await FindAsync<Shoe>(shoeId);

        item.Should().NotBeNull();
        item!.Id.Should().Be(shoeId);
        item.Name.Should().Be(shoe.Name);
        item.CreatedBy.Should().Be(userId);
        item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}