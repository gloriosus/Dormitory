using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dormitory
{
    class Userdata
    {
        private static Userdata instance;

        private Dictionary<string, string> data = new Dictionary<string, string>{
            { "username", "" },
            { "type", "" }
        };

        public static Userdata Instance()
        {
            return instance ?? (instance = new Userdata());
        }

        public Dictionary<string, string> Get()
        {
            return data;
        }

        public void Set(string username, string type)
        {
            data["username"] = username;
            data["type"] = type;
        }
    }
}
