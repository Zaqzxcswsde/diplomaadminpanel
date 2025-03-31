using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomaadminpanel.Models
{
    internal class UserInfo
    {
        public string uuid { get; set; } = null!;
        public string? token { get; set; }
        public string? fingerprint { get; set; }
        public string? additional_data { get; set; }
        public DateTime? last_login { get; set; }
        public DateTime? created { get; set; }
    }
}