using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OUC;
/// <summary>
/// Summary description for LocalEtsuItems
/// </summary>
/// 

namespace OUC
{

    public class LocalEtsuItems : LocalItems
    {
        public List<EtsuRssItem> etsurssitems = new List<EtsuRssItem>();

        public LocalEtsuItems()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public LocalEtsuItems(string _url, string _xpath):base(_url, _xpath)
        {
           // this.etsurssitems = this.items.Select(e => new EtsuRssItem { });
        }
    }
}