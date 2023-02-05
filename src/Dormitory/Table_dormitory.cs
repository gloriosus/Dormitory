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
    public partial class Table_dormitory : Form
    {
        public Table_dormitory()
        {
            InitializeComponent();
        }

        private Database db;

        private bool isSearched = false;                                            //Переменная для определения производили ли мы поиск, что дает возможность сортировки даже после поиска
        private string searchQuery = "";                                           //Служит для хранения запроса поиска для последующего его объединения с запросом сортировки (используется совместно с isSearched)
        private string[] categories = new string[] { "id", "dormitory_number", "street" };  //Хранение названий полей для подстановки в запросы поиска и сортировки
        private string[] orders = new string[] { "ASC", "DESC" };

        private void UpdateTable(string query)
        {
            var result = db.Get(query);

            int count = result.Count;
            Table.RowCount = count;

            for (int i = 0; i < count; i++)
            {
                Table.Rows[i].Cells[0].Value = result[i]["id"];
                Table.Rows[i].Cells[1].Value = result[i]["dormitory_number"];
                Table.Rows[i].Cells[2].Value = result[i]["street"];
            }
        }

        private void Table_dormitory_Load(object sender, EventArgs e)
        {
            try
            {
                db = Database.Instance();
                UpdateTable("SELECT * FROM dormitory WHERE is_active = true");
            }
            catch(Exception q)
            {
                //MessageBox.Show("Произошла ошибка при попытке подключения к базе данных.");
                MessageBox.Show(q.ToString());
            }
        }

        private void Button_insert_Click(object sender, EventArgs e)
        {
            string number = Field_number.Text;
            string street = Field_street.Text;

            if (number != "" && street != "")
            {
                db.Set("INSERT INTO dormitory (dormitory_number, street) VALUES ('" + number + "', '" + street + "')");
                UpdateTable("SELECT id, dormitory_number, street FROM dormitory WHERE is_active = true");
            }
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            if(Table.CurrentRow.Index != -1)
            {
                int id = Convert.ToInt32(Table.Rows[Table.CurrentRow.Index].Cells[0].Value);

                db.Set("UPDATE dormitory SET is_active = false WHERE id=" + id);
                UpdateTable("SELECT id, dormitory_number, street FROM dormitory WHERE is_active = true");
            }
        }

        private void Button_edit_Click(object sender, EventArgs e)
        {
            string number = Field_number.Text;
            string street = Field_street.Text;

            if (number != "" && street != "")
            {
                int id = Convert.ToInt32(Table.Rows[Table.CurrentRow.Index].Cells[0].Value);

                db.Set("UPDATE dormitory SET dormitory_number='" + number + "', street='" + street + "' WHERE id=" + id);
                UpdateTable("SELECT id, dormitory_number, street FROM dormitory WHERE is_active = true");
            }
        }

        //Чтобы поля Номер и Улица автоматически заполнялись в зависимости от выбранной в таблице записи, конструкция try-catch добавлена во избежание ошибок при пустой таблице
        private void Table_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Field_number.Text = Table.CurrentRow.Cells[1].Value.ToString();
                Field_street.Text = Table.CurrentRow.Cells[2].Value.ToString();
            }
            catch { }
        }

        private void Button_find_Click(object sender, EventArgs e)
        {
            if(SearchText.Text != "")
            {
                searchQuery = "SELECT id, dormitory_number, street FROM dormitory WHERE is_active = true AND " + categories[Category.SelectedIndex] + "='" + SearchText.Text + "'";
                UpdateTable(searchQuery);
                isSearched = true;
            }
            else
            {
                UpdateTable("SELECT id, dormitory_number, street FROM dormitory WHERE is_active = true");
                isSearched = false;
            }
        }

        private void Button_reset_Click(object sender, EventArgs e)
        {
            SearchText.Text = "";
            UpdateTable("SELECT id, dormitory_number, street FROM dormitory WHERE is_active = true");
            isSearched = false;
        }

        private void ButtonSort_Click(object sender, EventArgs e)
        {
            if(Sort_category.SelectedIndex != -1 && Sort_order.SelectedIndex != -1)
            {
                string query = "";

                if (!isSearched)
                {
                    query = "SELECT id, dormitory_number, street FROM dormitory WHERE is_active = true ORDER BY " + categories[Sort_category.SelectedIndex] + " " + orders[Sort_order.SelectedIndex];
                }
                else
                {
                    query = searchQuery +  " ORDER BY " + categories[Sort_category.SelectedIndex] + " " + orders[Sort_order.SelectedIndex];
                }

                UpdateTable(query);
            }
        }
    }
}