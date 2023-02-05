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
    public partial class Record_add : Form
    {
        public Record_add()
        {
            InitializeComponent();
        }

        private Database db = Database.Instance();

        //Массивы для хранения данных выпадающих списков
        private List<Dictionary<string, string>> dormitories;
        private List<Dictionary<string, string>> countries;
        private List<Dictionary<string, string>> courses;
        private List<Dictionary<string, string>> groups;
        private List<Dictionary<string, string>> faculties;
        private List<Dictionary<string, string>> forms;
        private List<Dictionary<string, string>> budgets;
        private List<Dictionary<string, string>> contracts;
        private List<Dictionary<string, string>> classes;

        private void Record_add_Load(object sender, EventArgs e)
        {
            dormitories = db.Get("SELECT CONCAT(dormitory_number, ', ', street) AS address FROM dormitory where is_active = true");
            foreach (Dictionary<string, string> item in dormitories)
            {
                FieldDormitory.Items.Add(item["address"]);
            }

            countries = db.Get("SELECT title FROM country where is_active = true");
            foreach (Dictionary<string, string> item in countries)
            {
                FieldCountry.Items.Add(item["title"]);
            }

            FieldCountry.SelectedIndex = FieldCountry.Items.IndexOf("Россия");

            courses = db.Get("SELECT course_number FROM course where is_active = true");
            foreach (Dictionary<string, string> item in courses)
            {
                FieldCourse.Items.Add(item["course_number"]);
            }

            classes = db.Get("SELECT class_number FROM class where is_active = true");
            foreach (Dictionary<string, string> item in classes)
            {
                FieldClass.Items.Add(item["class_number"]);
            }

            faculties = db.Get("SELECT title FROM faculty where is_active = true");
            foreach (Dictionary<string, string> item in faculties)
            {
                FieldFaculty.Items.Add(item["title"]);
            }

            forms = db.Get("SELECT title FROM form where is_active = true");
            foreach (Dictionary<string, string> item in forms)
            {
                FieldForm.Items.Add(item["title"]);
            }

            var status = db.Get("SELECT title FROM status where is_active = true");
            foreach (var item in status)
            {
                FieldStatus.Items.Add(item["title"]);
            }

            var education = db.Get("SELECT title FROM education where is_active = true");
            foreach (var item in education)
            {
                FieldEducation.Items.Add(item["title"]);
            }

            var stage = db.Get("SELECT title FROM stage where is_active = true");
            foreach (var item in stage)
            {
                FieldStage.Items.Add(item["title"]);
            }

            var budgets = db.Get("select title from budget where is_active = true");
            foreach (var budget in budgets)
            {
                FieldBudget.Items.Add(budget["title"]);
            }

            FieldOrphan.SelectedIndex = FieldOrphan.Items.IndexOf("Нет");
            FieldRegistered.SelectedIndex = FieldRegistered.Items.IndexOf("Есть");
            FieldGraduated.SelectedIndex = FieldGraduated.Items.IndexOf("Нет");
        }

        //Добавление записи
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            bool isFilled = true;

            foreach (var item in groupBox1.Controls.OfType<TextBox>())
            {
                if (String.IsNullOrEmpty(item.Text) && item.Name != "FieldPassportAddress")
                {
                    isFilled = false;
                    break;
                }
            }

            if (FieldDormitory.SelectedIndex == -1)
            {
                isFilled = false;
            }

            foreach (var item in groupBox2.Controls.OfType<ComboBox>())
            {
                if (item.SelectedIndex == -1)
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
                var is_registered = FieldRegistered.SelectedItem == "Есть" ? 1 : 0;
                var is_orphan = FieldOrphan.SelectedItem == "Да" ? 1 : 0;
                var is_graduated = FieldGraduated.SelectedItem == "Да" ? 1 : 0;

                string birth_date = FieldBirthDate.Value.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd") ? "'" + FieldBirthDate.Value.ToString("yyyy-MM-dd") + "'" : "null";

                int student_id = db.Set("INSERT INTO student (surname, first_name, patronymic, birth_date, country_id, status_id, course_id, class_id, faculty_id, form_id, stage_id, education_id, budget_id, is_registered, is_orphan, is_graduated) VALUES ('" + FieldFamily.Text + "', '" + FieldName.Text + "', '" + FieldOtchestvo.Text + "', " + birth_date + ", " + country_id + ", " + status_id + ", " + course_id + ", " + class_id + ", " + faculty_id + ", " + form_id + ", " + stage_id + ", " + education_id + ", " + budget_id + ", " + is_registered + ", " + is_orphan + ", " + is_graduated + ")");

                var dormitory_id = db.Get("SELECT id FROM dormitory WHERE CONCAT(dormitory_number, ', ', street)='" + FieldDormitory.SelectedItem + "'")[0]["id"];

                db.Set("INSERT INTO history (student_id, dormitory_id, room) VALUES (" + student_id + ", " + dormitory_id + ", '" + FieldRoom.Text + "')");

                Main main = this.Owner as Main;
                main.UpdateTable("SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.is_active=1 ORDER BY student.id ASC");
                main.Table.CurrentCell = main.Table.Rows[main.Table.Rows.Count - 1].Cells[0];

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
    }
}
