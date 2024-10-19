using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.HandelResponse
{
    public class ValidationErrorResponse : CustomerExeption
    {
        public ValidationErrorResponse() : base(500)
        {

        }
        public IEnumerable<String> Errors { get; set; }
    }
}
