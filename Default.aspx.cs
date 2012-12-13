using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OUC;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cont.InnerHtml += "<h2>newsList</h2>" + WnlDisplayMethods.newsList("rss/news.xml", "/rss/channel/item", 3);
       // cont.InnerHtml += "<h2> Sample 7 - 10 items</h2>"+ WnlDisplayMethods.rss_sample_7("rss/test1000.xml", "/rss/channel/item", 10);
      //  cont.InnerHtml += "<h2> Sample 0 - 3 items</h2>" + WnlDisplayMethods.MasterDisplayer("rss/test1000.xml", "/rss/channel/item", 3, "rss_sample_0");
        cont.InnerHtml += "<h2> Sample 1 - 3 items</h2>" + WnlDisplayMethods.MasterDisplayer("rss/news2012.xml", "/rss/channel/item", 3, "rss_sample_1");
        cont.InnerHtml += "<h2> Sample 2 - 3 items</h2>" + WnlDisplayMethods.MasterDisplayer("rss/news2012.xml", "/rss/channel/item", 3, "rss_sample_2");
        cont.InnerHtml += "<h2> Sample 3 - 3 items</h2>" + WnlDisplayMethods.MasterDisplayer("rss/news2012.xml", "/rss/channel/item", 3, "rss_sample_3");
        cont.InnerHtml += "<h2> Sample 4 - 3 items</h2>" + WnlDisplayMethods.MasterDisplayer("rss/news2012.xml", "/rss/channel/item", 3, "rss_sample_4");
        cont.InnerHtml += "<h2> Sample 6 - 3 items</h2>" + WnlDisplayMethods.MasterDisplayer("rss/news2012.xml", "/rss/channel/item", 3, "rss_sample_6");
        cont.InnerHtml += "<h2> Sample 7 - 3 items</h2>" + WnlDisplayMethods.MasterDisplayer("rss/news2012.xml", "/rss/channel/item", 3, "rss_sample_7");
        //cont.InnerHtml += WnlDisplayMethods.eventsList("http://calendar.spsu.edu/webcache/v1.0/xmlDays/7/list-xml/no--filter.xml", "/bedework/events/event");




    }
}