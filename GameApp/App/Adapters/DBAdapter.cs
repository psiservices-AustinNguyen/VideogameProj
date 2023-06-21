﻿using App.Models;
using Insight.Database;


namespace App.Adapters
{
    [DatabaseService(ConnectionStrings.Videogame)]
    public abstract class DBAdapter
    {
        [Sql("Get_DevCompanies", Schema = "dbo")]
        public abstract Task<IEnumerable<DevCompany>> GetAllDevCompanies();

        [Sql("Add_DevCompany", Schema = "dbo")]
        public abstract Task AddDevCo(DevCompany model);
    }
}
