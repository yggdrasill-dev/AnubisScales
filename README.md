# AnubisScales

AnubisScales is a .NET library for handling authorization.

## Features

- Defines an abstraction layer for authorization behavior
- Implements Web API authorization handling behavior

## Installation

Install AnubisScales using NuGet:

## Usage

### 1. Register Services

In your `Program.cs` or `Startup.cs`, register AnubisScales services using the Fluent Builder pattern:

```csharp
builder.Services.AddAnubisScales("YourSystemName")
    .RegisterAuthorizationDataStore<YourAuthorizationDataStore>()
    .RegisterIdentityResolveProvider<YourIdentityProvider>();

builder.Services.AddWebApiAuthorizationMiddlewareResultHandler();
```

### 2. Implement Required Interfaces

You need to implement two interfaces:

**IAuthorizationDataStore** - Manages authorization data:
```csharp
public class YourAuthorizationDataStore : IAuthorizationDataStore
{
    public ValueTask<bool> CheckHasPermissionAsync(
        string systemName,
        IAuthorizationFunction function,
        IEnumerable<IAuthorizationIdentity> identities,
        CancellationToken cancellationToken = default)
    {
        // Your permission checking logic
    }

    public IAsyncEnumerable<IAuthorizationFunction> GetFunctionsAsync(
        string systemName,
        CancellationToken cancellationToken = default)
    {
        // Return all functions
    }

    public ValueTask<IAuthorizationFunction?> FindFunctionAsync(
        string systemName,
        string functionName,
        CancellationToken cancellationToken = default)
    {
        // Find function by name
    }
}
```

**IAuthorizationIdentityResolveProvider** - Resolves user identities:
```csharp
public class YourIdentityProvider : IAuthorizationIdentityResolveProvider
{
    public IAsyncEnumerable<IAuthorizationIdentity> GetIdentitiesAsync(
        CancellationToken cancellationToken = default)
    {
        // Return current user's identities
    }
}
```

### 3. Define HTTP Functions

Create authorization functions for your API endpoints:

```csharp
var getUserFunction = new HttpFunction(
    Guid.NewGuid(),
    "GetUser",
    allowAnonymous: false,
    new HttpMethodFeature("GET"),
    new HttpPathFeature("/api/users/{id:int}", serviceProvider)
);
```

## License

This project is licensed under the MIT License. For more details, please refer to the [LICENSE](LICENSE) file.