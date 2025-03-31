using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomaadminpanel.Models
{
    internal class HistoryElem
    {
        public int id {  get; set; }
        public DateTime datetime { get; set; }
        public string? initial_data { get; set; }
        public string? ip { get; set; }
        public string? result { get; set; }
        public string? msg { get; set; }
        public int? token { get; set; }
        public string? fingerprint { get; set; }
    }
}
