using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


Console.WriteLine(configuration.GetSection("constr").Value);

Console.ReadKey();