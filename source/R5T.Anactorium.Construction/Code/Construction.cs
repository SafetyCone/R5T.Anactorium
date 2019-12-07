using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using R5T.Thermopylae;


namespace R5T.Anactorium.Construction
{
    public static class Construction
    {
        public static void SubMain()
        {
            //Construction.TryGetServerAuthentications();
            //Construction.GetServerAuthentications();
            Construction.GetConfiguredServerAuthentications();
        }

        private static void GetConfiguredServerAuthentications()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(FileNames.ExampleAuthenticationsJsonFileName)
                .Build();

            var configurationSection = configuration.GetSection(nameof(Raw.DatabaseServerAuthentications));

            var serviceProvider = new ServiceCollection()
                .AddOptions()
                .Configure<Raw.DatabaseServerAuthentications>(configurationSection)
                .ConfigureOptions<DatabaseServerAuthenticationsConfigureOptions>()
                .BuildServiceProvider();

            var databaseServerAuthentications = serviceProvider.GetRequiredService<IOptions<DatabaseServerAuthentications>>();

            Console.WriteLine($"Username: {databaseServerAuthentications.Value.DatabaseServerAuthenticationsByAuthenticationName[new AuthenticationName("First")].Username}");
        }

        private static void GetServerAuthentications()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(FileNames.ExampleAuthenticationsJsonFileName)
                .Build();

            var databaseServerAuthentications = configuration.GetSection(nameof(Raw.DatabaseServerAuthentications)).Get<Raw.DatabaseServerAuthentications>();

            Console.WriteLine($"Username: {databaseServerAuthentications.DatabaseServerAuthenticationsByAuthenticationName["First"].Username}");
        }

        private static void TryGetServerAuthentications()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(FileNames.ExampleAuthenticationsJsonFileName)
                .Build();

            Console.WriteLine("---Configuration---");

            foreach (var keyValuePair in configuration.AsEnumerable())
            {
                Console.WriteLine($"{keyValuePair.Key}:{keyValuePair.Value}");
            }

            Console.WriteLine("---Configuration Section---");

            var configurationSection = configuration.GetSection(nameof(Raw.DatabaseServerAuthentications));

            foreach (var keyValuePair in configurationSection.AsEnumerable())
            {
                Console.WriteLine($"{keyValuePair.Key}:{keyValuePair.Value}");
            }

            var databaseServerAuthentications = new Raw.DatabaseServerAuthentications();

            configurationSection.Bind(databaseServerAuthentications);

            Console.WriteLine($"Username: {databaseServerAuthentications.DatabaseServerAuthenticationsByAuthenticationName["First"].Username}");
        }
    }
}
