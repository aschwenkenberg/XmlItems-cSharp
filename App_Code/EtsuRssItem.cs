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
    public class EtsuRssItem : XmlItem
    {
        public XNamespace yahooMediaNS = "http://search.yahoo.com/mrss/";

        public XElement media { get; set; }
        public XElement ouc { get; set; }
        public bool hasMedia { get { return this.media != null ? true : false; } }
        public bool hasOuc { get { return this.ouc != null ? true : false; } }
        public string murl { get; set;}
        public string mtitle { get;set;}
        public string mdesc { get; set; }
        public string mkey { get; set; }
        public string mthumb { get; set; }
        public string tagline { get; set; }


        public DateTime DateObject
        {
            get
            {
                return DateTime.Parse((this.pubDate).Substring(0, 16));
            }

        }

        public string monthyear
        {
            get
            {
                return this.DateObject.ToString("MMMM d, yyyy");
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


        public EtsuRssItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public EtsuRssItem(XElement item) : base(item)
        {
            // Create a local variable for the items <media:content> node

            this.media = item.Element(this.yahooMediaNS + "content");

            if (this.hasMedia)
            {
              this.murl = (this.media.Attribute("url") != null) ? this.media.Attribute("url").Value : "murl";


            }

            this.ouc = item.Element("tagline");
            if (this.hasOuc)
            {
                this.tagline = (this.childNodeValue("tagline") != null) ? this.childNodeValue("tagline") : "tagline";
            }

            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        ///  ToListItemWithLink returns this YahooRssItem as 
        ///  </summary>
        /// <returns></returns>
     

        public string ToListSample0() { return String.Format("<li class=\"rss_listitems\"><span class=\"rss_imgspan\"><img src=\"{0}\"/></span><span class=\"rss_titlespan\"><a class=\"rss_hyperlink\" href=\"{1}\">{2}</a></span><span class=\"rss_datespan\">JOHNSON CITY, TN <em>({3}) </em></span><span class=\"rss_shortdescript\"> {4}<a class=\"rss_readmore\" href=\"{1}\">Read more...</a></span></li>", this.murl, this.link, this.title, this.monthyear, this.description); }

        public string ToListSample1() { return String.Format("<li class=\"rss_listitems\"><span class=\"rss_imgspan\"><img src=\"{0}\"/></span><span class=\"rss_titlespan\"><a class=\"rss_hyperlink\" href=\"{1}\">{2}</a></span><span class=\"rss_shortdescript\"><em>({3}) </em> {4}<a class=\"rss_readmore\" href=\"{1}\">Read more...</a></span></li>", this.murl, this.link, this.title, this.monthyear, this.description); }

        public string ToListSample2() { return String.Format("<li class=\"rss_listitems\"><span class=\"rss_titlespan\"><a class=\"rss_hyperlink\" href=\"{0}\">{1}</a></span><span class=\"rss_shortdescript\"><em>({2})  -  </em> {2}  <a class=\"rss_readmore\" href=\"{0}\">Read more...</a></span></li> ", this.link, this.title, this.description);}

        public string ToListSample3() { return String.Format("<li class=\"rss_simplelistitem\"><span class=\"rss_spantitle\"><a class=\"rss_hyperlink\" href=\"{0}\">{1}</a></span></li>", this.link, this.title);}

        public string ToListSample4() { return String.Format("<li class=\"rss_listitems\"><span class=\"rss_titlespan\"><a class=\"rss_hyperlink\" href=\"{0}\">{1}</a></span><span class=\"rss_imgspand2\"><img src=\"{2}\"/></span><span class=\"rss_datespan\">({3})</span><span class=\"rss_shortdescript\"> {4}  <a class=\"rss_readmore\" href=\"{0}\">Read more...</a></span></li>", this.link, this.title, this.murl, this.monthyear, this.description);}

        public string ToListSample6() { return String.Format(" <li class=\"rss_listitems\"><span class=\"rss_imgspan\"><img class=\"rss_image\" src=\"{0}\"/></span><span class=\"rss_titlespan\"><a class=\"rss_hyperlink\" href=\"{1}\">{2}</a></span><span class=\"rss_datespan\">{3}</span></li>", this.murl, this.link, this.title, this.monthyear); }

        public string ToListSample7() { return String.Format("<p class=\"rss_hptitle\"><a class=\"rss_hyperlink\" href=\"{0}\">{1}</a><br/><span class=\"newstagline\">{2}</span></p>", this.link, this.title, this.tagline); }


    }
}