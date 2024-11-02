using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MobimentiNewVersion.Business.Abstract;
using MobimentiNewVersion.Business.Concrete;
using MobimentiNewVersion.Components;
using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.DataAccess.Context;
using MobimentiNewVersion.DataAccess.EntityFramework;
using MobimentiNewVersion.DataAccess.Repositories;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();

builder.Services.AddScoped<NotificationService>();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);



builder.Services.AddScoped<IAdminDal, EfAdminDal>();
builder.Services.AddScoped<IAppointmentDal, EfAppointmentDal>();
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ILicenceDal, EfLicenceDal>();
builder.Services.AddScoped<IMentorDal, EfMentorDal>();
builder.Services.AddScoped<IPackageDal, EfPackageDal>();
builder.Services.AddScoped<ISaleDal, EfSaleDal>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IMentorApplicationDal, EfMentorApplicationDal>();

//Business Katmaný
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IAuthenticateService, AuthenticationService>();
builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IAppointmentService, AppointmentManager>();
builder.Services.AddScoped<ILicenceService, LicenceManager>();
builder.Services.AddScoped<IMentorApplicationService, MentorApplicationManager>();
builder.Services.AddScoped<IMentorService, MentorManager>();
builder.Services.AddScoped<IPackageService, PackageManager>();
builder.Services.AddScoped<ISaleService, SaleManager>();

builder.Services.AddScoped<IAuthenticateService, AuthenticationService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
