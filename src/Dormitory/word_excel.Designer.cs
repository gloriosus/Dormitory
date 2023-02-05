namespace Dormitory
{
    partial class word_excel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(word_excel));
            this.RadioWord = new System.Windows.Forms.RadioButton();
            this.RadioExcel = new System.Windows.Forms.RadioButton();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RadioWord
            // 
            this.RadioWord.AutoSize = true;
            this.RadioWord.Location = new System.Drawing.Point(22, 24);
            this.RadioWord.Name = "RadioWord";
            this.RadioWord.Size = new System.Drawing.Size(97, 17);
            this.RadioWord.TabIndex = 0;
            this.RadioWord.TabStop = true;
            this.RadioWord.Text = "Microsoft Word";
            this.RadioWord.UseVisualStyleBackColor = true;
            // 
            // RadioExcel
            // 
            this.RadioExcel.AutoSize = true;
            this.RadioExcel.Location = new System.Drawing.Point(139, 24);
            this.RadioExcel.Name = "RadioExcel";
            this.RadioExcel.Size = new System.Drawing.Size(97, 17);
            this.RadioExcel.TabIndex = 1;
            this.RadioExcel.TabStop = true;
            this.RadioExcel.Text = "Microsoft Excel";
            this.RadioExcel.UseVisualStyleBackColor = true;
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(22, 80);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 2;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(161, 80);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // word_excel
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(258, 114);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.RadioExcel);
            this.Controls.Add(this.RadioWord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "word_excel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбрать программу для отчета";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RadioWord;
        private System.Windows.Forms.RadioButton RadioExcel;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
    }
}