﻿using AnubisScales;

namespace AnubisScales;

public interface IAuthorizationSystem
{
	string Name { get; }

	ValueTask<bool> HasPermissionAsync(
		IAuthorizationFunction function,
		IAuthorizationIdentityResolveProvider identityResolver,
		CancellationToken cancellationToken = default);

	ValueTask<IAuthorizationFunction?> GetFunctionAsync(string functionName, CancellationToken cancellationToken = default);

	ValueTask<IAuthorizationFunction?> GetFunctionAsync(IAuthorizationFunctionMatcher functionMatcher, CancellationToken cancellationToken = default);
}
