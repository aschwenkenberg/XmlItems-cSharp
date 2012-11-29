<%@ WebHandler Language="C#" Class="wnl_handler" %>

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
using OUC;


namespace OUC
{

    public class wnl_handler : IHttpHandler
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

            
           
            //string html = WnlDisplayMethods.rss_sample_7("rss/news2012.xml", "/rss/channel/item");
            //context.Response.Write(html);
            string toJson = "";
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

    
}