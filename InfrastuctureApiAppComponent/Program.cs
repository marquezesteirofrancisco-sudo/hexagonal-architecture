using Application_Component;
using ApplicationComponent;
using Domain_Component.Entities;
using Domain_Component.Interfaces;
using DomainComponent.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Get the connection string from the configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Register the DbContext with the connection string
builder.Services.AddDbContext<ItemsDBContext>(options =>
    options.UseSqlServer(connectionString));

// Register the repository and service
builder.Services.AddTransient<IRepository, ItemRepository>();
builder.Services.AddTransient<ICommonRepository<Note>, NoteRepository>();

builder.Services.AddTransient<IService, ItemService>();
builder.Services.AddTransient<ICommonService<Note>, NoteService>();

// Build the service provider
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/items", async (IService itemService) =>
{
    var items = await itemService.GetAsync();
    return Results.Ok(items);
}).WithName("Get Items");


app.MapPost("/items", async (string title, IService itemService) =>
{
    await itemService.AddAsync(title);
    return Results.Ok("Item added successfully!");
}).WithName("Post Items");



// Note endpoints
app.MapGet("/notes", async (ICommonService<Note> noteService) =>
{
    var notes = await noteService.GetAsync();
    return Results.Ok(notes);
}).WithName("Get Notes");

// Note endpoints
app.MapPost("/notes", async (int itemId, string message, ICommonService<Note> noteService) =>
{
    var note = new Note(0, itemId, message);
    await noteService.AddAsync(note);
    return Results.Ok("Note added successfully!");
}).WithName("Post Notes");

app.Run();
 