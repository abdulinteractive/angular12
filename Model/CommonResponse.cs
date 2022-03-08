using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class CommonResponse
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
