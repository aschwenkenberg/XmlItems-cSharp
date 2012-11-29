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
            int numberToDisplay = 0;
            string rssUri = "rss/news2012.xml";
            string rssXPath = "rss/channel/item";
            string displayMethod = "";
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
            if (context.Request["display"] != null)
            {
                displayMethod = context.Request["display"];
            }
            else
            {
                displayMethod = "rss_sample_7";
            }


            string items = OUC.WnlDisplayMethods.MasterDisplayer(rssUri, rssXPath, numberToDisplay, displayMethod);
            context.Response.Write(items);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }





    }

   

       
