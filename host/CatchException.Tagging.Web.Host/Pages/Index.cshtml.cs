using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace CatchException.Tagging.Pages;

public class IndexModel : TaggingPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
