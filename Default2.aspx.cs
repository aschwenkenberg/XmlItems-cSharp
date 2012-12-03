using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OUC;
using System.Xml;
using System.Configuration;
using System.Xml.Linq;
using System.Xml.XPath;

public partial class Default2 : System.Web.UI.Page
{
    public List<XElement> els = new List<XElement>();


    protected void Page_Load(object sender, EventArgs e)
    {




       using(XmlReader reader = XmlReader.Create(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["rss"])))
       {
           reader.MoveToContent();
           // read the file adding the each item to the list as XElement
           while(reader.Read() && els.Count() < 1)
           {
               if(reader.NodeType == XmlNodeType.Element)
               {

                   if(reader.Name == "item")
                   {
                       XElement el = XNode.ReadFrom(reader) as XElement;
                       if(el != null)
                       { 
                           els.Add(el);
                       }
                   }
               }


           }


       }
         //els.ForEach( xmlel => { EtsuRssItem ei = new EtsuRssItem(xmlel); cont.InnerHtml += ei.ToListItemWithLink(); });
    }
}