// System.ComponentModel.DataAnnotations gives us validation attributes
// like [Required] and [Range]. Mvc gives us IActionResult, which lets a
// handler method return either "show this page again" or "go to another
// page."
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SignupModel : PageModel
{
    // TODO Step 3: Add the FullName, Email, and TicketCount properties
    // here, each with [BindProperty] and validation attributes,
    // following the instructions in the lab.

    // Runs when someone first visits the page. Nothing to do yet, the
    // form just needs to display.
    public void OnGet()
    {
    }

    // Runs when someone submits the form.
    public IActionResult OnPost()
    {
        // TODO Step 4: Check ModelState.IsValid here. If the form isn't
        // valid, show the page again. If it is, redirect to the
        // Confirmation page and pass along the data, following the
        // instructions in the lab.

        return Page();
    }
}
