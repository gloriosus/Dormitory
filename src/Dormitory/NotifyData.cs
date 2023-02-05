using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dormitory
{
    class NotifyData
    {
        private static NotifyData instance;

        private Dictionary<string, string> row = new Dictionary<string, string> 
        {
            { "id", String.Empty },
            { "fio", String.Empty },
            { "debt", String.Empty }
        };

        private List<Dictionary<string, string>> data_debt = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> data_violation = new List<Dictionary<string, string>>();

        public static NotifyData Instance()
        {
            return instance ?? (instance = new NotifyData());
        }

        public List<Dictionary<string, string>> Get(string type)
        {
            return type == "Debt" ? data_debt : data_violation;
        }

        public void Set(string type, List<Dictionary<string, string>> array)
        {
            if (type == "Debt")
            {
                data_debt = array;
            }
            else if(type == "Violation")
            {
                data_violation = array;
            }
        }

        public void Clear(string type)
        {
            if (type == "Debt")
            {
                data_debt.Clear();
            }
            else if(type == "Violation")
            {
                data_violation.Clear();
            }
        }
    }
}
