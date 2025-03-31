using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomaadminpanel.Models
{
    internal class OrderingResponse
    {
        public string? @default {  get; set; }
        public Dictionary<string, string>? choices { get; set; }
    }
}
