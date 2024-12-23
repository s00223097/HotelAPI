using HotelAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using HotelAPI.Validators;
using HotelAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Use Startup class
var startup = new Startup();
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();