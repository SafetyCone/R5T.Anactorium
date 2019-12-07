using System;
using System.Collections.Generic;

using R5T.Thermopylae;


namespace R5T.Anactorium.Raw
{
    public class DatabaseServerAuthentications
    {
        public Dictionary<string, BasicAuthentication> DatabaseServerAuthenticationsByAuthenticationName { get; set; } = new Dictionary<string, BasicAuthentication>();
    }
}
