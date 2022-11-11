using Microsoft.Identity.Client;

namespace Onebrb.Maui.MsalClient;

public interface IPCAWrapper
{
    string[] Scopes { get; set; }
    Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes);
    Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes);
    Task SignOutAsync();
}
