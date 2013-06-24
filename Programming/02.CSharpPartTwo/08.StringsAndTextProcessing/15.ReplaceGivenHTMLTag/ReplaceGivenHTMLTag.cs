/* Write a program that replaces in a HTML document given as string all
 * the tags <a href="…">…</a> with corresponding tags [URL=…]…[/URL]. 
 * Sample HTML fragment:
 * <p>Please visit <a href="http://academy.telerik. com">our site</a> 
 * to choose a training course. Also visit <a href="www.devbg.org">our forum</a> 
 * to discuss the courses.</p>
 * Result:
 * <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. 
 * Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
 */
using System;
using System.Text.RegularExpressions;

class ReplaceGivenHTMLTag
{
    static void Main()
    {
        string htmlDoc = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

        //string result = Regex.Replace(htmlDoc, @"<a href=""", @"[URL=");

        string replaceAnchorTag = Regex.Replace(htmlDoc, "<a href=\"(.*?)\">(.*?)</a>", "[URL=$1]$2[/URL]");

        Console.WriteLine(replaceAnchorTag);

        // reshenie na kolega
        //string htmlText = @"<p>Please visit <a href=""http://academy.telerik. com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
        //string[] aTags = { "<a href=\"", "\">", "</a>" };
        //string[] urlTags = { "[URL=", "]", "[/URL]" };

        //for (int i = 0; i < aTags.Length; i++)
        //{
        //    htmlText = htmlText.Replace(aTags[i], urlTags[i]);
        //}
        //Console.WriteLine(htmlText);
    }
}
