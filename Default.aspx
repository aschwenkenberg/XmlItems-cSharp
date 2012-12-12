<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html lang="en-us">
<head runat="server">
    <title>WNL Display Methods</title>
    <script type="text/javascript" src='js/jquery-1.8.3.min.js'></script>   

</head>
<body>
    <form id="form1" runat="server">
        <h2> Ajax Method Place Holder</h2>
         <div id="news-list">
            <!-- no empty elements -->
        </div>

        <div id="cont" runat="server">
        </div>


        <script type="text/javascript">

            var ajaxUrl = "wnl_handler.ashx";
            var quantity = 3;
            var display = "rss_sample_2";
            var feed = "rss/test1000.xml";
            var xpath = "/rss/channel/item";

            var param = { display:display, feed:feed, xpath:xpath, quantity:quantity };

            $.ajax({
                url: ajaxUrl,
                data: param,
                async: true,
                contentType: "text/plain",
                success: function (data) {
                    $("#news-list").html(data);
                }
            });

         
       
        </script>
        
       
    </form>
</body>
</html>
