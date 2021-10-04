using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
namespace WebApplication2.Models
{
    public class Static
    {
        public static T NewInstance<T>() where T : new()
        {
            return new T();
        }
       

    }
}