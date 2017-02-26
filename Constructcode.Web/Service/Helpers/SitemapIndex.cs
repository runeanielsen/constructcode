using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Constructcode.Web.Service.Helpers
{
    public class SitemapIndex
    {
        private readonly XmlWriter _writer;

        public SitemapIndex(TextWriter stream)
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
            _writer.WriteStartElement("sitemapindex", "http://www.sitemaps.org/schemas/sitemap/0.9");
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

        public void WriteItem(string link, DateTime lastModified)
        {
            _writer.WriteStartElement("sitemap");
            _writer.WriteElementString("loc", link);
            _writer.WriteElementString("lastmod", lastModified.ToString("yyyy-MM-dd"));
            _writer.WriteEndElement();
        }
    }
}