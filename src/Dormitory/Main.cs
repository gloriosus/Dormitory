using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Dormitory
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private Database db = Database.Instance();
        private Userdata user = Userdata.Instance();
        //private NotifyData notification = NotifyData.Instance();


        //Свойства для определения полей выделенной в данный момент времени записи для последующей их передаче на форму редактирования записи
        public int SelectedId { get { return Convert.ToInt32(Table.CurrentRow.Cells[0].Value); } }


        //Метод для заполнения таблицы данными, полученными по запросу query
        public void UpdateTable(string query)
        {
            var result = db.Get(query);

            int count = result.Count;
            Table.RowCount = count;

            var debts = new List<Dictionary<string, string>>();

            for (int i = 0; i < count; i++)
            {
                Table.Rows[i].Cells[0].Value = result[i]["Id"];
                Table.Rows[i].Cells[1].Value = result[i]["Surname"];
                Table.Rows[i].Cells[2].Value = result[i]["Name"];
                Table.Rows[i].Cells[3].Value = result[i]["Patronymic"];

                Table.Rows[i].Cells[4].Value = db.Get("SELECT CONCAT(dormitory_number, ', ', street) AS Address FROM dormitory WHERE id=(SELECT dormitory_id FROM history WHERE student_id=" + result[i]["Id"] + " ORDER BY dormitory_id DESC LIMIT 1)")[0]["Address"];

                Table.Rows[i].Cells[5].Value = db.Get("SELECT Room FROM history WHERE student_id=" + result[i]["Id"] + " ORDER BY dormitory_id DESC LIMIT 1")[0]["Room"];

                Table.Rows[i].Cells[6].Value = result[i]["Debt"];
                Table.Rows[i].Cells[7].Value = result[i]["Balance"];
                Table.Rows[i].Cells[8].Value = db.Get("SELECT COUNT(id) AS Count FROM violation WHERE student_id=" + result[i]["Id"])[0]["Count"];


                if (String.IsNullOrEmpty(db.Get("SELECT date_eviction as 'Eviction' FROM history WHERE student_id=" + result[i]["Id"] + " ORDER BY id DESC LIMIT 1")[0]["Eviction"]))
                {
                    if (Convert.ToInt32(result[i]["Debt"]) > 0 || Convert.ToInt32(db.Get("select count(id) as 'Count' from violation where student_id = " + result[i]["Id"])[0]["Count"]) > 0)
                    {
                        Table.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        Table.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
                else
                {
                    Table.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }

            var students = Convert.ToInt32(db.Get("select count(id) as 'count' from student where is_notification_read = false and is_active = true")[0]["count"]);

            if (students > 0)
            {
                MenuItemNotifications.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                MenuItemNotifications.Text = "Оповещения";
            }
            else
            {
                MenuItemNotifications.DisplayStyle = ToolStripItemDisplayStyle.Text;
                MenuItemNotifications.Text = "Нет оповещений";
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //user.Set("admin", "admin");

            MenuItemLogin.Text = user.Get()["type"] == "admin" ? "Вы вошли в систему, как администратор" : "Вы вошли в систему, как обычный пользователь";

            UpdateTable("SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.is_active=1 ORDER BY student.id ASC");


            // Оповещения по долгам
            /*var students = db.Get("SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.is_active=1 ORDER BY student.id ASC");

            var debts = new List<Dictionary<string, string>>();

            foreach (var student in students)
            {
                if (Convert.ToInt32(student["Debt"]) >= 2500)
                {
                    if (!Convert.ToBoolean(student["is_notification_read"]))
                    {
                        var row = new Dictionary<string, string>() { { "id", student["Id"] }, { "fio", student["Surname"] + " " + student["Name"] + " " + student["Patronymic"] }, { "debt", student["Debt"] } };
                        debts.Add(row);
                    }
                }
            }

            notification.Set("Debt", debts);

            if (debts.Count > 0)
            {
                MenuItemNotifications.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                MenuItemNotifications.Text = "Оповещения";
            }
            else
            {
                MenuItemNotifications.DisplayStyle = ToolStripItemDisplayStyle.Text;
                MenuItemNotifications.Text = "Нет оповещений";
            }

            var students = Convert.ToInt32(db.Get("select count(id) as 'count' from student where is_notification_read = false and is_active = true")[0]["count"]);

            if (students > 0)
            {
                MenuItemNotifications.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                MenuItemNotifications.Text = "Оповещения";
            }
            else
            {
                MenuItemNotifications.DisplayStyle = ToolStripItemDisplayStyle.Text;
                MenuItemNotifications.Text = "Нет оповещений";
            }*/
        }

        private void Menu_dormitory_Click(object sender, EventArgs e)
        {
            Table_dormitory form = new Table_dormitory();
            form.ShowDialog();
        }

        private void странаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_country form = new Table_country();
            form.ShowDialog();
        }

        private void курсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_course form = new Table_course();
            form.ShowDialog();
        }

        private void группаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_group form = new Table_group();
            form.ShowDialog();
        }

        private void факультетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_faculty form = new Table_faculty();
            form.ShowDialog();
        }

        private void формаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_form form = new Table_form();
            form.ShowDialog();
        }

        private void бюджетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_budget form = new Table_budget();
            form.ShowDialog();
        }

        private void образованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_education form = new Table_education();
            form.ShowDialog();
        }

        private void ступеньToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_stage form = new Table_stage();
            form.ShowDialog();
        }



        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Record_add form = new Record_add();
            form.Owner = this;
            form.ShowDialog();
        }

        private void редToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Record_edit form = new Record_edit();
            form.Owner = this;
            form.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись о студенте?", "Подтверждение удаления", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                db.Set("UPDATE student SET is_active = false WHERE id=" + SelectedId);

                UpdateTable("SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.is_active=1 ORDER BY student.id ASC");
            }
        }

        //Поиск записи по определенному полю
        private void ToolSearch_Click(object sender, EventArgs e)
        {
            if(ToolSearchCategory.SelectedIndex != -1 && ToolSearchText.Text != "")
            {
                string selected = ToolSearchCategory.SelectedItem.ToString();
                string query = "";

                if (selected == "ID")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.id=" + ToolSearchText.Text + " AND student.is_active = true";
                }
                else if(selected == "Фамилия")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.surname LIKE '%" + ToolSearchText.Text + "%' AND student.is_active = true";
                }
                else if(selected == "Имя")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.first_name LIKE '%" + ToolSearchText.Text + "%' AND student.is_active = true";
                }
                else if (selected == "Отчество")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.patronymic LIKE '%" + ToolSearchText.Text + "%' AND student.is_active = true";
                }
                else if (selected == "Общежитие")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.id in (SELECT history.student_id FROM history WHERE history.dormitory_id in (SELECT dormitory.id FROM dormitory WHERE dormitory.dormitory_number = '" + ToolSearchText.Text + "') AND history.date_eviction IS NULL) AND student.is_active = true";
                }
                else if (selected == "Комната")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.id in (SELECT history.student_id FROM history WHERE history.room = '" + ToolSearchText.Text + "' AND history.date_eviction IS NULL) AND student.is_active = true";
                }
                else if(selected == "Страна")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.country_id in (SELECT country.id FROM country WHERE country.title LIKE '%" + ToolSearchText.Text + "%') AND student.is_active = true";
                }
                else if (selected == "Положение")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.status_id in (SELECT status.id FROM status WHERE status.title = '" + ToolSearchText.Text + "') AND student.is_active = true";
                }
                else if (selected == "Курс")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.course_id in (SELECT course.id FROM course WHERE course.course_number='" + ToolSearchText.Text + "') AND student.is_active = true";
                }
                else if (selected == "Группа")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.class_id in (SELECT class.id FROM class WHERE class.class_number='" + ToolSearchText.Text + "') AND student.is_active = true";
                }
                else if (selected == "Факультет")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.faculty_id in (SELECT faculty.id FROM faculty WHERE faculty.title = '" + ToolSearchText.Text + "') AND student.is_active = true";
                }
                else if (selected == "Форма")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.form_id in (SELECT form.id FROM form WHERE form.title = '" + ToolSearchText.Text + "') AND student.is_active = true";
                }
                else if (selected == "Отделение")
                {
                    query = "SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.budget_id in (SELECT budget.id FROM budget WHERE budget.title = '" + ToolSearchText.Text + "') AND student.is_active = true";
                }

                UpdateTable(query);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите поле, по которому будет производиться поиск, и введите строку поиска.");
            }
        }

        private void ToolSearchReset_Click(object sender, EventArgs e)
        {
            UpdateTable("SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.is_active=1 ORDER BY student.id ASC");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /*if (user.Get()["type"] == "admin")
            {
                Record_edit form = new Record_edit();
                form.Owner = this;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Доступ запрещен");
            }*/
        }

        private void MenuItemStatus_Click(object sender, EventArgs e)
        {
            Table_status form = new Table_status();
            form.ShowDialog();
        }

        private void оповещенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Notifications();
            form.Owner = this;
            form.ShowDialog();
        }



        public string commandReport = "";



        //***************** Отчеты по сиротам *************************************

        private void общежитие1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commandReport = "orphan_1";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие2Советская74ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commandReport = "orphan_2";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие3Пионерская57ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commandReport = "orphan_3";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие4ША117ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commandReport = "orphan_4";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void всеОбщежитияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commandReport = "orphan_all";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }


        //****************************** Отчеты по китайцам ***********************************

        private void общежитие1Пионерская21ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commandReport = "chinese_1";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие2Советская74ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            commandReport = "chinese_2";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие3Пионерская57ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            commandReport = "chinese_3";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие4ША117ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            commandReport = "chinese_4";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void всеОбщежитияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            commandReport = "chinese_all";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }


        //*********************************** Отчеты по первокурсникам **************************************

        private void общежитие1Пионерская21ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            commandReport = "freshman_1";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие2Советская74ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            commandReport = "freshman_2";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие3Пионерская57ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            commandReport = "freshman_3";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие4ША117ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            commandReport = "freshman_4";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void всеОбщежитияToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            commandReport = "freshman_all";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }


        //******************************** Отчет по лицеистам ***************************************

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            commandReport = "lyceum";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }


        //********************************** Отчеты по должникам *************************************

        private void общежитие1Пионерская21ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            commandReport = "debtors_1";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие2Советская74ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            commandReport = "debtors_2";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие3Пионерская57ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            commandReport = "debtors_3";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие4ША117ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            commandReport = "debtors_4";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void всеОбщежитияToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            commandReport = "debtors_all";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }


        //**************************** Отчеты по нарушениям **************************************


        private void общежитие1Пионерская21ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            commandReport = "violations_1";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие2Советская74ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            commandReport = "violations_2";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие3Пионерская57ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            commandReport = "violations_3";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие4ША117ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            commandReport = "violations_4";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void всеОбщежитияToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            commandReport = "violations_all";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }


        //************************************ Отчеты по выпускникам *****************************************

        private void общежитие1Пионерская21ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            commandReport = "graduates_1";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие2Советская74ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            commandReport = "graduates_2";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие3Пионерская57ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            commandReport = "graduates_3";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие4ША117ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            commandReport = "graduates_4";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void всеОбщежитияToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            commandReport = "graduates_all";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }


        //********************************** Отчеты по проживающим ******************************************

        private void общежитие1Пионерская21ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            commandReport = "livinglist_1";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие2Советская74ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            commandReport = "livinglist_2";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие3Пионерская57ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            commandReport = "livinglist_3";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void общежитие4ША117ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            commandReport = "livinglist_4";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }

        private void всеОбщежитияToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            commandReport = "livinglist_all";

            word_excel we = new word_excel();
            we.Owner = this;
            we.ShowDialog();
        }







        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private bool is_logout = false;

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!is_logout)
            {
                Application.Exit();
            }
        }

        private void MenuItemLogin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сменить пользователя?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                is_logout = true;

                this.Close();
                ((Form)Application.OpenForms["Authorization"]).Show();
            }
        }

        private void переводНаСледующийКурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            course_selector selector = new course_selector();
            selector.Owner = this;
            selector.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {

        }

        private void Table_SizeChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in Table.Columns)
            {
                if (column.Name != "Column1")
                {
                    column.Width = ((Table.Width - PanelFilter.Width - 3) - 50) / 8;
                }
            }
        }



        //***************************************** Навигация *******************************************

        private void NavMenuFirstRecord_Click(object sender, EventArgs e)
        {
            Table.CurrentCell = Table.Rows[0].Cells[0];
        }

        private void NavMenuPrevRecord_Click(object sender, EventArgs e)
        {
            if (Table.CurrentRow.Index > 0)
            {
                Table.CurrentCell = Table.Rows[Table.CurrentRow.Index - 1].Cells[0];
            }
        }

        private void NavMenuNextRecord_Click(object sender, EventArgs e)
        {
            if (Table.CurrentRow.Index < Table.Rows.Count - 1)
            {
                Table.CurrentCell = Table.Rows[Table.CurrentRow.Index + 1].Cells[0];
            }
        }

        private void NavMenuLastRecord_Click(object sender, EventArgs e)
        {
            Table.CurrentCell = Table.Rows[Table.Rows.Count - 1].Cells[0];
        }



        public bool IsNumber(string number)
        {
            bool result = true;

            try
            {
                Convert.ToInt32(number);
            }
            catch
            {
                result = false;
            }

            return result;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                var student = db.Get("SELECT CONCAT(student.surname, ' ', student.first_name, ' ', student.patronymic) AS 'Name', student.debt AS 'Debt',  student.birth_date AS 'BirthDate', country.title AS 'Country', status.title AS 'Status', education.title AS 'Education', course.course_number AS 'Course', class.class_number AS 'Class', faculty.title AS 'Faculty', form.title AS 'Form', budget.title AS 'Budget', stage.title AS 'Stage', student.is_deducted AS 'Deducted', student.is_registered AS 'Registered', student.passport_address as 'PassportAddress', student.balance as 'Balance', student.is_orphan as 'Orphan', student.is_graduated as 'Graduated' FROM student LEFT JOIN country ON student.country_id = country.id LEFT JOIN status ON student.status_id = status.id LEFT JOIN education ON student.education_id = education.id LEFT JOIN course ON student.course_id = course.id LEFT JOIN class ON student.class_id = class.id LEFT JOIN faculty ON student.faculty_id = faculty.id LEFT JOIN form ON student.form_id = form.id LEFT JOIN budget ON student.budget_id = budget.id LEFT JOIN stage ON student.stage_id = stage.id WHERE student.id = " + Table.CurrentRow.Cells[0].Value.ToString())[0];

                student["BirthDate"] = String.IsNullOrEmpty(student["BirthDate"]) ? "Не указана" : Convert.ToDateTime(student["BirthDate"]).ToString("yyyy-MM-dd");
                student["Deducted"] = Convert.ToBoolean(student["Deducted"]) ? "Да" : "Нет";
                student["Registered"] = Convert.ToBoolean(student["Registered"]) ? "Есть" : "Нет";
                student["Orphan"] = Convert.ToBoolean(student["Orphan"]) ? "Да" : "Нет";
                student["Graduated"] = Convert.ToBoolean(student["Graduated"]) ? "Да" : "Нет";

                foreach (var col in student)
                {
                    tabPage2.Controls.Find("Label" + col.Key, false)[0].Text = col.Value;
                }


                var violations = db.Get("SELECT violation_item.order_number AS 'Number', violation.order_date AS 'Date' FROM violation left join violation_item on violation.violation_item_id = violation_item.id WHERE violation.student_id = " + Table.CurrentRow.Cells[0].Value.ToString() + " ORDER BY violation.id ASC");

                LabelViolationCount.Text = violations.Count.ToString();

                string violationsText = "";

                foreach (var violation in violations)
                {
                    violationsText += "Статья № " + violation["Number"] + ", " + Convert.ToDateTime(violation["Date"]).ToString("yyyy-MM-dd") + "\n";
                }

                LabelViolations.Text = violationsText;


                var history = db.Get("SELECT dormitory.dormitory_number AS 'Dormitory', history.room AS 'Room', history.date_settling AS 'Settling', history.date_eviction AS 'Eviction' FROM history LEFT JOIN dormitory ON history.dormitory_id = dormitory.id WHERE history.student_id = " + Table.CurrentRow.Cells[0].Value.ToString() + " ORDER BY history.id ASC");

                string historyText = "";
                int count = 1;

                foreach (var settle in history)
                {
                    historyText += count.ToString() + ". Общежитие № " + settle["Dormitory"] + ", № ком. " + settle["Room"] + ", \n" + (!String.IsNullOrEmpty(settle["Settling"]) ? Convert.ToDateTime(settle["Settling"]).ToString("yyyy-MM-dd") : "") + " - " + (!String.IsNullOrEmpty(settle["Eviction"]) ? Convert.ToDateTime(settle["Eviction"]).ToString("yyyy-MM-dd") : "по настоящее время") + "\n";
                    count++;
                }

                LabelHistory.Text = historyText;
            }
        }

        private void статьиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_violation_item form = new Table_violation_item();
            form.ShowDialog();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user.Get()["type"] == "admin")
            {
                Table_user form = new Table_user();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Доступ запрещен");
            }
        }

        private void ButtonFilterAccept_Click(object sender, EventArgs e)
        {
            if (CheckBoxRed.Checked && CheckBoxGreen.Checked && CheckBoxGrey.Checked)
            {
                foreach (DataGridViewRow row in Table.Rows)
                {
                    row.Visible = true;
                }
            }
            else if (CheckBoxRed.Checked && !CheckBoxGreen.Checked && !CheckBoxGrey.Checked)
            {
                foreach (DataGridViewRow row in Table.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightGreen || row.DefaultCellStyle.BackColor == Color.LightGray)
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }
            else if (!CheckBoxRed.Checked && CheckBoxGreen.Checked && !CheckBoxGrey.Checked)
            {
                foreach (DataGridViewRow row in Table.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightCoral || row.DefaultCellStyle.BackColor == Color.LightGray)
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }
            else if (!CheckBoxRed.Checked && !CheckBoxGreen.Checked && CheckBoxGrey.Checked)
            {
                foreach (DataGridViewRow row in Table.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightCoral || row.DefaultCellStyle.BackColor == Color.LightGreen)
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }
            else if (CheckBoxRed.Checked && CheckBoxGreen.Checked && !CheckBoxGrey.Checked)
            {
                foreach (DataGridViewRow row in Table.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightGray)
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }
            else if (!CheckBoxRed.Checked && CheckBoxGreen.Checked && CheckBoxGrey.Checked)
            {
                foreach (DataGridViewRow row in Table.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightCoral)
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }
            else if (CheckBoxRed.Checked && !CheckBoxGreen.Checked && CheckBoxGrey.Checked)
            {
                foreach (DataGridViewRow row in Table.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightGreen)
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }
            else if (!CheckBoxRed.Checked && !CheckBoxGreen.Checked && !CheckBoxGrey.Checked)
            {
                foreach (DataGridViewRow row in Table.Rows)
                {
                    row.Visible = false;
                }
            }


            foreach (DataGridViewRow row in Table.Rows)
            {
                if (row.Visible)
                {
                    Table.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void ButtonFilterReset_Click(object sender, EventArgs e)
        {
            CheckBoxRed.Checked = true;
            CheckBoxGreen.Checked = true;
            CheckBoxGrey.Checked = true;

            foreach (DataGridViewRow row in Table.Rows)
            {
                row.Visible = true;
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            UpdateTable("SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.is_active=1 ORDER BY student.id ASC");
        }

        private void погаситьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debt_payment debt = new debt_payment("Pay");
            debt.Owner = this;
            debt.ShowDialog();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            debt_payment debt = new debt_payment("Add");
            debt.Owner = this;
            debt.ShowDialog();
        }
    }
}