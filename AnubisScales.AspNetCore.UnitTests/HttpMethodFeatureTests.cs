﻿using AnubisScales.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace AnubisScales.AspNetCore.UnitTests;

public class HttpMethodFeatureTests
{
	[Fact]
	public void HttpMethodFeature_Http要求的Method符合設定IsMatch回傳為True()
	{
		// Arrange
		var sut = new HttpMethodFeature("Get");

		var httpContext = new DefaultHttpContext();
		httpContext.Request.Method = "GET";

		// Act
		var actual = sut.IsMatch(httpContext);

		// Assert
		Assert.True(actual);
	}

	[Fact]
	public void HttpMethodFeature_Http要求的Method不符合設定IsMatch回傳為False()
	{
		// Arrange
		var sut = new HttpMethodFeature("Put", "Post", "Delete");

		var httpContext = new DefaultHttpContext();
		httpContext.Request.Method = "GET";

		// Act
		var actual = sut.IsMatch(httpContext);

		// Assert
		Assert.False(actual);
	}
}
