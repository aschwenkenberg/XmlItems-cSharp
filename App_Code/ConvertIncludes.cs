using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for ConvertIncludes
/// </summary>
/// 
namespace OUC
{

    public class ConvertIncludes
    {
        public static string includeTags(string _filename)
        {

            string o = "";

            // Declare new List.
            List<string> lines = new List<string>();

            // Use using StreamReader for disposing.
            using (StreamReader r = new StreamReader(_filename))
            {
                // Use while != null pattern for loop
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    if (line.Length > 1)
                    {
                        // <option value="technology">Technology</option>
                        String regex_value = "\"([^\"]*)";
                        String regex_name = "\\\">(.*?)</";

                        MatchCollection coll_value = Regex.Matches(line, regex_value);
                        MatchCollection coll_name = Regex.Matches(line, regex_name);

                        String result_value = coll_value[0].Groups[1].Value;
                        String result_name = coll_name[0].Groups[1].Value;

                        String output = "<li><input type=\"checkbox\" value=\"" + result_value + "\" name=\"chk_tag\">" + result_name + "</li>";

                        lines.Add(output);
                    }
                }
            }


            foreach (string s in lines)
            {
                o += s;
            }

            return o;

        }

        public static string includeCollege(string _filename)
        {

            string o = "";

            // Declare new List.
            List<string> lines = new List<string>();

            // Use using StreamReader for disposing.
            using (StreamReader r = new StreamReader(_filename))
            {
                // Use while != null pattern for loop
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    if (line.Length > 1)
                    {
                        // <option value="technology">Technology</option>
                        String regex_value = "\"([^\"]*)";
                        String regex_name = "\\\">(.*?)</";

                        MatchCollection coll_value = Regex.Matches(line, regex_value);
                        MatchCollection coll_name = Regex.Matches(line, regex_name);

                        String result_value = coll_value[0].Groups[1].Value;
                        String result_name = coll_name[0].Groups[1].Value;

                        String output = "<li><input type=\"checkbox\" value=\"" + result_value + "\" name=\"chk_college\">" + result_name + "</li>";

                        lines.Add(output);
                    }
                }
            }


            foreach (string s in lines)
            {
                o += s;
            }

            return o;

        }

        public static string includeCategory(string _filename)
        {

            string o = "";

            // Declare new List.
            List<string> lines = new List<string>();

            // Use using StreamReader for disposing.
            using (StreamReader r = new StreamReader(_filename))
            {
                // Use while != null pattern for loop
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    if (line.Length > 1)
                    {
                        
                        // | <span>
                        // <a href="" id="other" class="category">Other</a>
                        // </span>

                        String regex_value = "\"([^\"]*)";
                        String regex_name = "\\\">(.*?)</";

                        MatchCollection coll_value = Regex.Matches(line, regex_value);
                        MatchCollection coll_name = Regex.Matches(line, regex_name);

                        String result_value = coll_value[0].Groups[1].Value;
                        String result_name = coll_name[0].Groups[1].Value;

                        String output = "<span><a href=\"\" id=\"" + result_value + "\" class=\"category\">" + result_name + "</a></span>";

                        lines.Add(output);
                    }
                }
            }

            string lastItem = lines[lines.Count - 1];
            foreach (string s in lines)
            {
                if (s != lastItem)
                {
                    o += s + "|";
                }
                else
                {
                    o += s;
                }
            }

            return o;

        }

    }
}