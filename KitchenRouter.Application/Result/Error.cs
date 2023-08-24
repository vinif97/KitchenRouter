using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRouter.Application.Result
{
    public class Error
    {
        public string Details { get; set; }

        public Error(string details) 
        {
            Details = details;
        }
    }
}
