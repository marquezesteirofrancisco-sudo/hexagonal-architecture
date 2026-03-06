using Application_Component;
using Application_RepositoryComponent.Models;
using ApplicationComponent;
using ApplicationComponent.DTOs;
using ApplicationRepositoryComponent;
using Domain_Component.Entities;
using Domain_Component.Interfaces;
using DomainComponent.Interfaces;
using InfrastructureRepositoryComponent.ExtraData;
using InfrastructureRepositoryComponent.Factories;
using MapperComponent;
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


// DTO
builder.Services.AddTransient<ICommonRepository<NoteDTO>, NoteDTORepository>();
builder.Services.AddTransient<ICommonService<NoteDTO>, NoteDTOService>();

// Mappers
builder.Services.AddTransient <IAddRepository<NoteModel>, NoteMapperRepository>();
builder.Services.AddTransient <IMapper<NoteDTO, Note>, NoteEntityMapper>();
builder.Services.AddTransient <IMapper<NoteDTO, NoteModel>, NoteModelMapper>();
builder.Services.AddTransient <IAddService<NoteDTO, NoteModel>, NoteMapperService<NoteDTO, NoteModel>>();

// Fabrica
builder.Services.AddTransient<IRepositoryFactory<IAddRepository<Note>, NoteExtraData>, NoteRepositoryFactory>();
builder.Services.AddTransient<IMapper<NoteDTO, NoteExtraData> , NoteExtraDataMapper>();
builder.Services.AddTransient<IAddService<NoteDTO, NoteExtraData>, NoteWithFactoryService<NoteDTO, NoteExtraData>>();


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


// DTO
app.MapGet("/notesDto", async (ICommonService<NoteDTO> service) =>
{
    return await service.GetAsync();

}).WithName("Get Note DTO");


app.MapPost("/notesDto", async (NoteDTO dto, ICommonService<NoteDTO> service ) =>
{
    await service.AddAsync(dto);
    return Results.Created();

}).WithName("Post Note DTO");


// end point de los mappers

app.MapPost("/notemapper", async (NoteDTO note, IAddService<NoteDTO, NoteModel> service) =>
{
    await service.AddAsync(note);
    return Results.Created();

}).WithName("Get Note Mapper");



app.MapPost("/notefactory", async (NoteDTO note, IAddService<NoteDTO, NoteExtraData> service) =>
{
    await service.AddAsync(note);
    return Results.Created();

}).WithName("Post Note Factory");


app.Run();
 