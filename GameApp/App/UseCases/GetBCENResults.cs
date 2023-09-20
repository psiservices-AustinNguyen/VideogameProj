using App.Adapters;
using App.Models;

namespace App.UseCases
{
    [TransientService]
    public class GetBCENResults
    {
        //injects objects of dependency classes through constructor
        private readonly DBAdapter _DBAdapter;
        public GetBCENResults(DBAdapter dbAdapter)
        {
            _DBAdapter = dbAdapter;
        }

        public Task<BcenModel> Execute() => _DBAdapter.GetBCENResults();

    }
}
