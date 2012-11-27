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
        //cont.InnerHtml = WnlDisplayMethods.newsList("http://www.gallenauniversity.com/_resources/rss/news.xml","/rss/channel/item");
        cont.InnerHtml += WnlDisplayMethods.rss_sample_7("rss/news.xml", "/rss/channel/item");
        //cont.InnerHtml += WnlDisplayMethods.eventsList("http://calendar.spsu.edu/webcache/v1.0/xmlDays/7/list-xml/no--filter.xml", "/bedework/events/event");
        
    }
}