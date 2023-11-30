using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.CustomErrors
{
    public class CustomeConfigErrors:Exception
    {

        public CustomeConfigErrors(string msg): base(msg)
        {

        }
    }
}
