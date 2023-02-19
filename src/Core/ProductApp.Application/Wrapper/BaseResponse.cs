using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Wrapper
{
    public class BaseResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public String? Message { get; set; }
    }
}
