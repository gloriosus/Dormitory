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
    public partial class date_selector : Form
    {
        public date_selector()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            word_excel main = this.Owner as word_excel;

            switch(main.dNumber)
            {
                case 1:
                    main.ViolationReport(" AND dormitory.dormitory_number = 1", "1", from.Value.ToString("yyyy-MM-dd"), to.Value.ToString("yyyy-MM-dd"));
                    break;
                case 2:
                    main.ViolationReport(" AND dormitory.dormitory_number = 2", "2", from.Value.ToString("yyyy-MM-dd"), to.Value.ToString("yyyy-MM-dd"));
                    break;
                case 3:
                    main.ViolationReport(" AND dormitory.dormitory_number = 3", "3", from.Value.ToString("yyyy-MM-dd"), to.Value.ToString("yyyy-MM-dd"));
                    break;
                case 4:
                    main.ViolationReport(" AND dormitory.dormitory_number = 4", "4", from.Value.ToString("yyyy-MM-dd"), to.Value.ToString("yyyy-MM-dd"));
                    break;
                case 5:
                    main.ViolationReport("", "1, 2, 3, 4", from.Value.ToString("yyyy-MM-dd"), to.Value.ToString("yyyy-MM-dd"));
                    break;
            }

            Close();
        }
    }
}
