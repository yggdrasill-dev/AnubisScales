namespace AnubisScales;

public interface IAuthorizationFunctionMatcher
{
	bool IsMatch(IAuthorizationFunction function);
}
