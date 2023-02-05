using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Dormitory
{
    class Report
    {
        public Report(string templatePath)
        {
            try
            {
                app = new Word.Application();
                app.Visible = false;
                document = app.Documents.Open(templatePath);
            }
            catch (Exception e)
            {
                document.Close(SaveChanges: Word.WdSaveOptions.wdDoNotSaveChanges);
                app.Quit(SaveChanges: Word.WdSaveOptions.wdDoNotSaveChanges);
                MessageBox.Show(e.ToString());
            }
        }

        private Word.Application app = null;
        private Word.Document document = null;

        public void Execute(List<Dictionary<string, string>> records, string dormitory_number, string date, string dateFrom, string dateTo)
        {
            try
            {
                ReplaceText("{number}", dormitory_number);
                ReplaceText("{number}", dormitory_number);
                ReplaceText("{count}", records.Count.ToString());
                ReplaceText("{year}", dateFrom + " - " + dateTo);
                ReplaceText("{date}", date);

                var keys = records[0].Keys;

                for (int i = 1; i <= records.Count; i++)
                {
                    var col = 0;
                    document.Tables[1].Rows.Add();

                    foreach (var key in keys)
                    {
                        col++;
                        document.Tables[1].Cell(i + 1, col).Range.Text = records[i - 1][key];
                    }
                }

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Файл Microsoft Word (*.docx)|*.docx|Все файлы (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    document.SaveAs2(FileName: dialog.FileName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                document.Close(SaveChanges: Word.WdSaveOptions.wdDoNotSaveChanges);
                app.Quit(SaveChanges: Word.WdSaveOptions.wdDoNotSaveChanges);
            }
        }

        public void ReplaceText(string findText, string newText)
        {
            var range = document.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: findText, ReplaceWith: newText);
        }

        public string GetChartTitle()
        {
            string title = "empty";

            try
            {
                title = document.InlineShapes[1].Chart.ChartTitle.Caption;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                document.Close(SaveChanges: Word.WdSaveOptions.wdDoNotSaveChanges);
                app.Quit(SaveChanges: Word.WdSaveOptions.wdDoNotSaveChanges);
            }

            return title;
        }
    }
}
