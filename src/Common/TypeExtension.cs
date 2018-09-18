using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using System.Globalization;
using System.ComponentModel;

namespace System.Reflection
{
    internal static class TypeExtension
    {
        /// <summary>
        /// 将<see cref="XDocument"/>转为XML格式的字符串
        /// </summary>
        /// <param name="xElement">对象</param>
        /// <returns></returns>
        internal static void XElementLoad(this Type typeInfo, XElement xElement, Func<PropertyInfo, object> getValue, Action<PropertyInfo, object> setValue)
        {
            var properties = typeInfo.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            if (properties == null || properties.Length <= 0)
                return;

            foreach (PropertyInfo item in properties)
            {
                var attr = item.GetCustomAttribute(typeof(XmlNodeNameAttribute));
                string eName = item.Name;
                if (attr != null)
                {
                    eName = ((XmlNodeNameAttribute)attr).Name;
                }
                var xElements = xElement.Elements(eName);

                foreach (var x in xElements)
                {
                    if (x == null || x.IsEmpty)
                        continue;

                    if (x.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        if (x.HasElements)
                        {
                            var itemValue = getValue(item);
                            if (itemValue == null)
                            {
                                itemValue = item.PropertyType.Assembly.CreateInstance(item.PropertyType.FullName);
                            }
                            setValue(item, itemValue);
                        }
                        else if (item.PropertyType == typeof(DateTime))
                        {
                            setValue(item, DateTime.ParseExact(x.Value, "yyyyMMddHHmmss", CultureInfo.CurrentCulture));
                        }
                        else if (item.PropertyType == typeof(Guid))
                        {
                            setValue(item, Guid.Parse(x.Value));
                        }
                        else
                            setValue(item, x.Value);

                    }
                }

            }
        }


        /// <summary>
        /// 生成xmlstring
        /// </summary>
        /// <param name="data"></param>
        internal static string ToXmlString(this object data)
        {
            XElement xRequest = new XElement("xml");
            return xRequest.BuildChildElement(data.GetType(), (info) => info.GetValue(data, null)).ToXmlString();
        }
    }
}
