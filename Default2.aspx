<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Import Namespace="OUC" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>ETSU JQUERY PLUGIN</title>
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery.etsuNews.js"></script>
    <script type="text/javascript" src="js/custom_news.js"></script>
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
         OUC.custom_news.quantity = "4";
         OUC.custom_news.feed = "rss/news2012.xml",
         OUC.custom_news.displayMethod =  "filteredNews",
         OUC.custom_news.categories = "";
         OUC.custom_news.colleges = "";
         OUC.custom_news.tags = "";
         OUC.custom_news.remember_tags = "";
         OUC.custom_news.year = "";
         OUC.custom_news.start = "";
         OUC.custom_news.end = "";
		
	</script>
	
	
	
	  <script>
	      // short hand for $(document).ready(function(){ ...
	      $(function () {
	          // calling the plugin
	          initNews();
	          bindNewsFilterControls();
              
	      });
    </script>



    <script type="text/javascript">
        // short hand for $(document).ready(function(){ ...
        $(function () {
        
           //var d = new Date();
           //var end = (d.getMonth() + 1) + "/" + d.getDate() + "/" + d.getFullYear();
          
                      
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
               <!-- COLLEGES -->
<div>
                  <h3>Refine by College or School</h3>
                  <ul class="rss_hidelist">
                     <li>
                        <input type="checkbox" name="chk_college" value="Arts &amp; Sciences"/> Arts &amp; Sciences</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="Business &amp; Technology"/> Business &amp; Technologu</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="Clinical &amp; Rehab. Health Sci."/> Clinical &amp; Rehab. Health Sci.</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="Education"/> Education</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="Honors"/> Honors</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="Medicine"/> Medicine</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="Nursing"/> Nursing</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="Pharmacy"/> Pharmacy</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="Public Health"/> Public Health</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="Continuing Studies"/> Continuing Studies</li>
                     <li>
                        <input type="checkbox" name="chk_college" value="Graduate Studies"/> Graduate Studies</li>
                  </ul>
               </div>
            </form>
            <!-- /com.omniupdate.div -->
 </div>
      </div>
    </form>
</body>
</html>
