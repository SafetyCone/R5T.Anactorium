using System;
using System.Collections.Generic;

using R5T.Knossos;
using R5T.Thermopylae;


namespace R5T.Anactorium
{
    public class DatabaseServerAuthentications
    {
        public Dictionary<AuthenticationName, DatabaseServerAuthentication> DatabaseServerAuthenticationsByAuthenticationName { get; set; } = new Dictionary<AuthenticationName, DatabaseServerAuthentication>();
    }
}
