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
    public partial class User_add : Form
    {
        public User_add()
        {
            InitializeComponent();
        }

        private Database db = Database.Instance();

        private void User_add_Load(object sender, EventArgs e)
        {
            var result = db.Get("SELECT title FROM type");

            foreach (Dictionary<string, string> item in result)
            {
                FieldType.Items.Add(item["title"]);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (FieldLogin.Text != "" && FieldPassword.Text != "" && FieldType.SelectedIndex != -1)
            {
                var type = db.Get("SELECT id FROM type WHERE title='" + FieldType.SelectedItem + "'")[0]["id"];
                db.Set("INSERT INTO user (username, password, type_id) VALUES ('" + FieldLogin.Text + "', '" + FieldPassword.Text + "', " + type +")");
                Table_user form = this.Owner as Table_user;
                form.UpdateTable();
                this.Close();
            }
            else
            {
                label4.Visible = true;
            }
        }
    }
}
