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
    /// Summary description for EtsuRssItem
    /// </summary>
    public class EtsuRssItem : XmlItem
    {
        public XNamespace yahooMediaNS = "http://search.yahoo.com/mrss/";
        public XNamespace OucNS = "http://omniupdate.com/XSL/Variables";

        public XElement media { get; set; }

        public bool hasMedia { get { return this.media != null ? true : false; } }
        public bool hasLocation { get { return this.originalElement.Element(this.OucNS + "location") != null ? true : false; } } 
        public string murl { get; set;}
        public string mtitle { get;set;}
        public string mdesc { get; set; }
        public string mkey { get; set; }
        public string mthumb { get; set; }
        public string tagline { get; set; }
        public string location { get; set; }
        public string homefeatured { get; set; }
        public string highlighted { get; set; }
        public string itemisvideo { get; set; }

        public string category { get; set; }
        public string colleges { get; set; }
        public string tags { get; set; }


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
              this.mtitle = (this.media.Element(this.yahooMediaNS + "title") != null) ? this.media.Element(this.yahooMediaNS + "title").Value : "mtitle";
              this.mdesc = (this.media.Element(this.yahooMediaNS + "description") != null) ? this.media.Element(this.yahooMediaNS + "description").Value : "mdesc";
              this.mthumb = (this.media.Element(this.yahooMediaNS + "thumbnail") != null) ? this.media.Element(this.yahooMediaNS + "thumbnail").Attribute("url").Value : "mthumb";
              this.mkey = (this.media.Element(this.yahooMediaNS + "keyword") != null) ? this.media.Element(this.yahooMediaNS + "keyword").Value : "mkey";
            }
           
            this.location = (item.Element(this.OucNS + "location") != null) ? item.Element(this.OucNS + "location").Value : "JOHNSON CITY, TN";                       
            this.tagline = (item.Element(this.OucNS + "tagline") != null) ? item.Element(this.OucNS + "tagline").Value : "";            
            this.homefeatured = (item.Element(this.OucNS + "home-featured") != null) ? item.Element(this.OucNS + "home-featured").Value : "home-featured";
            this.highlighted = (item.Element(this.OucNS + "highlighted") != null) ? item.Element(this.OucNS + "highlighted").Value : "highlighted";
            this.itemisvideo = (item.Element(this.OucNS + "item-is-video") != null) ? item.Element(this.OucNS + "item-is-video").Value : "item-is-video";

            this.category = (item.Element(this.OucNS + "category") != null) ? item.Element(this.OucNS + "category").Value : "";
            this.colleges = (item.Element(this.OucNS + "colleges") != null) ? item.Element(this.OucNS + "colleges").Value : "";
            this.tags = (item.Element(this.OucNS + "tags") != null) ? item.Element(this.OucNS + "tags").Value : "";                     
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        ///  ToListItemWithLink returns this EtsuRssItem as 
        ///  </summary>
        /// <returns></returns>
     

        public string ToListSample0() { return String.Format("<li class=\"rss_listitems\"><span class=\"rss_imgspan\"><img src=\"{0}\"/></span><span class=\"rss_titlespan\"><a class=\"rss_hyperlink\" href=\"{1}\">{2}</a></span><span class=\"rss_datespan\">{5} <em>({3}) </em></span><span class=\"rss_shortdescript\"> {4}  <a class=\"rss_readmore\" href=\"{1}\">Read more...</a></span></li>", this.mthumb, this.link, this.title, this.monthyear, this.description, this.location); }

        public string ToListSample1() { return String.Format("<li class=\"rss_listitems\"><span class=\"rss_imgspan\"><img src=\"{0}\"/></span><span class=\"rss_titlespan\"><a class=\"rss_hyperlink\" href=\"{1}\">{2}</a></span><span class=\"rss_shortdescript\"><em>({3}) </em> {4}  <a class=\"rss_readmore\" href=\"{1}\">Read more...</a></span></li>", this.mthumb, this.link, this.title, this.monthyear, this.description); }

        public string ToListSample2() { return String.Format("<li class=\"rss_listitems\"><span class=\"rss_titlespan\"><a class=\"rss_hyperlink\" href=\"{0}\">{1}</a></span><span class=\"rss_shortdescript\"><em>({2})  -  </em> {3}  <a class=\"rss_readmore\" href=\"{0}\">Read more...</a></span></li> ", this.link, this.title, this.monthyear, this.description); }

        public string ToListSample3() { return String.Format("<li class=\"rss_simplelistitem\"><span class=\"rss_spantitle\"><a class=\"rss_hyperlink\" href=\"{0}\">{1}</a></span></li>", this.link, this.title);}

        public string ToListSample4() { return String.Format("<li class=\"rss_listitems\"><span class=\"rss_titlespan\"><a class=\"rss_hyperlink\" href=\"{0}\">{1}</a></span><span class=\"rss_imgspand2\"><img src=\"{2}\"/></span><span class=\"rss_datespan\">({3})</span><span class=\"rss_shortdescript\"> {4}  <a class=\"rss_readmore\" href=\"{0}\">Read more...</a></span></li>", this.link, this.title, this.murl, this.monthyear, this.description);}

        public string ToListSample6() { return String.Format("<li class=\"rss_listitems\"><span class=\"rss_imgspan\"><img class=\"rss_image\" src=\"{0}\"/></span><span class=\"rss_titlespan\"><a class=\"rss_hyperlink\" href=\"{1}\">{2}</a></span><span class=\"rss_datespan\">{3}</span></li>", this.mthumb, this.link, this.title, this.monthyear); }

        public string ToListSample7() { return String.Format("<p class=\"rss_hptitle\"><a class=\"rss_hyperlink\" href=\"{0}\">{1}</a><br/><span class=\"newstagline\">{2}</span></p>", this.link, this.title, this.tagline); }

        public bool shouldBeDisplayed()
        {
            if (this.title == "display")
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool dateIsGood(string start_date, string end_date)
        {

            return false;
        }
    }
}