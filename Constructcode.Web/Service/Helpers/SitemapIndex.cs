using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Constructcode.Web.Service.Helpers
{
    public class SitemapIndex
    {
        XmlWriter writer;

        public SitemapIndex(StreamWriter stream)
        {
            var encoding = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                IndentChars = "\t"
            };

            writer = XmlWriter.Create(stream, encoding);
        }

        public void WriteStartDocument()
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("sitemapindex", "http://www.sitemaps.org/schemas/sitemap/0.9");
        }

        public void WriteEndDocument()
        {
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        public void Close()
        {
            writer.Flush();
            writer.Dispose();
        }

        public void WriteItem(string link, DateTime lastModified)
        {
            writer.WriteStartElement("sitemap");
            writer.WriteElementString("loc", link);
            writer.WriteElementString("lastmod", lastModified.ToString("yyyy-MM-dd"));
            writer.WriteEndElement();
        }
    }
}