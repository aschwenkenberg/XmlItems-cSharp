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

                     var tags = "";
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

                             displayTagsCount(data);

                         }
                     });
                 }

                 tagsCount();

                 function displayTagsCount(jsonResultObject) {

                     obj = JSON.parse(jsonResultObject);

                     for (var i = 0; i < obj.TagTotals.length; i++) {

                         var name = obj.TagTotals[i].Name;
                         $("input[name='chk_tag'][value='" + name + "']").parent().append(' (' + obj.TagTotals[i].Total + ')');

                     }
                 }

             });

             

    </script> 

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h3>Refine by Tags</h3>
                  <ul class="rss_hidelist">
                     <li>
                        <input type="checkbox" name="chk_tag" value="academics"/> Academics</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="alumni"/> Alumni</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="arts, museums, galleries"/> Arts, Museums, Galleries</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="athletics"/> Athletics</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="campus Recreation"/> Campus Recreation</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="faculty &amp; Staff"/> Faculty &amp; Staff</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="entertainment"/> Entertainment</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="policies &amp; Procedures"/> Policies &amp; Procedures</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="students"/> Students</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="special Events"/> Special Events</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="technology"/> Technology</li>
                  </ul>
               </div>
    </form>
</body>
</html>
