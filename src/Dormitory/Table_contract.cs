﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dormitory
{
    public partial class Table_contract : Form
    {
        public Table_contract()
        {
            InitializeComponent();
        }

        private Database db;

        private bool isSearched = false;
        private string searchQuery = "";
        private string[] categories = new string[] { "id", "number" };
        private string[] orders = new string[] { "ASC", "DESC" };

        private void UpdateTable(string query)
        {
            var result = db.Get(query);

            int count = result.Count;
            Table.RowCount = count;

            for (int i = 0; i < count; i++)
            {
                Table.Rows[i].Cells[0].Value = result[i]["id"];
                Table.Rows[i].Cells[1].Value = result[i]["number"];
            }
        }

        private void Table_country_Load(object sender, EventArgs e)
        {
            try
            {
                db = Database.Instance();
                UpdateTable("SELECT * FROM contract");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при попытке подключения к базе данных.");
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            string nominal = FieldNominal.Text;

            if (nominal != "")
            {
                try
                {
                    db.Set("INSERT INTO contract (number) VALUES ('" + nominal + "')");
                    UpdateTable("SELECT * FROM contract");
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при попытке подключения к базе данных.");
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (Table.CurrentRow.Index != -1)
            {
                int id = Convert.ToInt32(Table.Rows[Table.CurrentRow.Index].Cells[0].Value);

                try
                {
                    db.Set("DELETE FROM contract WHERE id=" + id);
                    UpdateTable("SELECT * FROM contract");
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при попытке подключения к базе данных.");
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            string nominal = FieldNominal.Text;

            if (nominal != "")
            {
                int id = Convert.ToInt32(Table.Rows[Table.CurrentRow.Index].Cells[0].Value);

                try
                {
                    db.Set("UPDATE contract SET number='" + nominal + "' WHERE id=" + id);
                    UpdateTable("SELECT * FROM contract");
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при попытке подключения к базе данных.");
                }
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
                searchQuery = "SELECT * FROM contract WHERE " + categories[FieldSearchCategory.SelectedIndex] + "='" + FieldSearch.Text + "'";
                UpdateTable(searchQuery);
                isSearched = true;
            }
            else
            {
                UpdateTable("SELECT * FROM contract");
                isSearched = false;
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            FieldSearch.Text = "";
            UpdateTable("SELECT * FROM contract");
            isSearched = false;
        }

        private void ButtonSort_Click(object sender, EventArgs e)
        {
            if (FieldSortCategory.SelectedIndex != -1 && FieldSortOrder.SelectedIndex != -1)
            {
                string query = "";

                if (!isSearched)
                {
                    query = "SELECT * FROM contract ORDER BY " + categories[FieldSortCategory.SelectedIndex] + " " + orders[FieldSortOrder.SelectedIndex];
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
