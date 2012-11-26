using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OUC
{
    /// <summary>
    /// Summary description for YahooRssItem
    /// </summary>
    public class YahooRssItem : XmlItem
    {
        public XNamespace yahooMediaNS = "http://search.yahoo.com/mrss/";
        public XElement media { get; set; }
        public bool hasMedia { get { return this.media != null ? true : false; } }
        public string murl { get; set;}
        public string mtitle { get;set;}
        public string mdesc { get; set; }
        public string mkey { get; set; }
        public string mthumb { get; set; }
        public DateTime DateObject
        {
            get
            {
                return DateTime.Parse((this.pubDate).Substring(0, 16));
            }

        }
        public string longdate
        {
            get
            {
                return this.DateObject.ToString("D");
            }

        }

        public string shortdate
        {
            get
            {
                return this.DateObject.ToString("d");
            }

        }
        public string month { get { return this.DateObject.ToString("MMM"); } }
        public string twodigitday { get { return this.DateObject.ToString("dd"); } }
        public string year { get { return this.DateObject.ToString("year"); } }


        public YahooRssItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public YahooRssItem(XElement item) : base(item)
        {
            // Create a local variable for the items <media:content> node

            this.media = item.Element(this.yahooMediaNS + "content");

            if (this.hasMedia)
            {
              this.murl = (this.media.Attribute("url") != null) ? this.media.Attribute("url").Value : "murl";


            }




            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        ///  ToListItemWithLink returns this YahooRssItem as 
        /// </summary>
        /// <returns></returns>
     


    }
}