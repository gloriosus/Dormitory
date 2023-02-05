namespace Dormitory
{
    partial class Record_edit_settle
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FieldRoom = new System.Windows.Forms.TextBox();
            this.FieldDormitory = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.FieldDateSettling = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Общежитие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Комната";
            // 
            // FieldRoom
            // 
            this.FieldRoom.Location = new System.Drawing.Point(12, 91);
            this.FieldRoom.Name = "FieldRoom";
            this.FieldRoom.Size = new System.Drawing.Size(181, 20);
            this.FieldRoom.TabIndex = 12;
            // 
            // FieldDormitory
            // 
            this.FieldDormitory.FormattingEnabled = true;
            this.FieldDormitory.Location = new System.Drawing.Point(12, 38);
            this.FieldDormitory.Name = "FieldDormitory";
            this.FieldDormitory.Size = new System.Drawing.Size(181, 21);
            this.FieldDormitory.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 126);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Дата заселения";
            // 
            // FieldDateSettling
            // 
            this.FieldDateSettling.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FieldDateSettling.Location = new System.Drawing.Point(12, 142);
            this.FieldDateSettling.Name = "FieldDateSettling";
            this.FieldDateSettling.Size = new System.Drawing.Size(181, 20);
            this.FieldDateSettling.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(120, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Record_edit_settle
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(207, 227);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FieldDateSettling);
            this.Controls.Add(this.FieldDormitory);
            this.Controls.Add(this.FieldRoom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Record_edit_settle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заселение";
            this.Load += new System.EventHandler(this.Record_edit_settle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FieldRoom;
        private System.Windows.Forms.ComboBox FieldDormitory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker FieldDateSettling;
    }
}