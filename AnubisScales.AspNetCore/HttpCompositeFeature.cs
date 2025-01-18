using Microsoft.AspNetCore.Http;
using AnubisScales.AspNetCore;

namespace AnubisScales.AspNetCore;

public class HttpCompositeFeature(params IHttpFeature[] features) : IHttpFeature
{
	public bool IsMatch(HttpContext httpContext)
	{
		foreach (var feature in features)
			if (!feature.IsMatch(httpContext))
				return false;

		return true;
	}
}
