using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomaadminpanel.Forms
{
    public partial class FormCustomCheckboxFilter : Form
    {
        public FormCustomCheckboxFilter()
        {
            InitializeComponent();
        }

        private Dictionary<string, CheckBox> _checkboxes { get; set; } = [];

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, bool>? Result { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public required Dictionary<string, bool> InitialValues { get; set; }

        //private Dictionary<string, bool>? all_items;
        private void FormCustomCheckboxFilter_Load(object sender, EventArgs e)
        {
            CreateCheckboxes(InitialValues);
            //var rnd = new Random();
            //all_items = new Dictionary<string, bool>
            //{
            //    ["pin is invalid"] = rnd.Next(2) == 0,
            //    ["that token is not active, token"] = rnd.Next(2) == 0,
            //    ["not a valid IP"] = rnd.Next(2) == 0,
            //    ["that token is not registered in the database, token"] = rnd.Next(2) == 0,
            //    ["unsupported app version"] = rnd.Next(2) == 0,
            //    ["ticket has expired"] = rnd.Next(2) == 0,
            //    ["unsupported ticket version"] = rnd.Next(2) == 0,
            //    ["flow control error, token has been deactivated for security reasons, the incident has been logged"] = rnd.Next(2) == 0
            //};
        }


        private void CreateCheckboxes(Dictionary<string, bool> data)
        {
            int y = 20;
            int maxTextWidth = 0;

            foreach (var item in data)
            {
                var cb = new CheckBox
                {
                    Checked = item.Value,
                    Text = item.Key,
                    Location = new Point(10, y),
                    AutoSize = true
                };

                var textSize = TextRenderer.MeasureText(item.Key, cb.Font);
                if (textSize.Width > maxTextWidth)
                    maxTextWidth = textSize.Width;

                groupBox1.Controls.Add(cb);
                _checkboxes.Add(item.Key, cb);

                y += 25;
            }

            this.Width = maxTextWidth + 45;
            this.Height = (data.Count > 0 ? 25 : 0) + (25 * data.Count) + 100;
        }

        //private int ind = 0;
        //private Dictionary<string, bool> dict = [];
        //private void btnOk_Click(object sender, EventArgs e)
        //{
        //    //if (ind >= all_items!.Count()) return;
        //    //groupBox1.Controls.Clear();
        //    //_checkboxes.Clear();
        //    //dict.Add(all_items!.Keys.ToArray()[ind], all_items[all_items!.Keys.ToArray()[ind]]);
        //    //ind++;
        //    //CreateCheckboxes(dict);
        //}

        private void FormCustomCheckboxFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                Result = _checkboxes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Checked);
            }
            else
            {
                Result = new Dictionary<string, bool>(InitialValues);
            }
        }
    }
}
