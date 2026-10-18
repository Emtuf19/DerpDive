using DeepDive.Services;
using System.Net;
using System.Text;

namespace DeepDiveTest;

[TestClass]
public class APITest
{
    [TestMethod]
    public async Task GetLocationAsync_ReturnsCoordinatesForValidCity()
    {
        // Arrange
        var json = """
        [
            {
                "name": "Odense",
                "country": "DK",
                "latitude": 55.3997,
                "longitude": 10.3852
            }
        ]
        """;

        var factory = CreateFactory("GeocodingClient", json);
        var service = new CompleteWeatherService(factory);

        // Act
        var result = await service.GetLocationAsync("Odense");

        // Assert
        Assert.AreEqual("Odense", result.Name);
        Assert.AreEqual("DK", result.Country);
        Assert.AreEqual(55.3997, result.Latitude, 0.001);
        Assert.AreEqual(10.3852, result.Longitude, 0.001);
    }

    [TestMethod]
    public async Task GetWeatherAsync_ReturnsWeatherData()
    {
        // Arrange
        var json = """
        {
            "current": {
                "temperature_2m": 18.5,
                "rain": 0.2,
                "wind_speed_10m": 12.0,
                "weather_code": 2
            }
        }
        """;

        var factory = CreateFactory("WeatherClient", json);
        var service = new CompleteWeatherService(factory);

        // Act
        var result = await service.GetWeatherAsync(55.3997, 10.3852);

        // Assert
        Assert.AreEqual(18.5, result.Current.Temperature);
        Assert.AreEqual(0.2, result.Current.Rain);
        Assert.AreEqual(12.0, result.Current.WindSpeed);
        Assert.AreEqual(2, result.Current.WeatherCode);
    }

    [TestMethod]
    public async Task GetMarineWeatherAsync_ReturnsMarineData()
    {
        // Arrange
        var json = """
        {
            "current": {
                "wave_height": 0.8,
                "sea_surface_temperature": 16.4
            }
        }
        """;

        var factory = CreateFactory("MarineClient", json);
        var service = new CompleteWeatherService(factory);

        // Act
        var result = await service.GetMarineWeatherAsync(55.3997, 10.3852);

        // Assert
        Assert.AreEqual(0.8, result.Current.WaveHeight);
        Assert.AreEqual(16.4, result.Current.SeaSurfaceTemperature);
    }

    [TestMethod]
    public async Task GetLocationAsync_ThrowsExceptionWhenApiFails()
    {
        // Arrange
        var json = """{"error": "Internal Server Error"}""";

        // TODO: Opret en factory, der returnerer HTTP 500.
        // Brug din eksisterende TestHttpClientFactory og
        // StubHttpMessageHandler.
        var factory = new TestHttpClientFactory(name =>
        {
            if (name != "GeocodingClient")
            {
                throw new InvalidOperationException(
                    $"Forkert HTTP-klient: {name}");
            }
            return new StubHttpMessageHandler((request, _) =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(
                        json, Encoding.UTF8, "application/json")
                };
                return Task.FromResult(response);
            });
        });

        // TODO: Opret CompleteWeatherService med factory.
        var service = new CompleteWeatherService(factory);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(
            async () => await service.GetLocationAsync("Odense"));

        Assert.Contains("Internal Server Error", exception.Message);
        Assert.Contains("Geocoding API fejl", exception.Message);
    }

    private static IHttpClientFactory CreateFactory(
        string expectedClientName, string json)
    {
        return new TestHttpClientFactory(name =>
        {
            if (name != expectedClientName)
            {
                throw new InvalidOperationException(
                    $"Forkert HTTP-klient: {name}");
            }

            return new StubHttpMessageHandler((request, _) =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        json, Encoding.UTF8, "application/json")
                };

                return Task.FromResult(response);
            });
        });
    }
}

internal sealed class TestHttpClientFactory : IHttpClientFactory
{
    private readonly Func<string, HttpMessageHandler> _handlerFactory;

    public TestHttpClientFactory(
        Func<string, HttpMessageHandler> handlerFactory)
    {
        _handlerFactory = handlerFactory;
    }

    public HttpClient CreateClient(string name)
    {
        return new HttpClient(_handlerFactory(name))
        {
            BaseAddress = new Uri("https://example.test/")
        };
    }
}

internal sealed class StubHttpMessageHandler : HttpMessageHandler
{
    private readonly Func<
        HttpRequestMessage,
        CancellationToken,
        Task<HttpResponseMessage>> _responseFactory;

    public StubHttpMessageHandler(
        Func<HttpRequestMessage, CancellationToken,
            Task<HttpResponseMessage>> responseFactory)
    {
        _responseFactory = responseFactory;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return _responseFactory(request, cancellationToken);
    }
}
