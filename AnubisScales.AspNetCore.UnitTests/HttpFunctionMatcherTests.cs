﻿using AnubisScales;
using AnubisScales.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace AnubisScales.AspNetCore.UnitTests;

public class HttpFunctionMatcherTests
{
	[Fact]
	public void HttpFunctionMatcher_Function需要是HttpFunction並且使用IsMatch來判斷要求是否符合功能()
	{
		// Arrange
		var httpContext = new DefaultHttpContext();
		var sut = new HttpFunctionMatcher(httpContext);

		var fakeFeature = Substitute.For<IHttpFeature>();
		var function = new HttpFunction(Guid.NewGuid(), "Test", false, fakeFeature);

		_ = fakeFeature.IsMatch(Arg.Is(httpContext))
			.Returns(true);

		// Act
		var actual = sut.IsMatch(function);

		// Assert
		Assert.True(actual);
	}

	[Fact]
	public void HttpFunctionMatcher_Function不是HttpFunction則不符合()
	{
		// Arrange
		var httpContext = new DefaultHttpContext();
		var sut = new HttpFunctionMatcher(httpContext);

		var function = Substitute.For<IAuthorizationFunction>();

		// Act
		var actual = sut.IsMatch(function);

		// Assert
		Assert.False(actual);
	}
}