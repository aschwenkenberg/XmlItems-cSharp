<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tags_count.aspx.cs" Inherits="tags_count" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tags</title>

     <script type="text/javascript" src='js/jquery-1.8.3.min.js'></script>

         <script type="text/javascript">
             // short hand for $(document).ready(function(){ ...


             $(function () {

                 function tagsCount() {

                     var tags;
                     $('input[name="chk_tag"]').each(function (index) {
                         if (index != 0) {
                             tags += ",";
                         }
                         tags += $(this).val();
                     });


                     $.ajax({
                         url: "tags_count_handler.ashx",
                         feed: "rss/news2012.xml",
                         xpath: "/rss/channel/item",
                         data: tags,
                         contentType: "text/plain",
                         success: function (data) {

                             
                         }
                     });
                 }

                 tagsCount();
             });



    </script> 

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h3>Refine by Tags</h3>
                  <ul class="rss_hidelist">
                     <li>
                        <input type="checkbox" name="chk_tag" value="Academics"/> Academics</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="Alumni"/> Alumni</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="Arts, Museums, Galleries"/> Arts, Museums, Galleries</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="Athletics"/> Athletics</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="Campus Recreation"/> Campus Recreation</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="Faculty &amp; Staff"/> Faculty &amp; Staff</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="Entertainment"/> Entertainment</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="Policies &amp; Procedures"/> Policies &amp; Procedures</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="Students"/> Students</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="Special Events"/> Special Events</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="Technology"/> Technology</li>
                  </ul>
               </div>
    </form>
</body>
</html>
