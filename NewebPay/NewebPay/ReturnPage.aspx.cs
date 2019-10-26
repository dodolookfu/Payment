using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using NewebPay.Helper;
using NewebPay.Model;

namespace WebApplication4 {
    public partial class ReturnPage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.HttpMethod == "POST") {
                var form = Request.Form;
                var HashIV = "your HashIV";
                var HashKey = "your HashKey";
                ParameterConfig storeConfig = new ParameterConfig(HashKey, HashIV);
                if (form["MerchantID"] != null && string.Equals(form["MerchantID"], storeConfig.MerchantID) &&
                    form["TradeInfo"] != null && string.Equals(form["TradeSha"], CryptoHelper.EncryptSHA256($"HashKey={storeConfig.HashKey}&{form["TradeInfo"]}&HashIV={storeConfig.HashIV}"))) {
                    //解密
                    var decryptTradeInfo = CryptoHelper.DecryptAESHex(form["TradeInfo"], storeConfig.HashKey, storeConfig.HashIV);
                    //to name/value
                    NameValueCollection decryptTradeCollection = System.Web.HttpUtility.ParseQueryString(decryptTradeInfo);
                    //to output model
                    NewebOutputDataModel model = CryptoHelper.DictionaryToObject<NewebOutputDataModel>(decryptTradeCollection.AllKeys.ToDictionary(k => k, k => decryptTradeCollection[k]));
                    var json = new JavaScriptSerializer().Serialize(model);
                    Response.Write(json);
                } else {
                    Response.Write(string.Format("<script language='javascript'>alert('{0}！');</script>", "回傳檔案發生錯誤"));
                }
            }
        }
    }
}