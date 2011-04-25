using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Xml.Linq;

namespace EverGTD
{
    public class ContentWriter : IDisposable
    {
        private XDocument xDoc;
        private Note n;
        private XName div;

        public ContentWriter(Note n)
        {
            this.n = n;
            xDoc = XDocument.Parse(n.Content);
            div = XName.Get("div", "");
        }

        public void WriteLine(string text)
        {
            XElement elem = new XElement(div) { Value = text };
            xDoc.Elements().First().Add(elem);
        }

        public void Dispose()
        {
            n.Content = xDoc.ToString();
        }
    }
}
