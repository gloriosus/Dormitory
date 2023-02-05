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
    public partial class Table_user : Form
    {
        public Table_user()
        {
            InitializeComponent();
        }

        private Database db = Database.Instance();

        public string SelectedId { get { return Table.CurrentRow.Cells[0].Value.ToString(); } }

        private void Table_user_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        public void UpdateTable()
        {
            var result = db.Get("SELECT id, username, password, type_id FROM user WHERE is_active=1");
            int count = result.Count;
            Table.RowCount = count;

            for (int i = 0; i < count; i++)
            {
                Table.Rows[i].Cells[0].Value = result[i]["id"];
                Table.Rows[i].Cells[1].Value = result[i]["username"];
                Table.Rows[i].Cells[2].Value = "****";
                Table.Rows[i].Cells[3].Value = db.Get("SELECT title FROM type WHERE id=" + result[i]["type_id"])[0]["title"];
            }
        }

        private void ToolStripAdd_Click(object sender, EventArgs e)
        {
            User_add form = new User_add();
            form.Owner = this;
            form.ShowDialog();
        }

        private void ToolStripEdit_Click(object sender, EventArgs e)
        {
            User_edit form = new User_edit();
            form.Owner = this;
            form.ShowDialog();
        }

        private void DeleteToolStrip_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить пользователя?", "Удаление", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                db.Set("DELETE FROM user WHERE id=" + SelectedId);
                UpdateTable();
            }
        }
    }
}
