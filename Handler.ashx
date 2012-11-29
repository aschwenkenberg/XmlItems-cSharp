<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Text;
using System.Xml;
using System.Linq;
using System.Data;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;




public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "application/json";
        context.Response.ContentType = "text/plain";
        context.Response.ContentEncoding = Encoding.UTF8;
        int numberToDisplay = 0;
        var doc = new XDocument();
        string rssUri = "rss/news2012.xml";
        string callback = "?";
        if (context.Request["quantity"] != null)
        {
            numberToDisplay = int.Parse(context.Request["quantity"]);
        }
        else
        {
            numberToDisplay = 30;
        }

        if (context.Request["feed"] != null)
        {
            rssUri = context.Request["feed"];
        }
        if (context.Request["callback"] != null)
        {
            callback = context.Request["callback"];
        }
        else
        {

            callback = "callback";

        }


        List<EtsuRssItem> itemsToDisplay = new List<EtsuRssItem>();

               
        if (rssUri.StartsWith("http"))
        {
            doc = System.Xml.Linq.XDocument.Load(rssUri);
        }
        else
        {
            doc = System.Xml.Linq.XDocument.Load(HttpContext.Current.Server.MapPath(rssUri));
        }
        var items =

                from el in doc.Elements("rss").Elements("channel").Elements("item")

                select (

                  new EtsuRssItem
                  {
                      title = el.Element("title").Value,
                      description = el.Element("description").Value,
                      link = el.Element("link").Value,
                      pubDate = el.Element("pubDate").Value,
                      murl = el.Element(el.GetNamespaceOfPrefix("media") + "content").Attribute("url").Value,
                      //mtitle = el.Element(el.GetNamespaceOfPrefix("media") + "content").Element("title").Value,
                      //mdesc = el.Element(el.GetNamespaceOfPrefix("media") + "description").Value,
                      //mthumb = el.Element(el.GetNamespaceOfPrefix("media") + "thumbnail").Value,
                      //mkey = el.Element(el.GetNamespaceOfPrefix("media") + "keywords").Value,
                      
                  });

        int numberOfItems = items.Count();

        if (numberToDisplay != 0)
        {
            itemsToDisplay = items.Take(numberToDisplay).ToList<EtsuRssItem>();


        }

        JavaScriptSerializer serial = new JavaScriptSerializer();
        string toJson = serial.Serialize(itemsToDisplay);
        context.Response.Write(callback + "(" + toJson + ")");

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }





}

class EtsuRssItem
{

    public XNamespace yahooMediaNS = "http://search.yahoo.com/mrss/";
    public XNamespace OucNS = "http://omniupdate.com/XSL/Variables";

    public XElement media { get; set; }

    public bool hasMedia { get { return this.media != null ? true : false; } }
    //public bool hasLocation { get { return this.originalElement.Element(this.OucNS + "location") != null ? true : false; } }
    public string murl { get; set; }
    public string mtitle { get; set; }
    public string mdesc { get; set; }
    public string mkey { get; set; }
    public string mthumb { get; set; }
    public string tagline { get; set; }
    public string location { get; set; }
    public string homefeatured { get; set; }
    public string highlighted { get; set; }
    public string itemisvideo { get; set; }

    public string title { get; set; }
    public string description { get; set; }
    public string pubDate { get; set; }
    public string link { get; set; }
    public DateTime DateObject
    {
        get
        {
            return DateTime.Parse(this.pubDate);
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
}
