using Microsoft.AspNetCore.Http;

namespace AnubisScales.AspNetCore;

internal class HttpFunctionMatcher(HttpContext context) : IAuthorizationFunctionMatcher
{
	public bool IsMatch(IAuthorizationFunction function)
		=> function is HttpFunction httpFunction
			&& httpFunction.IsMatch(context);
}
