using Insight.Database;
using Microsoft.Data.SqlClient;

namespace App.Utils
{
    public static class DbAdapterFactory
    {
        //takes a connection string as input and creates a SqlConnectionStringBuilder object with the provided connection string.
        //It then calls the As<T> method from Insight.Database on the SqlConnectionStringBuilder object,
        //which creates and returns a connection object of type T.
        public static T GetConnectionAs<T>(string connectionString) where T : class
        {
            return new SqlConnectionStringBuilder(connectionString).As<T>();
        }

        //Constructor
        static DbAdapterFactory()
        {
            SqlInsightDbProvider.RegisterProvider();
            
        }
    }
}
