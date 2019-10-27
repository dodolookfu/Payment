using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECPay.Payment.Integration.Helper {
    public class FormPost {
        private SortedDictionary<string, string> Inputs;
        private string url = null;
        public string Method = "POST";
        public string FormName = "Form1";

        public FormPost() {            
            Inputs = new SortedDictionary<string, string>();
        }

        public void Add(string fname, string fvalue) {
            Inputs.Add(fname, fvalue);
        }

        public void Post() {
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write("<html><head>");
            System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
            System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >",
                FormName, Method, url));
            foreach (KeyValuePair<string, string> item in Inputs) {
                System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", item.Key, item.Value));
            }
            System.Web.HttpContext.Current.Response.Write("</form>");
            System.Web.HttpContext.Current.Response.Write("</body></html>");            
        }

        public FormPost(string remoteUrl, SortedDictionary<string, string> source) {
            url = remoteUrl;
            Inputs = source;
        }
    }
}