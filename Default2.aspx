<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Import Namespace="OUC" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>ETSU JQUERY PLUGIN</title>
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <script type="text/javascript" src="js/jquery.etsuNews.js"></script>
    <script type="text/javascript" src="js/jquery.etsuTagsCount.js"></script>
    <script type="text/javascript" src="js/custom_news.js"></script>
    <link rel="stylesheet" type="text/css" href="js/jquery-ui.css"/>

     <script>
         if (typeof (OUC) == "undefined") { var OUC = {}; }
         // add and populate properties of the OUC object
         OUC.path = "/news/default.aspx";
         OUC.dirname = "/news/";
         OUC.httproot = "http://www.etsu.edu/";
        
         OUC.custom_news = {};
         OUC.custom_news.remember = true;
         OUC.custom_news.use_remembered_settings = true;
         OUC.custom_news.pagetype = "news";
         OUC.custom_news.quantity = "10";
         OUC.custom_news.feed = "rss/news2012.xml",
         OUC.custom_news.displayMethod =  "filteredNews",
         OUC.custom_news.categories = "";
         OUC.custom_news.colleges = "";
         OUC.custom_news.tags = "";
         OUC.custom_news.remember_tags = "";
         OUC.custom_news.year = "";
         OUC.custom_news.fromDate = "";
         OUC.custom_news.toDate = "";
         OUC.custom_news.pageStart = 1;
		
	</script>
	  
	
	  <script>
	      // short hand for $(document).ready(function(){ ...
	      $(function () {

	          $("#from").datepicker({
	              defaultDate: "+1w",
	              changeMonth: true,
	              numberOfMonths: 3,
	              onClose: function (selectedDate) {
	                  $("#to").datepicker("option", "minDate", selectedDate);
	              }
	          });
	          $("#to").datepicker({
	              defaultDate: "+1w",
	              changeMonth: true,
	              numberOfMonths: 3,
	              onClose: function (selectedDate) {
	                  $("#from").datepicker("option", "maxDate", selectedDate);
	              }
	          });

	              function initTagsCount() {
	                  $(this).etsuTagsCount({
	                      feed: "rss/news2012.xml"
	                  });
	                  return false;
	              }

	              initTagsCount();
	          

	          // calling the plugin
	          initNews();
	          bindNewsFilterControls();
              
	      });
    </script>



    <script type="text/javascript">
        // short hand for $(document).ready(function(){ ...
        $(function () {        
                      
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="cont" runat="server">
       
    </div>
         <div id="crumbs_hNav">
            <div id="breadcrumbs"> <a href='http://www.etsu.edu/news/default.aspx'>news</a> &gt;News</div>
         </div>
         <div id="centerCol">
 
  <!-- com.omniupdate.div label="maincontent" group="Everyone"  button="707" -->
  <!-- com.omniupdate.editor csspath="/_resources/ou/editor/OneColmaincontent.css" cssmenu="/_resources/ou/editor/classes.txt" -->
<div id="newscats">
	              <span>Show me news <br/>in the category...</span> 
	
	              <span>
                  <a class="custom_news_category_link" id="all" href="">All</a>
               </span> | 
	<span>
                  <a class="custom_news_category_link" id="seminars" href="">Seminars</a>
               </span> | 
	<span>
                  <a class="custom_news_category_link" id="cultural" href="">Cultural</a>
               </span> | 
	<span>
                  <a class="custom_news_category_link" id="medical" href="">Medical</a>
               </span> | 
	<span>
                  <a class="custom_news_category_link" id="headlines" href="">Headlines</a>
               </span> | 
	<span>
                  <a class="custom_news_category_link" id="other" href="">Other</a>
               </span> | 
	<span>
                  <a class="custom_news_category_link" id="personnel" href="">Personnel</a>
               </span> | 
	<span>
                  <a class="custom_news_category_link" id="student" href="">Student</a>
               </span> | 
	<span>
                  <a class="custom_news_category_link" id="feature" href="">Features</a>
               </span>
	
            </div>
	           <!-- end news categories -->
	 
   <div id="newslisting">
	              
   </div>
            <!-- end news listings -->
	 
	 <div id="news"><!-- empty --></div>
 
            <!-- /com.omniupdate.div -->
 </div>
         <div id="rightCol">
 <!-- com.omniupdate.div label="rightcolumn" group="Everyone"  button="707" --><form>

               <div>
                  <h3>Search by Date</h3>
                  <p>
                     <label style="font-size: 90%;" for="from">From</label> 
                     <input id="from" style="width: 100px;" type="text" name="from"/>
                  </p>
                  <p>
                     <label style="font-size: 90%;" for="to">To     </label> 
                     <input id="to" style="width: 100px;" type="text" name="to"/>
                  </p>
               </div>
               <!--  KEYWORDS  -->
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
                        <input type="checkbox" name="chk_tag" value="campus recreation"/> Campus Recreation</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="faculty &amp; staff"/> Faculty &amp; Staff</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="entertainment"/> Entertainment</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="policies &amp; procedures"/> Policies &amp; Procedures</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="students"/> Students</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="special events"/> Special Events</li>
                     <li>
                        <input type="checkbox" name="chk_tag" value="technology"/> Technology</li>
                  </ul>
               </div>
               <!-- COLLEGES -->
<div>
                  <h3>Refine by College or School</h3>
                  <ul class="rss_hidelist">
                     <li>
                        <input type="checkbox" name="chk_college" value="arts &amp; sciences"/> Arts &amp; Sciences</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="business &amp; technology"/> Business &amp; Technologu</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="clinical &amp; rehab. health Sci."/> Clinical &amp; Rehab. Health Sci.</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="education"/> Education</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="honors"/> Honors</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="medicine"/> Medicine</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="nursing"/> Nursing</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="pharmacy"/> Pharmacy</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="public health"/> Public Health</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="continuing studies"/> Continuing Studies</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="graduate studies"/> Graduate Studies</li>
                  </ul>
               </div>
            </form>
            <!-- /com.omniupdate.div -->
 </div>
     
    </form>
</body>
</html>
