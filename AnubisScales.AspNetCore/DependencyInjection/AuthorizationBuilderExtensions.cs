using AnubisScales.AspNetCore;
using Microsoft.AspNetCore.Authorization;

namespace Microsoft.Extensions.DependencyInjection;

public static class AuthorizationBuilderExtensions
{
	public static AuthorizationBuilder AddHttpFallbackPolicy(this AuthorizationBuilder builder)
		=> builder.AddFallbackPolicy(
			"HttpFallback",
			new AuthorizationPolicyBuilder()
				.AddRequirements(new HttpAuthorizationRequirement())
				.Build());
}
