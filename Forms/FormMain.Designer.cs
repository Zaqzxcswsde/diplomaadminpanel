namespace diplomaadminpanel.Forms
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            toolStrip1 = new ToolStrip();
            tslCurrentMode = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripDropDownButtonEnv = new ToolStripDropDownButton();
            devToolStripMenuItem = new ToolStripMenuItem();
            prodToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tpAddNewTokens = new TabPage();
            groupBox3 = new GroupBox();
            buttonActivateSelectedTokens = new Button();
            label3 = new Label();
            groupBox2 = new GroupBox();
            lblPgInfo = new Label();
            btnTknNext = new Button();
            btnTknPrev = new Button();
            buttonUpdateTokensList = new Button();
            clbTokensList = new CheckedListBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            buttonSwitchToGraceful = new Button();
            label1 = new Label();
            tpHistory = new TabPage();
            tpListTokens = new TabPage();
            groupBox5 = new GroupBox();
            cbOnlyActive = new CheckBox();
            cbOnlyLinked = new CheckBox();
            LblAllTkn = new Label();
            groupBox4 = new GroupBox();
            btnDeleteUnlinked = new Button();
            btnDeleteInactive = new Button();
            btnAllTknPrev = new Button();
            btnAllTknNext = new Button();
            btnAllTknSearch = new Button();
            txtAllTknSearch = new TextBox();
            label4 = new Label();
            dgvAllTkn = new DataGridView();
            columnId = new DataGridViewTextBoxColumn();
            ColumnFingerprint = new DataGridViewTextBoxColumn();
            ColumnPubkey = new DataGridViewTextBoxColumn();
            ColumnIsActive = new DataGridViewCheckBoxColumn();
            ColumnCanResetPassword = new DataGridViewCheckBoxColumn();
            ColumnLastActivated = new DataGridViewTextBoxColumn();
            ColumnAllowedIps = new DataGridViewTextBoxColumn();
            ColumnUserID = new DataGridViewTextBoxColumn();
            ColumnUserAddInfo = new DataGridViewTextBoxColumn();
            tabPage1 = new TabPage();
            toolTip1 = new ToolTip(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            paginatedView1 = new PaginatedView();
            label5 = new Label();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            checkBox1 = new CheckBox();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tpAddNewTokens.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tpHistory.SuspendLayout();
            tpListTokens.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAllTkn).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tslCurrentMode, toolStripSeparator1, toolStripDropDownButtonEnv });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(928, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // tslCurrentMode
            // 
            tslCurrentMode.Alignment = ToolStripItemAlignment.Right;
            tslCurrentMode.Name = "tslCurrentMode";
            tslCurrentMode.Size = new Size(181, 22);
            tslCurrentMode.Text = "Текущий режим: <placeholder>";
            tslCurrentMode.Click += tslCurrentMode_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripDropDownButtonEnv
            // 
            toolStripDropDownButtonEnv.Alignment = ToolStripItemAlignment.Right;
            toolStripDropDownButtonEnv.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButtonEnv.DropDownItems.AddRange(new ToolStripItem[] { devToolStripMenuItem, prodToolStripMenuItem });
            toolStripDropDownButtonEnv.Image = (Image)resources.GetObject("toolStripDropDownButtonEnv.Image");
            toolStripDropDownButtonEnv.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButtonEnv.Name = "toolStripDropDownButtonEnv";
            toolStripDropDownButtonEnv.Size = new Size(83, 22);
            toolStripDropDownButtonEnv.Text = "Окружение";
            toolStripDropDownButtonEnv.DropDownItemClicked += toolStripDropDownButton1_DropDownItemClicked;
            // 
            // devToolStripMenuItem
            // 
            devToolStripMenuItem.Name = "devToolStripMenuItem";
            devToolStripMenuItem.Size = new Size(99, 22);
            devToolStripMenuItem.Text = "dev";
            // 
            // prodToolStripMenuItem
            // 
            prodToolStripMenuItem.Name = "prodToolStripMenuItem";
            prodToolStripMenuItem.Size = new Size(99, 22);
            prodToolStripMenuItem.Text = "prod";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpAddNewTokens);
            tabControl1.Controls.Add(tpHistory);
            tabControl1.Controls.Add(tpListTokens);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 25);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(928, 451);
            tabControl1.TabIndex = 2;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tpAddNewTokens
            // 
            tpAddNewTokens.Controls.Add(groupBox3);
            tpAddNewTokens.Controls.Add(groupBox2);
            tpAddNewTokens.Controls.Add(groupBox1);
            tpAddNewTokens.Location = new Point(4, 24);
            tpAddNewTokens.Margin = new Padding(4, 3, 4, 3);
            tpAddNewTokens.Name = "tpAddNewTokens";
            tpAddNewTokens.Padding = new Padding(4, 3, 4, 3);
            tpAddNewTokens.Size = new Size(920, 423);
            tpAddNewTokens.TabIndex = 0;
            tpAddNewTokens.Text = "Валидация нового токена";
            tpAddNewTokens.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonActivateSelectedTokens);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(57, 294);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(278, 105);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Шаг 3";
            // 
            // buttonActivateSelectedTokens
            // 
            buttonActivateSelectedTokens.Enabled = false;
            buttonActivateSelectedTokens.Location = new Point(7, 56);
            buttonActivateSelectedTokens.Margin = new Padding(4, 3, 4, 3);
            buttonActivateSelectedTokens.Name = "buttonActivateSelectedTokens";
            buttonActivateSelectedTokens.Size = new Size(264, 42);
            buttonActivateSelectedTokens.TabIndex = 1;
            buttonActivateSelectedTokens.Text = "Завершить";
            buttonActivateSelectedTokens.UseVisualStyleBackColor = true;
            buttonActivateSelectedTokens.Click += buttonActivateSelectedTokens_Click;
            // 
            // label3
            // 
            label3.Location = new Point(7, 18);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(263, 35);
            label3.TabIndex = 0;
            label3.Text = "Перевести систему в on режим и активировать выбранные токены";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblPgInfo);
            groupBox2.Controls.Add(btnTknNext);
            groupBox2.Controls.Add(btnTknPrev);
            groupBox2.Controls.Add(buttonUpdateTokensList);
            groupBox2.Controls.Add(clbTokensList);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(57, 84);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(278, 204);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Шаг 2";
            // 
            // lblPgInfo
            // 
            lblPgInfo.AutoSize = true;
            lblPgInfo.Location = new Point(238, 59);
            lblPgInfo.Name = "lblPgInfo";
            lblPgInfo.Size = new Size(22, 15);
            lblPgInfo.TabIndex = 7;
            lblPgInfo.Text = "?/?";
            // 
            // btnTknNext
            // 
            btnTknNext.Enabled = false;
            btnTknNext.Location = new Point(190, 52);
            btnTknNext.Name = "btnTknNext";
            btnTknNext.Size = new Size(36, 29);
            btnTknNext.TabIndex = 6;
            btnTknNext.Text = "->";
            btnTknNext.UseVisualStyleBackColor = true;
            // 
            // btnTknPrev
            // 
            btnTknPrev.Enabled = false;
            btnTknPrev.Location = new Point(150, 52);
            btnTknPrev.Name = "btnTknPrev";
            btnTknPrev.Size = new Size(34, 29);
            btnTknPrev.TabIndex = 5;
            btnTknPrev.Text = "<-";
            btnTknPrev.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateTokensList
            // 
            buttonUpdateTokensList.Enabled = false;
            buttonUpdateTokensList.Location = new Point(7, 52);
            buttonUpdateTokensList.Margin = new Padding(4, 3, 4, 3);
            buttonUpdateTokensList.Name = "buttonUpdateTokensList";
            buttonUpdateTokensList.Size = new Size(136, 29);
            buttonUpdateTokensList.TabIndex = 4;
            buttonUpdateTokensList.Text = "Обновить список";
            buttonUpdateTokensList.UseVisualStyleBackColor = true;
            buttonUpdateTokensList.Click += buttonUpdateTokensList_Click;
            // 
            // clbTokensList
            // 
            clbTokensList.CheckOnClick = true;
            clbTokensList.FormattingEnabled = true;
            clbTokensList.Location = new Point(7, 84);
            clbTokensList.Margin = new Padding(4, 3, 4, 3);
            clbTokensList.Name = "clbTokensList";
            clbTokensList.Size = new Size(263, 94);
            clbTokensList.TabIndex = 3;
            clbTokensList.ItemCheck += clbTokensList_ItemCheck;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 18);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(183, 30);
            label2.TabIndex = 2;
            label2.Text = "Выбрать из списка токены,\r\nкоторые необходимо включить";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonSwitchToGraceful);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(57, 6);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(278, 72);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Шаг 1";
            // 
            // buttonSwitchToGraceful
            // 
            buttonSwitchToGraceful.Location = new Point(7, 37);
            buttonSwitchToGraceful.Margin = new Padding(4, 3, 4, 3);
            buttonSwitchToGraceful.Name = "buttonSwitchToGraceful";
            buttonSwitchToGraceful.Size = new Size(264, 27);
            buttonSwitchToGraceful.TabIndex = 1;
            buttonSwitchToGraceful.Text = "Переключить";
            buttonSwitchToGraceful.UseVisualStyleBackColor = true;
            buttonSwitchToGraceful.Click += buttonSwitchToGraceful_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 19);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(210, 15);
            label1.TabIndex = 0;
            label1.Text = "Перевести систему в Graceful режим";
            // 
            // tpHistory
            // 
            tpHistory.Controls.Add(checkBox1);
            tpHistory.Controls.Add(dateTimePicker2);
            tpHistory.Controls.Add(dateTimePicker1);
            tpHistory.Controls.Add(textBox1);
            tpHistory.Controls.Add(label5);
            tpHistory.Controls.Add(paginatedView1);
            tpHistory.Location = new Point(4, 24);
            tpHistory.Margin = new Padding(4, 3, 4, 3);
            tpHistory.Name = "tpHistory";
            tpHistory.Padding = new Padding(4, 3, 4, 3);
            tpHistory.Size = new Size(920, 423);
            tpHistory.TabIndex = 1;
            tpHistory.Text = "История";
            tpHistory.UseVisualStyleBackColor = true;
            // 
            // tpListTokens
            // 
            tpListTokens.Controls.Add(groupBox5);
            tpListTokens.Controls.Add(LblAllTkn);
            tpListTokens.Controls.Add(groupBox4);
            tpListTokens.Controls.Add(btnAllTknPrev);
            tpListTokens.Controls.Add(btnAllTknNext);
            tpListTokens.Controls.Add(btnAllTknSearch);
            tpListTokens.Controls.Add(txtAllTknSearch);
            tpListTokens.Controls.Add(label4);
            tpListTokens.Controls.Add(dgvAllTkn);
            tpListTokens.Location = new Point(4, 24);
            tpListTokens.Name = "tpListTokens";
            tpListTokens.Padding = new Padding(3);
            tpListTokens.Size = new Size(920, 423);
            tpListTokens.TabIndex = 2;
            tpListTokens.Text = "Управление токенами";
            tpListTokens.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cbOnlyActive);
            groupBox5.Controls.Add(cbOnlyLinked);
            groupBox5.Location = new Point(455, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(157, 85);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "Фильтр";
            // 
            // cbOnlyActive
            // 
            cbOnlyActive.AutoSize = true;
            cbOnlyActive.Location = new Point(6, 22);
            cbOnlyActive.Name = "cbOnlyActive";
            cbOnlyActive.Size = new Size(120, 19);
            cbOnlyActive.TabIndex = 7;
            cbOnlyActive.Text = "Только активные";
            cbOnlyActive.UseVisualStyleBackColor = true;
            cbOnlyActive.CheckedChanged += cbOnlyActive_CheckedChanged;
            // 
            // cbOnlyLinked
            // 
            cbOnlyLinked.AutoSize = true;
            cbOnlyLinked.Location = new Point(6, 53);
            cbOnlyLinked.Name = "cbOnlyLinked";
            cbOnlyLinked.Size = new Size(141, 19);
            cbOnlyLinked.TabIndex = 6;
            cbOnlyLinked.Text = "Только привязанные";
            cbOnlyLinked.UseVisualStyleBackColor = true;
            cbOnlyLinked.CheckedChanged += cbOnlyLinked_CheckedChanged;
            // 
            // LblAllTkn
            // 
            LblAllTkn.ImageAlign = ContentAlignment.TopLeft;
            LblAllTkn.Location = new Point(850, 38);
            LblAllTkn.Name = "LblAllTkn";
            LblAllTkn.Size = new Size(64, 27);
            LblAllTkn.TabIndex = 11;
            LblAllTkn.Text = "? / ?";
            LblAllTkn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnDeleteUnlinked);
            groupBox4.Controls.Add(btnDeleteInactive);
            groupBox4.Location = new Point(618, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(226, 85);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Действия";
            // 
            // btnDeleteUnlinked
            // 
            btnDeleteUnlinked.Location = new Point(6, 22);
            btnDeleteUnlinked.Name = "btnDeleteUnlinked";
            btnDeleteUnlinked.Size = new Size(101, 50);
            btnDeleteUnlinked.TabIndex = 8;
            btnDeleteUnlinked.TabStop = false;
            btnDeleteUnlinked.Text = "Удалить непривязанные";
            btnDeleteUnlinked.UseVisualStyleBackColor = true;
            btnDeleteUnlinked.Click += btnDeleteUnlinked_Click;
            // 
            // btnDeleteInactive
            // 
            btnDeleteInactive.Location = new Point(113, 22);
            btnDeleteInactive.Name = "btnDeleteInactive";
            btnDeleteInactive.Size = new Size(101, 50);
            btnDeleteInactive.TabIndex = 9;
            btnDeleteInactive.TabStop = false;
            btnDeleteInactive.Text = "Удалить неактивные";
            btnDeleteInactive.UseVisualStyleBackColor = true;
            btnDeleteInactive.Click += btnDeleteInactive_Click;
            // 
            // btnAllTknPrev
            // 
            btnAllTknPrev.Enabled = false;
            btnAllTknPrev.Location = new Point(850, 68);
            btnAllTknPrev.Name = "btnAllTknPrev";
            btnAllTknPrev.Size = new Size(64, 23);
            btnAllTknPrev.TabIndex = 5;
            btnAllTknPrev.Text = "<-";
            btnAllTknPrev.UseVisualStyleBackColor = true;
            // 
            // btnAllTknNext
            // 
            btnAllTknNext.Enabled = false;
            btnAllTknNext.Location = new Point(850, 12);
            btnAllTknNext.Name = "btnAllTknNext";
            btnAllTknNext.Size = new Size(64, 23);
            btnAllTknNext.TabIndex = 4;
            btnAllTknNext.Text = "->";
            btnAllTknNext.UseVisualStyleBackColor = true;
            // 
            // btnAllTknSearch
            // 
            btnAllTknSearch.Location = new Point(206, 38);
            btnAllTknSearch.Name = "btnAllTknSearch";
            btnAllTknSearch.Size = new Size(243, 53);
            btnAllTknSearch.TabIndex = 3;
            btnAllTknSearch.Text = "Поиск";
            btnAllTknSearch.UseVisualStyleBackColor = true;
            btnAllTknSearch.Click += btnAllTknSearch_Click;
            // 
            // txtAllTknSearch
            // 
            txtAllTknSearch.Location = new Point(206, 9);
            txtAllTknSearch.Name = "txtAllTknSearch";
            txtAllTknSearch.Size = new Size(243, 23);
            txtAllTknSearch.TabIndex = 2;
            txtAllTknSearch.KeyDown += txtAllTknSearch_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 3);
            label4.Name = "label4";
            label4.Size = new Size(192, 90);
            label4.TabIndex = 1;
            label4.Text = "Можно искать по:\r\n- ID\r\n- отпечатку\r\n- публичному ключу\r\n- ID пользователя\r\n- доп. информации пользователя";
            toolTip1.SetToolTip(label4, "Можно искать по:\r\n- ID\r\n- публичному ключу\r\n- ID пользователя\r\n- доп. информации пользователя");
            // 
            // dgvAllTkn
            // 
            dgvAllTkn.AllowUserToAddRows = false;
            dgvAllTkn.AllowUserToDeleteRows = false;
            dgvAllTkn.AllowUserToResizeColumns = false;
            dgvAllTkn.AllowUserToResizeRows = false;
            dgvAllTkn.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvAllTkn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllTkn.Columns.AddRange(new DataGridViewColumn[] { columnId, ColumnFingerprint, ColumnPubkey, ColumnIsActive, ColumnCanResetPassword, ColumnLastActivated, ColumnAllowedIps, ColumnUserID, ColumnUserAddInfo });
            dgvAllTkn.Location = new Point(8, 97);
            dgvAllTkn.MultiSelect = false;
            dgvAllTkn.Name = "dgvAllTkn";
            dgvAllTkn.RowHeadersVisible = false;
            dgvAllTkn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllTkn.ShowEditingIcon = false;
            dgvAllTkn.Size = new Size(907, 321);
            dgvAllTkn.TabIndex = 0;
            dgvAllTkn.CellDoubleClick += dgvAllTkn_CellDoubleClick;
            dgvAllTkn.CellValueChanged += dgvAllTkn_CellValueChanged;
            dgvAllTkn.CurrentCellDirtyStateChanged += dgvAllTkn_CurrentCellDirtyStateChanged;
            // 
            // columnId
            // 
            columnId.HeaderText = "ID";
            columnId.Name = "columnId";
            columnId.ReadOnly = true;
            // 
            // ColumnFingerprint
            // 
            ColumnFingerprint.HeaderText = "Отпечаток";
            ColumnFingerprint.Name = "ColumnFingerprint";
            ColumnFingerprint.ReadOnly = true;
            // 
            // ColumnPubkey
            // 
            ColumnPubkey.HeaderText = "Public Key";
            ColumnPubkey.Name = "ColumnPubkey";
            ColumnPubkey.ReadOnly = true;
            // 
            // ColumnIsActive
            // 
            ColumnIsActive.HeaderText = "Активен?";
            ColumnIsActive.Name = "ColumnIsActive";
            // 
            // ColumnCanResetPassword
            // 
            ColumnCanResetPassword.HeaderText = "Может сбросить пароль?";
            ColumnCanResetPassword.Name = "ColumnCanResetPassword";
            // 
            // ColumnLastActivated
            // 
            ColumnLastActivated.HeaderText = "Последняя активация";
            ColumnLastActivated.Name = "ColumnLastActivated";
            ColumnLastActivated.ReadOnly = true;
            // 
            // ColumnAllowedIps
            // 
            ColumnAllowedIps.HeaderText = "Разрешённые IP";
            ColumnAllowedIps.Name = "ColumnAllowedIps";
            ColumnAllowedIps.ReadOnly = true;
            // 
            // ColumnUserID
            // 
            ColumnUserID.HeaderText = "ID пользователя";
            ColumnUserID.Name = "ColumnUserID";
            ColumnUserID.ReadOnly = true;
            // 
            // ColumnUserAddInfo
            // 
            ColumnUserAddInfo.HeaderText = "Доп. инф. пользователя";
            ColumnUserAddInfo.Name = "ColumnUserAddInfo";
            ColumnUserAddInfo.ReadOnly = true;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(920, 423);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "Управление пользователями";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            toolTip1.Tag = "(можно искать по ...)";
            // 
            // paginatedView1
            // 
            paginatedView1.Location = new Point(7, 105);
            paginatedView1.Name = "paginatedView1";
            paginatedView1.Size = new Size(906, 312);
            paginatedView1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(146, 54);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 1;
            label5.Text = "label5";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(301, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(485, 24);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(504, 61);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 4;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(344, 65);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 476);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormMain";
            Text = "Админ-панель";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tpAddNewTokens.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tpHistory.ResumeLayout(false);
            tpHistory.PerformLayout();
            tpListTokens.ResumeLayout(false);
            tpListTokens.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAllTkn).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslCurrentMode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpAddNewTokens;
        private System.Windows.Forms.TabPage tpHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSwitchToGraceful;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonUpdateTokensList;
        private System.Windows.Forms.CheckedListBox clbTokensList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonActivateSelectedTokens;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton toolStripDropDownButtonEnv;
        private ToolStripMenuItem devToolStripMenuItem;
        private ToolStripMenuItem prodToolStripMenuItem;
        private TabPage tpListTokens;
        private DataGridView dgvAllTkn;
        private Button btnAllTknPrev;
        private Button btnAllTknNext;
        private Button btnAllTknSearch;
        private TextBox txtAllTknSearch;
        private Label label4;
        private Button btnTknNext;
        private Button btnTknPrev;
        private Label lblPgInfo;
        private ToolTip toolTip1;
        private CheckBox cbOnlyActive;
        private CheckBox cbOnlyLinked;
        private Button btnDeleteInactive;
        private Button btnDeleteUnlinked;
        private GroupBox groupBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label LblAllTkn;
        private GroupBox groupBox5;
        private DataGridViewTextBoxColumn columnId;
        private DataGridViewTextBoxColumn ColumnFingerprint;
        private DataGridViewTextBoxColumn ColumnPubkey;
        private DataGridViewCheckBoxColumn ColumnIsActive;
        private DataGridViewCheckBoxColumn ColumnCanResetPassword;
        private DataGridViewTextBoxColumn ColumnLastActivated;
        private DataGridViewTextBoxColumn ColumnAllowedIps;
        private DataGridViewTextBoxColumn ColumnUserID;
        private DataGridViewTextBoxColumn ColumnUserAddInfo;
        private TabPage tabPage1;
        private CheckBox checkBox1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Label label5;
        private PaginatedView paginatedView1;
    }
}

