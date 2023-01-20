using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Product : Entity
    {
        private decimal price;
        public decimal Price 
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                price = value;
            } 
        }


    public int Getid()
        {
            return Id;
        }
    }
}
