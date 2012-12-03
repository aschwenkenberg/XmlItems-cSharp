<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <!--<link href="css/OUpage_layout_general.css" rel="Stylesheet" type="text/css" />-->
    <script type="text/javascript" src='js/jquery-1.8.3.min.js' />
    <script type="text/javascript" src='js/rss_news.js' />
    <title>WNL Display Methods</title>

</head>
<body>
    <form id="form1" runat="server">
    <div id="cont" runat="server">
    
    </div>
    

<script type="text/javascript">

        var ajaxUrl = "wnl_handler.ashx";
        $(document).ready(function () {

            var quantity = 20;
            var display = "rss_sample_2";
            var feed = "rss/news2012.xml";
            var xpath = "rss/channel/item";
            var type = "test&data";

            var param = { display:display, feed:feed, xpath:xpath, quantity:quantity };

            $.ajax({
                url: ajaxUrl,
                data: param,
                async: true,
                contentType: "text/plain",
                success: function (data) {
                    $("#news-list").html(data);
                }
            })

        });

       
</script>

 <div id="news-list"><!-- no empty elements --></div>
    </form>
</body>
</html>
