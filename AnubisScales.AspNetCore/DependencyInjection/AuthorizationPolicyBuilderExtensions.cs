using Microsoft.AspNetCore.Authorization;
using AnubisScales.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class AuthorizationPolicyBuilderExtensions
{
	public static AuthorizationPolicyBuilder RequireHttpAuthorize(this AuthorizationPolicyBuilder builder)
	{
		builder.Requirements.Add(new HttpAuthorizationRequirement());

		return builder;
	}
}
