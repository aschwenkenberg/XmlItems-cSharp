using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OUC;
using System.Reflection;
using System.IO;
using System.Xml;


/// <summary>
/// Summary description for WNLDisplayMethods
/// </summary>
namespace OUC
{
   
    public static class WnlDisplayMethods
    {
        public static string newsList(string _url, string _xpath, int _qty)
        {
            XmlItems xml = new XmlItems(_url,_xpath);
            string o = "<ul>";
            xml.items.Take(_qty).ToList().ForEach(x => { YahooRssItem item = new YahooRssItem(x); o += item.ToListItemWithLink(); });
            o += "</ul>";
            return o;
        }


        public static string rss_sample_0(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_hidelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { EtsuRssItem item = new EtsuRssItem(x); o += item.ToListSample0(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_1(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_simplelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { EtsuRssItem item = new EtsuRssItem(x); o += item.ToListSample1(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_2(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_simplelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { EtsuRssItem item = new EtsuRssItem(x); o += item.ToListSample2(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_3(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_simplelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { EtsuRssItem item = new EtsuRssItem(x); o += item.ToListSample3(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_4(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_hidelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { EtsuRssItem item = new EtsuRssItem(x); o += item.ToListSample4(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_6(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_hidelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { EtsuRssItem item = new EtsuRssItem(x); o += item.ToListSample6(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_7(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<div style=\"overflow:hidden;\">";
            xml.items.Take(_qty).ToList().ForEach(x => { EtsuRssItem item = new EtsuRssItem(x); o += item.ToListSample7(); });
            o += "</div>";
            return o;
        }
       
        public static string eventsList(string _url,string _xpath)
        {
            XmlItems xml = new XmlItems(_url,_xpath);
            string r = "<ul>";
            xml.items.ForEach(x => { BedeworkXmlEvent item = new BedeworkXmlEvent(x); r += item.ToListItemWithLink();});
            r += "</ul>";
            return r;
        }

        public static string MasterDisplayer(string _url, string _xpath, int _qty, string _displayMethodName)
        {
            string output = "";

            MethodInfo mi = WnlDisplayMethods.getWnlDisplayMethodByName(_displayMethodName);

            output += mi.Invoke(new object { }, new object[] { _url, _xpath, _qty });

            return output;

        }

        public static string MasterDisplayer(string _url, string _heading, string _heading_link, int _qty, string _displayMethodName)
        {
            string output = "";

            MethodInfo mi = WnlDisplayMethods.getWnlDisplayMethodByName(_displayMethodName);

            output += mi.Invoke(new object { }, new object[] { _url, _heading, _heading_link, _qty });

            return output;

        }

        public static string MasterDisplayer(string _url, string _xpath, string _heading, string _heading_link, string _more_link, int _qty, string _displayMethodName)
        {
            string output = "";

            MethodInfo mi = WnlDisplayMethods.getWnlDisplayMethodByName(_displayMethodName);

            output += mi.Invoke(new object { }, new object[] { _url, _xpath, _heading, _heading_link, _more_link, _qty });

            return output;

        }
        
         public static string MasterDisplayer(string _url, string _xpath, string _heading, string _heading_link, int _qty, string _displayMethodName)
        {
            string output = "";

            MethodInfo mi = WnlDisplayMethods.getWnlDisplayMethodByName(_displayMethodName);

            output += mi.Invoke(new object { }, new object[] { _url, _xpath, _heading, _heading_link, _qty });

            return output;

        }

        public static string MasterDisplayer(string _heading, string _heading_link, string _displayMethodName, string _url_one, string _xpath_one, string _heading_one, string _heading_link_one, int _qty_one, string _displayMethodName_one, string _url_two, string _xpath_two, string _heading_two, string _heading_link_two, int _qty_two, string _displayMethodName_two)
        {
            string output = "";

            MethodInfo mi = WnlDisplayMethods.getWnlDisplayMethodByName(_displayMethodName);

            output += mi.Invoke(new object { }, new object[] { _heading, _heading_link, _url_one, _xpath_one, _heading_one, _heading_link_one, _qty_one, _displayMethodName_one, _url_two, _xpath_two, _heading_two, _heading_link_two, _qty_two, _displayMethodName_two });

            return output;

        }

        public static MethodInfo getWnlDisplayMethodByName(string name)
        {
            Type type = typeof(WnlDisplayMethods);
            MethodInfo info = type.GetMethod(name);
            return info;

        }

       


       
       
      

       

       


              
       

    }
}
