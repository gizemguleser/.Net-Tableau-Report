using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
namespace WebApplication2.Models
{
    public class XmlData<T> : IData<T>where T:class,new()
    {
        private string FileName;
        private FileStream Stream;
        public XmlData(string fileName)
        {
            FileName = fileName;
        }
        public Response<T> Get()
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Content/" + FileName + ".xlsx");
            Stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader;
            int counter = 0;
            if (Path.GetExtension(filePath).ToUpper() == ".XLS")
                excelReader = ExcelReaderFactory.CreateBinaryReader(Stream);
            else
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(Stream);

            List<T> list = new List<T>();

            List<string> propertyList = new List<string>();
            var totalData = excelReader.RowCount - 1;
            //int count = totalData < length + start + 1 ? totalData : length + start + 1;
            while (excelReader.Read())
            {
                //if (counter < start+1)
                //{
                //    counter++;
                //    continue;
                //}
                //else if (counter >= length + start + 1)
                //    break;
               
                
                var objProperties =Static.NewInstance<T>();
                int objCounter = 0;
                foreach (var item in objProperties.GetType().GetProperties())
                {
                    if (counter == 0)
                        propertyList.Add(excelReader.GetString(objCounter));
                    else
                    {
                        var getObj = excelReader.GetValue(objCounter);
                        var fds = item.PropertyType;
                        if (item.PropertyType.Equals(typeof(int)))
                            item.SetValue(objProperties, getObj == null ? (int?)null : Convert.ToInt32(getObj));
                        else if (item.PropertyType.Equals(typeof(Nullable<int>)))
                            item.SetValue(objProperties, getObj == null ? (int?)null : Convert.ToInt32(getObj));
                        else if (!item.PropertyType.Equals(typeof(string)))
                            item.SetValue(objProperties, getObj == null ? null : getObj);
                        else
                            item.SetValue(objProperties, getObj == null ? null : getObj.ToString());
                    }
                    objCounter++;
                }
                if (counter > 0)
                    list.Add(objProperties);
                counter++;
            }


            excelReader.Close();
            Response<T> res = new Response<T>();
            res.List = list;
            res.TotalCount = totalData;
            return res;
        }
    }
}