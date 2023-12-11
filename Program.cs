using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Radzen;
using RegistroCitas.Areas.Identity;
using RegistroCitas.Data;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

var emailSettings = new EmailSettings
{
    DisplayName = "Syncfusion Scheduler",
    Username = "CorreoProyecto92@outlook.com",
    Password = "Cproyecto-92",
    Port = 587,
    Host = "smtp.office365.com"
};

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var ConStr = builder.Configuration.GetConnectionString("ConStr");
var ConStr2 = builder.Configuration.GetConnectionString("ConStr2");
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(ConStr2));
builder.Services.AddDbContext<Context>(opt => opt.UseSqlite(ConStr));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddTransient<EmployeeBLL>();
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<NotificationService>();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk2MDIxMUAzMjMzMmUzMDJlMzBreEdpZjUzOWtSL1hXTE5FVHZoVklYeG02TE9laGFxRUxCSHlvK2s1SVJ3PQ==");

builder.Services.AddSingleton(emailSettings).AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
