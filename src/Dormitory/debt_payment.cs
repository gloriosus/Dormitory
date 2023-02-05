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
    public partial class debt_payment : Form
    {
        public debt_payment(string type)
        {
            InitializeComponent();

            Type = type;
        }

        private string Type = "";


        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && IsNumber(textBox1.Text))
            {
                int pay = Math.Abs(Convert.ToInt32(textBox1.Text));

                Database db = Database.Instance();

                Main main = this.Owner as Main;

                if (Type == "Pay")
                {
                    foreach (DataGridViewRow row in main.Table.SelectedRows)
                    {
                        int debt = Convert.ToInt32(row.Cells[6].Value);
                        int balance = Convert.ToInt32(row.Cells[7].Value);
                        int result = 0;

                        if (balance > 0)
                        {
                            result = debt - (pay + balance);
                            balance = 0;
                        }
                        else
                        {
                            result = debt - pay;
                        }

                        if (Math.Sign(result) != -1)
                        {
                            db.Set("update student set debt = " + result + ", balance = " + balance + " where id = " + row.Cells[0].Value.ToString());
                        }
                        else
                        {
                            balance = Math.Abs(result);
                            db.Set("update student set debt = 0, balance = " + balance + " where id = " + row.Cells[0].Value.ToString());
                        }

                        if (Convert.ToInt32(db.Get("select debt from student where id = " + row.Cells[0].Value.ToString())[0]["debt"]) >= 2500)
                        {
                            db.Set("update student set is_notification_read = false where id = " + row.Cells[0].Value.ToString());
                        }
                        else
                        {
                            db.Set("update student set is_notification_read = true where id = " + row.Cells[0].Value.ToString());
                        }
                    }

                    main.UpdateTable("SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.is_active=1 ORDER BY student.id ASC");

                    MessageBox.Show("Задоженность погашена", "Успешное завершение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Type == "Add")
                {
                    foreach (DataGridViewRow row in main.Table.SelectedRows)
                    {
                        int debt = Convert.ToInt32(row.Cells[6].Value) + pay;

                        db.Set("update student set debt = " + debt + " where id = " + row.Cells[0].Value.ToString());

                        if (Convert.ToInt32(db.Get("select debt from student where id = " + row.Cells[0].Value.ToString())[0]["debt"]) >= 2500)
                        {
                            db.Set("update student set is_notification_read = false where id = " + row.Cells[0].Value.ToString());
                        }
                        else
                        {
                            db.Set("update student set is_notification_read = true where id = " + row.Cells[0].Value.ToString());
                        }
                    }

                    main.UpdateTable("SELECT student.id as 'Id', student.surname as 'Surname', student.first_name as 'Name', student.patronymic as 'Patronymic', student.debt as 'Debt', student.balance as 'Balance', student.is_notification_read FROM student WHERE student.is_active=1 ORDER BY student.id ASC");

                    MessageBox.Show("Задоженность добавлена", "Успешное завершение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля правильно");
            }
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Clear();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "0";
            }
        }

        private void debt_payment_Load(object sender, EventArgs e)
        {
            Main main = this.Owner as Main;

            if (Type == "Pay")
            {
                Text = "Погасить долг";

                label2.Visible = true;
                int result = Convert.ToInt32(main.Table.CurrentRow.Cells[6].Value) - Convert.ToInt32(main.Table.CurrentRow.Cells[7].Value);
                label2.Text = "Сумма к оплате: " + result.ToString();
            }
            else if (Type == "Add")
            {
                Text = "Добавить долг";
                label2.Visible = false;
            }
        }
    }
}
