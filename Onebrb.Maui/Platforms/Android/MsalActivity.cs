
using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace Onebrb.Maui.Platforms.Android
{
    [Activity(Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
        DataHost = "auth",
        DataScheme = "msal27f86fae-10ee-4a94-b534-49454bdfc470")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}
