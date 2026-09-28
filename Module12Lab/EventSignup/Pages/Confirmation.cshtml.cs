using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ConfirmationModel : PageModel
{
    // SupportsGet = true tells Razor Pages to fill these properties from
    // the URL's query string (the part after the ?) on a GET request.
    // That's how the data the Signup page redirected with arrives here.
    [BindProperty(SupportsGet = true)]
    public string FullName { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)]
    public string Email { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)]
    public int TicketCount { get; set; }

    public void OnGet()
    {
    }
}
