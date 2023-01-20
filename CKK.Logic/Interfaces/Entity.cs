using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;
using CKK.Logic.Models;

namespace CKK.Logic.Interfaces
{
    [Serializable]
    public abstract class Entity
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidIdException();
                }
                id = value;
            }
        }
        public string Name { get; set; }
    }
}
