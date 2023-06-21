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
    public class AddDevCo
    {
        private readonly DBAdapter _adapter;

        public AddDevCo(DBAdapter adapter)
        {
            _adapter = adapter;
        }

        public async Task Execute(DevCompany model)
        {
            await _adapter.AddDevCo(model);
        }
    }
}
