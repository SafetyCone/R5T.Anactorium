using System;

using Microsoft.Extensions.Options;

using R5T.Knossos;
using R5T.Thermopylae;


namespace R5T.Anactorium
{
    public class DatabaseServerAuthenticationsConfigureOptions : IConfigureOptions<DatabaseServerAuthentications>
    {
        private IOptions<Raw.DatabaseServerAuthentications> RawDatabaseServerAuthentications { get; }


        public DatabaseServerAuthenticationsConfigureOptions(IOptions<Raw.DatabaseServerAuthentications> rawDatabaseServerAuthentications)
        {
            this.RawDatabaseServerAuthentications = rawDatabaseServerAuthentications;
        }

        public void Configure(DatabaseServerAuthentications options)
        {
            foreach (var rawAuthenticationByAuthenticationName in this.RawDatabaseServerAuthentications.Value.DatabaseServerAuthenticationsByAuthenticationName)
            {
                var authenticationName = new AuthenticationName(rawAuthenticationByAuthenticationName.Key);
                var databaseServerAuthentication = new DatabaseServerAuthentication()
                {
                    Name = authenticationName,
                    Username = new Username(rawAuthenticationByAuthenticationName.Value.Username),
                    Password = new Password(rawAuthenticationByAuthenticationName.Value.Password)
                };

                options.DatabaseServerAuthenticationsByAuthenticationName.Add(databaseServerAuthentication.Name, databaseServerAuthentication);
            }
        }
    }
}
