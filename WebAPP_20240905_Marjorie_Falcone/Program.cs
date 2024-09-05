using Microsoft.AspNetCore.Server.IIS;
using WebAPP_20240905_Marjorie_Falcone.Services.Usuario;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddAuthentication(IISServerDefaults.AuthenticationScheme);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

//builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();

builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
