namespace diplomaadminpanel
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
            ((System.ComponentModel.ISupportInitialize)dgvView).BeginInit();
            SuspendLayout();
            // 
            // lblPage
            // 
            lblPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPage.Location = new Point(491, 4);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(46, 23);
            lblPage.TabIndex = 18;
            lblPage.Text = "? / ?";
            lblPage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Location = new Point(543, 4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(33, 23);
            btnNext.TabIndex = 17;
            btnNext.Text = "->";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            btnPrev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrev.Location = new Point(452, 4);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(33, 23);
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
            dgvView.Location = new Point(3, 33);
            dgvView.MultiSelect = false;
            dgvView.Name = "dgvView";
            dgvView.ReadOnly = true;
            dgvView.RowHeadersVisible = false;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Size = new Size(573, 276);
            dgvView.TabIndex = 15;
            dgvView.CellDoubleClick += this.dgvView_CellDoubleClick;
            // 
            // PaginatedView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPage);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(dgvView);
            Name = "PaginatedView";
            Size = new Size(579, 312);
            Load += PaginatedView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblPage;
        private Button btnNext;
        private Button btnPrev;
        private DataGridView dgvView;
    }
}
