using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomaadminpanel.Models
{
    internal class TokenInfo
    {
        public int id { get; set; }
        public required string fingerprint { get; set; }

        public override string ToString()
        {
            return $"{fingerprint}";
        }

    }
}
