using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class DevCompany
    {
        public int DevCoId { get; set; }
        public string? DevName { get; set; }
        public string? DevAddress { get; set; }
        public DateTime? FoundedDate { get; set; }
        public string? MostPopularGame { get; set;}
    }
}
