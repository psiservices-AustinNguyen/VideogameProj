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
    public class DeleteDevCo
    {
        private readonly DBAdapter _DBAdapter;
        public DeleteDevCo(DBAdapter dbAdapter)
        {
            _DBAdapter = dbAdapter;
        }
        public async Task Execute(int Id) => await _DBAdapter.DeleteDevCo(Id);
    }
}
