using App.Adapters;
using App.Models;

namespace App.UseCases
{
    [TransientService]
    public class GetDevCompany
    {
        private readonly DBAdapter _DBAdapter;
        public GetDevCompany(DBAdapter dbAdapter)
        {
            _DBAdapter = dbAdapter;
        }
        public async Task<DevCompany> Execute(int DevCoId) => await _DBAdapter.GetDevCompany(DevCoId);
    }
}