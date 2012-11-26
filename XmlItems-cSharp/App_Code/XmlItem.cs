using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;



namespace OUC
{
    /// <summary>
    /// Base Class for a What's New Live Item
    /// </summary>
    public class XmlItem
    {
        public XElement originalElement = null;
              
        public string title { get; set; }
        public string description { get; set; }
        public string pubDate { get; set; }
        public string link { get; set; }

        public XElement original { get { return this.originalElement; } }

        /// <summary>
        /// returns value of a child node named '_nodename', returns the name of the node as value if node is null.
        /// </summary>
        /// <param name="_nodename"></param>
        /// <returns></returns>
        public string childNodeValue(string _nodename)
        {
            return (this.originalElement.Element(_nodename) != null ? this.originalElement.Element(_nodename).Value : _nodename);
        }

        /// <summary>
        /// if child element by string name exists.
        /// </summary>
        /// <param name="ename"></param>
        /// <returns></returns>
        public bool elementExists(string ename)
        {
            return this.originalElement.Element(ename) != null ? true : false;
        }

        public XmlItem() { }

        public XmlItem(XElement _originalElement)
        {
            this.originalElement = new XElement(_originalElement);
            this.title = this.childNodeValue("title");
            this.description = this.childNodeValue("description");
            this.link = this.childNodeValue("link");
            this.pubDate = this.originalElement.Element("pubDate") != null ? this.originalElement.Element("pubDate").Value : "Wed, 14 Nov 2012 12:02:57 -0800";

        }

        public string ToListItemWithLink() { return String.Format("<li><a href=\"{0}\">{1}</a></li>",this.link,this.title); }
        //public string rss_sample_0() { return String.Format("<li class=\"rss_listitems\"><span class=\"rss_imgspan\"><img src=\"{0}\"/></span>", this.murl, this.link); }
    }

}