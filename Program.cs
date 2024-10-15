using APIHelperModule;
using CurrencyConverterHelper;
using NewsFeederHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAPIHelper, APIHelper>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<CurrencyConverter>();
builder.Services.AddScoped<NewsFeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/MultiPurpose/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MultiPurpose}/{action=Index}/{id?}");

app.Run();
