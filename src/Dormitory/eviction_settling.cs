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
    public partial class eviction_settling : Form
    {
        public eviction_settling()
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
            if (!String.IsNullOrEmpty(FieldOrderNumber.Text) && !String.IsNullOrEmpty(FieldRoom.Text))
            {
                Record_edit edit = this.Owner as Record_edit;

                var history_id = db.Get("select history.id as 'id' from history where history.student_id = " + edit.StudentId + " and history.date_eviction is null")[0]["id"];

                db.Set("UPDATE history SET order_number_eviction = '" + FieldOrderNumber.Text + "', date_eviction='" + FieldDateEviction.Value.ToString("yyyy-MM-dd") + "' WHERE id=" + history_id);



                var dormitory_id = db.Get("select dormitory_id from history where id = " + history_id)[0]["dormitory_id"];

                db.Set("insert into history (student_id, dormitory_id, room, date_settling) values (" + edit.StudentId + ", " + dormitory_id + ", " + FieldRoom.Text + ", '" + FieldDateEviction.Value.ToString("yyyy-MM-dd") + "')");




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