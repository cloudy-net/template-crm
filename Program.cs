using CrmApplication.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

    context.Companies.Add(new Company { Id = new Guid("042f0213-6e95-4b23-b924-e43bb51c219d"), Name = "IBM" });
    context.Companies.Add(new Company { Id = new Guid("51e36eda-12ce-41f7-893e-4a475a2b7116"), Name = "HP" });

    context.Customers.Add(new Customer { Id = new Guid("8e4c70f8-a37a-4566-821c-aa30c9e05563"), Name = "John Doe", CompanyId = new Guid("042f0213-6e95-4b23-b924-e43bb51c219d") });
    context.Customers.Add(new Customer { Id = new Guid("bfdacf55-19a0-4f5b-b9c8-4e48cb4f42f5"), Name = "Jane Doe", CompanyId = new Guid("042f0213-6e95-4b23-b924-e43bb51c219d") });
    context.Customers.Add(new Customer { Id = new Guid("c7c1a10d-51b6-4e25-8305-fe4a8b67a568"), Name = "James Boe", CompanyId = new Guid("51e36eda-12ce-41f7-893e-4a475a2b7116") });

    context.SaveChanges();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions().MustValidate());

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.MapGet("/", async c => c.Response.Redirect("/Admin"));
});

app.Run();
