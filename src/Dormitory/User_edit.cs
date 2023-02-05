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
    public partial class User_edit : Form
    {
        public User_edit()
        {
            InitializeComponent();
        }

        private Database db = Database.Instance();

        private void User_edit_Load(object sender, EventArgs e)
        {
            var types = db.Get("SELECT title FROM type");

            foreach (Dictionary<string, string> type in types)
            {
                FieldType.Items.Add(type["title"]);
            }

            Table_user form = this.Owner as Table_user;
            var data = db.Get("SELECT id, username, type_id FROM user WHERE id=" + form.SelectedId)[0];

            FieldLogin.Text = data["username"];
            FieldType.SelectedItem = db.Get("SELECT title FROM type WHERE id=" + data["type_id"])[0]["title"];
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (FieldLogin.Text != "" && FieldPassword.Text != "" && FieldType.SelectedIndex != -1)
            {
                Table_user form = this.Owner as Table_user;
                var type = db.Get("SELECT id FROM type WHERE title='" + FieldType.SelectedItem + "'")[0]["id"];
                db.Set("UPDATE user SET username='" + FieldLogin.Text + "', password='" + FieldPassword.Text + "', type_id=" + type + " WHERE id=" + form.SelectedId);
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
