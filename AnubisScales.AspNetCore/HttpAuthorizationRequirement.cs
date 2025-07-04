﻿using AnubisScales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AnubisScales.AspNetCore;

namespace AnubisScales.AspNetCore;

internal class HttpAuthorizationRequirement : AuthorizationHandler<HttpAuthorizationRequirement>, IAuthorizationRequirement
{
	protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, HttpAuthorizationRequirement requirement)
	{
		if (context.Resource is HttpContext httpContext)
		{
			var function = httpContext.Features.Get<IAuthorizationFunction>();
			var system = httpContext.RequestServices.GetRequiredService<IAuthorizationSystem>();
			var idResolver = httpContext.RequestServices.GetRequiredService<IAuthorizationIdentityResolveProvider>();

			if (function is null)
			{
				context.Fail(new AuthorizationFailureReason(this, "Can't found function data."));

				return;
			}

			if (await system.HasPermissionAsync(
				function,
				idResolver,
				httpContext.RequestAborted).ConfigureAwait(false))
				context.Succeed(requirement);
			else
				context.Fail(new AuthorizationFailureReason(this, "Access deny!"));
		}
	}
}
