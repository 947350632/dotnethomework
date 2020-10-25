using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;
using System.Net;
using System.IO;

namespace Crawler
{
    public class ZSCrawler
    {
        private List<Urlstatus> Urls = new List<Urlstatus>();
        public List<Urlstatus> URLS
        {
            get { return Urls; }
        }
        /*
        private Hashtable urls = new Hashtable();
        public Hashtable URLS
        {
            get { return urls; }
        }*/
        private List<string> pending = new List<string>();
        public int count = 0;
        private int max_num = 10;

        public string news = "";
        public ZSCrawler(string starturls,int max_num)
        {
            Urls.Add(new Urlstatus(starturls));
            this.max_num = max_num;
        }
        public bool Crawl()
        {
            Console.WriteLine("开始爬取");
            while(true)
            {
                string cur = null;
                foreach(Urlstatus url in Urls)
                {
                    //Console.WriteLine(url);
                    if (url.status == "Success") continue;
                    cur = url.url;
                }
                if (cur == null || count > max_num) break;
                news += $"{cur}\r\n";
                Console.WriteLine($"{cur}");
                string html = Download(cur);
                Urls.ForEach(x =>
                {
                    if (x.url == cur)
                        x.SetStatus();
                });
                count++;
                Parse(cur,html);
            }
            return true;
        }
        public bool ParallCrawl()
        {
            Console.WriteLine("开始爬取");
            //DownloadAndParse(Urls[0].url);
            while (true)
            {
                Parallel.ForEach(Urls, url =>
                {
                    if (count < max_num && url.isTry == false)
                    {
                        Interlocked.Increment(ref count);
                        DownloadAndParse(url.url);
                        Console.WriteLine(count);
                    }
                });
                if (count >= max_num) break;
            }
            return true;
        }
        public void DownloadAndParse(string url)
        {
            news += $"{url}\r\n";
            Console.WriteLine($"{url}");
            string html = Download(url);
            Urls.ForEach(x =>
            {
                if (x.url == url)
                    x.SetStatus();
            });
            //lock (this) { count++; }
            Parse(url, html);
        }
        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string filename = count.ToString();
                File.WriteAllText(filename, html, Encoding.UTF8);
                return html;
            }
            catch(Exception e)
            {
                Urls.ForEach(x =>
                {
                    if (x.url == url)
                    {
                        x.reason = e.Message;
                        x.status = "Failed";
                    }
                });
                Console.WriteLine(e.Message);
                return "";
            }
        }
        public void Parse(string cur,string html)
        {
            //提取出可用的url
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+(html|htm|jsp|aspx|php|com)[""']";
            //判断前缀http
            string strHttp = @"^(http|https)";
            
            MatchCollection matches = new Regex(strRef).Matches(html);
            
            //分相对地址与绝对地址
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('=','\"','#',' ','>');
                if (!Regex.IsMatch(strRef, strHttp))//相对地址
                    strRef = cur + strRef;
                Console.WriteLine(strRef);
                if (strRef.Length == 0) continue;
                if (!Urls.Contains(new Urlstatus(strRef))) Urls.Add(new Urlstatus(strRef));
            }
        }
        public List<Urlstatus> GetUrls()
        {
            var res = from s in Urls where s.isTry == true select s;
            return res.ToList();
        }
    }
}
