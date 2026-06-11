namespace EbaDemoAgents.Tests;

public class StarterServiceTests
{
    [Fact]
    public void GetGreeting_ReturnsExpectedMessage()
    {
        var service = new StarterService();

        var result = service.GetGreeting();

        Assert.Equal("Hello from .NET 10 starter project!", result);
    }
}
