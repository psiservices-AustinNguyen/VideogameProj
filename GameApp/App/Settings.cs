using Insight.Database;
using Microsoft.Extensions.Configuration;

namespace App
{
    public class Settings
    {
        //Sets up the connection string into an a connection object that can be passsed around

        //declares a public property named DatabaseConnectionString of type string (written as an auto property). The property has a getter(get;) and a private
        //setter(private set;), which means the value can be retrieved from outside the class but can only be set within the class
        //Makes it a readonly
        public string DatabaseConnectionString { get; private set; }

        //This is used to set up the sql connection throughout the program
        //Parameter is all the configurations from builder
        public Settings(IConfiguration configuration) 
        {
            //assigns the value of the connection string retrieved from the configuration to the DatabaseConnectionString property.It uses the
            //GetConnectionString method of the configuration object, passing the ConnectionStrings.Videogame
            //key to retrieve the corresponding connection string value.

            //DatabaseConnectionString = configuration.GetConnectionString(ConnectionStrings.Videogame);

            DatabaseConnectionString = configuration.GetConnectionString("VideogameDbConnection");
        }
        
    }
}
