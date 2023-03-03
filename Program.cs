using CrmApplication.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCloudy(cloudy => cloudy
    .AddAdmin(admin => admin.Unprotect())   // NOTE: Admin UI will be publicly available!
    .AddAzureMediaPicker()
    .AddContext<MyContext>()                // Adds EF Core context with your content types
);

builder.Services.AddDbContext<MyContext>(options => options
    .UseInMemoryDatabase("cloudytest")
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// seed with some data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<MyContext>();

    context.Companies.Add(new Company { Id = 1, Name = "IBM", Image = "https://cloudytest.blob.core.windows.net/media/logos/ibm.png" });
    context.Companies.Add(new Company { Id = 2, Name = "HP", Image = "https://cloudytest.blob.core.windows.net/media/logos/hp.png" });

    context.Customers.Add(new Person { Id = 11, Name = "John Doe", CompanyId = 1 });
    context.Customers.Add(new Person { Id = 12, Name = "Jane Doe", CompanyId = 1 });
    context.Customers.Add(new Person { Id = 13, Name = "James Boe", CompanyId = 2 });

    context.SaveChanges();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions().MustValidate());

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapGet("/", async c => c.Response.Redirect("/Admin"));

app.Run();
