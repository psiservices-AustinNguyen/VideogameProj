using App.Adapters;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UseCases
{
    [TransientService]
    public class UpdateDevCo
    {
        private readonly DBAdapter _DBAdapter;
        public UpdateDevCo(DBAdapter dbAdapter)
        {
            _DBAdapter = dbAdapter;
        }
        public async Task Execute(int Id, DevCompany model) => await _DBAdapter.UpdateDevCo(Id, model);
    }
}