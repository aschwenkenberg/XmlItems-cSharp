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
    public class LocalItemsCat
    {
        public List<string> errors = new List<string>();
        public XNamespace OucNS = "http://omniupdate.com/XSL/Variables";
        public XNamespace yahooMediaNS = "http://search.yahoo.com/mrss/";
        public List<XElement> items = new List<XElement>();
        public bool hasItems { get { return (items.Count > 0) ? true : false; } }

        public LocalItemsCat() { }

        public LocalItemsCat(string _url, string _xpath, string _category, string _colleges, string _tags, string _start, string _end)
        {
            try
            {
                var doc = XDocument.Load(HttpContext.Current.Server.MapPath(_url));
                //var doc = XDocument.Load(_url);
                //this.items = doc.XPathSelectElements(_xpath).ToList();
                DateTime start, end;
                if (_start == "") { start = Convert.ToDateTime("1/1/12"); } else { start = Convert.ToDateTime(_start); };
                if (_end == "") { end = DateTime.Now; } else { end = Convert.ToDateTime(_end); } 

                string category = "medical"; //_category.ToLower().Trim();
                string all = "all";

                if (!(string.Equals(category, all)))
                {
                   /* IEnumerable<XElement> nodes =
                                     from node in doc.Descendants("item")
                                     where node.Elements(OucNS + "category")
                                      .Any(x => x.Value.Contains(category)) //&& where(y => ((DateTime) y.Element("pubDate")).Date  > (start))
                                    select node; */

                    IEnumerable<XElement> nodes = from node in doc.Descendants("item")
                               .Where(x => ((DateTime)x.Element("pubDate") >= start)).Where(x => ((DateTime)x.Element("pubDate") <= end)).Where(y => y.Element(OucNS + "category").Value.ToLower().Contains(category))
                                       select node;

                    if (nodes != null )
                    {
                        this.items = nodes.ToList();
                    }
                    else {
                        var docu = XDocument.Load(HttpContext.Current.Server.MapPath(_url));
                        this.items = docu.XPathSelectElements(_xpath).ToList();
                    }
               }else{
                   var docu = XDocument.Load(HttpContext.Current.Server.MapPath(_url));
                       this.items = docu.XPathSelectElements(_xpath).ToList();
               }

            }
            catch (XmlException exception)
            {
                this.errors.Add(exception.ToString());
            }

        }

      
    }
}