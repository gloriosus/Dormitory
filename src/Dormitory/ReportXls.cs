using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Xls = Microsoft.Office.Interop.Excel;

namespace Dormitory
{
    class ReportXls
    {
        public ReportXls(string templatePath)
        {
            try
            {
                app = new Xls.Application();
                app.Visible = false;
                book = app.Workbooks.Open(Filename: templatePath);
                sheets = book.Worksheets;
            }
            catch (Exception e)
            {
                sheets = null;
                book.Close(false);
                app.Quit();

                MessageBox.Show(e.ToString());
            }
        }

        private Xls.Application app = null;
        private Xls.Workbook book = null;
        private Xls.Sheets sheets = null;
        private Xls.Worksheet sheet = null;

        public void Execute(List<Dictionary<string, string>> records, Dictionary<string, string> info)
        {
            try
            {
                sheet = (Xls.Worksheet)sheets.get_Item(1);

                var keys = records[0].Keys;

                var n = 0;

                foreach (var key in keys)
                {
                    n++;
                    sheet.Cells[10, n].Value = key;
                }

                for (int i = 11; i <= records.Count + 10; i++)
                {
                    var col = 0;

                    foreach (var key in keys)
                    {
                        col++;
                        sheet.Cells[i, col].Value = records[i - 11][key];
                        sheet.Cells[i, col].Borders.Color = Color.Black.ToArgb();
                    }
                }

                foreach (var item in info) 
                {
                    if (item.Key == "Date")
                    {
                        sheet.Cells[8, 1].Value = item.Value;
                    }
                    else if (item.Key == "Header")
                    {
                        sheet.Cells[5, 1].Value = item.Value;
                    }
                    else if (item.Key == "Count")
                    {
                        sheet.Cells[8, 2].Value = item.Value;
                    }
                }

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    book.SaveAs(Filename: dialog.FileName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                book.Close(false);
                app.Quit();

                sheet = null;
                sheets = null;
                book = null;
                app = null;
            }
        }
    }
}
