using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDatabaseCore
{
    public static class DBCreationHelper
    {
        private const string DB_HOST_EV = "DB_HOST";
        private const string DB_NAME_EV = "DB_NAME";
        private const string DB_PW_EV = "DB_SA_PASSWORD";

        public static string CreateUserDatabaseConnectionString()
        {
            var dbHost = Environment.GetEnvironmentVariable(DB_HOST_EV);
            var dbName = Environment.GetEnvironmentVariable(DB_NAME_EV);
            var dbPassword = Environment.GetEnvironmentVariable(DB_PW_EV);

            return $"Data Source={dbHost}; Initial Catalog={dbName};User ID=sa; Password={dbPassword}";
        }

    }
}

