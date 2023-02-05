using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dormitory
{
    public partial class eviction_order : Form
    {
        public eviction_order()
        {
            InitializeComponent();
        }

        Database db = Database.Instance();

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(FieldOrderNumber.Text))
            {
                Record_edit edit = this.Owner as Record_edit;

                var history_id = db.Get("select history.id as 'id' from history where history.student_id = " + edit.StudentId + " and history.date_eviction is null")[0]["id"];

                db.Set("UPDATE history SET order_number_eviction = '" + FieldOrderNumber.Text + "', date_eviction='" + FieldDateEviction.Value.ToString("yyyy-MM-dd") + "' WHERE id=" + history_id);

                edit.UpdateTable("History");

                MessageBox.Show(edit.student["surname"] + " " + edit.student["first_name"] + " " + edit.student["patronymic"] + " выселен(а)");

                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните поле 'Номер приказа'", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
