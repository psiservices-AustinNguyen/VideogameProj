using Insight.Database;
using Microsoft.Extensions.Configuration;

namespace App
{
    public class Settings
    {
        public string DatabaseConnectionString { get; private set; }
        //This is used to set up the sql connection throughout the program
        public Settings(IConfiguration configuration) 
        {
            DatabaseConnectionString = configuration.GetConnectionString(ConnectionStrings.Videogame);
        }
        
    }
}
