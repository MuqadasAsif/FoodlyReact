var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// Restaurant API ka address
builder.Services.AddHttpClient("RestaurantApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5184/");
});
builder.Services.AddHttpClient("OrderApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5269/");
});
builder.Services.AddHttpClient("MenuApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5245/");
});
builder.Services.AddHttpClient("DeliveryApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5018/");
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Restaurant}/{action=Index}/{id?}");

app.Run();