using System.Net.Http.Json;
using System.Security.Claims;

namespace REP.Web.Services;

public class UserBootstrapService
{
    private bool _initialized = false;

    public async Task EnsureInitializedAsync(ClaimsPrincipal user, HttpClient http)
    {
        if (_initialized || !user.Identity!.IsAuthenticated)
            return;

        _initialized = true;

        var userId = user.FindFirst("sub")?.Value
                     ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        await http.PostAsJsonAsync("api/users/bootstrap", new
        {
            UserId = userId,
            Email = user.Identity.Name
        });
    }
}
