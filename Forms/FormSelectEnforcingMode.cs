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
    public partial class FormSelectEnforcingMode : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PrepopulatedOption { get; set; } = "on";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedOption { get; private set; } = "";

        public FormSelectEnforcingMode()
        {
            InitializeComponent();
        }

        private void FormSelectEnforcingMode_Load(object sender, EventArgs e)
        {
            foreach (Control control in gbModes.Controls)
            {
                if (control is RadioButton rb && rb.Text == PrepopulatedOption)
                {
                    rb.Checked = true;
                    break;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (Control control in gbModes.Controls)
            {
                if (control is RadioButton rb && rb.Checked == true)
                {
                    SelectedOption = rb.Text;
                    break;
                }
            }
        }
    }
}
