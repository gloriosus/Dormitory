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
    public partial class Table_form : Form
    {
        public Table_form()
        {
            InitializeComponent();
        }

        private Database db;

        private bool isSearched = false;
        private string searchQuery = "";
        private string[] categories = new string[] { "id", "title" };
        private string[] orders = new string[] { "ASC", "DESC" };

        private void UpdateTable(string query)
        {
            var result = db.Get(query);

            int count = result.Count;
            Table.RowCount = count;

            for (int i = 0; i < count; i++)
            {
                Table.Rows[i].Cells[0].Value = result[i]["id"];
                Table.Rows[i].Cells[1].Value = result[i]["title"];
            }
        }

        private void Table_country_Load(object sender, EventArgs e)
        {
            db = Database.Instance();
            UpdateTable("SELECT id, title FROM form WHERE is_active = true");
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            string nominal = FieldNominal.Text;

            if (nominal != "")
            {
                db.Set("INSERT INTO form (title) VALUES ('" + nominal + "')");
                UpdateTable("SELECT id, title FROM form WHERE is_active = true");
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (Table.CurrentRow.Index != -1)
            {
                int id = Convert.ToInt32(Table.Rows[Table.CurrentRow.Index].Cells[0].Value);

                db.Set("UPDATE form SET is_active = false WHERE id=" + id);
                UpdateTable("SELECT id, title FROM form WHERE is_active = true");
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            string nominal = FieldNominal.Text;

            if (nominal != "")
            {
                int id = Convert.ToInt32(Table.Rows[Table.CurrentRow.Index].Cells[0].Value);

                db.Set("UPDATE form SET title='" + nominal + "' WHERE id=" + id);
                UpdateTable("SELECT id, title FROM form WHERE is_active = true");
            }
        }

        private void Table_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                FieldNominal.Text = Table.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            if (FieldSearch.Text != "")
            {
                searchQuery = "SELECT id, title FROM form WHERE is_active = true AND " + categories[FieldSearchCategory.SelectedIndex] + "='" + FieldSearch.Text + "'";
                UpdateTable(searchQuery);
                isSearched = true;
            }
            else
            {
                UpdateTable("SELECT id, title FROM form WHERE is_active = true");
                isSearched = false;
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            FieldSearch.Text = "";
            UpdateTable("SELECT id, title FROM form WHERE is_active = true");
            isSearched = false;
        }

        private void ButtonSort_Click(object sender, EventArgs e)
        {
            if (FieldSortCategory.SelectedIndex != -1 && FieldSortOrder.SelectedIndex != -1)
            {
                string query = "";

                if (!isSearched)
                {
                    query = "SELECT id, title FROM form WHERE is_active = true ORDER BY " + categories[FieldSortCategory.SelectedIndex] + " " + orders[FieldSortOrder.SelectedIndex];
                }
                else
                {
                    query = searchQuery + " ORDER BY " + categories[FieldSortCategory.SelectedIndex] + " " + orders[FieldSortOrder.SelectedIndex];
                }

                UpdateTable(query);
            }
        }
    }
}
