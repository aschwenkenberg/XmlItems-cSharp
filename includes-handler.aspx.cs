using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;


public partial class includes_handler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string output = "";
         output += OUC.ConvertIncludes.includeTags(@"C:\Users\aschwenkenberg\Documents\GitHub\XmlItems-cSharp\news-tags.inc");
         output += OUC.ConvertIncludes.includeCategory(@"C:\Users\aschwenkenberg\Documents\GitHub\XmlItems-cSharp\news-categories.inc");
         output += OUC.ConvertIncludes.includeCollege(@"C:\Users\aschwenkenberg\Documents\GitHub\XmlItems-cSharp\news-colleges.inc");
        form1.InnerHtml += output;

    }
}