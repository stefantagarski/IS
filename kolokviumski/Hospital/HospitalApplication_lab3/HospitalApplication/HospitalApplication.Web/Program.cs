using Hos.Repository.Implementation;
using HospitalApplication.Domain.IdenitityModels;
using HospitalApplication.Repository.Data;
using HospitalApplication.Repository.Interface;
using HospitalApplication.Service.Implementation;
using HospitalApplication.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<HospitalApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IPatientDepartmentService, PatientDepartmentService>();
builder.Services.AddTransient<ITreatmentService, TreatmentService>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<ITransferRequestService, TransferRequestService>();

var app = builder.Build();

// TODO: Configure the Dependency Injection for the services, adding them as Transient objects
// TODO: Configure the Dependency Injection for the Repository, adding it as Scoped object



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
