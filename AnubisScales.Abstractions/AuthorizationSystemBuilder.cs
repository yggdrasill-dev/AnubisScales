using Microsoft.Extensions.DependencyInjection;

namespace AnubisScales;

public class AuthorizationSystemBuilder
{
	internal AuthorizationSystemBuilder(IServiceCollection services)
	{
		Services = services;
	}

	public IServiceCollection Services { get; }

	public AuthorizationSystemBuilder RegisterIdentityResolveProvider<TIdentityResolveProvider>()
		where TIdentityResolveProvider : class, IAuthorizationIdentityResolveProvider
	{
		Services.AddScoped<IAuthorizationIdentityResolveProvider, TIdentityResolveProvider>();

		return this;
	}

	public AuthorizationSystemBuilder RegisterAuthorizationDataStore<TAuthorizationDataStore>()
		where TAuthorizationDataStore : class, IAuthorizationDataStore
	{
		Services.AddSingleton<IAuthorizationDataStore, TAuthorizationDataStore>();

		return this;
	}
}