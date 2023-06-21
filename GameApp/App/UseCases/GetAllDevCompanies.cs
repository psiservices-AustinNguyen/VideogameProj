using App.Adapters;
using App.Models;

namespace App.UseCases
{
    [TransientService]
    public class GetAllDevCompanies
    {
        private readonly DBAdapter _DBAdapter;
        public GetAllDevCompanies(DBAdapter dbAdapter)
        {
            _DBAdapter = dbAdapter;
        }

        public Task<IEnumerable<DevCompany>> Execute() => _DBAdapter.GetAllDevCompanies();

    }
}
