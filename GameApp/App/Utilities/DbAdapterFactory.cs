using Insight.Database;
using Microsoft.Data.SqlClient;

namespace App.Utils
{
    public static class DbAdapterFactory
    {

        //This method returns a generic type T
        //T inherits from class
        //" where T : class" ensures its a reference type?
        public static T GetConnectionAs<T>(string connectionString) where T : class
        {
            //takes a connection string from parameter and creates a SqlConnectionStringBuilder object with the provided connection string.
            //It then calls the As<T> method from Insight.Database on the SqlConnectionStringBuilder object,
            //which creates and returns a connection object of type T.
            return new SqlConnectionStringBuilder(connectionString).As<T>();
        }

        //Constructor that is used to register the SQL Server provider for Insight.Database,
        //which allows Insight.Database to interact with SQL Server databases.
        static DbAdapterFactory()
        {
            SqlInsightDbProvider.RegisterProvider();
            
        }
    }
}
