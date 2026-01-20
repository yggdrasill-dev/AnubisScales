using AnubisScales.Abstractions.UnitTests.Stubs;
using Microsoft.Extensions.DependencyInjection;

namespace AnubisScales.Abstractions.UnitTests;

public class DependencyInjectionTests
{
    [Fact]
    public void DI註冊測試()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddAnubisScales("Test")
            .RegisterAuthorizationDataStore<StubAuthorizationDataStore>()
            .RegisterIdentityResolveProvider<StubIdentityResolveProvider>()
            .Services;

        var sut = services.BuildServiceProvider(true);

        // Act
        var actual = sut.GetRequiredService<IAuthorizationSystem>();

        // Assert
        Assert.NotNull(actual);
    }
}