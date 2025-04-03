using diplomaadminpanel.Models;

namespace diplomaadminpanel.Forms
{
    partial class FormEditToken
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
            btnUpdate = new Button();
            btnSave = new Button();
            cbIsActive = new CheckBox();
            cbCanResetPassword = new CheckBox();
            groupBox2 = new GroupBox();
            groupBox6 = new GroupBox();
            label8 = new Label();
            txtAdditionalInfo = new TextBox();
            txtUserID = new TextBox();
            label7 = new Label();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtLastActivated = new TextBox();
            txtFingerprint = new TextBox();
            txtPubkey = new TextBox();
            txtId = new TextBox();
            btnUserChangeRollback2 = new Button();
            groupBox5 = new GroupBox();
            txtAllowedIps = new TextBox();
            tabPage3 = new TabPage();
            groupBox7 = new GroupBox();
            btnUserChangeRollback1 = new Button();
            cbClearUser = new CheckBox();
            lblNewUserStatus = new Label();
            label10 = new Label();
            cbCreateNewUser = new CheckBox();
            label9 = new Label();
            btnSearchUser = new Button();
            txtSearchUser = new TextBox();
            paginatedView2 = new PaginatedView();
            tabPage1 = new TabPage();
            groupBox4 = new GroupBox();
            txtHistSearch = new TextBox();
            label6 = new Label();
            button1 = new Button();
            groupBox3 = new GroupBox();
            cbSuccess = new CheckBox();
            cbErr = new CheckBox();
            paginatedView1 = new PaginatedView();
            groupBox2.SuspendLayout();
            groupBox6.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox7.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Dock = DockStyle.Bottom;
            btnUpdate.Location = new Point(0, 504);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(620, 36);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Обновить из базы (удалит текущие изменения)";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Location = new Point(0, 436);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(620, 68);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить\r\n(применит текущие изменения)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cbIsActive
            // 
            cbIsActive.AutoSize = true;
            cbIsActive.Location = new Point(6, 22);
            cbIsActive.Name = "cbIsActive";
            cbIsActive.Size = new Size(109, 19);
            cbIsActive.TabIndex = 5;
            cbIsActive.Text = "Токен активен?";
            cbIsActive.UseVisualStyleBackColor = true;
            // 
            // cbCanResetPassword
            // 
            cbCanResetPassword.AutoSize = true;
            cbCanResetPassword.Location = new Point(6, 53);
            cbCanResetPassword.Name = "cbCanResetPassword";
            cbCanResetPassword.Size = new Size(166, 19);
            cbCanResetPassword.TabIndex = 6;
            cbCanResetPassword.Text = "Может сбросить пароль?";
            cbCanResetPassword.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbIsActive);
            groupBox2.Controls.Add(cbCanResetPassword);
            groupBox2.Location = new Point(6, 155);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(176, 85);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Изменить параметры входа";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label8);
            groupBox6.Controls.Add(txtAdditionalInfo);
            groupBox6.Controls.Add(txtUserID);
            groupBox6.Controls.Add(label7);
            groupBox6.Location = new Point(188, 155);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(321, 85);
            groupBox6.TabIndex = 4;
            groupBox6.TabStop = false;
            groupBox6.Text = "Изменить текущего пользователя";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 44);
            label8.Name = "label8";
            label8.Size = new Size(82, 30);
            label8.TabIndex = 3;
            label8.Text = "Доп.\r\nинформация:";
            // 
            // txtAdditionalInfo
            // 
            txtAdditionalInfo.Location = new Point(94, 51);
            txtAdditionalInfo.Name = "txtAdditionalInfo";
            txtAdditionalInfo.Size = new Size(221, 23);
            txtAdditionalInfo.TabIndex = 1;
            // 
            // txtUserID
            // 
            txtUserID.BackColor = SystemColors.Window;
            txtUserID.BorderStyle = BorderStyle.None;
            txtUserID.Location = new Point(33, 22);
            txtUserID.Name = "txtUserID";
            txtUserID.ReadOnly = true;
            txtUserID.Size = new Size(282, 16);
            txtUserID.TabIndex = 0;
            txtUserID.Text = "<placeholder>";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 22);
            label7.Name = "label7";
            label7.Size = new Size(21, 15);
            label7.TabIndex = 2;
            label7.Text = "ID:";
            // 
            // label1
            // 
            label1.Location = new Point(650, 210);
            label1.Name = "label1";
            label1.Size = new Size(408, 52);
            label1.TabIndex = 18;
            label1.Text = "Измените описание текущего пользователя, привязанного к токену";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(620, 436);
            tabControl1.TabIndex = 20;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Controls.Add(btnUserChangeRollback2);
            tabPage2.Controls.Add(groupBox5);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox6);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(612, 408);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Информация";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtLastActivated);
            groupBox1.Controls.Add(txtFingerprint);
            groupBox1.Controls.Add(txtPubkey);
            groupBox1.Controls.Add(txtId);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(600, 143);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Общая информация (нельзя изменить)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 108);
            label5.Name = "label5";
            label5.Size = new Size(97, 30);
            label5.TabIndex = 8;
            label5.Text = "Последний вход\r\nпользователя:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 86);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 7;
            label4.Text = "Отпечаток:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 44);
            label3.Name = "label3";
            label3.Size = new Size(73, 30);
            label3.TabIndex = 6;
            label3.Text = "Публичный\r\nключ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 22);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 5;
            label2.Text = "ID:";
            // 
            // txtLastActivated
            // 
            txtLastActivated.BackColor = SystemColors.Window;
            txtLastActivated.BorderStyle = BorderStyle.None;
            txtLastActivated.Location = new Point(108, 116);
            txtLastActivated.Name = "txtLastActivated";
            txtLastActivated.ReadOnly = true;
            txtLastActivated.Size = new Size(486, 16);
            txtLastActivated.TabIndex = 4;
            txtLastActivated.TabStop = false;
            txtLastActivated.Text = "<placeholder>";
            // 
            // txtFingerprint
            // 
            txtFingerprint.BackColor = SystemColors.Window;
            txtFingerprint.BorderStyle = BorderStyle.None;
            txtFingerprint.Location = new Point(108, 86);
            txtFingerprint.Name = "txtFingerprint";
            txtFingerprint.ReadOnly = true;
            txtFingerprint.Size = new Size(486, 16);
            txtFingerprint.TabIndex = 3;
            txtFingerprint.TabStop = false;
            txtFingerprint.Text = "<placeholder>";
            // 
            // txtPubkey
            // 
            txtPubkey.BackColor = SystemColors.Window;
            txtPubkey.BorderStyle = BorderStyle.None;
            txtPubkey.Location = new Point(106, 44);
            txtPubkey.Multiline = true;
            txtPubkey.Name = "txtPubkey";
            txtPubkey.ReadOnly = true;
            txtPubkey.ScrollBars = ScrollBars.Horizontal;
            txtPubkey.Size = new Size(488, 36);
            txtPubkey.TabIndex = 2;
            txtPubkey.TabStop = false;
            txtPubkey.Text = "<placeholder>";
            txtPubkey.WordWrap = false;
            // 
            // txtId
            // 
            txtId.BackColor = SystemColors.Window;
            txtId.BorderStyle = BorderStyle.None;
            txtId.Location = new Point(108, 22);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(486, 16);
            txtId.TabIndex = 1;
            txtId.TabStop = false;
            txtId.Text = "<placeholder>";
            // 
            // btnUserChangeRollback2
            // 
            btnUserChangeRollback2.Location = new Point(515, 155);
            btnUserChangeRollback2.Name = "btnUserChangeRollback2";
            btnUserChangeRollback2.Size = new Size(91, 85);
            btnUserChangeRollback2.TabIndex = 21;
            btnUserChangeRollback2.Text = "Откатить изменения пользователя\r\n";
            btnUserChangeRollback2.UseVisualStyleBackColor = true;
            btnUserChangeRollback2.Click += btnUserChangeRollback_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(txtAllowedIps);
            groupBox5.Location = new Point(6, 246);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(600, 156);
            groupBox5.TabIndex = 20;
            groupBox5.TabStop = false;
            groupBox5.Text = "Изменить разрешённые IP";
            // 
            // txtAllowedIps
            // 
            txtAllowedIps.Dock = DockStyle.Fill;
            txtAllowedIps.Location = new Point(3, 19);
            txtAllowedIps.Multiline = true;
            txtAllowedIps.Name = "txtAllowedIps";
            txtAllowedIps.ScrollBars = ScrollBars.Vertical;
            txtAllowedIps.Size = new Size(594, 134);
            txtAllowedIps.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox7);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(612, 408);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Изменить привязанного пользователя";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(btnUserChangeRollback1);
            groupBox7.Controls.Add(cbClearUser);
            groupBox7.Controls.Add(lblNewUserStatus);
            groupBox7.Controls.Add(label10);
            groupBox7.Controls.Add(cbCreateNewUser);
            groupBox7.Controls.Add(label9);
            groupBox7.Controls.Add(btnSearchUser);
            groupBox7.Controls.Add(txtSearchUser);
            groupBox7.Controls.Add(paginatedView2);
            groupBox7.Location = new Point(6, 6);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(602, 398);
            groupBox7.TabIndex = 5;
            groupBox7.TabStop = false;
            groupBox7.Text = "Изменение пользователя";
            // 
            // btnUserChangeRollback1
            // 
            btnUserChangeRollback1.Location = new Point(367, 19);
            btnUserChangeRollback1.Name = "btnUserChangeRollback1";
            btnUserChangeRollback1.Size = new Size(229, 29);
            btnUserChangeRollback1.TabIndex = 8;
            btnUserChangeRollback1.Text = "Откатить изменения пользователя";
            btnUserChangeRollback1.UseVisualStyleBackColor = true;
            btnUserChangeRollback1.Click += btnUserChangeRollback_Click;
            // 
            // cbClearUser
            // 
            cbClearUser.AutoCheck = false;
            cbClearUser.AutoSize = true;
            cbClearUser.Location = new Point(344, 54);
            cbClearUser.Name = "cbClearUser";
            cbClearUser.Padding = new Padding(10, 0, 0, 0);
            cbClearUser.Size = new Size(143, 19);
            cbClearUser.TabIndex = 7;
            cbClearUser.Text = "Очистить текущего";
            cbClearUser.UseVisualStyleBackColor = true;
            cbClearUser.Click += cbClearUser_Click;
            // 
            // lblNewUserStatus
            // 
            lblNewUserStatus.Location = new Point(6, 19);
            lblNewUserStatus.Name = "lblNewUserStatus";
            lblNewUserStatus.Size = new Size(356, 29);
            lblNewUserStatus.TabIndex = 6;
            lblNewUserStatus.Text = "Будет изменён на: <пользователь не будет изменён>";
            lblNewUserStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 84);
            label10.Name = "label10";
            label10.Size = new Size(103, 15);
            label10.TabIndex = 5;
            label10.Text = "Поиск по доп св.:";
            // 
            // cbCreateNewUser
            // 
            cbCreateNewUser.AutoCheck = false;
            cbCreateNewUser.AutoSize = true;
            cbCreateNewUser.Location = new Point(94, 57);
            cbCreateNewUser.Name = "cbCreateNewUser";
            cbCreateNewUser.Padding = new Padding(10, 0, 0, 0);
            cbCreateNewUser.Size = new Size(121, 19);
            cbCreateNewUser.TabIndex = 1;
            cbCreateNewUser.Text = "Создать нового";
            cbCreateNewUser.UseVisualStyleBackColor = true;
            cbCreateNewUser.Click += cbCreateNewUser_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 58);
            label9.Name = "label9";
            label9.Size = new Size(592, 15);
            label9.TabIndex = 4;
            label9.Text = "---------------------------------------------------------------------------------------------------------------------";
            // 
            // btnSearchUser
            // 
            btnSearchUser.Location = new Point(368, 79);
            btnSearchUser.Name = "btnSearchUser";
            btnSearchUser.Size = new Size(75, 23);
            btnSearchUser.TabIndex = 3;
            btnSearchUser.Text = "Поиск";
            btnSearchUser.UseVisualStyleBackColor = true;
            btnSearchUser.Click += btnSearchUser_Click;
            // 
            // txtSearchUser
            // 
            txtSearchUser.Location = new Point(115, 79);
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.Size = new Size(247, 23);
            txtSearchUser.TabIndex = 2;
            txtSearchUser.KeyDown += txtSearchUser_KeyDown;
            // 
            // paginatedView2
            // 
            paginatedView2.Location = new Point(6, 76);
            paginatedView2.Name = "paginatedView2";
            paginatedView2.Size = new Size(591, 316);
            paginatedView2.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(612, 408);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "История";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtHistSearch);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(groupBox3);
            groupBox4.Controls.Add(paginatedView1);
            groupBox4.Location = new Point(8, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(602, 398);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            groupBox4.Text = "История запросов (нельзя изменить)";
            // 
            // txtHistSearch
            // 
            txtHistSearch.Location = new Point(75, 48);
            txtHistSearch.Name = "txtHistSearch";
            txtHistSearch.Size = new Size(165, 23);
            txtHistSearch.TabIndex = 15;
            txtHistSearch.KeyDown += txtHistSearch_KeyDown;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(107, 45);
            label6.TabIndex = 13;
            label6.Text = "Можно искать по:\r\n- ошибке\r\n- IP";
            // 
            // button1
            // 
            button1.Location = new Point(119, 19);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 14;
            button1.Text = " Искать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += EventLoadHistoryWithParams;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbSuccess);
            groupBox3.Controls.Add(cbErr);
            groupBox3.Location = new Point(246, 19);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(218, 52);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Фильтр истории";
            // 
            // cbSuccess
            // 
            cbSuccess.AutoSize = true;
            cbSuccess.Checked = true;
            cbSuccess.CheckState = CheckState.Checked;
            cbSuccess.Location = new Point(6, 22);
            cbSuccess.Name = "cbSuccess";
            cbSuccess.Size = new Size(85, 19);
            cbSuccess.TabIndex = 9;
            cbSuccess.Text = "Успешные";
            cbSuccess.UseVisualStyleBackColor = true;
            cbSuccess.CheckedChanged += EventLoadHistoryWithParams;
            // 
            // cbErr
            // 
            cbErr.AutoSize = true;
            cbErr.Checked = true;
            cbErr.CheckState = CheckState.Checked;
            cbErr.Location = new Point(97, 22);
            cbErr.Name = "cbErr";
            cbErr.Size = new Size(102, 19);
            cbErr.TabIndex = 11;
            cbErr.Text = "Безуспешные";
            cbErr.UseVisualStyleBackColor = true;
            cbErr.CheckedChanged += EventLoadHistoryWithParams;
            // 
            // paginatedView1
            // 
            paginatedView1.Location = new Point(6, 43);
            paginatedView1.Name = "paginatedView1";
            paginatedView1.Size = new Size(590, 347);
            paginatedView1.TabIndex = 16;
            // 
            // FormEditToken
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(620, 540);
            Controls.Add(tabControl1);
            Controls.Add(btnSave);
            Controls.Add(btnUpdate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormEditToken";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактирование токена";
            FormClosing += FormEditToken_FormClosing;
            Load += FormEditToken_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            tabPage3.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            tabPage1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnUpdate;
        private Button btnSave;
        private CheckBox cbIsActive;
        private CheckBox cbCanResetPassword;
        private GroupBox groupBox2;
        private Label label8;
        private Label label7;
        private TextBox txtAdditionalInfo;
        private TextBox txtUserID;
        private GroupBox groupBox6;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox4;
        private TextBox txtHistSearch;
        private Label label6;
        private Button button1;
        private GroupBox groupBox3;
        private CheckBox cbSuccess;
        private CheckBox cbErr;
        private PaginatedView paginatedView1;
        private TabPage tabPage3;
        private GroupBox groupBox7;
        private CheckBox cbClearUser;
        private Label lblNewUserStatus;
        private Label label10;
        private CheckBox cbCreateNewUser;
        private Label label9;
        private Button btnSearchUser;
        private TextBox txtSearchUser;
        private PaginatedView paginatedView2;
        private GroupBox groupBox5;
        private TextBox txtAllowedIps;
        private Button btnUserChangeRollback2;
        private Button btnUserChangeRollback1;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtLastActivated;
        private TextBox txtFingerprint;
        private TextBox txtPubkey;
        private TextBox txtId;
    }
}