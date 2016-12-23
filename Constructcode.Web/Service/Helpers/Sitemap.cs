using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Constructcode.Web.Service.Helpers
{
    public class Sitemap
    {
        XmlWriter writer;

        public Sitemap(StreamWriter stream)
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
            writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
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

        public void WriteItem(string link, DateTime lastModified, string changefreq, string priority)
        {
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", link);
            writer.WriteElementString("lastmod", lastModified.ToString("yyyy-MM-dd"));
            writer.WriteElementString("changefreq", changefreq);
            writer.WriteElementString("priority", priority);
            writer.WriteEndElement();
        }
    }
}