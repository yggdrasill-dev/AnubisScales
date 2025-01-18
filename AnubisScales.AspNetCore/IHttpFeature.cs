using Microsoft.AspNetCore.Http;

namespace AnubisScales.AspNetCore;

public interface IHttpFeature
{
	bool IsMatch(HttpContext httpContext);
}
