using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpdOstatni.ViewModel;

namespace UnitTestProject1
{
    class DebugDisplayError : DisplayError
    {
        public void PresentError(string message)
        {
            throw new Exception(message);
        }
    }
}
