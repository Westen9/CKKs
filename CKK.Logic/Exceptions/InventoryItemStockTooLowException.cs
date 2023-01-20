using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InventoryItemStockTooLowException : Exception
    {
        public InventoryItemStockTooLowException() : base()
        {
            Console.WriteLine("value can not be less than 0");
        }
    }
}
