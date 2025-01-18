using Microsoft.AspNetCore.Routing.Constraints;

namespace AnubisScales.AspNetCore;

public class HttpMethodFeature(params string[] httpMethods) : IHttpFeature
{
	private readonly HttpMethodRouteConstraint m_Constraint = new(httpMethods);

	public bool IsMatch(HttpContext httpContext)
		=> m_Constraint.Match(
			httpContext,
			null,
			string.Empty,
			[],
			RouteDirection.IncomingRequest);
}
