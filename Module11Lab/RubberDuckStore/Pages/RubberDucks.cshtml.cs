using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace RubberDuckStore.Pages
{
    // This PageModel handles all four CRUD operations for our rubber
    // duck products: Read (already written, study this one first),
    // Create, Update, and Delete (you'll write these in Part 2).
    public class RubberDucksModel : PageModel
    {
        [BindProperty]
        public int SelectedDuckId { get; set; }

        public List<SelectListItem> DuckList { get; set; } = new();

        public Duck? SelectedDuck { get; set; }

        // READ: runs on every page load, and loads the dropdown list of
        // ducks so you always have something to pick from.
        public void OnGet()
        {
            LoadDuckList();
        }

        // READ: runs when someone picks a duck from the dropdown and
        // clicks Show Duck, then looks up that one duck's full details.
        public IActionResult OnPost()
        {
            LoadDuckList();
            if (SelectedDuckId != 0)
            {
                SelectedDuck = GetDuckById(SelectedDuckId);
            }
            return Page();
        }

        // TODO Step 8 (Part 2): Add an OnPostAdd handler here that reads
        // Name, Description, Price, and ImageFileName from the request
        // form and inserts a new row into the Ducks table.

        // TODO Step 9 (Part 2): Add an OnPostUpdatePrice handler here
        // that reads a duck ID and a new price from the request form
        // and updates that duck's Price column.

        // TODO Step 10 (Part 2): Add an OnPostDelete handler here that
        // reads a duck ID from the request form and deletes that row
        // from the Ducks table.

        // Helper method that loads every duck's ID and name from the
        // database, for the dropdown list. This is the READ pattern
        // you'll copy for your own queries in Part 2.
        private void LoadDuckList()
        {
            DuckList = new List<SelectListItem>();
            using (var connection = new SqliteConnection("Data Source=RubberDucks.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name FROM Ducks";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DuckList.Add(new SelectListItem
                        {
                            Value = reader.GetInt32(0).ToString(),
                            Text = reader.GetString(1)
                        });
                    }
                }
            }
        }

        // Helper method that retrieves one specific duck by its ID,
        // including all of its details.
        private Duck? GetDuckById(int id)
        {
            using (var connection = new SqliteConnection("Data Source=RubberDucks.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Ducks WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Duck
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            Price = reader.GetDecimal(3),
                            ImageFileName = reader.GetString(4)
                        };
                    }
                }
            }
            return null;
        }
    }

    // Simple model class representing a rubber duck product. Nothing to
    // add here, this part is just a data holder.
    public class Duck
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageFileName { get; set; } = string.Empty;
    }
}
