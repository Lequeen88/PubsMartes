using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsMartes.Application.Exeptions
{
    public class JobServiceExeptions : Exception
    {
        public JobServiceExeptions(string message) : base(message)
        {

        }

    }
}
