using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;


/// <summary>
/// Summary description for Xml2Html
/// </summary>
namespace OUC
{
    public class LocalItems
    {
        public List<string> errors = new List<string>();
        public List<XElement> items = new List<XElement>();
        public bool hasItems { get { return (items.Count > 0) ? true : false; } }

        public LocalItems() { }
        
        public LocalItems(string _url, string _xpath)
        {
            try
            {
                var doc = XDocument.Load(HttpContext.Current.Server.MapPath(_url));    
                //var doc = XDocument.Load(_url);
                this.items = doc.XPathSelectElements(_xpath).ToList();
                
            }
            catch (XmlException exception)
            {
                this.errors.Add(exception.ToString());
            }

        }
    }
}