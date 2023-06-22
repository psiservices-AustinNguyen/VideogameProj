using App.Models;
using Insight.Database;

namespace App.Adapters
{
    //[DatabaseService(ConnectionStrings.Videogame)]
    [DatabaseService("VideogameDbConnection")]
    public abstract class DBAdapter
    {
        [Sql("Get_DevCompanyList", Schema = "dbo")]
        public abstract Task<IEnumerable<DevCompany>> GetAllDevCompanies();

        [Sql("Get_DevCompany", Schema = "dbo")]
        public abstract Task<DevCompany> GetDevCompany(int DevCoId);

        [Sql("Add_DevCompany", Schema = "dbo")]
        public abstract Task AddDevCo(DevCompany model);

        [Sql("Delete_DevCompany", Schema = "dbo")]
        public abstract Task DeleteDevCo(int DevCoId);

        [Sql("Update_DevCompany", Schema = "dbo")]
        public abstract Task UpdateDevCo(int DevCoId, DevCompany model);
    }
}
