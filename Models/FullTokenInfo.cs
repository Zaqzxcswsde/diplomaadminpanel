using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomaadminpanel.Models
{
    internal class FullTokenInfo
    {
        public int id { get; set; }
        public string? fingerprint { get; set; }
        public string? pubkey { get; set; }
        public bool is_active { get; set; }
        public bool can_reset_password { get; set; }
        public DateTime last_activated { get; set; }
        public string? allowed_ips { get; set; }
        public string? user { get; set; }
        public string? user_additional_data { get; set; }
        public DateTime? user_last_login { get; set; }

        public FullTokenInfo Clone()
        {
            return new FullTokenInfo
            {
                id = this.id,
                fingerprint = this.fingerprint,
                pubkey = this.pubkey,
                is_active = this.is_active,
                can_reset_password = this.can_reset_password,
                last_activated = this.last_activated,
                allowed_ips = this.allowed_ips,
                user = this.user,
                user_additional_data = this.user_additional_data,
                user_last_login = this.user_last_login
            };
        }

        public void CopyFrom(FullTokenInfo from)
        {
            this.id = from.id;
            this.fingerprint = from.fingerprint;
            this.pubkey = from.pubkey;
            this.is_active = from.is_active;
            this.can_reset_password = from.can_reset_password;
            this.last_activated = from.last_activated;
            this.allowed_ips = from.allowed_ips;
            this.user = from.user;
            this.user_additional_data = from.user_additional_data;
            this.user_last_login = from.user_last_login;
        }

    }
}
