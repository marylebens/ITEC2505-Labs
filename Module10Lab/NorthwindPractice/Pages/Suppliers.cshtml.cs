// This page is already fully working. Read through it carefully in
// Part 1, since you'll build Categories.cshtml.cs yourself in Part 2
// by following this exact same pattern.
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

public class SuppliersModel : PageModel
{
    private readonly IConfiguration _configuration;

    public SuppliersModel(IConfiguration configuration)
    {
        // The connection string lives in appsettings.json, under
        // ConnectionStrings:Northwind. Getting it through IConfiguration
        // like this, instead of typing the string again in this file,
        // means you only have to update it in one place if it ever
        // changes.
        _configuration = configuration;
    }

    public List<Supplier> Suppliers { get; set; } = new();

    public void OnGet()
    {
        string connectionString = _configuration.GetConnectionString("Northwind")!;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT SupplierID, CompanyName, Country FROM Suppliers";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Suppliers.Add(new Supplier
                        {
                            SupplierID = reader.GetInt32(0),
                            CompanyName = reader.GetString(1),
                            Country = reader.GetString(2)
                        });
                    }
                }
            }
        }
    }
}

public class Supplier
{
    public int SupplierID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
