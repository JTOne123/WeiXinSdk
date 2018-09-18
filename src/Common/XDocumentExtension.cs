using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.XPath;

namespace System.Xml.Linq
{
    /// <summary>
    /// XDocument
    /// </summary>
    public static class XDocumentExtension
    {
        /// <summary>
        /// 将<see cref="XDocument"/>转为XML格式的字符串
        /// </summary>
        /// <param name="xDocument">对象</param>
        /// <returns></returns>
        public static string ToXmlString(this XDocument xDocument)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                {
                    xDocument.WriteTo(xmlTextWriter);
                    return stringWriter.ToString();
                }
            }
        }

        /// <summary>
        /// 格式化Xml格式的字符串
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static string FormatXml(this string xmlString)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter)
                {
                    Formatting = Formatting.Indented
                })
                {
                    xmlString.ToXDocument().WriteTo(xmlTextWriter);
                    return stringWriter.ToString();
                }
            }
        }

        /// <summary>
        /// 将XML格式的字符串转换为<see cref="XDocument"/> 对象
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static XDocument ToXDocument(this string xmlString)
        {
            return XDocument.Parse(xmlString);
        }


        /// <summary>
        /// 将<see cref="XDocument"/>转为XML格式的字符串
        /// </summary>
        /// <param name="xDocument">对象</param>
        /// <returns></returns>
        public static string FindPathContent(this XDocument xDocument, string expression)
        {
            var root = xDocument.Root;

            var node = root.XPathSelectElement(expression);

            if (node ==null || node.IsEmpty)
            {
                return string.Empty;
            }

            return node.Value;
        }

        public static string FindPathContent(this XElement xElement, string expression)
        {
            var node = xElement.XPathSelectElement(expression);

            if (node == null || node.IsEmpty)
            {
                return string.Empty;
            }

            return node.Value;
        }
        

    }
}
