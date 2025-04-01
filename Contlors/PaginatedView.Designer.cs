﻿namespace diplomaadminpanel
{
    partial class PaginatedView
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            lblPage = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            dgvView = new DataGridView();
            pnlBtns = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvView).BeginInit();
            pnlBtns.SuspendLayout();
            SuspendLayout();
            // 
            // lblPage
            // 
            lblPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPage.Location = new Point(53, 0);
            lblPage.Margin = new Padding(0);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(64, 42);
            lblPage.TabIndex = 18;
            lblPage.Text = "? / ?";
            lblPage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Enabled = false;
            btnNext.Location = new Point(119, 0);
            btnNext.Margin = new Padding(0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(50, 42);
            btnNext.TabIndex = 17;
            btnNext.Text = "->";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            btnPrev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrev.Enabled = false;
            btnPrev.Location = new Point(3, 0);
            btnPrev.Margin = new Padding(0);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(50, 42);
            btnPrev.TabIndex = 16;
            btnPrev.Text = "<-";
            btnPrev.UseVisualStyleBackColor = true;
            // 
            // dgvView
            // 
            dgvView.AllowUserToAddRows = false;
            dgvView.AllowUserToDeleteRows = false;
            dgvView.AllowUserToResizeRows = false;
            dgvView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgvView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvView.Location = new Point(0, 50);
            dgvView.Margin = new Padding(0);
            dgvView.MultiSelect = false;
            dgvView.Name = "dgvView";
            dgvView.ReadOnly = true;
            dgvView.RowHeadersVisible = false;
            dgvView.RowHeadersWidth = 62;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Size = new Size(714, 450);
            dgvView.TabIndex = 15;
            dgvView.CellContentClick += dgvView_CellContentClick;
            dgvView.CellDoubleClick += dgvView_CellDoubleClick;
            // 
            // pnlBtns
            // 
            pnlBtns.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlBtns.Controls.Add(btnNext);
            pnlBtns.Controls.Add(lblPage);
            pnlBtns.Controls.Add(btnPrev);
            pnlBtns.Location = new Point(546, 0);
            pnlBtns.Margin = new Padding(0);
            pnlBtns.Name = "pnlBtns";
            pnlBtns.Size = new Size(169, 50);
            pnlBtns.TabIndex = 19;
            // 
            // PaginatedView
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(pnlBtns);
            Controls.Add(dgvView);
            Margin = new Padding(4, 5, 4, 5);
            Name = "PaginatedView";
            Size = new Size(714, 500);
            Load += PaginatedView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvView).EndInit();
            pnlBtns.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblPage;
        private Button btnNext;
        private Button btnPrev;
        private DataGridView dgvView;
        private Panel pnlBtns;
    }
}
