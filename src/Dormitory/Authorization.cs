using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;

namespace Dormitory
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private Database db = Database.Instance();

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            if (FieldLogin.Text != "" && FieldPassword.Text != "")
            {
                Login();
            }
        }

        private void Login()
        {
            var data = db.Get("SELECT username, password, type_id FROM user WHERE username='" + FieldLogin.Text + "' AND password='" + FieldPassword.Text + "'");

            if (data.Count == 1)
            {
                Userdata user = Userdata.Instance();
                var type = db.Get("SELECT title FROM type WHERE id=" + data[0]["type_id"])[0]["title"];
                user.Set(data[0]["username"], type);

                Main form = new Main();
                form.Show();
                this.Hide();
            }
            else
            {
                label3.Visible = true;
                FieldPassword.Clear();
            }
        }

        private void FieldLogin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(FieldLogin.Text) && !String.IsNullOrEmpty(FieldPassword.Text))
                {
                    Login();
                }
            }
        }

        private void FieldPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(FieldLogin.Text) && !String.IsNullOrEmpty(FieldPassword.Text))
                {
                    Login();
                }
            }
        }

        private void Authorization_Activated(object sender, EventArgs e)
        {
            FieldLogin.Clear();
            FieldPassword.Clear();
            FieldLogin.Focus();
        }
    }
}
