using _01_Framework.Application;
using BlogManagement.Infrastructure.Configuration;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("MarketDb");
builder.Services.AddTransient<IFileUploader, FileUploader>();
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
