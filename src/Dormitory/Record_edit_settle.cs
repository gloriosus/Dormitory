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
    public partial class Record_edit_settle : Form
    {
        public Record_edit_settle()
        {
            InitializeComponent();
        }

        Database db = Database.Instance();

        List<Dictionary<string, string>> dormitories;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FieldDormitory.SelectedIndex != -1 && !String.IsNullOrEmpty(FieldRoom.Text))
            {
                var form = this.Owner as Record_edit;

                db.Set("INSERT INTO history (student_id, dormitory_id, room, date_settling) VALUES (" + form.student["id"] + ", " + dormitories[FieldDormitory.SelectedIndex]["id"] + ", '" + FieldRoom.Text + "', '" + FieldDateSettling.Value.ToString("yyyy-MM-dd") + "')");

                form.UpdateTable("History");

                MessageBox.Show(form.student["surname"] + " " + form.student["first_name"] + " " + form.student["patronymic"] + " заселен(а)");

                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
        }

        private void Record_edit_settle_Load(object sender, EventArgs e)
        {
            dormitories = db.Get("SELECT id, CONCAT(dormitory_number, ', ', street) AS address FROM dormitory");
            foreach (Dictionary<string, string> item in dormitories)
            {
                FieldDormitory.Items.Add(item["address"]);
            }
        }
    }
}
