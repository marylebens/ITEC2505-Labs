using Microsoft.AspNetCore.Mvc.RazorPages;

public class CustomersModel : PageModel
{
    public List<Customer> Customers { get; set; } = new();

    public void OnGet()
    {
        // TODO Step 7: Connect to the database with SqlConnection, run a
        // SELECT with SqlCommand, and read the rows with SqlDataReader
        // here, following the instructions in the lab.
    }
}

// This class is just a data holder, its properties map to columns in the
// Customers table. Nothing to add here.
public class Customer
{
    public string CustomerID { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string ContactName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
