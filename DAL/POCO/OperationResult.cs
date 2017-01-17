using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.POCO
{
    public class OperationResult
    {
        public string Message { get; set; }
        public bool Succeded { get; set; }
        public object Data { get; set; }
    }
}
