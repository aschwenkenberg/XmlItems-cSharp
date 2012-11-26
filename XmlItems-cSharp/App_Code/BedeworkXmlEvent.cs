using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OUC;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
/// <summary>
/// Summary description for BedeworkEvent
/// </summary>
public class BedeworkXmlEvent : XmlItem
{

   
   public string guid { get ; set ; }
   public string recID { get ; set;  }
   public string calpath { get ; set; }
   
   
    public XElement endNode
    {
        get
        {
            return this.originalElement.Element("end");
        }
    }

    public XElement startNode
    {
        get
        {
             return this.originalElement.Element("start");
        }
    }

	public BedeworkXmlEvent(XElement _original_element) : base(_original_element)
	{
        this.title = this.childNodeValue("summary");
        this.guid = this.childNodeValue("guid"); 
        this.recID = this.childNodeValue("recurrenceId"); 
        //calendar_node represents the child <calendar> child node of the <event>
        var calendar_node = this.originalElement.Element("calendar");
        // endcodedPath_node represents the <encodedPath> child node of the above <calendar> node - var calendar_node
        var encodedPath_node = (calendar_node != null) ? calendar_node.Element("encodedPath") : null;

        this.calpath= (encodedPath_node != null) ? encodedPath_node.Value : "%2Fpublic%2Fcals%2FMainCal";
       
	}

    public string bedeworkLi() { return String.Format("<li><a href=\"{0}\">{1}</a></li>", this.link, this.title); }
  
}


