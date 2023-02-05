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
    public partial class Record_edit : Form
    {
        public Record_edit()
        {
            InitializeComponent();
        }

        private Database db = Database.Instance();

        private List<Dictionary<string, string>> dormitories;
        private List<Dictionary<string, string>> countries;
        private List<Dictionary<string, string>> courses;
        private List<Dictionary<string, string>> classes;
        private List<Dictionary<string, string>> faculties;
        private List<Dictionary<string, string>> forms;

        public Dictionary<string, string> student;

        private List<Dictionary<string, string>> history;
        private List<Dictionary<string, string>> violation;

        private Main main;

        public int StudentId = -1;

        private void Record_add_Load(object sender, EventArgs e)
        {
            main = this.Owner as Main;

            countries = db.Get("SELECT title FROM country WHERE is_active = true");
            foreach (Dictionary<string, string> item in countries)
            {
                FieldCountry.Items.Add(item["title"]);
            }

            courses = db.Get("SELECT course_number FROM course WHERE is_active = true");
            foreach (Dictionary<string, string> item in courses)
            {
                FieldCourse.Items.Add(item["course_number"]);
            }

            classes = db.Get("SELECT class_number FROM class WHERE is_active = true");
            foreach (Dictionary<string, string> item in classes)
            {
                FieldClass.Items.Add(item["class_number"]);
            }

            faculties = db.Get("SELECT title FROM faculty WHERE is_active = true");
            foreach (Dictionary<string, string> item in faculties)
            {
                FieldFaculty.Items.Add(item["title"]);
            }

            forms = db.Get("SELECT title FROM form WHERE is_active = true");
            foreach (Dictionary<string, string> item in forms)
            {
                FieldForm.Items.Add(item["title"]);
            }

            var status = db.Get("SELECT title FROM status WHERE is_active = true");
            foreach (var item in status)
            {
                FieldStatus.Items.Add(item["title"]);
            }

            var education = db.Get("SELECT title FROM education WHERE is_active = true");
            foreach (var item in education)
            {
                FieldEducation.Items.Add(item["title"]);
            }

            var stage = db.Get("SELECT title FROM stage WHERE is_active = true");
            foreach (var item in stage)
            {
                FieldStage.Items.Add(item["title"]);
            }

            var budgets = db.Get("SELECT title FROM budget WHERE is_active = true");
            foreach (var budget in budgets)
            {
                FieldBudget.Items.Add(budget["title"]);
            }

            student = db.Get("SELECT * FROM student WHERE id=" + main.SelectedId)[0];

            StudentId = main.SelectedId;

            //Присвоение значений для выбранного студента
            FieldName.Text = student["first_name"];
            FieldFamily.Text = student["surname"];
            FieldOtchestvo.Text = student["patronymic"];
            FieldCountry.SelectedItem = db.Get("SELECT title FROM country WHERE id=(SELECT country_id FROM student WHERE id=" + main.SelectedId + ")")[0]["title"];

            FieldPassportAddress.Text = student["passport_address"];
            FieldOrphan.SelectedItem = Convert.ToBoolean(student["is_orphan"]) ? "Да" : "Нет";
            FieldGraduated.SelectedItem = Convert.ToBoolean(student["is_graduated"]) ? "Да" : "Нет";


            FieldBirthDate.Value = String.IsNullOrEmpty(student["birth_date"]) ? DateTime.Now : Convert.ToDateTime(student["birth_date"]);
            FieldStatus.SelectedItem = !String.IsNullOrEmpty(student["status_id"]) ? db.Get("SELECT title FROM status WHERE id=" + student["status_id"])[0]["title"] : "";
            FieldEducation.SelectedItem = db.Get("SELECT title FROM education WHERE id=" + student["education_id"])[0]["title"];
            FieldCourse.SelectedItem = db.Get("SELECT course_number FROM course WHERE id=" + student["course_id"])[0]["course_number"];
            FieldClass.SelectedItem = db.Get("SELECT class_number FROM class WHERE id=" + student["class_id"])[0]["class_number"];
            FieldFaculty.SelectedItem = db.Get("SELECT title FROM faculty WHERE id=" + student["faculty_id"])[0]["title"];
            FieldForm.SelectedItem = db.Get("SELECT title FROM form WHERE id=" + student["form_id"])[0]["title"];
            FieldBudget.SelectedItem = db.Get("SELECT title FROM budget WHERE id = " + student["budget_id"])[0]["title"];
            FieldStage.SelectedItem = db.Get("SELECT title FROM stage WHERE id=" + student["stage_id"])[0]["title"];
            FieldDeducted.SelectedItem = student["is_deducted"] == "1" ? "Да" : "Нет";
            FieldRegistered.SelectedItem = student["is_registered"] == "1" ? "Есть" : "Нет";


            UpdateTable("History");
            UpdateTable("Violation");

            TableHistory.CurrentCell = TableHistory.Rows.OfType<DataGridViewRow>().Last().Cells[0];
            TableHistory.Rows.OfType<DataGridViewRow>().Last().Selected = true;
        }

        public void UpdateTable(string table)
        {
            if (table == "History")
            {
                history = db.Get("SELECT id, order_number_eviction, dormitory_id, room, date_settling, date_eviction FROM history WHERE student_id=" + main.SelectedId + " order by id");
                TableHistory.RowCount = history.Count >= 1 ? history.Count : 1;

                for (int i = 0; i < history.Count; i++)
                {
                    TableHistory.Rows[i].Cells[0].Value = history[i]["order_number_eviction"];
                    TableHistory.Rows[i].Cells[1].Value = db.Get("SELECT CONCAT(dormitory_number, ', ', street) AS address FROM dormitory WHERE id=" + history[i]["dormitory_id"])[0]["address"];
                    TableHistory.Rows[i].Cells[2].Value = history[i]["room"];
                    TableHistory.Rows[i].Cells[3].Value = Convert.ToDateTime(history[i]["date_settling"]).ToShortDateString();
                    TableHistory.Rows[i].Cells[4].Value = history[i]["date_eviction"] != "" ? Convert.ToDateTime(history[i]["date_eviction"]).ToShortDateString() : "";
                    TableHistory.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                }

                TableHistory.Rows[TableHistory.RowCount - 1].DefaultCellStyle.BackColor = Color.White;
            }
            else if(table == "Violation")
            {
                violation = db.Get("SELECT violation.id as 'Id', violation_item.order_number as 'Number', violation.order_date as 'Date', violation_item.article as 'Article' FROM violation left join violation_item on violation.violation_item_id = violation_item.id WHERE violation.student_id=" + main.SelectedId + " order by violation.id");
                TableViolation.RowCount = violation.Count >= 1 ? violation.Count : 1;

                for (int i = 0; i < violation.Count; i++)
                {
                    TableViolation.Rows[i].Cells[0].Value = violation[i]["Id"];
                    TableViolation.Rows[i].Cells[1].Value = violation[i]["Number"];
                    TableViolation.Rows[i].Cells[2].Value = Convert.ToDateTime(violation[i]["Date"]).ToString("yyyy-MM-dd");
                    TableViolation.Rows[i].Cells[3].Value = violation[i]["Article"];
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            bool isFilled = true;

            foreach (var item in groupBox2.Controls.OfType<ComboBox>())
            {
                if (item.SelectedIndex == -1)
                {
                    isFilled = false;
                    break;
                }
            }

            foreach (var item in groupBox1.Controls.OfType<TextBox>())
            {
                if (String.IsNullOrEmpty(item.Text) && item.Name != "FieldPassportAddress")
                {
                    isFilled = false;
                    break;
                }
            }

            if (isFilled)
            {
                var country_id = db.Get("SELECT id FROM country WHERE title='" + FieldCountry.SelectedItem + "'")[0]["id"];
                var status_id = db.Get("SELECT id FROM status WHERE title='" + FieldStatus.SelectedItem + "'")[0]["id"];
                var course_id = db.Get("SELECT id FROM course WHERE course_number='" + FieldCourse.SelectedItem + "'")[0]["id"];
                var class_id = db.Get("SELECT id FROM class WHERE class_number='" + FieldClass.SelectedItem + "'")[0]["id"];
                var faculty_id = db.Get("SELECT id FROM faculty WHERE title='" + FieldFaculty.SelectedItem + "'")[0]["id"];
                var form_id = db.Get("SELECT id FROM form WHERE title='" + FieldForm.SelectedItem + "'")[0]["id"];
                var stage_id = db.Get("SELECT id FROM stage WHERE title='" + FieldStage.SelectedItem + "'")[0]["id"];
                var education_id = db.Get("SELECT id FROM education WHERE title='" + FieldEducation.SelectedItem + "'")[0]["id"];
                var budget_id = db.Get("SELECT id FROM budget WHERE title='" + FieldBudget.SelectedItem + "'")[0]["id"];
                var is_deducted = FieldDeducted.SelectedItem == "Да" ? 1 : 0;
                var is_registered = FieldRegistered.SelectedItem == "Есть" ? 1 : 0;
                var is_orphan = FieldOrphan.SelectedItem == "Да" ? 1 : 0;
                var is_graduated = FieldGraduated.SelectedItem == "Да" ? 1 : 0;
                string birth_date = FieldBirthDate.Value.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd") ? "'" + FieldBirthDate.Value.ToString("yyyy-MM-dd") + "'" : "null";

                var is_notification_read = TableViolation.RowCount >= 2 ? 0 : 1;

                db.Set("UPDATE student SET first_name='" + FieldName.Text + "', surname='" + FieldFamily.Text + "', patronymic='" + FieldOtchestvo.Text + "', birth_date=" + birth_date + ", country_id=" + country_id + ", status_id=" + status_id + ", course_id=" + course_id + ", class_id=" + class_id + ", faculty_id=" + faculty_id + ", form_id=" + form_id + ", stage_id=" + stage_id + ", education_id=" + education_id + ", budget_id=" + budget_id + ", is_deducted=" + is_deducted + ", is_registered=" + is_registered + ", is_notification_read = " + is_notification_read + ", passport_address = '" + FieldPassportAddress.Text + "', is_orphan = " + is_orphan + ", is_graduated = " + is_graduated + " WHERE id=" + main.SelectedId);

                main.UpdateTable("SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.is_active=1 ORDER BY student.id ASC");

                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripEviction_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TableHistory.Rows[TableHistory.Rows.Count - 1].Cells[0].Value.ToString()) && String.IsNullOrEmpty(TableHistory.Rows[TableHistory.Rows.Count - 1].Cells[4].Value.ToString()))
            {
                    int debt = Convert.ToInt32(main.Table.CurrentRow.Cells[6].Value);

                    if (debt == 0)
                    {
                        eviction_order form = new eviction_order();
                        form.Owner = this;
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("У студента имеется долг", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
            }
            else
            {
                MessageBox.Show("Для начала заселите студента", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void отправитьВЮрОтделToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TableHistory.Rows[TableHistory.Rows.Count - 1].Cells[0].Value.ToString()) && String.IsNullOrEmpty(TableHistory.Rows[TableHistory.Rows.Count - 1].Cells[4].Value.ToString()))
            {
                int debt = Convert.ToInt32(main.Table.CurrentRow.Cells[6].Value);

                if (debt > 0)
                {
                    eviction_order form = new eviction_order();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("У студента отсутствует долг", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Для начала выселите студента", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ToolStripSettling_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TableHistory.Rows[TableHistory.Rows.Count - 1].Cells[0].Value.ToString()) && !String.IsNullOrEmpty(TableHistory.Rows[TableHistory.Rows.Count - 1].Cells[4].Value.ToString()))
            {
                Record_edit_settle form = new Record_edit_settle();
                form.Owner = this;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Для начала выселите студента", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TableViolation.CurrentRow.Index != -1 && MessageBox.Show("Удалить выделенное нарушение?", "Подтверждение удаления", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                db.Set("delete from violation where id = " + TableViolation.CurrentRow.Cells[0].Value.ToString());
                UpdateTable("Violation");
            }
        }

        public string status = "";

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status = "Create";

            violation_control form = new violation_control();
            form.Owner = this;
            form.ShowDialog();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TableViolation.Rows[0].Cells[0].Value.ToString()))
            {
                status = "Edit";

                violation_control form = new violation_control();
                form.Owner = this;
                form.ShowDialog();
            }
        }

        private void переселитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TableHistory.Rows[TableHistory.Rows.Count - 1].Cells[0].Value.ToString()) && String.IsNullOrEmpty(TableHistory.Rows[TableHistory.Rows.Count - 1].Cells[4].Value.ToString()))
            {
                int debt = Convert.ToInt32(main.Table.CurrentRow.Cells[6].Value);

                    eviction_settling form = new eviction_settling();
                    form.Owner = this;
                    form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Для начала заселите студента", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
