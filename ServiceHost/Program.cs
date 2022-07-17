using BlogManagement.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("MarketDb");
BlogManagementBootstrapper.Configure(builder.Services,connectionString);





var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});
app.Run();
