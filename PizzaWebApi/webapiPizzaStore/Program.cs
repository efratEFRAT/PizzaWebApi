using webapiPizzaStore;
using MyS;
using MyModelse;
using MyModelse.Interface;
using FireService;
using FireService.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSingleton<IFireService<ChanisPizza>,ReadWrite<ChanisPizza>>();
builder.Services.AddSingleton<IpizzaMannager,ChanisPizzaServices>();
builder.Services.AddTransient<IorderManager,OrderService>();
builder.Services.AddScoped<IworkerManager,workerService>();
builder.Services.AddSingleton<IFireService<ChanisPizza>>(new ReadWrite<ChanisPizza>(@"L:\webAPI\הגשות\lesson6\תמי שיקוביצקי ואפרת מרקוביץ\PizzaWebApi\PizzaWebApi\file.json"));

builder.Services.AddProblemDetails();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}
 app.UseExceptionHandler(o => {});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
// app.UseDefaultFiles();
// app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// app.MapFallbackToFile("/index.html");
app.Run();


