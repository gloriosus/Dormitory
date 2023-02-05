using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Dormitory
{
    class Database
    {
        private static Database _instance;

        private readonly MySqlConnection _connection;
        private readonly MySqlCommand _command;

        private string host = "";
        private string dbname = "";
        private string user = "";
        private string password = "";

        private Database()
        {
            IniEditor Ini = new IniEditor();

            host = Ini.GetValue(AppDomain.CurrentDomain.BaseDirectory + @"settings.ini", "[Database]", "host");
            dbname = Ini.GetValue(AppDomain.CurrentDomain.BaseDirectory + @"settings.ini", "[Database]", "dbname");
            user = Ini.GetValue(AppDomain.CurrentDomain.BaseDirectory + @"settings.ini", "[Database]", "user");
            password = Ini.GetValue(AppDomain.CurrentDomain.BaseDirectory + @"settings.ini", "[Database]", "password");

            _connection = new MySqlConnection();
            _connection.ConnectionString = "Server=" + host + "; Database=" + dbname + "; Uid=" + user + "; Pwd=" + password + ";";
            _command = new MySqlCommand();
            _command.Connection = _connection;
        }

        public static Database Instance()
        {
            return _instance ?? (_instance = new Database());
        }

        //Only for SELECT queries
        public List<Dictionary<string, string>> Get(string query)
        {
            _connection.Open();
            _command.CommandText = query;
            MySqlDataReader reader = _command.ExecuteReader();

            int columns = reader.FieldCount;
            List<Dictionary<string, string>> records = new List<Dictionary<string, string>>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Dictionary<string, string> row = new Dictionary<string, string>();

                    for(int i = 0; i < columns; i++)
                    {
                        row.Add(reader.GetName(i), reader[i].ToString());
                    }

                    records.Add(row);
                }
            }

            _connection.Close();

            return records;
        }

        //For INSERT, DELETE and UPDATE queries
        public int Set(string query)
        {
            int result = -1;

            try
            {
                _connection.Open();
                _command.CommandText = query;
                _command.ExecuteNonQuery();
                _command.CommandText = "SELECT @@IDENTITY";
                result = Convert.ToInt32(_command.ExecuteScalar());
            }
            catch(Exception e)
            {
                foreach (var value in e.Data.Values)
                {
                    if (value.ToString() == "1062")
                    {
                        MessageBox.Show("Невозможно выполнить операцию, так как запись о таком студенте уже существует", "Найдено совпадение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка, повторите позже");
                    }
                }
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        public int Count(string table)
        {
            _connection.Open();
            _command.CommandText = "SELECT COUNT(*) FROM " + table;
            MySqlDataReader reader = _command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt32(0);
            return count;
        }
    }
}
