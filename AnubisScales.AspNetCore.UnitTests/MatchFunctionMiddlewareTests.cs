using Microsoft.AspNetCore.Http;

namespace AnubisScales.AspNetCore.UnitTests;

public class MatchFunctionMiddlewareTests
{
	[Fact]
	public async Task MatchFunctionMiddleware_使用ISystem來判斷要求是否有符合的Function()
	{
		// Arrange
		var fakeSystem = Substitute.For<IAuthorizationSystem>();
		var sut = new MatchFunctionMiddleware(fakeSystem);

		var httpContext = new DefaultHttpContext();

		var function = Substitute.For<IAuthorizationFunction>();
		_ = fakeSystem.GetFunctionAsync(Arg.Any<IAuthorizationFunctionMatcher>())
			.Returns(function);

		// Act
		await sut.InvokeAsync(httpContext, ctx => Task.CompletedTask);

		// Assert
		Assert.Equal(function, httpContext.Features.Get<IAuthorizationFunction>());
	}
}
