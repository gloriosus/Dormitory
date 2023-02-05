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
    public partial class course_selector : Form
    {
        public course_selector()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = Database.Instance();

            Main main = this.Owner as Main;

            if (radioSelection.Checked)
            {
                int max = Convert.ToInt32(db.Get("SELECT MAX(course_number) AS Max FROM course")[0]["Max"]);

                string ids = "";

                foreach(DataGridViewRow row in main.Table.SelectedRows)
                {
                    int course = Convert.ToInt32(db.Get("SELECT course_number FROM course WHERE id = (SELECT course_id FROM student WHERE id = " + row.Cells[0].Value + ")")[0]["course_number"]);

                    if (course < max)
                    {
                        ids += row.Cells[0].Value.ToString() + ", ";
                    }
                }

                if (!String.IsNullOrEmpty(ids))
                {
                    ids = ids.Substring(0, ids.Length - 2);

                    db.Set("UPDATE student SET course_id = (SELECT id FROM course WHERE course_number = ((SELECT course_number FROM course WHERE id = student.course_id) + 1)) WHERE id in (" + ids + ")");
                }

                MessageBox.Show("Студенты переведены на следующий курс!", "Успешное завершение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            else if (radioAll.Checked)
            {
                int max = Convert.ToInt32(db.Get("SELECT MAX(course_number) AS Max FROM course")[0]["Max"]);

                string ids = "";

                var students = db.Get("SELECT student.id AS id, course.course_number AS course FROM student LEFT JOIN course ON student.course_id = course.id WHERE student.is_active = true");

                foreach (var student in students)
                {
                    int course = Convert.ToInt32(student["course"]);

                    if (course < max)
                    {
                        ids += student["id"] + ", ";
                    }
                }

                if (!String.IsNullOrEmpty(ids))
                {
                    ids = ids.Substring(0, ids.Length - 2);

                    db.Set("UPDATE student SET course_id = (SELECT id FROM course WHERE course_number = ((SELECT course_number FROM course WHERE id = student.course_id) + 1)) WHERE id in (" + ids + ")");
                }

                MessageBox.Show("Студенты переведены на следующий курс!", "Успешное завершение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
        }
    }
}
