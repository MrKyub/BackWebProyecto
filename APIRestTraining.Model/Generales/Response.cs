using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Model.Generales
{
    public class Response
    {
        public object model {  get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
    }
}
