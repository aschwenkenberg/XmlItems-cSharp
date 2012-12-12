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
using OUC;


    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentEncoding = Encoding.UTF8;
            
            int numberToDisplay = 10;
            int numToDisplay = 0;
            bool isNum = int.TryParse(context.Request["quantity"], out numToDisplay);
            string rssUri = "rss/news2012.xml";
            string rssXPath = "rss/channel/item";
            string displayMethod = "rss_test_0";
            string categories = "medical";
            string colleges = "all";
            string tags = "all";
            string start = "01/01/2012";
            string end = "12/12/2012";
            
            string callback = "?";

            if (context.Request["quantity"] != null && isNum)
            {
                numberToDisplay = int.Parse(context.Request["quantity"]);
            }
            if (context.Request["feed"] != null)
            {
                rssUri = context.Request["feed"];
            }
            if (context.Request["xpath"] != null)
            {
                rssXPath = context.Request["xpath"];
            }
            if (context.Request["display"] != null)
            {
                displayMethod = context.Request["displayMethod"];
            }
            if (context.Request["categories"] != null)
            {
                categories = context.Request["categories"].ToLower();
            }
            if (context.Request["colleges"] != null)
            {
                colleges = context.Request["colleges"].ToLower();
            }
            if (context.Request["tags"] != null)
            {
                tags = context.Request["tags"].ToLower();
            }
            if (context.Request["start"] != null)
            {
                tags = context.Request["start"];
            }
            if (context.Request["end"] != null)
            {
                tags = context.Request["end"];
            }
            if (context.Request["callback"] != null)
            {
                callback = context.Request["callback"];
            }
            else
            {
                callback = "callback";
            }
           

            string output = OUC.WnlDisplayMethods.MasterDisplayer(rssUri, rssXPath, numberToDisplay, displayMethod, categories, colleges, tags, start, end);
            context.Response.Write(output);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }





    }

   

       
