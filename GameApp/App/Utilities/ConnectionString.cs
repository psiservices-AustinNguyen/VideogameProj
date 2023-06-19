namespace Insight.Database
{
    //This means that this class can be applied as an attribute in other classes
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DatabaseServiceAttribute : Attribute
    {
        public DatabaseServiceAttribute(string connectionString)
        {
            ConnectionString = connectionString;
        }
           public string ConnectionString { get; }
    }
    //In the future if there were other databases to connect to, they would be added here
    public sealed  class ConnectionStrings
    {
        public const string Videogame = "VideogameDbConnection";
    }
}
