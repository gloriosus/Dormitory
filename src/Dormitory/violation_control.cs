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
    public partial class violation_control : Form
    {
        public violation_control()
        {
            InitializeComponent();
        }

        Database db = Database.Instance();

        Record_edit edit;

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void violation_control_Load(object sender, EventArgs e)
        {
            edit = this.Owner as Record_edit;

            if (edit.status == "Edit")
            {
                FieldDate.Value = Convert.ToDateTime(edit.TableViolation.CurrentRow.Cells[2].Value);
            }

            var orders = db.Get("select order_number as 'Number', article as 'Article' from violation_item where is_active = true");

            Table.RowCount = orders.Count;

            for (int i = 0; i < Table.RowCount; i++)
            {
                Table.Rows[i].Cells[0].Value = orders[i]["Number"];
                Table.Rows[i].Cells[1].Value = orders[i]["Article"];
            }

            ButtonCheckSelect.Checked = true;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (FieldNumber.Text != "" && FieldArticle.Text != "")
            {
                var violation_item_id = db.Set("insert into violation_item (order_number, article) values (" + FieldNumber.Text + ", '" + FieldArticle.Text + "')");
                var order_date = FieldDate.Value.ToString("yyyy-MM-dd");

                if (edit.status == "Create")
                {
                    db.Set("insert into violation (student_id, violation_item_id, order_date) values (" + edit.StudentId + ", " + violation_item_id + ", '" + order_date + "')");
                }
                else if (edit.status == "Edit")
                {
                    db.Set("update violation set student_id = " + edit.StudentId + ", violation_item_id = " + violation_item_id + ", order_date = '" + order_date + "' where id = " + edit.TableViolation.CurrentRow.Cells[0].Value.ToString());
                }

                edit.UpdateTable("Violation");

                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите номер статьи и краткое описание");
            }
        }

        private void ButtonCheckSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ButtonCheckSelect.Checked)
            {
                panel1.Visible = false;
                panel2.Location = panel1.Location;
                panel2.Visible = true;

                label4.Text = "Выберите нарушение из списка ...";
                label5.Text = "... или добавьте новое";

                ButtonCheckSelect.Text = "Добавить";
            }
            else
            {
                panel1.Visible = true;
                panel2.Location = panel1.Location;
                panel2.Visible = false;

                label4.Text = "Введите новое нарушение ...";
                label5.Text = "... или выберите из существующего";

                ButtonCheckSelect.Text = "Выбрать";
            }
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            if (Table.CurrentRow.Index != -1)
            {
                var violation_item_id = db.Get("select id from violation_item where order_number = " + Table.CurrentRow.Cells[0].Value.ToString())[0]["id"];

                if (edit.status == "Create")
                {
                    db.Set("insert into violation (student_id, violation_item_id, order_date) values (" + edit.StudentId + ", " + violation_item_id + ", '" + FieldDate.Value.ToString("yyyy-MM-dd") + "')");
                }
                else if (edit.status == "Edit")
                {
                    db.Set("update violation set student_id = " + edit.StudentId + ", violation_item_id = " + violation_item_id + ", order_date = '" + FieldDate.Value.ToString("yyyy-MM-dd") + "' where id = " + edit.TableViolation.CurrentRow.Cells[0].Value.ToString());
                }

                edit.UpdateTable("Violation");

                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите статью из списка");
            }
        }
    }
}
