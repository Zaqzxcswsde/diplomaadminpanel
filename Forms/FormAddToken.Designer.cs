namespace diplomaadminpanel.Forms
{
    partial class FormAddToken
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pgViewListUsers = new PaginatedView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            SuspendLayout();
            // 
            // pgViewListUsers
            // 
            pgViewListUsers.Location = new Point(12, 12);
            pgViewListUsers.Name = "pgViewListUsers";
            pgViewListUsers.Size = new Size(379, 300);
            pgViewListUsers.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(165, 23);
            txtSearch.TabIndex = 3;
            txtSearch.KeyDown += textBox1_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(183, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(84, 23);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Поиск";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // FormAddToken
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(401, 321);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(pgViewListUsers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAddToken";
            ShowIcon = false;
            Text = "Привязка токена";
            Load += FormAddToken_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PaginatedView pgViewListUsers;
        private TextBox txtSearch;
        private Button btnSearch;
    }
}