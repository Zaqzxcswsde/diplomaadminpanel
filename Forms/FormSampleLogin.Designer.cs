namespace diplomaadminpanel.Forms
{
    partial class FormSampleLogin
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
            BtnSimulateLogin = new Button();
            txtLogin = new TextBox();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            SuspendLayout();
            // 
            // BtnSimulateLogin
            // 
            BtnSimulateLogin.Location = new Point(14, 64);
            BtnSimulateLogin.Margin = new Padding(4, 3, 4, 3);
            BtnSimulateLogin.Name = "BtnSimulateLogin";
            BtnSimulateLogin.Size = new Size(237, 27);
            BtnSimulateLogin.TabIndex = 0;
            BtnSimulateLogin.Text = "Симуляция логина";
            BtnSimulateLogin.UseVisualStyleBackColor = true;
            BtnSimulateLogin.Click += BtnSimulateLogin_Click;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(14, 35);
            txtLogin.Margin = new Padding(4, 3, 4, 3);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(237, 23);
            txtLogin.TabIndex = 1;
            // 
            // label1
            // 
            label1.Location = new Point(14, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(237, 23);
            label1.TabIndex = 2;
            label1.Text = "Введите ID пользователя в поле ниже";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            progressBar1.Enabled = false;
            progressBar1.Location = new Point(14, 97);
            progressBar1.Margin = new Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(237, 27);
            progressBar1.TabIndex = 5;
            // 
            // timer1
            // 
            timer1.Interval = 2000;
            timer1.Tick += timer1_Tick;
            // 
            // label3
            // 
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(14, 127);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(237, 17);
            label3.TabIndex = 6;
            label3.Text = "Ожидание команды";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // FormSampleLogin
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(267, 150);
            Controls.Add(label3);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(txtLogin);
            Controls.Add(BtnSimulateLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSampleLogin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Симуляция логина";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSimulateLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
    }
}

