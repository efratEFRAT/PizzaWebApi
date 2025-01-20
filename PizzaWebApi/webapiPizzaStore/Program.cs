using MyS;
using MyModelse;
using MyModelse.Interface;
using FireService;
using FireService.Interfaces;
using  Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Login;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// builder.WebHost.UseUrls("http://localhost:5190");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFireService<string>>(new ReadWrite<string>(@"C:\Users\USER\Desktop\webapi\LESSON6_1\PizzaWebApi\PizzaWebApi\middlewere.txt"));
builder.Services.AddSingleton<IpizzaMannager,ChanisPizzaServices>();
builder.Services.AddTransient<IorderManager,OrderService>();
builder.Services.AddScoped<IworkerManager,workerService>();
 builder.Services.AddSingleton<IFireService<ChanisPizza>>(new ReadWrite<ChanisPizza>(@"C:\Users\USER\Desktop\webapi\LESSON6_1\PizzaWebApi\PizzaWebApi\file.json"));
builder.Services.AddSingleton<IFireService<Order>>(new ReadWrite<Order>(@"C:\Users\USER\Desktop\webapi\LESSON6_1\PizzaWebApi\PizzaWebApi\bill.json"));
builder.Services.AddSingleton<IFireService<Worker>>(new ReadWrite<Worker>(@"C:\Users\USER\Desktop\webapi\LESSON6_1\PizzaWebApi\PizzaWebApi\worker.json"));
builder.Services.AddScoped<Ilogin,loginService>();

// builder.Services.AddControllersWithViews();
builder.Services
              .AddAuthentication(options =>
              {
                  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(cfg =>
              {
                  cfg.RequireHttpsMetadata = false;
                  cfg.TokenValidationParameters = LoginToken.GetTokenValidationParameters();
              });

        builder.Services.AddAuthorization(cfg =>
        {
            cfg.AddPolicy("Admin", policy => policy.RequireClaim("role", "Admin"));
            cfg.AddPolicy("superWorker", policy => policy.RequireClaim("role", "superWorker"));

        });


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "pizza", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        { new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
            new string[] {}
        }
    });
});

builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else{
     app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseExceptionHandler();
 app.UseDefaultFiles();
 app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();



app.MapControllers();
//  app.MapFallbackToFile("/index.html");
//  app.UseCustom();
app.Run();


