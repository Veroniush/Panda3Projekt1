using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Panda3
{
    public static class HttpHelper
    {
        /// <summary>
        /// function to get http contetnt from url 
        /// </summary>
        public static string GetContent(string url)
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            WebResponse myRes =myReq.GetResponse();
            Stream myStream =myRes.GetResponseStream();
            StreamReader readStream = new StreamReader(myStream, Encoding.UTF8);
            string content = readStream.ReadToEnd();
            return content;
        }
    }
}
