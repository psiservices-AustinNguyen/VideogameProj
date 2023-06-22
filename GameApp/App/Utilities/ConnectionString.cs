namespace Insight.Database
{
    //This means that this class can be applied as an attribute in other classes
    [AttributeUsage(AttributeTargets.Class)]
    //sealed (cannot be inherited) class that inherits from Attribute class
    public sealed class DatabaseServiceAttribute : Attribute
    {
        public string ConnectionString { get; }

        public DatabaseServiceAttribute(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
    //In the future if there were other databases to connect to, they would be added here
    //public sealed class ConnectionStrings
    //{
    //    public const string Videogame = "VideogameDbConnection";
    //}
}
