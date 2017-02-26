using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Constructcode.Web.Service.Helpers
{
    public class Sitemap
    {
        private readonly XmlWriter _writer;

        public Sitemap(TextWriter stream)
        {
            var encoding = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                IndentChars = "\t"
            };

            _writer = XmlWriter.Create(stream, encoding);
        }

        public void WriteStartDocument()
        {
            _writer.WriteStartDocument();
            _writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
        }

        public void WriteEndDocument()
        {
            _writer.WriteEndElement();
            _writer.WriteEndDocument();
        }

        public void Close()
        {
            _writer.Flush();
            _writer.Dispose();            
        }

        public void WriteItem(string link, DateTime lastModified, string changefreq, string priority)
        {
            _writer.WriteStartElement("url");
            _writer.WriteElementString("loc", link);
            _writer.WriteElementString("lastmod", lastModified.ToString("yyyy-MM-dd"));
            _writer.WriteElementString("changefreq", changefreq);
            _writer.WriteElementString("priority", priority);
            _writer.WriteEndElement();
        }
    }
}