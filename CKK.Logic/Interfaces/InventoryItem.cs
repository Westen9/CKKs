using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    [Serializable]
    public abstract class InventoryItem
    {
        private int quy;
        public int Quantity
        {
            get
            {
                return quy;
            }
            set
            {
                if (value < 0)
                {
                    throw new InventoryItemStockTooLowException();
                }
                quy = value;
            }
        }

        private Product prd;
        public Product Product
        {
            get 
            {
                return prd;
            }
            set 
            {
                prd = value;
            }
            
        }
    }
}
