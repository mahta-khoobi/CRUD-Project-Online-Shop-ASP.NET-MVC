using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Sample02.Models.Helper
{
    public static class ModelHelper
    {
        public static DataTable ToDataTable<T>(this List<T> list_T) where T:class
        {
            //DataTable dataTable = new DataTable(typeof(T).Name);
            //PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //foreach (PropertyInfo prop in Props)
            //{
            //    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
            //    dataTable.Columns.Add(prop.Name, type);
            //}
            //foreach (T item in list_T)
            //{
            //    var values = new object[Props.Length];
            //    for (int i = 0; i < Props.Length; i++)
            //        values[i] = Props[i].GetValue(item, null);
            //    dataTable.Rows.Add(values);
            //}
            //return dataTable;

            PropertyDescriptorCollection props =
        TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in list_T)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}