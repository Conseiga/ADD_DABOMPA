using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADD_DABOMPA.Services
{
    sealed class WindowsManagemantService
    {
        private WindowsManagemantService() { }
        public Window CurrentWindow { get; private set; }

        private static WindowsManagemantService _instance;
        private static readonly object _lock = new object();

        public static WindowsManagemantService Instance(Window newWindow)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new WindowsManagemantService();
                    }
                }
            }
            _instance.CurrentWindow = newWindow;
            return _instance; // Added return statement to fix CS0161
        }
    }
}
