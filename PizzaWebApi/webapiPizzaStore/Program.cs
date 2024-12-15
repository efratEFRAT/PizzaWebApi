using MyS;
using MyModelse;
using MyModelse.Interface;
using FireService;
using FireService.Interfaces;
using תשתית_לניהול_חנות_פיצה_חני_גולדברג.middleware;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.WebHost.UseUrls("http://localhost:5190");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

 builder.Services.AddSingleton<IFireService<string>>(new ReadWrite<string>(@"C:\Users\USER\Desktop\webapi\LESSON6_1\PizzaWebApi\PizzaWebApi\middlewere.txt"));
builder.Services.AddSingleton<IpizzaMannager,ChanisPizzaServices>();
builder.Services.AddTransient<IorderManager,OrderService>();
builder.Services.AddScoped<IworkerManager,workerService>();
 builder.Services.AddSingleton<IFireService<ChanisPizza>>(new ReadWrite<ChanisPizza>(@"C:\Users\USER\Desktop\webapi\LESSON6_1\PizzaWebApi\PizzaWebApi\file.json"));
builder.Services.AddControllersWithViews();

builder.Services.AddProblemDetails();

var app = builder.Build();

// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/error");
// }
 app.UseExceptionHandler(o => {});
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
// app.UseExceptionHandler();
 app.UseDefaultFiles();
 app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
 app.MapFallbackToFile("/index.html");
 app.UseCustom();
app.Run();


