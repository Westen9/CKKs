using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InvalidIdException:Exception
    {
        public InvalidIdException():base()
        {
            Console.WriteLine("can not take a value less than 0");
        }
    }
}
