using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace System.Xml.Linq
{
    public static class XElementExtension
    {
        /// <summary>
        /// 将<see cref="XDocument"/>转为XML格式的字符串
        /// </summary>
        /// <param name="xDocument">对象</param>
        /// <returns></returns>
        public static XDocument FilledToDocument(this XElement xElement)
        {
            var xDocument = new XDocument()
            {
                Declaration = null
            };
            xDocument.Add(xElement);
            return xDocument;
        }

        /// <summary>
        /// 将<see cref="xElement"/>转为XML格式的字符串
        /// </summary>
        /// <param name="xElement">对象</param>
        /// <returns></returns>
        public static string ToXmlString(this XElement xElement)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                {
                    xElement.WriteTo(xmlTextWriter);
                    return stringWriter.ToString();
                }
            }
        }


        /// <summary>
        /// 将<see cref="XDocument"/>转为XML格式的字符串
        /// </summary>
        /// <param name="xElement">对象</param>
        /// <returns></returns>
        internal static XElement BuildChildElement(this XElement xElement, Type typeInfo, Func<PropertyInfo, object> funcValue)
        {
            var properties = typeInfo.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            if (properties == null || properties.Length <= 0)
                return null;

            foreach (PropertyInfo item in properties)
            {
                var value = funcValue(item);

                if (value == null)
                    continue;

                xElement.Add(new XElement(item.Name, value));
            }
            return xElement;
        }
    }
}
