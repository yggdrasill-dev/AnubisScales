using AnubisScales;

namespace AnubisScales;

public interface IAuthorizationIdentityResolveProvider
{
	IAsyncEnumerable<IAuthorizationIdentity> GetIdentitiesAsync(CancellationToken cancellationToken = default);
}
