using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Helper
    {
        private static mydbContext instance;
        public static mydbContext GetContext() => instance ??= new mydbContext();
    }
}
