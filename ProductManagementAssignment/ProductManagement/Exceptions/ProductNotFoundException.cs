using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.Exceptions
{
    //User Defined Exception ProductNotFoundException
    public class ProductNotFoundException:Exception
    {
        public ProductNotFoundException(string message)
            : base(message)
        {

        }
        public ProductNotFoundException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}