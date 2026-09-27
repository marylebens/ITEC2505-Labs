// Program.cs is the entry point of every .NET app. This is the first
// code that runs when you type "dotnet run". For a Razor Pages web app,
// this file builds and configures the web server.

// WebApplication.CreateBuilder sets up a "builder" object that we use to
// configure services (like Razor Pages) before the app actually starts.
var builder = WebApplication.CreateBuilder(args);

// This line tells the app "we're building a Razor Pages application,"
// which turns on the features that let .cshtml and .cshtml.cs files work
// together as pages.
builder.Services.AddRazorPages();

// Build() takes everything we configured above and produces the actual
// running app object.
var app = builder.Build();

// The code below only runs when the app is NOT in development mode
// (for example, once it's deployed). It sends a friendly error page
// instead of a raw stack trace, and forces browsers to remember to use
// HTTPS next time.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Automatically redirects any plain http:// request to https://.
app.UseHttpsRedirection();

// Allows the app to serve files that live in the wwwroot folder, like
// CSS, JavaScript, and images, directly to the browser.
app.UseStaticFiles();

// Turns on the routing system, which is what matches an incoming browser
// request (like /Index) to the right Razor Page.
app.UseRouting();

// Turns on authorization checks. We aren't using login/permissions in
// this lab, but Razor Pages expects this to be here.
app.UseAuthorization();

// Tells the app "use the Pages folder to figure out which page to show."
app.MapRazorPages();

// Actually starts the web server and keeps it running until you press
// Ctrl+C in the terminal.
app.Run();
