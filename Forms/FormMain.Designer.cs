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
            toolStripDropDownButtonTools = new ToolStripDropDownButton();
            tsmSimulateLogin = new ToolStripMenuItem();
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
            groupBox8 = new GroupBox();
            lblHistFilterAmount = new Label();
            btnFilterHistory = new Button();
            btnHistClearFilters = new Button();
            groupBox7 = new GroupBox();
            cbHistUnsuccessful = new CheckBox();
            cbHistSuccessfull = new CheckBox();
            groupBox6 = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            dtpHistFrom = new DateTimePicker();
            dtpHistTo = new DateTimePicker();
            btnSearchHistory = new Button();
            cbHistAutoupdate = new CheckBox();
            txtSearchHist = new TextBox();
            label5 = new Label();
            pgViewHist = new PaginatedView();
            tpListTokens = new TabPage();
            groupBox5 = new GroupBox();
            cbOnlyActive = new CheckBox();
            cbOnlyLinked = new CheckBox();
            groupBox4 = new GroupBox();
            btnDeleteUnlinked = new Button();
            btnDeleteInactive = new Button();
            btnAllTknSearch = new Button();
            txtAllTknSearch = new TextBox();
            label4 = new Label();
            pgViewAllTokens = new PaginatedView();
            tpAllUsers = new TabPage();
            groupBox11 = new GroupBox();
            cbUserOrdering = new ComboBox();
            groupBox10 = new GroupBox();
            label10 = new Label();
            label9 = new Label();
            dtpUsersTo = new DateTimePicker();
            dtpUsersFrom = new DateTimePicker();
            gbFilterUser = new GroupBox();
            cbOnlyLinkedUsers = new CheckBox();
            groupBox9 = new GroupBox();
            cbAllowUsersDeletion = new CheckBox();
            label8 = new Label();
            txtAllUsersSearch = new TextBox();
            btnAllUsersSearch = new Button();
            pgViewAllUsers = new PaginatedView();
            toolTip1 = new ToolTip(components);
            tmrAutoUpdateHistory = new System.Windows.Forms.Timer(components);
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tpAddNewTokens.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tpHistory.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            tpListTokens.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            tpAllUsers.SuspendLayout();
            groupBox11.SuspendLayout();
            groupBox10.SuspendLayout();
            gbFilterUser.SuspendLayout();
            groupBox9.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tslCurrentMode, toolStripSeparator1, toolStripDropDownButtonEnv, toolStripDropDownButtonTools });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(929, 25);
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
            // toolStripDropDownButtonTools
            // 
            toolStripDropDownButtonTools.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButtonTools.DropDownItems.AddRange(new ToolStripItem[] { tsmSimulateLogin });
            toolStripDropDownButtonTools.Image = (Image)resources.GetObject("toolStripDropDownButtonTools.Image");
            toolStripDropDownButtonTools.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButtonTools.Name = "toolStripDropDownButtonTools";
            toolStripDropDownButtonTools.Size = new Size(96, 22);
            toolStripDropDownButtonTools.Text = "Инструменты";
            // 
            // tsmSimulateLogin
            // 
            tsmSimulateLogin.Name = "tsmSimulateLogin";
            tsmSimulateLogin.Size = new Size(180, 22);
            tsmSimulateLogin.Text = "Симуляция Логина";
            tsmSimulateLogin.Click += tsmSimulateLogin_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpAddNewTokens);
            tabControl1.Controls.Add(tpHistory);
            tabControl1.Controls.Add(tpListTokens);
            tabControl1.Controls.Add(tpAllUsers);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 25);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(929, 451);
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
            tpAddNewTokens.Size = new Size(921, 423);
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
            tpHistory.Controls.Add(groupBox8);
            tpHistory.Controls.Add(groupBox7);
            tpHistory.Controls.Add(groupBox6);
            tpHistory.Controls.Add(btnSearchHistory);
            tpHistory.Controls.Add(cbHistAutoupdate);
            tpHistory.Controls.Add(txtSearchHist);
            tpHistory.Controls.Add(label5);
            tpHistory.Controls.Add(pgViewHist);
            tpHistory.Location = new Point(4, 24);
            tpHistory.Margin = new Padding(4, 3, 4, 3);
            tpHistory.Name = "tpHistory";
            tpHistory.Padding = new Padding(4, 3, 4, 3);
            tpHistory.Size = new Size(921, 423);
            tpHistory.TabIndex = 1;
            tpHistory.Text = "История";
            tpHistory.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(lblHistFilterAmount);
            groupBox8.Controls.Add(btnFilterHistory);
            groupBox8.Controls.Add(btnHistClearFilters);
            groupBox8.Location = new Point(471, 7);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(227, 103);
            groupBox8.TabIndex = 13;
            groupBox8.TabStop = false;
            groupBox8.Text = "Фильтр по ошибке";
            // 
            // lblHistFilterAmount
            // 
            lblHistFilterAmount.Location = new Point(4, 72);
            lblHistFilterAmount.Name = "lblHistFilterAmount";
            lblHistFilterAmount.Size = new Size(217, 25);
            lblHistFilterAmount.TabIndex = 11;
            lblHistFilterAmount.Text = "Выбрано фильтров: 0";
            lblHistFilterAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnFilterHistory
            // 
            btnFilterHistory.Location = new Point(4, 22);
            btnFilterHistory.Name = "btnFilterHistory";
            btnFilterHistory.Size = new Size(131, 49);
            btnFilterHistory.TabIndex = 6;
            btnFilterHistory.Text = "Выбрать фильтр";
            btnFilterHistory.UseVisualStyleBackColor = true;
            btnFilterHistory.Click += btnFilterHistory_Click;
            // 
            // btnHistClearFilters
            // 
            btnHistClearFilters.Enabled = false;
            btnHistClearFilters.Location = new Point(141, 22);
            btnHistClearFilters.Name = "btnHistClearFilters";
            btnHistClearFilters.Size = new Size(80, 49);
            btnHistClearFilters.TabIndex = 10;
            btnHistClearFilters.Text = "Сбросить";
            btnHistClearFilters.UseVisualStyleBackColor = true;
            btnHistClearFilters.Click += btnHistClearFilters_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(cbHistUnsuccessful);
            groupBox7.Controls.Add(cbHistSuccessfull);
            groupBox7.Location = new Point(138, 35);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(104, 74);
            groupBox7.TabIndex = 12;
            groupBox7.TabStop = false;
            groupBox7.Text = "Результат";
            // 
            // cbHistUnsuccessful
            // 
            cbHistUnsuccessful.AutoSize = true;
            cbHistUnsuccessful.Checked = true;
            cbHistUnsuccessful.CheckState = CheckState.Checked;
            cbHistUnsuccessful.Location = new Point(6, 47);
            cbHistUnsuccessful.Name = "cbHistUnsuccessful";
            cbHistUnsuccessful.Size = new Size(94, 19);
            cbHistUnsuccessful.TabIndex = 9;
            cbHistUnsuccessful.Text = "Безуспешно";
            cbHistUnsuccessful.UseVisualStyleBackColor = true;
            cbHistUnsuccessful.CheckedChanged += cbHistUnsuccessful_CheckedChanged;
            // 
            // cbHistSuccessfull
            // 
            cbHistSuccessfull.AutoSize = true;
            cbHistSuccessfull.Checked = true;
            cbHistSuccessfull.CheckState = CheckState.Checked;
            cbHistSuccessfull.Location = new Point(6, 22);
            cbHistSuccessfull.Name = "cbHistSuccessfull";
            cbHistSuccessfull.Size = new Size(77, 19);
            cbHistSuccessfull.TabIndex = 8;
            cbHistSuccessfull.Text = "Успешно";
            cbHistSuccessfull.UseVisualStyleBackColor = true;
            cbHistSuccessfull.CheckedChanged += cbHistSuccessfull_CheckedChanged;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label7);
            groupBox6.Controls.Add(label6);
            groupBox6.Controls.Add(dtpHistFrom);
            groupBox6.Controls.Add(dtpHistTo);
            groupBox6.Location = new Point(248, 35);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(217, 74);
            groupBox6.TabIndex = 11;
            groupBox6.TabStop = false;
            groupBox6.Text = "Фильтр по времени";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 48);
            label7.Name = "label7";
            label7.Size = new Size(21, 15);
            label7.TabIndex = 6;
            label7.Text = "От";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 22);
            label6.Name = "label6";
            label6.Size = new Size(22, 15);
            label6.TabIndex = 5;
            label6.Text = "До";
            // 
            // dtpHistFrom
            // 
            dtpHistFrom.Checked = false;
            dtpHistFrom.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dtpHistFrom.Format = DateTimePickerFormat.Custom;
            dtpHistFrom.Location = new Point(34, 44);
            dtpHistFrom.Name = "dtpHistFrom";
            dtpHistFrom.ShowCheckBox = true;
            dtpHistFrom.Size = new Size(175, 23);
            dtpHistFrom.TabIndex = 3;
            dtpHistFrom.ValueChanged += dtpHistFrom_ValueChanged;
            dtpHistFrom.EnabledChanged += dtpHistFrom_EnabledChanged;
            // 
            // dtpHistTo
            // 
            dtpHistTo.Checked = false;
            dtpHistTo.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dtpHistTo.Format = DateTimePickerFormat.Custom;
            dtpHistTo.Location = new Point(34, 18);
            dtpHistTo.Name = "dtpHistTo";
            dtpHistTo.ShowCheckBox = true;
            dtpHistTo.Size = new Size(175, 23);
            dtpHistTo.TabIndex = 4;
            dtpHistTo.ValueChanged += dtpHistTo_ValueChanged;
            // 
            // btnSearchHistory
            // 
            btnSearchHistory.Location = new Point(703, 6);
            btnSearchHistory.Name = "btnSearchHistory";
            btnSearchHistory.Size = new Size(209, 42);
            btnSearchHistory.TabIndex = 7;
            btnSearchHistory.Text = "Искать";
            btnSearchHistory.UseVisualStyleBackColor = true;
            btnSearchHistory.Click += btnSearchHistory_Click;
            // 
            // cbHistAutoupdate
            // 
            cbHistAutoupdate.AutoSize = true;
            cbHistAutoupdate.Location = new Point(717, 58);
            cbHistAutoupdate.Name = "cbHistAutoupdate";
            cbHistAutoupdate.Size = new Size(187, 19);
            cbHistAutoupdate.TabIndex = 5;
            cbHistAutoupdate.Text = "Автоматическое обновление";
            cbHistAutoupdate.UseVisualStyleBackColor = true;
            cbHistAutoupdate.CheckedChanged += cbHistAutoupdate_CheckedChanged;
            // 
            // txtSearchHist
            // 
            txtSearchHist.Location = new Point(138, 6);
            txtSearchHist.Name = "txtSearchHist";
            txtSearchHist.Size = new Size(327, 23);
            txtSearchHist.TabIndex = 2;
            txtSearchHist.KeyDown += txtSearchHist_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 12);
            label5.Name = "label5";
            label5.Size = new Size(124, 90);
            label5.TabIndex = 1;
            label5.Text = "Можно искать по:\r\n- отпечатку\r\n(с пробелами и без)\r\n- доп. данным\r\n- IP\r\n- публичному ключу";
            // 
            // pgViewHist
            // 
            pgViewHist.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pgViewHist.Location = new Point(6, 85);
            pgViewHist.Name = "pgViewHist";
            pgViewHist.Size = new Size(909, 332);
            pgViewHist.TabIndex = 0;
            pgViewHist.TabStop = false;
            // 
            // tpListTokens
            // 
            tpListTokens.Controls.Add(groupBox5);
            tpListTokens.Controls.Add(groupBox4);
            tpListTokens.Controls.Add(btnAllTknSearch);
            tpListTokens.Controls.Add(txtAllTknSearch);
            tpListTokens.Controls.Add(label4);
            tpListTokens.Controls.Add(pgViewAllTokens);
            tpListTokens.Location = new Point(4, 24);
            tpListTokens.Name = "tpListTokens";
            tpListTokens.Padding = new Padding(3);
            tpListTokens.Size = new Size(921, 423);
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
            groupBox5.Size = new Size(157, 103);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "Фильтр";
            // 
            // cbOnlyActive
            // 
            cbOnlyActive.AutoSize = true;
            cbOnlyActive.Location = new Point(6, 30);
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
            cbOnlyLinked.Checked = true;
            cbOnlyLinked.CheckState = CheckState.Checked;
            cbOnlyLinked.Location = new Point(6, 68);
            cbOnlyLinked.Name = "cbOnlyLinked";
            cbOnlyLinked.Size = new Size(141, 19);
            cbOnlyLinked.TabIndex = 6;
            cbOnlyLinked.Text = "Только привязанные";
            cbOnlyLinked.UseVisualStyleBackColor = true;
            cbOnlyLinked.CheckedChanged += cbOnlyLinked_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnDeleteUnlinked);
            groupBox4.Controls.Add(btnDeleteInactive);
            groupBox4.Location = new Point(621, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(294, 73);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Действия";
            // 
            // btnDeleteUnlinked
            // 
            btnDeleteUnlinked.Location = new Point(6, 22);
            btnDeleteUnlinked.Name = "btnDeleteUnlinked";
            btnDeleteUnlinked.Size = new Size(134, 45);
            btnDeleteUnlinked.TabIndex = 8;
            btnDeleteUnlinked.TabStop = false;
            btnDeleteUnlinked.Text = "Удалить непривязанные";
            btnDeleteUnlinked.UseVisualStyleBackColor = true;
            btnDeleteUnlinked.Click += btnDeleteUnlinked_Click;
            // 
            // btnDeleteInactive
            // 
            btnDeleteInactive.Location = new Point(151, 22);
            btnDeleteInactive.Name = "btnDeleteInactive";
            btnDeleteInactive.Size = new Size(137, 45);
            btnDeleteInactive.TabIndex = 9;
            btnDeleteInactive.TabStop = false;
            btnDeleteInactive.Text = "Удалить неактивные";
            btnDeleteInactive.UseVisualStyleBackColor = true;
            btnDeleteInactive.Click += btnDeleteInactive_Click;
            // 
            // btnAllTknSearch
            // 
            btnAllTknSearch.Location = new Point(206, 41);
            btnAllTknSearch.Name = "btnAllTknSearch";
            btnAllTknSearch.Size = new Size(243, 68);
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
            label4.Location = new Point(6, 6);
            label4.Name = "label4";
            label4.Size = new Size(192, 105);
            label4.TabIndex = 1;
            label4.Text = "Можно искать по:\r\n- ID\r\n- ID пользователя\r\n- отпечатку (с пробелами и без)\r\n- публичному ключу\r\n- IP\r\n- доп. информации пользователя";
            toolTip1.SetToolTip(label4, "Можно искать по:\r\n- отпечатку\r\n- ID (+пользователя)\r\n- публичному ключу\r\n- IP\r\n- доп. информации пользователя");
            // 
            // pgViewAllTokens
            // 
            pgViewAllTokens.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pgViewAllTokens.Location = new Point(6, 85);
            pgViewAllTokens.Name = "pgViewAllTokens";
            pgViewAllTokens.Size = new Size(909, 332);
            pgViewAllTokens.TabIndex = 13;
            // 
            // tpAllUsers
            // 
            tpAllUsers.Controls.Add(groupBox11);
            tpAllUsers.Controls.Add(groupBox10);
            tpAllUsers.Controls.Add(gbFilterUser);
            tpAllUsers.Controls.Add(groupBox9);
            tpAllUsers.Controls.Add(label8);
            tpAllUsers.Controls.Add(txtAllUsersSearch);
            tpAllUsers.Controls.Add(btnAllUsersSearch);
            tpAllUsers.Controls.Add(pgViewAllUsers);
            tpAllUsers.Location = new Point(4, 24);
            tpAllUsers.Name = "tpAllUsers";
            tpAllUsers.Padding = new Padding(3);
            tpAllUsers.Size = new Size(921, 423);
            tpAllUsers.TabIndex = 3;
            tpAllUsers.Text = "Управление пользователями";
            tpAllUsers.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(cbUserOrdering);
            groupBox11.Location = new Point(206, 6);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new Size(161, 78);
            groupBox11.TabIndex = 12;
            groupBox11.TabStop = false;
            groupBox11.Text = "Сортировка";
            // 
            // cbUserOrdering
            // 
            cbUserOrdering.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUserOrdering.Location = new Point(6, 33);
            cbUserOrdering.Name = "cbUserOrdering";
            cbUserOrdering.Size = new Size(149, 23);
            cbUserOrdering.TabIndex = 0;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(label10);
            groupBox10.Controls.Add(label9);
            groupBox10.Controls.Add(dtpUsersTo);
            groupBox10.Controls.Add(dtpUsersFrom);
            groupBox10.Location = new Point(373, 6);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(206, 78);
            groupBox10.TabIndex = 11;
            groupBox10.TabStop = false;
            groupBox10.Text = "Последний вход";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 51);
            label10.Name = "label10";
            label10.Size = new Size(21, 15);
            label10.TabIndex = 13;
            label10.Text = "От";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 22);
            label9.Name = "label9";
            label9.Size = new Size(22, 15);
            label9.TabIndex = 12;
            label9.Text = "До";
            // 
            // dtpUsersTo
            // 
            dtpUsersTo.Checked = false;
            dtpUsersTo.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dtpUsersTo.Format = DateTimePickerFormat.Custom;
            dtpUsersTo.Location = new Point(34, 18);
            dtpUsersTo.Name = "dtpUsersTo";
            dtpUsersTo.ShowCheckBox = true;
            dtpUsersTo.Size = new Size(163, 23);
            dtpUsersTo.TabIndex = 7;
            dtpUsersTo.ValueChanged += dtpUsersTo_ValueChanged;
            // 
            // dtpUsersFrom
            // 
            dtpUsersFrom.Checked = false;
            dtpUsersFrom.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dtpUsersFrom.Format = DateTimePickerFormat.Custom;
            dtpUsersFrom.Location = new Point(34, 47);
            dtpUsersFrom.Name = "dtpUsersFrom";
            dtpUsersFrom.ShowCheckBox = true;
            dtpUsersFrom.Size = new Size(163, 23);
            dtpUsersFrom.TabIndex = 8;
            dtpUsersFrom.ValueChanged += dtpUsersFrom_ValueChanged;
            // 
            // gbFilterUser
            // 
            gbFilterUser.Controls.Add(cbOnlyLinkedUsers);
            gbFilterUser.Location = new Point(585, 6);
            gbFilterUser.Name = "gbFilterUser";
            gbFilterUser.Size = new Size(144, 50);
            gbFilterUser.TabIndex = 10;
            gbFilterUser.TabStop = false;
            gbFilterUser.Text = "Фильтр";
            // 
            // cbOnlyLinkedUsers
            // 
            cbOnlyLinkedUsers.AutoSize = true;
            cbOnlyLinkedUsers.Checked = true;
            cbOnlyLinkedUsers.CheckState = CheckState.Checked;
            cbOnlyLinkedUsers.Location = new Point(6, 22);
            cbOnlyLinkedUsers.Name = "cbOnlyLinkedUsers";
            cbOnlyLinkedUsers.Size = new Size(130, 19);
            cbOnlyLinkedUsers.TabIndex = 5;
            cbOnlyLinkedUsers.Text = "Только с токенами";
            cbOnlyLinkedUsers.UseVisualStyleBackColor = true;
            cbOnlyLinkedUsers.CheckedChanged += cbOnlyLinkedUsers_CheckedChanged;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(cbAllowUsersDeletion);
            groupBox9.Location = new Point(735, 6);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(180, 50);
            groupBox9.TabIndex = 9;
            groupBox9.TabStop = false;
            groupBox9.Text = "Danger Zone";
            // 
            // cbAllowUsersDeletion
            // 
            cbAllowUsersDeletion.AutoCheck = false;
            cbAllowUsersDeletion.AutoSize = true;
            cbAllowUsersDeletion.Location = new Point(6, 22);
            cbAllowUsersDeletion.Name = "cbAllowUsersDeletion";
            cbAllowUsersDeletion.Size = new Size(169, 19);
            cbAllowUsersDeletion.TabIndex = 4;
            cbAllowUsersDeletion.Text = "Разблокировать удаление";
            cbAllowUsersDeletion.UseVisualStyleBackColor = true;
            cbAllowUsersDeletion.CheckedChanged += cbAllowUsersDeletion_CheckedChanged;
            cbAllowUsersDeletion.Click += cbAllowUsersDeletion_Click;
            // 
            // label8
            // 
            label8.Location = new Point(8, 6);
            label8.Name = "label8";
            label8.Size = new Size(192, 104);
            label8.TabIndex = 6;
            label8.Text = "Можно искать по:\r\n- Доп. сведениям\r\n- Отпечатку\r\n(с пробелами и без)\r\n- Публичному ключу";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAllUsersSearch
            // 
            txtAllUsersSearch.Location = new Point(206, 87);
            txtAllUsersSearch.Name = "txtAllUsersSearch";
            txtAllUsersSearch.Size = new Size(373, 23);
            txtAllUsersSearch.TabIndex = 3;
            txtAllUsersSearch.KeyDown += txtAllUsersSearch_KeyDown;
            // 
            // btnAllUsersSearch
            // 
            btnAllUsersSearch.Location = new Point(585, 62);
            btnAllUsersSearch.Name = "btnAllUsersSearch";
            btnAllUsersSearch.Size = new Size(208, 48);
            btnAllUsersSearch.TabIndex = 1;
            btnAllUsersSearch.Text = "Искать";
            btnAllUsersSearch.UseVisualStyleBackColor = true;
            btnAllUsersSearch.Click += btnAllUsersSearch_Click;
            // 
            // pgViewAllUsers
            // 
            pgViewAllUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pgViewAllUsers.Location = new Point(6, 85);
            pgViewAllUsers.Name = "pgViewAllUsers";
            pgViewAllUsers.Size = new Size(909, 332);
            pgViewAllUsers.TabIndex = 0;
            // 
            // toolTip1
            // 
            toolTip1.Tag = "(можно искать по ...)";
            // 
            // tmrAutoUpdateHistory
            // 
            tmrAutoUpdateHistory.Interval = 3000;
            tmrAutoUpdateHistory.Tick += tmrAutoUpdateHistory_Tick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 476);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimumSize = new Size(945, 515);
            Name = "FormMain";
            Text = "Админ-панель";
            Load += Form1_Load;
            Shown += FormMain_Shown;
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
            groupBox8.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            tpListTokens.ResumeLayout(false);
            tpListTokens.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            tpAllUsers.ResumeLayout(false);
            tpAllUsers.PerformLayout();
            groupBox11.ResumeLayout(false);
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            gbFilterUser.ResumeLayout(false);
            gbFilterUser.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
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
        private GroupBox groupBox5;
        private TabPage tpAllUsers;
        private CheckBox cbHistAutoupdate;
        private DateTimePicker dtpHistTo;
        private DateTimePicker dtpHistFrom;
        private TextBox txtSearchHist;
        private Label label5;
        private PaginatedView pgViewHist;
        private Button btnFilterHistory;
        private Button btnSearchHistory;
        private CheckBox cbHistSuccessfull;
        private CheckBox cbHistUnsuccessful;
        private System.Windows.Forms.Timer tmrAutoUpdateHistory;
        private Button btnHistClearFilters;
        private GroupBox groupBox6;
        private Label label7;
        private Label label6;
        private GroupBox groupBox8;
        private Label lblHistFilterAmount;
        private GroupBox groupBox7;
        private ToolStripDropDownButton toolStripDropDownButtonTools;
        private ToolStripMenuItem tsmSimulateLogin;
        private Button btnAllUsersSearch;
        private PaginatedView pgViewAllUsers;
        private PaginatedView pgViewAllTokens;
        private CheckBox cbAllowUsersDeletion;
        private TextBox txtAllUsersSearch;
        private CheckBox cbOnlyLinkedUsers;
        private Label label8;
        private GroupBox groupBox9;
        private DateTimePicker dtpUsersFrom;
        private DateTimePicker dtpUsersTo;
        private GroupBox gbFilterUser;
        private GroupBox groupBox10;
        private GroupBox groupBox11;
        private ComboBox cbUserOrdering;
        private Label label10;
        private Label label9;
    }
}

