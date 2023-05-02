using LearnAspNet.Controllers;
using LearnAspNet.Handler;
using LearnAspNet.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<ConfigModel>();
builder.Services
    .AddAuthentication(options=>{
        options.DefaultAuthenticateScheme = "forbidScheme";
        options.DefaultForbidScheme = "forbidScheme";
        options.AddScheme<MyAuthenticationHandler>("forbidScheme", "Handle Forbidden");
    });
builder.Services.AddSingleton(typeof(ProductService));
//builder.Services.AddTransient(typeof(ILogger<>),typeof(Logger<>)); da tu dong dang ky
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection(); // sẽ đưa ra mã phản hồi HTTP chuyển hướng từ http sang https
app.UseStaticFiles(); // link den file

app.UseRouting(); // route

app.UseAuthentication();//xac dinh danh tinh
app.UseAuthorization();//xac dinh quyen truy cap
app.UseEndpoints(
    (app) => {
        // URL : /{controller}/action}/{id}?
        app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"); //anh xa url cua controller

        app.MapRazorPages(); //truy cap den trang razor
});


app.Run();
