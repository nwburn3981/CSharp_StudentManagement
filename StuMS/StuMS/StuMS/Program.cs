using Microsoft.EntityFrameworkCore;


using StuMS.Services;
using StuMS.Services.IService;

//Heres your Github practice Momo

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(StuMS.MappingConfig));

builder.Services.AddHttpClient<IStudentService, StudentService>();

builder.Services.AddScoped<IStudentService, StudentService>();

//Register repos for Dependency Injection


//TODO
//builder.Services.AddSwaggerGen();

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
    pattern: "{area=Student}/{controller=Home}/{action=Index}/{id?}");

app.Run();
