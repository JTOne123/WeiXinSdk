using System;
using System.Collections.Generic;
using System.Text;

namespace System.ComponentModel
{
    /// <summary>
    ///  生成XML的节点名
    /// </summary>
    public class XmlNodeNameAttribute : Attribute
    {
        public XmlNodeNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
