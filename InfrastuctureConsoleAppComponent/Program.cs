

using ApplicationComponent;
using DomainComponent.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryComponent;

// Build the configuration
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Get the connection string from the configuration
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Create a service collection and configure the DbContext
var services  = new ServiceCollection();

// Register the DbContext with the connection string
services.AddDbContext<ItemsDBContext>(options =>
    options.UseSqlServer(connectionString));

// Register the repository and service
services.AddTransient<IRepository, ItemRepository>();
services.AddTransient<IService, ItemService>();


// Build the service provider
var serviceProvider = services.BuildServiceProvider();

// Resolve the service and use it
var itemService = serviceProvider.GetRequiredService<IService>();


// Example usage

while (true)
{


    Console.WriteLine("Seleccine una opcin");
    Console.WriteLine("1.- Agregar una tarea");
    Console.WriteLine("2.- Mostrar tareas");
    Console.WriteLine("3.- Salir");

    string option = Console.ReadLine(); 

    switch(option)
    {
        case "1":
            Console.WriteLine("Enter a title for the item:");
            var title = Console.ReadLine();
            await itemService.AddAsync(title);
            Console.WriteLine("Item added successfully!");
            break;


        case "2":
            var items = await itemService.GetAsync();
            Console.WriteLine("Oteniendo Tareas:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.Title} (Completed: {item.IsCompleted})");
            }
            break;

        case "3":
            Console.WriteLine("Exiting...");
            return;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;

    }



 
}
