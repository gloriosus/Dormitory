namespace Dormitory
{
    partial class Table_country
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Table_country));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FieldNominal = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonFind = new System.Windows.Forms.Button();
            this.FieldSearch = new System.Windows.Forms.TextBox();
            this.FieldSearchCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ButtonSort = new System.Windows.Forms.Button();
            this.FieldSortOrder = new System.Windows.Forms.ComboBox();
            this.FieldSortCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Table = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(345, 136);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ButtonDelete);
            this.tabPage1.Controls.Add(this.ButtonEdit);
            this.tabPage1.Controls.Add(this.ButtonAdd);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.FieldNominal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(337, 110);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Редактирование";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(240, 57);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelete.TabIndex = 4;
            this.ButtonDelete.Text = "Удалить";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(159, 57);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 23);
            this.ButtonEdit.TabIndex = 3;
            this.ButtonEdit.Text = "Изменить";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(78, 57);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 2;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название";
            // 
            // FieldNominal
            // 
            this.FieldNominal.Location = new System.Drawing.Point(78, 31);
            this.FieldNominal.Name = "FieldNominal";
            this.FieldNominal.Size = new System.Drawing.Size(156, 20);
            this.FieldNominal.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ButtonReset);
            this.tabPage2.Controls.Add(this.ButtonFind);
            this.tabPage2.Controls.Add(this.FieldSearch);
            this.tabPage2.Controls.Add(this.FieldSearchCategory);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(337, 110);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Поиск";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(226, 69);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 5;
            this.ButtonReset.Text = "Сбросить";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // ButtonFind
            // 
            this.ButtonFind.Location = new System.Drawing.Point(145, 69);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(75, 23);
            this.ButtonFind.TabIndex = 4;
            this.ButtonFind.Text = "Найти";
            this.ButtonFind.UseVisualStyleBackColor = true;
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // FieldSearch
            // 
            this.FieldSearch.Location = new System.Drawing.Point(145, 43);
            this.FieldSearch.Name = "FieldSearch";
            this.FieldSearch.Size = new System.Drawing.Size(156, 20);
            this.FieldSearch.TabIndex = 3;
            // 
            // FieldSearchCategory
            // 
            this.FieldSearchCategory.FormattingEnabled = true;
            this.FieldSearchCategory.Items.AddRange(new object[] {
            "ID",
            "Название"});
            this.FieldSearchCategory.Location = new System.Drawing.Point(145, 16);
            this.FieldSearchCategory.Name = "FieldSearchCategory";
            this.FieldSearchCategory.Size = new System.Drawing.Size(156, 21);
            this.FieldSearchCategory.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Что искать";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "По какому полю искать";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ButtonSort);
            this.tabPage3.Controls.Add(this.FieldSortOrder);
            this.tabPage3.Controls.Add(this.FieldSortCategory);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(337, 110);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Сортировка";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ButtonSort
            // 
            this.ButtonSort.Location = new System.Drawing.Point(183, 70);
            this.ButtonSort.Name = "ButtonSort";
            this.ButtonSort.Size = new System.Drawing.Size(121, 23);
            this.ButtonSort.TabIndex = 4;
            this.ButtonSort.Text = "Сортировать";
            this.ButtonSort.UseVisualStyleBackColor = true;
            this.ButtonSort.Click += new System.EventHandler(this.ButtonSort_Click);
            // 
            // FieldSortOrder
            // 
            this.FieldSortOrder.FormattingEnabled = true;
            this.FieldSortOrder.Items.AddRange(new object[] {
            "По возрастанию",
            "По убыванию"});
            this.FieldSortOrder.Location = new System.Drawing.Point(183, 43);
            this.FieldSortOrder.Name = "FieldSortOrder";
            this.FieldSortOrder.Size = new System.Drawing.Size(121, 21);
            this.FieldSortOrder.TabIndex = 3;
            // 
            // FieldSortCategory
            // 
            this.FieldSortCategory.FormattingEnabled = true;
            this.FieldSortCategory.Items.AddRange(new object[] {
            "ID",
            "Название"});
            this.FieldSortCategory.Location = new System.Drawing.Point(183, 16);
            this.FieldSortCategory.Name = "FieldSortCategory";
            this.FieldSortCategory.Size = new System.Drawing.Size(121, 21);
            this.FieldSortCategory.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Порядок сортировки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "По какому полю сортировать";
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nominal});
            this.Table.Location = new System.Drawing.Point(12, 154);
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            this.Table.RowHeadersVisible = false;
            this.Table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Table.Size = new System.Drawing.Size(346, 327);
            this.Table.TabIndex = 1;
            this.Table.SelectionChanged += new System.EventHandler(this.Table_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 40;
            // 
            // nominal
            // 
            this.nominal.HeaderText = "Название";
            this.nominal.Name = "nominal";
            this.nominal.ReadOnly = true;
            this.nominal.Width = 300;
            // 
            // Table_country
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 493);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Table_country";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Таблица \"Страна\"";
            this.Load += new System.EventHandler(this.Table_country_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FieldNominal;
        private System.Windows.Forms.ComboBox FieldSearchCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FieldSearch;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonFind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FieldSortOrder;
        private System.Windows.Forms.ComboBox FieldSortCategory;
        private System.Windows.Forms.Button ButtonSort;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominal;
    }
}