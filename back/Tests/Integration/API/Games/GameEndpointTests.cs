using Xunit;
using FluentAssertions;
using Application.DTOs;
using System.Net.Http.Json;
using System.Net;

namespace Tests.Integration.API.Games;

[Collection("Integration")]
public class GameEndpointTests 
{
    private IntegrationFixture integrationFixture;

    public GameEndpointTests(IntegrationFixture integrationFixture)
    {
        this.integrationFixture = integrationFixture;
    }

    [Fact]
    [Trait("Category", "GameEndpoint")]
    public async Task Post_ShouldReturnOk()
    {
        await integrationFixture.ResetDbAsync();


        CreateGameRequest createGameRequest = 
        new CreateGameRequest("Good of war", "Brabo", "");

        var response = await integrationFixture.Client.PostAsJsonAsync(
                        "/games", createGameRequest);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}