using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.HandelResponse
{
    public class CustomerExeption : Response
    {
        public CustomerExeption(int statusCode, string? message = null, string? details= null) : base(statusCode, message)
        {
            Details=details;
        }
        public string? Details { get; set; }
    }
}
