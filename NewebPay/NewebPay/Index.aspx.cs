using NewebPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newebpay {
    public partial class Index : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.HttpMethod == "POST") { 
                var amount = Request.Form["amount"];
                var HashIV = "your HashIV"; 
                var HashKey = "your HashKey";
                SendToNeweb payInfo = new SendToNeweb(int.Parse(amount), HashIV, HashKey);
                var msg = payInfo.Checkout();
                Response.Write(string.Format("<script language='javascript'>alert('{0}！');</script>", msg));
            }
        }

    }
}