using AnubisScales;

namespace AnubisScales.Abstractions.UnitTests.Stubs;

internal class StubIdentityResolveProvider : IAuthorizationIdentityResolveProvider
{
	public IAsyncEnumerable<IAuthorizationIdentity> GetIdentitiesAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
