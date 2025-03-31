using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomaadminpanel.Models
{
    internal class ComboBoxItem
    {
        public string Text { get; set; } = "";
        public object Tag { get; set; } = "";

        public ComboBoxItem()
        {
            //Text = text;
            //Tag = tag;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
