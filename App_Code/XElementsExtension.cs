using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for XElementsExtension
/// </summary>

namespace OUC
{
    public static class XElementsExtension
    {

        public static YahooRssItem ToYahooRssItem(this XElement x)
        {
            return new YahooRssItem(x);

        }


        public static XmlItem ToXmlItem(this XElement x)
        {
            return new XmlItem(x);

        }

        public static EtsuRssItem ToEtsuRssItem(this XElement x)
        {
            return new EtsuRssItem(x);

        }
       

    }
}
