namespace Dormitory
{
    partial class violation_control
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(violation_control));
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FieldDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.FieldArticle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FieldNumber = new System.Windows.Forms.TextBox();
            this.Table = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.article = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ButtonSelect = new System.Windows.Forms.Button();
            this.ButtonCheckSelect = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(16, 242);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 0;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(188, 242);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Номер статьи";
            // 
            // FieldDate
            // 
            this.FieldDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FieldDate.Location = new System.Drawing.Point(15, 32);
            this.FieldDate.Name = "FieldDate";
            this.FieldDate.Size = new System.Drawing.Size(276, 20);
            this.FieldDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата приказа";
            // 
            // FieldArticle
            // 
            this.FieldArticle.Location = new System.Drawing.Point(16, 83);
            this.FieldArticle.Multiline = true;
            this.FieldArticle.Name = "FieldArticle";
            this.FieldArticle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FieldArticle.Size = new System.Drawing.Size(247, 148);
            this.FieldArticle.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Пункт, подпункт";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Введите новое нарушение ...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "... или выберите из существующего";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.FieldNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ButtonOk);
            this.panel1.Controls.Add(this.ButtonCancel);
            this.panel1.Controls.Add(this.FieldArticle);
            this.panel1.Location = new System.Drawing.Point(12, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 278);
            this.panel1.TabIndex = 10;
            // 
            // FieldNumber
            // 
            this.FieldNumber.Location = new System.Drawing.Point(16, 32);
            this.FieldNumber.Name = "FieldNumber";
            this.FieldNumber.Size = new System.Drawing.Size(247, 20);
            this.FieldNumber.TabIndex = 8;
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.article});
            this.Table.Dock = System.Windows.Forms.DockStyle.Top;
            this.Table.Location = new System.Drawing.Point(0, 0);
            this.Table.MultiSelect = false;
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            this.Table.RowHeadersVisible = false;
            this.Table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Table.Size = new System.Drawing.Size(279, 231);
            this.Table.TabIndex = 12;
            // 
            // number
            // 
            this.number.HeaderText = "Номер статьи";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.number.Width = 90;
            // 
            // article
            // 
            this.article.HeaderText = "Пунк, подпункт";
            this.article.Name = "article";
            this.article.ReadOnly = true;
            this.article.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.article.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.article.Width = 185;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.Table);
            this.panel2.Location = new System.Drawing.Point(316, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 278);
            this.panel2.TabIndex = 13;
            this.panel2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.ButtonSelect);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 229);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 49);
            this.panel3.TabIndex = 14;
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonSelect.Location = new System.Drawing.Point(0, 0);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(279, 49);
            this.ButtonSelect.TabIndex = 0;
            this.ButtonSelect.Text = "Выбрать";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // ButtonCheckSelect
            // 
            this.ButtonCheckSelect.Appearance = System.Windows.Forms.Appearance.Button;
            this.ButtonCheckSelect.Location = new System.Drawing.Point(207, 385);
            this.ButtonCheckSelect.Name = "ButtonCheckSelect";
            this.ButtonCheckSelect.Size = new System.Drawing.Size(84, 24);
            this.ButtonCheckSelect.TabIndex = 14;
            this.ButtonCheckSelect.Text = "Выбрать";
            this.ButtonCheckSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonCheckSelect.UseVisualStyleBackColor = true;
            this.ButtonCheckSelect.CheckedChanged += new System.EventHandler(this.ButtonCheckSelect_CheckedChanged);
            // 
            // violation_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(305, 421);
            this.Controls.Add(this.ButtonCheckSelect);
            this.Controls.Add(this.FieldDate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "violation_control";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить нарушение";
            this.Load += new System.EventHandler(this.violation_control_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FieldDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FieldArticle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox FieldNumber;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn article;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ButtonSelect;
        private System.Windows.Forms.CheckBox ButtonCheckSelect;
    }
}