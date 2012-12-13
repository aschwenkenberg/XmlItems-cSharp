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
        public static string test() { return "test"; }

        public static string newsList(string _url, string _xpath, int _qty)
        {
            XmlItems xml = new XmlItems(_url,_xpath);
            string o = "<ul>";
            //xml.items.Take(_qty).ToList().ForEach(x => { YahooRssItem item = new YahooRssItem(x); o += item.ToListItemWithLink(); });
            xml.items.Take(_qty).ToList().ForEach(x => { o += x.ToYahooRssItem().ToListItemWithLink(); });
            o += "</ul>";
            return o;
        }


        public static string rss_sample_0(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_hidelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { o += x.ToEtsuRssItem().ToListSample0(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_1(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_simplelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { o += x.ToEtsuRssItem().ToListSample1(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_2(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_simplelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { o += x.ToEtsuRssItem().ToListSample2(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_3(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_simplelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { o += x.ToEtsuRssItem().ToListSample3(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_4(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_hidelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { o += x.ToEtsuRssItem().ToListSample4(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_6(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<ul class=\"rss_hidelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { o += x.ToEtsuRssItem().ToListSample6(); });
            o += "</ul>";
            return o;
        }

        public static string rss_sample_7(string _url, string _xpath, int _qty)
        {
            LocalItems xml = new LocalItems(_url, _xpath);
            string o = "<div style=\"overflow:hidden;\">";
            xml.items.Take(_qty).ToList().ForEach(x => { o += x.ToEtsuRssItem().ToListSample7(); });
            o += "</div>";
            return o;
        }

        public static string filteredNews(string _url, string _xpath, int _qty, string _categories, string _colleges, string _tags, string _start, string _end)
        {
            LocalItemsCat xml = new LocalItemsCat(_url, _xpath, _categories, _colleges, _tags, _start, _end);
            string o = "<ul class=\"rss_hidelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { o += x.ToEtsuRssItem().ToListSample0(); });
            o += "</ul>";
            return o;
        }







        public static string rss_test_0(string _url, string _xpath, int _qty, string _categories, string _colleges, string _tags, string _start, string _end)
        {
            LocalItemsCat xml = new LocalItemsCat(_url, _xpath, _categories, _colleges, _tags, _start, _end);
            string o = "<ul class=\"rss_hidelist\">";
            xml.items.Take(_qty).ToList().ForEach(x => { o += x.ToEtsuRssItem().ToListSample0(); });
            o += "</ul>";
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

            if (mi != null)
            {
                output += mi.Invoke(new object { }, new object[] { _url, _xpath, _qty });
            }
            else {
                output = "Error in the WNLDisplayMethod";
            }
            return output;

        }

        public static string MasterDisplayer(string _url, string _xpath, int _qty, string _displayMethodName, string _categories, string _colleges, string _tags, string _start, string _end)
        {
            string output = "";

            MethodInfo mi = WnlDisplayMethods.getWnlDisplayMethodByName(_displayMethodName);

            if (mi != null)
            {
                output += mi.Invoke(new object { }, new object[] { _url, _xpath, _qty, _categories, _colleges, _tags, _start, _end });
            }
            else
            {
                output = "Error in the WNLDisplayMethod";
            }
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
