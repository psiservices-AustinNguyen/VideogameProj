using App.Models;
using Insight.Database;


namespace App.Adapters
{
    [DatabaseService(ConnectionStrings.VideogameConnection)]
    public abstract class DBAdapter
    {
        [Sql("Get_DevCompanies", Schema = "dbo")]
        public abstract Task<IEnumerable<DevCompany>> GetAllDevCompanies();
    }
}
