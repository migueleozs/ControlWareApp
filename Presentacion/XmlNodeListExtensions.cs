using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Presentacion
{
    public static class XmlNodeListExtensions
    {
        public static void ForEach(this XmlNodeList nodeList, Action<XmlNode> action)
        {
            foreach (XmlNode node in nodeList)
            {
                action(node);
            }
        }
    }
}
