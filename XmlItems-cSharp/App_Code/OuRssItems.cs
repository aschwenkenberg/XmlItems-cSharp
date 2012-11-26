using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;
using OUC;

/// <summary>
/// Summary description for OuRss
/// </summary>
/// 
namespace OUC
{
public class YahooRssItems : XmlItems
{
    public List<YahooRssItem> yahooRssItems = new List<YahooRssItem>();
    
    public YahooRssItems(string _url , string _xpath) : base ( _url,  _xpath)
	{
                
         try
                {
                  this.yahooRssItems = (from i in this.items select new YahooRssItem(i){}).ToList<YahooRssItem>();
                }
                catch ( XmlException exception)
                {
                    this.errors.Add(exception.ToString());
                }

		//
		// TODO: Add constructor logic here
		//
	}
}

}