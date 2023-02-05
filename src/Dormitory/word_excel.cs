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
    public partial class word_excel : Form
    {
        public word_excel()
        {
            InitializeComponent();
        }

        Database db = Database.Instance();

        public int dNumber = -1;

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Main main = this.Owner as Main;

            if (RadioWord.Checked)
            {
                if (main.commandReport == "orphan_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_orphan = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\orphans.docx");
                        report.Execute(records, "1", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "orphan_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_orphan = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\orphans.docx");
                        report.Execute(records, "2", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "orphan_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_orphan = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\orphans.docx");
                        report.Execute(records, "3", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "orphan_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_orphan = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\orphans.docx");
                        report.Execute(records, "4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "orphan_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_orphan = true AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\orphans.docx");
                        report.Execute(records, "1, 2, 3, 4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "chinese_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.country_id = (SELECT country.id FROM country WHERE country.title = 'Китай') AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\chinese.docx");
                        report.Execute(records, "1", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "chinese_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.country_id = (SELECT country.id FROM country WHERE country.title = 'Китай') AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\chinese.docx");
                        report.Execute(records, "2", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "chinese_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.country_id = (SELECT country.id FROM country WHERE country.title = 'Китай') AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\chinese.docx");
                        report.Execute(records, "3", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "chinese_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.country_id = (SELECT country.id FROM country WHERE country.title = 'Китай') AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\chinese.docx");
                        report.Execute(records, "4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "chinese_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.country_id = (SELECT country.id FROM country WHERE country.title = 'Китай') AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\chinese.docx");
                        report.Execute(records, "1, 2, 3, 4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "freshman_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.course_id = (SELECT course.id FROM course WHERE course.course_number = 1) AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\freshman.docx");
                        report.Execute(records, "1", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "freshman_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.course_id = (SELECT course.id FROM course WHERE course.course_number = 1) AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\freshman.docx");
                        report.Execute(records, "2", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "freshman_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.course_id = (SELECT course.id FROM course WHERE course.course_number = 1) AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\freshman.docx");
                        report.Execute(records, "3", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "freshman_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.course_id = (SELECT course.id FROM course WHERE course.course_number = 1) AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\freshman.docx");
                        report.Execute(records, "4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "freshman_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.course_id = (SELECT course.id FROM course WHERE course.course_number = 1) AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\freshman.docx");
                        report.Execute(records, "1, 2, 3, 4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }

                }
                else if (main.commandReport == "lyceum")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.education_id = (SELECT education.id FROM education WHERE education.title = 'Лицей') AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\lyceum.docx");
                        report.Execute(records, "2", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "debtors_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.debt > 0 AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\debtors.docx");
                        report.Execute(records, "1", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "debtors_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.debt > 0 AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\debtors.docx");
                        report.Execute(records, "2", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "debtors_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.debt > 0 AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\debtors.docx");
                        report.Execute(records, "3", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "debtors_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.debt > 0 AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\debtors.docx");
                        report.Execute(records, "4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "debtors_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.debt > 0 AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\debtors.docx");
                        report.Execute(records, "1, 2, 3, 4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "violations_1")
                {
                    dNumber = 1;

                    date_selector form = new date_selector();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (main.commandReport == "violations_2")
                {
                    dNumber = 2;

                    date_selector form = new date_selector();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (main.commandReport == "violations_3")
                {
                    dNumber = 3;

                    date_selector form = new date_selector();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (main.commandReport == "violations_4")
                {
                    dNumber = 4;

                    date_selector form = new date_selector();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (main.commandReport == "violations_all")
                {
                    dNumber = 5;

                    date_selector form = new date_selector();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (main.commandReport == "graduates_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_graduated = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\graduates.docx");
                        report.Execute(records, "1", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "graduates_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_graduated = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\graduates.docx");
                        report.Execute(records, "2", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "graduates_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_graduated = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\graduates.docx");
                        report.Execute(records, "3", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "graduates_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_graduated = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\graduates.docx");
                        report.Execute(records, "4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "graduates_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_graduated = true AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\graduates.docx");
                        report.Execute(records, "1, 2, 3, 4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "livinglist_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', form.title AS 'Форма', education.title AS 'Образование' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN education ON student.education_id = education.id WHERE student.is_active = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\livinglist.docx");
                        report.Execute(records, "1", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "livinglist_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', form.title AS 'Форма', education.title AS 'Образование' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN education ON student.education_id = education.id WHERE student.is_active = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\livinglist.docx");
                        report.Execute(records, "2", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "livinglist_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', form.title AS 'Форма', education.title AS 'Образование' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN education ON student.education_id = education.id WHERE student.is_active = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\livinglist.docx");
                        report.Execute(records, "3", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "livinglist_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', form.title AS 'Форма', education.title AS 'Образование' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN education ON student.education_id = education.id WHERE student.is_active = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\livinglist.docx");
                        report.Execute(records, "4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "livinglist_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', form.title AS 'Форма', education.title AS 'Образование' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN education ON student.education_id = education.id WHERE student.is_active = true AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        Report report = new Report(Application.StartupPath + @"\Templates\livinglist.docx");
                        report.Execute(records, "1, 2, 3, 4", DateTime.Today.ToShortDateString(), "", "");
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
            }
            else if (RadioExcel.Checked)
            {
                if (main.commandReport == "orphan_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_orphan = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов-сирот, проживающих в общежитии(ях) № 1 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "orphan_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_orphan = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов-сирот, проживающих в общежитии(ях) № 2 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "orphan_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_orphan = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов-сирот, проживающих в общежитии(ях) № 3 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "orphan_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_orphan = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов-сирот, проживающих в общежитии(ях) № 4 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "orphan_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_orphan = true AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов-сирот, проживающих в общежитии(ях) № 1, 2, 3, 4 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "chinese_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.country_id = (SELECT country.id FROM country WHERE country.title = 'Китай') AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов КНР, проживающих в общежитии(ях) № 1 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "chinese_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.country_id = (SELECT country.id FROM country WHERE country.title = 'Китай') AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов КНР, проживающих в общежитии(ях) № 2 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "chinese_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.country_id = (SELECT country.id FROM country WHERE country.title = 'Китай') AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов КНР, проживающих в общежитии(ях) № 3 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "chinese_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.country_id = (SELECT country.id FROM country WHERE country.title = 'Китай') AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов КНР, проживающих в общежитии(ях) № 4 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "chinese_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.country_id = (SELECT country.id FROM country WHERE country.title = 'Китай') AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов КНР, проживающих в общежитии(ях) № 1, 2, 3, 4 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "freshman_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.course_id = (SELECT course.id FROM course WHERE course.course_number = 1) AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов первого курса, проживающих в общежитии(ях) № 1 ПГУ им. Шолом-Алейхема" }, { "Count", "Итого первокурсников в общежитии № 1 : " + records.Count.ToString() } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "freshman_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.course_id = (SELECT course.id FROM course WHERE course.course_number = 1) AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов первого курса, проживающих в общежитии(ях) № 2 ПГУ им. Шолом-Алейхема" }, { "Count", "Итого первокурсников в общежитии № 2 : " + records.Count.ToString() } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "freshman_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.course_id = (SELECT course.id FROM course WHERE course.course_number = 1) AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов первого курса, проживающих в общежитии(ях) № 3 ПГУ им. Шолом-Алейхема" }, { "Count", "Итого первокурсников в общежитии № 3 : " + records.Count.ToString() } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "freshman_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.course_id = (SELECT course.id FROM course WHERE course.course_number = 1) AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов первого курса, проживающих в общежитии(ях) № 4 ПГУ им. Шолом-Алейхема" }, { "Count", "Итого первокурсников в общежитии № 4 : " + records.Count.ToString() } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "freshman_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.course_id = (SELECT course.id FROM course WHERE course.course_number = 1) AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов первого курса, проживающих в общежитии(ях) № 1, 2, 3, 4 ПГУ им. Шолом-Алейхема" }, { "Count", "Итого первокурсников в общежитии(ях) № 1, 2, 3, 4 : " + records.Count.ToString() } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "lyceum")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.education_id = (SELECT education.id FROM education WHERE education.title = 'Лицей') AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список учащихся лицея ПГУ им. Шолом-Алейхема, проживающих в общежитии(ях) № 2" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "debtors_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.debt > 0 AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, имеющих задолженность за проживание в общежитии(ях) № 1 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "debtors_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.debt > 0 AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, имеющих задолженность за проживание в общежитии(ях) № 2 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "debtors_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.debt > 0 AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, имеющих задолженность за проживание в общежитии(ях) № 3 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "debtors_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.debt > 0 AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, имеющих задолженность за проживание в общежитии(ях) № 4 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "debtors_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.debt > 0 AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, имеющих задолженность за проживание в общежитии(ях) № 1, 2, 3, 4 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "violations_1")
                {
                    dNumber = 1;

                    date_selector form = new date_selector();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (main.commandReport == "violations_2")
                {
                    dNumber = 2;

                    date_selector form = new date_selector();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (main.commandReport == "violations_3")
                {
                    dNumber = 3;

                    date_selector form = new date_selector();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (main.commandReport == "violations_4")
                {
                    dNumber = 4;

                    date_selector form = new date_selector();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (main.commandReport == "violations_all")
                {
                    dNumber = 5;

                    date_selector form = new date_selector();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (main.commandReport == "graduates_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_graduated = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов выпускного курса, проживающих в общежитии(ях) № 1 ПГУ им. Шолом-Алейхема" }, { "Count", "Итого выпускников в общежитии № 1 : " + records.Count.ToString() } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "graduates_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_graduated = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов выпускного курса, проживающих в общежитии(ях) № 2 ПГУ им. Шолом-Алейхема" }, { "Count", "Итого выпускников в общежитии № 2 : " + records.Count.ToString() } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "graduates_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_graduated = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов выпускного курса, проживающих в общежитии(ях) № 3 ПГУ им. Шолом-Алейхема" }, { "Count", "Итого выпускников в общежитии № 3 : " + records.Count.ToString() } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "graduates_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_graduated = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов выпускного курса, проживающих в общежитии(ях) № 4 ПГУ им. Шолом-Алейхема" }, { "Count", "Итого выпускников в общежитии № 4 : " + records.Count.ToString() } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "graduates_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', CONCAT(dormitory.dormitory_number, ' (', dormitory.street, ')') AS '№ Общежития', student.debt as 'Задолженность' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE student.is_active = true AND student.is_graduated = true AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов выпускного курса, проживающих в общежитии(ях) № 1, 2, 3, 4 ПГУ им. Шолом-Алейхема" }, { "Count", "Итого выпускников в общежитии № 1, 2, 3, 4 : " + records.Count.ToString() } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "livinglist_1")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', form.title AS 'Форма', education.title AS 'Образование' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN education ON student.education_id = education.id WHERE student.is_active = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 1 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, проживающих в общежитии № 1 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "livinglist_2")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', form.title AS 'Форма', education.title AS 'Образование' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN education ON student.education_id = education.id WHERE student.is_active = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 2 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, проживающих в общежитии № 2 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "livinglist_3")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', form.title AS 'Форма', education.title AS 'Образование' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN education ON student.education_id = education.id WHERE student.is_active = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 3 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, проживающих в общежитии № 3 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "livinglist_4")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', form.title AS 'Форма', education.title AS 'Образование' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN education ON student.education_id = education.id WHERE student.is_active = true AND history.date_eviction IS NULL AND dormitory.dormitory_number = 4 ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, проживающих в общежитии № 4 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
                else if (main.commandReport == "livinglist_all")
                {
                    var records = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'ФИО', faculty.title AS 'Факультет', course.course_number AS 'Курс', form.title AS 'Форма', education.title AS 'Образование' FROM student LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN history ON student.id = history.student_id LEFT JOIN dormitory ON history.dormitory_id = dormitory.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN education ON student.education_id = education.id WHERE student.is_active = true AND history.date_eviction IS NULL ORDER BY student.id");

                    if (records.Count != 0)
                    {
                        ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                        report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, проживающих в общежитии № 1, 2, 3, 4 ПГУ им. Шолом-Алейхема" } });
                    }
                    else
                    {
                        MessageBox.Show("По данному отчету нет записей");
                    }
                }
            }

            Close();
        }

        public void ViolationReport(string addClause, string dormitoryNumber, string dateFrom, string dateTo)
        {
            var records = db.Get("set sql_mode = ''; select concat(student.surname, ' ', student.first_name, ' ', student.patronymic) as 'ФИО', faculty.title as 'Факультет', course.course_number as 'Курс', dormitory.dormitory_number as '№ общежития', group_concat(violation_item.order_number separator ', ') as 'Краткое описание' from violation left join student on violation.student_id = student.id left join violation_item on violation.violation_item_id = violation_item.id left join faculty on student.faculty_id = faculty.id left join course on student.course_id = course.id left join history on history.student_id = student.id left join dormitory on history.dormitory_id = dormitory.id where student.is_active = true and history.date_eviction is null and violation.order_date > '" + dateFrom + "' and violation.order_date < '" + dateTo + "'" + addClause + " group by concat(student.surname, ' ', student.first_name, ' ', student.patronymic) order by student.id");

            if (records.Count != 0)
            {
                if (RadioWord.Checked)
                {
                    Report report = new Report(Application.StartupPath + @"\Templates\violations.docx");
                    report.Execute(records, dormitoryNumber, DateTime.Today.ToShortDateString(), dateFrom, dateTo);
                }
                else if (RadioExcel.Checked)
                {
                    ReportXls report = new ReportXls(Application.StartupPath + @"\Templates\common.xlsx");
                    report.Execute(records, new Dictionary<string, string> { { "Date", "Дата: " + DateTime.Now.ToString("yyyy-MM-dd") }, { "Header", "Список студентов, имеющих выговор за нарушение правил проживания в общежитии(ях) № " + dormitoryNumber + " ПГУ им. Шолом-Алейхема за период " + dateFrom + " - " + dateTo } });
                }
            }
            else
            {
                MessageBox.Show("По данному отчету нет записей");
            }
        }
    }
}
