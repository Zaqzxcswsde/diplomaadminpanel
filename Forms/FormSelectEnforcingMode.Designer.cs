namespace diplomaadminpanel.Forms
{
    partial class FormSelectEnforcingMode
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
            gbModes = new GroupBox();
            rbGr = new RadioButton();
            rbOf = new RadioButton();
            rbOn = new RadioButton();
            btnOk = new Button();
            btnCancel = new Button();
            gbModes.SuspendLayout();
            SuspendLayout();
            // 
            // gbModes
            // 
            gbModes.Controls.Add(rbGr);
            gbModes.Controls.Add(rbOf);
            gbModes.Controls.Add(rbOn);
            gbModes.Location = new Point(12, 12);
            gbModes.Name = "gbModes";
            gbModes.Size = new Size(120, 100);
            gbModes.TabIndex = 0;
            gbModes.TabStop = false;
            gbModes.Text = "Выберите режим";
            // 
            // rbGr
            // 
            rbGr.AutoSize = true;
            rbGr.Location = new Point(6, 47);
            rbGr.Name = "rbGr";
            rbGr.Size = new Size(36, 19);
            rbGr.TabIndex = 2;
            rbGr.TabStop = true;
            rbGr.Text = "gr";
            rbGr.UseVisualStyleBackColor = true;
            // 
            // rbOf
            // 
            rbOf.AutoSize = true;
            rbOf.Location = new Point(6, 72);
            rbOf.Name = "rbOf";
            rbOf.Size = new Size(36, 19);
            rbOf.TabIndex = 3;
            rbOf.TabStop = true;
            rbOf.Text = "of";
            rbOf.UseVisualStyleBackColor = true;
            // 
            // rbOn
            // 
            rbOn.AutoSize = true;
            rbOn.Location = new Point(6, 22);
            rbOn.Name = "rbOn";
            rbOn.Size = new Size(39, 19);
            rbOn.TabIndex = 1;
            rbOn.TabStop = true;
            rbOn.Text = "on";
            rbOn.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(12, 118);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(37, 23);
            btnOk.TabIndex = 4;
            btnOk.TabStop = false;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(55, 118);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(77, 23);
            btnCancel.TabIndex = 5;
            btnCancel.TabStop = false;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormSelectEnforcingMode
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(144, 153);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(gbModes);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSelectEnforcingMode";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Выбор";
            Load += FormSelectEnforcingMode_Load;
            gbModes.ResumeLayout(false);
            gbModes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbModes;
        private RadioButton rbGr;
        private RadioButton rbOf;
        private RadioButton rbOn;
        private Button btnOk;
        private Button btnCancel;
    }
}