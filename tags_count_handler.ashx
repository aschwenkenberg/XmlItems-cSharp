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

            List<EtsuRssItem> eItems = new List<EtsuRssItem>();
                
            string rssUri = "rss/news2012.xml";
            string rssXPath = "rss/channel/item";
            string url_tags = "academics,alumni,arts";         
            
            string callback = "?";

            
            if (context.Request["feed"] != null)
            {
                rssUri = context.Request["feed"];
            }
            if (context.Request["xpath"] != null)
            {
                rssXPath = context.Request["xpath"];
            }
            
            if (context.Request["tags"] != null)
            {
                url_tags = context.Request["tags"].ToLower().Trim();
            }
            string[] url_tags_array = url_tags.Split(',');
            if (context.Request["callback"] != null)
            {
                callback = context.Request["callback"];
            }
            else
            {
                callback = "callback";
            }
           
         
            
            CountResult result = new CountResult();
           
            result.TagTotals = new List<TagTotal>();
         

            LocalItems xml = new LocalItems(rssUri, rssXPath);

            xml.items.ToList().ForEach(x => { EtsuRssItem etsuItem = x.ToEtsuRssItem(); eItems.Add(etsuItem); });
           
            
            foreach (string tag in url_tags_array)
            {
                
                TagTotal t = new TagTotal();
                t.Name = tag.ToString();
                t.Total = eItems.Where(i => i.tags.ToLower().Contains(tag)).Count();

                result.TagTotals.Add(t);
                                
            }
           
          
            JavaScriptSerializer serial = new JavaScriptSerializer();
            string toJson = serial.Serialize(result);
            context.Response.Write( toJson ); 
           
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public class CountResult
        {

           public List<TagTotal> TagTotals { get; set; }

        }

        public class TagTotal
        {
            public string Name { get; set; }
            public int Total { get; set; }
        }

    }

   

       
