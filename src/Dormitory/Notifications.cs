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
    public partial class Notifications : Form
    {
        public Notifications()
        {
            InitializeComponent();
        }

        //NotifyData notification = NotifyData.Instance();
        Database db = Database.Instance();

        List<Dictionary<string, string>> students;
        List<Dictionary<string, string>> debts;

        private void Notifications_Load(object sender, EventArgs e)
        {
            /*foreach (var row in notification.Get("Debt"))
            {
                var item = new ListViewItem(new string[] { row["fio"], row["debt"] }, listView1.Groups["GroupDebt"]);
                listView1.Items.Add(item);
            }*/

            //var students = db.Get("SELECT concat(student.surname, ' ', student.first_name, ' ', student.patronymic) as 'fio', violation_item.order_number as 'number', violation.order_date as 'date', violation_item.article as 'article' FROM violation left join student on violation.student_id = student.id left join violation_item on violation.violation_item_id = violation_item.id ORDER BY violation.id ASC");

            debts = db.Get("select student.id, concat(surname, ' ', first_name, ' ', patronymic) as 'fio', debt from student where debt >= 2500 and is_active = true and is_notification_read = false order by id");

            foreach (var debt in debts)
            {
                var item = new ListViewItem(new string[] { debt["fio"], debt["debt"] }, listView1.Groups["GroupDebt"]);
                listView1.Items.Add(item);
            }


            students = db.Get("set sql_mode = ''; select student.id as 'id', concat(student.surname, ' ', student.first_name, ' ', student.patronymic) as 'fio' from violation left join student on violation.student_id = student.id where student.is_notification_read = false and student.is_active = true group by student.id");

            foreach (var student in students)
            {
                listView2.Groups.Add(student["fio"], student["fio"]);

                var violations = db.Get("select violation_item.order_number as 'number', violation.order_date as 'date', violation_item.article as 'article' from violation left join violation_item on violation.violation_item_id = violation_item.id where violation.student_id = " + student["id"]);


                if (violations.Count >= 2)
                {
                    foreach (var violation in violations)
                    {
                        var item = new ListViewItem(new string[] { "", violation["number"], violation["date"], violation["article"] }, listView2.Groups[student["fio"]]);
                        listView2.Items.Add(item);
                    }
                }
            }
        }

        private void MenuItemClearAll_Click(object sender, EventArgs e)
        {
            /*foreach (var row in notification.Get("Debt"))
            {
                db.Set("UPDATE student SET is_notification_read=1 WHERE id=" + row["id"]);
            }*/

            foreach (var debt in debts)
            {
                db.Set("UPDATE student SET is_notification_read=1 WHERE id=" + debt["id"]);
            }

            foreach (var student in students)
            {
                db.Set("UPDATE student SET is_notification_read=1 WHERE id=" + student["id"]);
            }

            listView1.Items.Clear();
            listView2.Items.Clear();

            //notification.Set("Debt", null);

            var form = this.Owner as Main;
            form.UpdateTable("SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.is_active=1 ORDER BY student.id ASC");
        }

        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void прочитатьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
