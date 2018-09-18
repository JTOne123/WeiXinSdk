using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System.Xml
{
    /// <summary>
    /// XML文档对象扩展
    /// </summary>
    public static class XmlDocumentExtension
    {
        /// <summary>
        /// 将<see cref="XmlDocument"/>转为XML格式的字符串
        /// </summary>
        /// <param name="xmlDocument">XmlDocument对象</param>
        /// <returns></returns>
        public static string ToXmlString(this XmlDocument xmlDocument)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                {
                    xmlDocument.WriteTo(xmlTextWriter);
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
                    xmlString.ToXmlDocument().WriteTo(xmlTextWriter);
                    return stringWriter.ToString();
                }
            }
        }

        /// <summary>
        /// 将XML格式的字符串转换为XMLDocument对象
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static XmlDocument ToXmlDocument(this string xmlString)
        {
            XmlDocument xmlDocument = new XmlDocument
            {
                PreserveWhitespace = true
            };
            MemoryStream inStream = new MemoryStream(new UTF8Encoding().GetBytes(xmlString));
            xmlDocument.Load(inStream);
            return xmlDocument;
        }

        /// <summary>
        /// 获取节点内容
        /// </summary>
        /// <param name="doc">XML文档</param>
        /// <param name="tagName">标记名称</param>
        /// <returns></returns>
        public static string GetNodeText(this XmlDocument doc, string tagName)
        {
            XmlNodeList elementsByTagName = doc.GetElementsByTagName(tagName);
            if (elementsByTagName != null && elementsByTagName[0] != null)
            {
                return elementsByTagName[0].InnerXml;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取子节点的内容
        /// </summary>
        /// <param name="parentNode">父节点对象</param>
        /// <param name="childName">子节点名称</param>
        /// <returns></returns>
        public static string GetChildNodeText(this XmlNode parentNode, string childName)
        {
            XmlNodeList childNodes = parentNode.ChildNodes;
            if (childNodes == null || childNodes.Count == 0)
                return string.Empty;
            foreach (XmlNode xmlNode in childNodes)
            {
                if (xmlNode.NodeType == XmlNodeType.Element && xmlNode.Name.Equals(childName, StringComparison.OrdinalIgnoreCase))
                {
                    return xmlNode.InnerXml;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 通过节点名称获取子节点
        /// </summary>
        /// <param name="parentNode">父节点</param>
        /// <param name="nodeName">节点名称</param>
        /// <returns></returns>
        public static XmlNode GetChildNodeByName(this XmlNode parentNode, string nodeName)
        {
            for (XmlNode xmlNode = parentNode.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
            {
                if (nodeName.Equals(xmlNode.Name))
                {
                    return xmlNode;
                }
            }
            return null;
        }
    }

}
