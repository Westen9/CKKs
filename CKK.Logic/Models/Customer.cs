using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Customer : Entity
    {
        public string Address { get; set; }
    }
}
