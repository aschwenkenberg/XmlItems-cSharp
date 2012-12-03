﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>ETSU JQUERY PLUGIN</title>
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery.etsuNews.js"></script>
    <script>
        // short hand for $(document).ready(function(){ ...
        $(function () {
          
            // calling the plugin
            $('#news').etsuNews({
               quantity : "3"
            });
           
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="cont" runat="server">
       
    </div>
        <div id="news"></div>
    </form>
</body>
</html>
