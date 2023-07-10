using App.Adapters;
using App.Models;

namespace App.UseCases
{
    [TransientService]
    public class GetAllDevCompanies
    {
        //injects objects of dependency classes through constructor
        private readonly DBAdapter _DBAdapter;
        public GetAllDevCompanies(DBAdapter dbAdapter)
        {
            _DBAdapter = dbAdapter;
        }

        public Task<IEnumerable<DevCompany>> Execute() => _DBAdapter.GetAllDevCompanies();

    }
}
