namespace Dormitory
{
    partial class Table_violation_item
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Table_violation_item));
            this.Table = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.article = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldNumber = new System.Windows.Forms.TextBox();
            this.FieldArticle = new System.Windows.Forms.TextBox();
            this.Button_insert = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Button_delete = new System.Windows.Forms.Button();
            this.Button_edit = new System.Windows.Forms.Button();
            this.Category = new System.Windows.Forms.ComboBox();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.Button_find = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Button_reset = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ButtonSort = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Sort_order = new System.Windows.Forms.ComboBox();
            this.Sort_category = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.number,
            this.article});
            this.Table.Location = new System.Drawing.Point(11, 204);
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            this.Table.RowHeadersVisible = false;
            this.Table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Table.Size = new System.Drawing.Size(346, 279);
            this.Table.TabIndex = 0;
            this.Table.SelectionChanged += new System.EventHandler(this.Table_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 50;
            // 
            // number
            // 
            this.number.HeaderText = "Номер";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.number.Width = 90;
            // 
            // article
            // 
            this.article.HeaderText = "Статья";
            this.article.Name = "article";
            this.article.ReadOnly = true;
            this.article.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.article.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.article.Width = 200;
            // 
            // FieldNumber
            // 
            this.FieldNumber.Location = new System.Drawing.Point(97, 16);
            this.FieldNumber.Name = "FieldNumber";
            this.FieldNumber.Size = new System.Drawing.Size(156, 20);
            this.FieldNumber.TabIndex = 2;
            // 
            // FieldArticle
            // 
            this.FieldArticle.Location = new System.Drawing.Point(97, 42);
            this.FieldArticle.Multiline = true;
            this.FieldArticle.Name = "FieldArticle";
            this.FieldArticle.Size = new System.Drawing.Size(221, 68);
            this.FieldArticle.TabIndex = 3;
            // 
            // Button_insert
            // 
            this.Button_insert.Location = new System.Drawing.Point(81, 128);
            this.Button_insert.Name = "Button_insert";
            this.Button_insert.Size = new System.Drawing.Size(75, 23);
            this.Button_insert.TabIndex = 4;
            this.Button_insert.Text = "Добавить";
            this.Button_insert.UseVisualStyleBackColor = true;
            this.Button_insert.Click += new System.EventHandler(this.Button_insert_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Номер статьи";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Статья";
            // 
            // Button_delete
            // 
            this.Button_delete.Location = new System.Drawing.Point(243, 128);
            this.Button_delete.Name = "Button_delete";
            this.Button_delete.Size = new System.Drawing.Size(75, 23);
            this.Button_delete.TabIndex = 8;
            this.Button_delete.Text = "Удалить";
            this.Button_delete.UseVisualStyleBackColor = true;
            this.Button_delete.Click += new System.EventHandler(this.Button_delete_Click);
            // 
            // Button_edit
            // 
            this.Button_edit.Location = new System.Drawing.Point(162, 128);
            this.Button_edit.Name = "Button_edit";
            this.Button_edit.Size = new System.Drawing.Size(75, 23);
            this.Button_edit.TabIndex = 9;
            this.Button_edit.Text = "Изменить";
            this.Button_edit.UseVisualStyleBackColor = true;
            this.Button_edit.Click += new System.EventHandler(this.Button_edit_Click);
            // 
            // Category
            // 
            this.Category.FormattingEnabled = true;
            this.Category.Items.AddRange(new object[] {
            "ID",
            "Номер",
            "Статья"});
            this.Category.Location = new System.Drawing.Point(145, 16);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(156, 21);
            this.Category.TabIndex = 13;
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(145, 43);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(156, 20);
            this.SearchText.TabIndex = 14;
            // 
            // Button_find
            // 
            this.Button_find.Location = new System.Drawing.Point(145, 69);
            this.Button_find.Name = "Button_find";
            this.Button_find.Size = new System.Drawing.Size(75, 23);
            this.Button_find.TabIndex = 15;
            this.Button_find.Text = "Найти";
            this.Button_find.UseVisualStyleBackColor = true;
            this.Button_find.Click += new System.EventHandler(this.Button_find_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "По какому полю искать";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Что искать";
            // 
            // Button_reset
            // 
            this.Button_reset.Location = new System.Drawing.Point(226, 69);
            this.Button_reset.Name = "Button_reset";
            this.Button_reset.Size = new System.Drawing.Size(75, 23);
            this.Button_reset.TabIndex = 18;
            this.Button_reset.Text = "Сбросить";
            this.Button_reset.UseVisualStyleBackColor = true;
            this.Button_reset.Click += new System.EventHandler(this.Button_reset_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(345, 186);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Button_edit);
            this.tabPage1.Controls.Add(this.FieldNumber);
            this.tabPage1.Controls.Add(this.Button_delete);
            this.tabPage1.Controls.Add(this.FieldArticle);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.Button_insert);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(337, 160);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Редактирование";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Button_reset);
            this.tabPage2.Controls.Add(this.Category);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.SearchText);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.Button_find);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(337, 160);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Поиск";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ButtonSort);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.Sort_order);
            this.tabPage3.Controls.Add(this.Sort_category);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(337, 160);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Сортировка";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ButtonSort
            // 
            this.ButtonSort.Location = new System.Drawing.Point(183, 70);
            this.ButtonSort.Name = "ButtonSort";
            this.ButtonSort.Size = new System.Drawing.Size(121, 23);
            this.ButtonSort.TabIndex = 19;
            this.ButtonSort.Text = "Сортировать";
            this.ButtonSort.UseVisualStyleBackColor = true;
            this.ButtonSort.Click += new System.EventHandler(this.ButtonSort_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Порядок сортировки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "По какому полю сортировать";
            // 
            // Sort_order
            // 
            this.Sort_order.FormattingEnabled = true;
            this.Sort_order.Items.AddRange(new object[] {
            "По возрастанию",
            "По убыванию"});
            this.Sort_order.Location = new System.Drawing.Point(183, 43);
            this.Sort_order.Name = "Sort_order";
            this.Sort_order.Size = new System.Drawing.Size(121, 21);
            this.Sort_order.TabIndex = 1;
            // 
            // Sort_category
            // 
            this.Sort_category.FormattingEnabled = true;
            this.Sort_category.Items.AddRange(new object[] {
            "ID",
            "Номер",
            "Статья"});
            this.Sort_category.Location = new System.Drawing.Point(183, 16);
            this.Sort_category.Name = "Sort_category";
            this.Sort_category.Size = new System.Drawing.Size(121, 21);
            this.Sort_category.TabIndex = 0;
            // 
            // Table_violation_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 493);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Table);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Table_violation_item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Таблица \"Статьи\"";
            this.Load += new System.EventHandler(this.Table_dormitory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.TextBox FieldNumber;
        private System.Windows.Forms.TextBox FieldArticle;
        private System.Windows.Forms.Button Button_insert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Button_delete;
        private System.Windows.Forms.Button Button_edit;
        private System.Windows.Forms.ComboBox Category;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button Button_find;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Button_reset;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button ButtonSort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Sort_order;
        private System.Windows.Forms.ComboBox Sort_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn article;
    }
}