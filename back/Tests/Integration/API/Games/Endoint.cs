using Xunit;
using FluentAssertions;
using Application.DTOs;
using System.Net.Http.Json;
using System.Net;

namespace Tests.Integration.API.Games;

public class GameEndpointTests : IClassFixture<APIFactory>
{
    private readonly HttpClient httpClient;

    public GameEndpointTests(APIFactory factory)
    {
        httpClient = factory.CreateClient();

    }

    [Fact]
    [Trait("Category", "GameEndpoint")]
    public async Task Post_ShouldReturnOk()
    {
        CreateGameRequest createGameRequest = 
        new CreateGameRequest("Good of war", "Brabo", "");

        var response = await httpClient.PostAsJsonAsync("/games", createGameRequest);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}