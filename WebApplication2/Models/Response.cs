using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Response<T> where T : class
    {
        public int TotalCount { get; set; }
        public List<T> List { get; set; }
    }
}