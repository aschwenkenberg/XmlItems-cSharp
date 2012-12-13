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
                        
            string rssUri = "rss/news2012.xml";
            string rssXPath = "rss/channel/item";
            string tags = "academics,alumni,arts";         
            
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
                tags = context.Request["tags"].ToLower();
            }
           
            if (context.Request["callback"] != null)
            {
                callback = context.Request["callback"];
            }
            else
            {
                callback = "callback";
            }
           
            // TODO add pagination row to filteredNews or NewsIndex method

            //string output = OUC.WnlDisplayMethods.tags_count(rssUri, rssXPath, tags);
            //context.Response.Write(output);      

            string[] _tags =
	        {
	            "academics",
	            "alumni",
	            "arts"
	        };
            
            CountResult result = new CountResult();
            result.Tags = new List<string>();
            result.TagTotals = new List<TagTotal>();
            tags.ToList();
            //result.Tags = "";

            LocalItems xml = new LocalItems(rssUri, rssXPath);
            int c;
           
            
            foreach (string tag in _tags)
            {
                TagTotal t = new TagTotal();
                t.Name = tag.ToString();
                t.Total = 5; //.Where(s => s == tag).Count();
                //t.Total = xml.items.ToList().ForEach(x => { c += x.ToEtsuRssItem().Where(x => x.Elements("tags").Value.ToLower().Contains(tag); });
                result.TagTotals.Add(t);
                                
            }

            
            result.Success = true;
            JavaScriptSerializer serial = new JavaScriptSerializer();
            string toJson = serial.Serialize(result);
            context.Response.Write(context.Request["callback"] + "(" + toJson + ")"); 
           
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

            public bool Success { get; set; }
            public List<string> Tags { get; set; }
            public List<TagTotal> TagTotals { get; set; }

        }

        public class TagTotal
        {
            public string Name { get; set; }
            public int Total { get; set; }
        }

    }

   

       
