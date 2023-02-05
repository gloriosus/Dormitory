namespace Dormitory
{
    partial class eviction_settling
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
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.FieldOrderNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FieldDateEviction = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FieldRoom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(12, 196);
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
            this.ButtonCancel.Location = new System.Drawing.Point(120, 196);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FieldOrderNumber
            // 
            this.FieldOrderNumber.Location = new System.Drawing.Point(15, 34);
            this.FieldOrderNumber.Name = "FieldOrderNumber";
            this.FieldOrderNumber.Size = new System.Drawing.Size(181, 20);
            this.FieldOrderNumber.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Номер приказа";
            // 
            // FieldDateEviction
            // 
            this.FieldDateEviction.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FieldDateEviction.Location = new System.Drawing.Point(14, 147);
            this.FieldDateEviction.Name = "FieldDateEviction";
            this.FieldDateEviction.Size = new System.Drawing.Size(181, 20);
            this.FieldDateEviction.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата выселения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Номер комнаты";
            // 
            // FieldRoom
            // 
            this.FieldRoom.Location = new System.Drawing.Point(15, 90);
            this.FieldRoom.Name = "FieldRoom";
            this.FieldRoom.Size = new System.Drawing.Size(181, 20);
            this.FieldRoom.TabIndex = 6;
            // 
            // eviction_settling
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(207, 231);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FieldRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FieldDateEviction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FieldOrderNumber);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "eviction_settling";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выселение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.TextBox FieldOrderNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FieldDateEviction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FieldRoom;
    }
}